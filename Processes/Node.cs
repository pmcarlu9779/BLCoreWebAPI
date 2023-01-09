using BLCoreWebAPI.Models;
using FuzzySharp;
using System.Collections.Generic;
using System.Diagnostics;

namespace BLCoreWebAPI.Processes
{
    public class Node
    {
        public List<NodeRedNode> createNode(NodeRedNode createNodeJSONObject, string dbConnectionString, string dbName, string nodeRedRepo)
        {
            Capabilities capabilities = new Capabilities();
            List<NodeRedNode> capabilitiesList = capabilities.getCapabilitiesList(dbConnectionString, dbName);
            const int LOWER_FUZZY_MATCH_THRESHOLD = 50;

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
                        // Then capability exists in the collection. Break, and return message.
                        break;
                    }
                }

                // return capabilityExistsMessage;
            }

            // Then, insert that NodeRedNode object into MongoDB.
            // from node-red util.js - bytes.push(Math.round(0xff*Math.random()).toString(16).padStart(2,'0'));

            //NodeRedNode nodeRedNode = new NodeRedNode();
            //return nodeRedNode;
            return capabilitiesList;
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
