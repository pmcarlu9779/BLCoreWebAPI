using BLCoreWebAPI.Database;
using BLCoreWebAPI.Models;

namespace BLCoreWebAPI.Processes
{
    public class Capabilities
    {
        public object getCapabilitiesList(string dbConnectionString, string dbName)
        {
            MongoDBHelper mongo = new MongoDBHelper(dbConnectionString, dbName);
            var capabilitiesList = mongo.LoadAllDocuments<NodeRedNode>("capabilities");
            return capabilitiesList;
        }
    }
}
