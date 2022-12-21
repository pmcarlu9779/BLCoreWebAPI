using BLCoreWebAPI.Database;
using BLCoreWebAPI.Models;
using System.Collections.Generic;

namespace BLCoreWebAPI.Processes
{
    public class Capabilities
    {
        public List<NodeRedNode> getCapabilitiesList(string dbConnectionString, string dbName)
        {
            MongoDBHelper mongo = new MongoDBHelper(dbConnectionString, dbName);
            List<NodeRedNode> capabilitiesList = mongo.LoadAllDocuments<NodeRedNode>("capabilities");
            return capabilitiesList;
        }
    }
}
