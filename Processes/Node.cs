using BLCoreWebAPI.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace BLCoreWebAPI.Processes
{
    public class Node
    {
        public List<NodeRedNode> createNode(object createNodeJSONObject, string dbConnectionString, string dbName, string nodeRedRepo)
        {
            // First, query for capability in MongoDB.
            Capabilities capabilities = new Capabilities();
            List<NodeRedNode> capabilitiesList = capabilities.getCapabilitiesList(dbConnectionString, dbName);

            Debug.WriteLine(capabilitiesList);

            // Search for capability in results.

            // If found, return some message stating this.  If not found, create the NodeRedNode.

            // Then, insert that NodeRedNode object into MongoDB.

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

            Process.Start(gitCommand, gitAddArgument);
            Process.Start(gitCommand, gitCommitArgument);
            Process.Start(gitCommand, gitPushArgument);
        }

        public void pullNodeRedConfigFromRepo()
        {

        }
    }
}
