using System.IO;
using Pls.SimpleMongoDb.Resources;
using Pls.SimpleMongoDb.Serialization;
using Pls.SimpleMongoDb.DataTypes;

namespace Pls.SimpleMongoDb.Commands
{
    /// <summary>
    /// Used to update documents.
    /// </summary>
    public class UpdateDocumentsCommand
        //:SimoResponseCommand<SimoKeyValues> TODO: modify for version >2.6.
        : SimoCommand
    {
        /// <summary>
        /// Defines the collection that holds the documents being updated.
        /// E.g <![CDATA["dbname.collectionname"]]>.
        /// </summary>
        public string FullCollectionName { get; set; }

        /// <summary>
        /// Determines how the MongoDb-database will handle
        /// missing document and/or multiple matches. See
        /// <see cref="UpdateModes"/> for more info.
        /// </summary>
        public UpdateModes Mode { get; set; } // db.version() TODO: modify for version >2.6.
        // db.version() TODO: modify for version >2.6.
        //http://docs.mongodb.org/manual/reference/method/db.collection.update/
        //public bool upsert;
        //public bool multi;
        //public bool writeConcern;

        /// <summary>
        /// Defines the query object that is used to
        /// identify the document(s) to update.
        /// </summary>
        /// <remarks>Needs to be convertible to BSON.</remarks>
        public object QuerySelector { get; set; }

        /// <summary>
        /// The document that will be updated or inserted depending on
        /// the <see cref="Mode"/>.
        /// </summary>
        /// <remarks>Needs to be convertible to BSON.</remarks>
        public object Document { get; set; }

        public UpdateDocumentsCommand(ISimoConnection connection, Reconnection recCallback)
            : base(connection, recCallback)
        {
            Mode = UpdateModes.Upsert;
        }

        protected override void OnEnsureValidForExecution()
        {
            if (string.IsNullOrEmpty(FullCollectionName))
                throw new SimoCommandException(ExceptionMessages.SimoCommand_IsMissingNodeName);
        }

        protected override Request GenerateRequest()
        {
            return new Request(OpCodes.Update, GenerateBody());
        }

        protected byte[] GenerateBody()
        {
            //http://www.mongodb.org/display/DOCS/Mongo+Wire+Protocol#MongoWireProtocol-OPUPDATE
            //int32     ZERO;               // 0 - reserved for future use
            //cstring   fullCollectionName; // "dbname.collectionname"
            //int32 flags;                  // bit vector. see below
            //BSON selector;                // the query to select the document
            //BSON document;                // the document data to update with or insert

            var stream = new MemoryStream();
            //using (var stream = new MemoryStream())
            //{
            using (var writer = new BodyWriter(stream))
            {
                writer.Write(0);
                writer.Write(FullCollectionName);
                writer.WriteTerminator();
                writer.Write((int)Mode);// db.version() TODO: modify for version >2.6.
                writer.WriteSelector(QuerySelector ?? new object());
                writer.WriteDocument(Document);

                return stream.ToArray();
            }
            //}
        }
        //protected override void OnReadResponse(ResponseStreamReader responseStreamReader)
        //{
        //    var response = responseStreamReader.Read<SimoKeyValues>();
        //    var document = response.ReturnedDocuments[0];
        //    //var commandWasOk = document.GetDouble("ok") == 1.0;

        //    //if (commandWasOk)
        //    //{
        //    //    this.Response.SetDocuments(response.ReturnedDocuments);
        //    //    return;
        //    //}

        //    var errMsg = MongoDbErrorMessage.FromDocument(document);
        //    if (errMsg == null)
        //        return;

        //    throw new SimoCommandException(ExceptionMessages.DatabaseCommand_CommandWasNotOk, errMsg);
        //}
    }
}