using BLCoreWebAPI.Database;
using BLCoreWebAPI.Models;

namespace BLCoreWebAPI.Processes
{
    public class Capabilities
    {
        MongoDBHelper mongo;

        public object getCapabilitiesList()
        {
            object capabilitiesList = new object();

            capabilitiesList = mongo.LoadAllDocuments<NodeRedNode>("capabilities");

            return capabilitiesList;
        }
    }
}
