using BLCoreWebAPI.Database;
using BLCoreWebAPI.Models;
using FuzzySharp;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Text.Json;
using System.Web.Http;

namespace BLCoreWebAPI.Processes
{
    public class Node
    {
        public HttpResponseMessage createNode(string createNodeJSONString, string dbConnectionString, string dbName)
        {
            Capabilities capabilities = new Capabilities();
            List<dynamic> capabilitiesList = capabilities.getCapabilitiesList(dbConnectionString, dbName);
            var createNodeJSONObject = BsonSerializer.Deserialize<dynamic>(createNodeJSONString);
            string capabilityExistsMessage;
            string capabilityAddedMessage;
            HttpResponseMessage response = new HttpResponseMessage();
            const int LOWER_FUZZY_MATCH_THRESHOLD = 60;

            if (createNodeJSONObject.name != "")
            {
                if (capabilitiesList.Count != 0)
                {
                    foreach (dynamic capability in capabilitiesList)
                    {
                        // What identifier(s) do we look for in the object to determine it exists?
                        // For now, using a Levenschtein distance algorithm with name field. We can adjust the method behind this, if necessary, later.

                        // Test cases:
                        // 1) Name = "send gmail"
                        // 2) Name = "send an email"
                        // 3) Name = "mail"

                        // Have to lower threshold to 50, for this.
                        int simScore = Fuzz.PartialRatio(capability.name, createNodeJSONObject.name);

                        // Have to lower threshold to 50, for this.
                        //int simScore = Fuzz.PartialTokenSetRatio(capability.Name, createNodeJSONObject.Name);

                        // Have to lower threshold to 49, for this.
                        //int simScore = Fuzz.WeightedRatio(capability.Name, createNodeJSONObject.Name); 

                        if (simScore >= LOWER_FUZZY_MATCH_THRESHOLD)
                        {
                            capabilityExistsMessage = $"The capability '{capability.name}' already exists.";
                            response.StatusCode = System.Net.HttpStatusCode.Found;
                            response.ReasonPhrase = capabilityExistsMessage;
                            return response;
                        }
                    }
                }

            } else
            {
                // Reject the incoming node object. Give response of Bad Request.
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.ReasonPhrase = "Name property is empty.";
                return response;
            }

            //addNodeToDB(createNodeJSONObject, dbConnectionString, dbName);

            addNodeToDBViaDynamicObject(createNodeJSONObject, dbConnectionString, dbName);

            capabilityAddedMessage = $"The capability '{createNodeJSONObject.name}' has been learned.";
            response.StatusCode = System.Net.HttpStatusCode.Created;
            response.ReasonPhrase = capabilityAddedMessage;

            //addNodeToNodeRedRepo();

            // from node-red util.js - bytes.push(Math.round(0xff*Math.random()).toString(16).padStart(2,'0'));

            return response;
        }

        public void addNodeToDB(NodeRedNode createNodeJSONObject, string dbConnectionString, string dbName)
        {
            MongoDBHelper mongo = new MongoDBHelper(dbConnectionString, dbName);
            mongo.InsertDocument("capabilities", createNodeJSONObject);
        }

        public void addNodeToDBViaDynamicObject(object document, string dbConnectionString, string dbName)
        {
            //dynamic dynamicObject = JsonConvert.DeserializeObject<JsonDocument>(createNodeJSONString); - Resulted in $numberLong entries for the integer values in DB.
            //var dynamicObject = JsonConvert.DeserializeObject<dynamic>(createNodeJSONString)!; - Resulted in nothing but Jsonvalue entries for each property.
            //var jsonElement = JsonSerializer.Deserialize<JsonElement>(createNodeJSONString); - Resulted in only an object id and nothing else.  Those who are responsible have been sacked.
            //var dynamicObject = JsonConvert.DeserializeObject<ExpandoObject>(createNodeJSONString); - Wik.
            //dynamic dynamicObject = JsonConvert.DeserializeObject<NodeRedNode>(createNodeJSONString); - Also wik.
            MongoDBHelper mongo = new MongoDBHelper(dbConnectionString, dbName);
            mongo.InsertDocument("capabilities", document);
        }

        public void addNodeToNodeRedRepo()
        {
            /* Merge new node object into NodeRed repo file.
             * Turns out this can be done through the NodeRed Admin API.
             * string gitCommand = "git";
             * string gitAddArgument = @"add -A";
             * string gitCommitArgument = @"commit ""explanations_of_changes""";
             * string gitPushArgument = @"push our_remote";
             * 
             * System.Diagnostics.Process.Start(gitCommand, gitAddArgument);
             * System.Diagnostics.Process.Start(gitCommand, gitCommitArgument);
             * System.Diagnostics.Process.Start(gitCommand, gitPushArgument);
             */


        }

        public void pullNodeRedConfigFromRepo()
        {

        }
    }
}
