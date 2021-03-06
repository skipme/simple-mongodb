namespace Pls.SimpleMongoDb.Commands
{
    public class GetNonceCommand
        : DatabaseCommand
    {
        /// <summary>
        /// Defines the Database-name to be queried for
        /// last errors.
        /// </summary>
        public string DatabaseName
        {
            get { return NodeName; }
            set { NodeName = value; }
        }

        public GetNonceCommand(ISimoConnection connection, Reconnection OnReconnect)
            : base(connection, OnReconnect, new { getnonce = 1.0 })
        {
        }
    }
}