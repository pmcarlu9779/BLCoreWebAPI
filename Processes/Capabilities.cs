using BLCoreWebAPI.Database;
using BLCoreWebAPI.Models;

namespace BLCoreWebAPI.Processes
{
    public class Capabilities
    {
        MongoDBHelper mongo = new MongoDBHelper("mongodb://localhost:27017","BroomOrLamp");

        public object getCapabilitiesList()
        {
            object capabilitiesList = new object();

            capabilitiesList = mongo.LoadAllDocuments<NodeRedNode>("capabilities");

            return capabilitiesList;
        }
    }
}
