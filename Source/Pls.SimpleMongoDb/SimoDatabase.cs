using System.Collections.Generic;
using System.Linq;
using Pls.SimpleMongoDb.Commands;
using Pls.SimpleMongoDb.DataTypes;
using System.Security.Cryptography;
using System.Text;

namespace Pls.SimpleMongoDb
{
    public class SimoDatabase
        : ISimoDatabase
    {
        protected string auth_user;
        protected string auth_pwd;

        public ISimoSession Session { get; private set; }

        public string Name { get; private set; }

        public ISimoCollection this[string name]
        {
            get { return GetCollection(name); }
        }

        public SimoDatabase(ISimoSession session, string name)
        {
            Session = session;
            Name = name;
        }
        public void ConnectionLost_Stateless(long lostnum)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine("MONGO DB DRIVER `DB LVL COMMAND` stateless reconnection num#" + lostnum);
#endif
            if (this.Authorised)
            {
                // authorisation in prev connection lost too
                this.AutoriseOnLostConnection();
            }
        }
        private string CalculateMD5Hash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.Default.GetBytes(input));
            return System.BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
        public void Autorise(string user, string pwd)
        {
            ISimoConnection conO = Session.Connection;
            var cmd = new GetNonceCommand(conO, 
                (Number_rec) =>
                {
                    // TODO: stop command execution, new nonce, attemptsNumber
                }) 
                { DatabaseName = Name };
            cmd.Execute();

            string nonce = cmd.Response.Documents[0]["nonce"] as string;

            string key = user + ":mongo:" + pwd;
            var cmdAuth = new AuthenticateCommand(conO,
                (Number_rec) =>
                {
                    // TODO: stop command execution, new nonce, attemptsNumber
                },
                user,
                CalculateMD5Hash(nonce + user + CalculateMD5Hash(key)),
                nonce) { DatabaseName = Name };
            cmdAuth.Execute();

            auth_user = user;
            auth_pwd = pwd;

            Authorised = true;

            var resl = cmdAuth.Response.Documents;
        }

        public void AutoriseOnLostConnection()
        {
            Autorise(auth_user, auth_pwd);
        }

        public bool Authorised { get; private set; }
        public void DropDatabase()
        {
            var cmd = new DropDatabaseCommand(Session.Connection, ConnectionLost_Stateless) { DatabaseName = Name };
            cmd.Execute();
        }

        public void DropCollections(params string[] collectionNames)
        {
            var collectionsAreSpecified = (collectionNames != null && collectionNames.Length > 0);
            var collectionNamesToDrop = collectionsAreSpecified
                                            ? collectionNames
                                            : GetCollectionNames(incluceSystemCollections: false);

            if (collectionNamesToDrop == null || collectionNamesToDrop.Count < 1)
                return;

            var fullCollectionNamePrefix = Name + ".";
            var prefixLen = fullCollectionNamePrefix.Length;

            var cmd = new DropCollectionCommand(Session.Connection, ConnectionLost_Stateless) { DatabaseName = Name };

            foreach (var collectionName in collectionNamesToDrop)
            {
                var dropName = collectionName;

                if (collectionsAreSpecified)
                {
                    var collectionNameIsFullCollectionName = dropName.StartsWith(fullCollectionNamePrefix);
                    if (collectionNameIsFullCollectionName)
                        dropName = collectionName.Substring(prefixLen);

                    if (MongoSystem.ReservedCollections.IsReserved(dropName))
                        continue;
                }

                cmd.CollectionName = dropName;
                cmd.Execute();
            }
        }

        public IList<string> GetCollectionNames(bool incluceSystemCollections = false)
        {
            var cmd = new QueryDocumentsCommand<SimoKeyValues>(Session.Connection, (Number_rec) => { })
            {
                FullCollectionName = Name + ".system.namespaces"
            };
            cmd.Execute();

            var fullCollectionNamePrefix = Name + ".";
            var prefixLen = fullCollectionNamePrefix.Length;
            var fullCollectionNames = cmd.Response.Documents.Select(kv =>
                                                     {
                                                         var cn = kv.GetString("name");
                                                         var collectionNameIsFullCollectionName =
                                                             cn.StartsWith(fullCollectionNamePrefix);
                                                         if (collectionNameIsFullCollectionName)
                                                             cn = cn.Substring(prefixLen);

                                                         return cn;
                                                     });


            fullCollectionNames = incluceSystemCollections
                                      ? fullCollectionNames
                                      : fullCollectionNames.Where(cn => !MongoSystem.ReservedCollections.IsReserved(cn));

            return fullCollectionNames.ToList();
        }

        public ISimoCollection GetCollection<T>()
            where T : class
        {
            var entityName = EntityMetadata<T>.EntityName;

            return GetCollection(entityName);
        }

        private ISimoCollection GetCollection(string name)
        {
            return new SimoCollection(this, name);
        }


    }
}