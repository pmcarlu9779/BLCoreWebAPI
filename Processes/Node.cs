using BLCoreWebAPI.Database;
using BLCoreWebAPI.Models;
using FuzzySharp;
using System.Collections.Generic;
using System.Net.Http;

namespace BLCoreWebAPI.Processes
{
    public class Node
    {
        public HttpResponseMessage createNode(NodeRedNode createNodeJSONObject, string dbConnectionString, string dbName, string nodeRedRepo)
        {
            Capabilities capabilities = new Capabilities();
            List<NodeRedNode> capabilitiesList = capabilities.getCapabilitiesList(dbConnectionString, dbName);
            string capabilityExistsMessage;
            string capabilityAddedMessage;
            HttpResponseMessage response = new HttpResponseMessage();
            HttpRequestMessage request = new HttpRequestMessage();
            const int LOWER_FUZZY_MATCH_THRESHOLD = 60;

            if (capabilitiesList.Count != 0)
            {
                foreach (NodeRedNode capability in capabilitiesList)
                {
                    // What identifier(s) do we look for in the object to determine it exists?
                    // For now, using a Levenschtein distance algorithm with name field. We can adjust the method behind this, if necessary, later.
                    
                    // Test cases:
                    // 1) Name = "send gmail"
                    // 2) Name = "send an email"
                    // 3) Name = "mail"

                    // Have to lower threshold to 50, for this.
                    int simScore = Fuzz.PartialRatio(capability.Name, createNodeJSONObject.Name);

                    // Have to lower threshold to 50, for this.
                    //int simScore = Fuzz.PartialTokenSetRatio(capability.Name, createNodeJSONObject.Name);

                    // Have to lower threshold to 49, for this.
                    //int simScore = Fuzz.WeightedRatio(capability.Name, createNodeJSONObject.Name); 

                    if (simScore >= LOWER_FUZZY_MATCH_THRESHOLD)
                    {
                        capabilityExistsMessage = $"The capability \"{capability.Name}\" already exists.";
                        response.StatusCode = System.Net.HttpStatusCode.Found;
                        response.ReasonPhrase = capabilityExistsMessage;
                        return response;
                    }
                }
            }

            addNodeToDB(createNodeJSONObject, dbConnectionString, dbName);
            capabilityAddedMessage = $"The capability \"{createNodeJSONObject.Name}\" has been learned.";
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

        public void addNodeToNodeRedRepo()
        {
            // Merge new node object into NodeRed repo file.
            string gitCommand = "git";
            string gitAddArgument = @"add -A";
            string gitCommitArgument = @"commit ""explanations_of_changes""";
            string gitPushArgument = @"push our_remote";

            System.Diagnostics.Process.Start(gitCommand, gitAddArgument);
            System.Diagnostics.Process.Start(gitCommand, gitCommitArgument);
            System.Diagnostics.Process.Start(gitCommand, gitPushArgument);
        }

        public void pullNodeRedConfigFromRepo()
        {

        }
    }
}
