using BLCoreWebAPI.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace BLCoreWebAPI.Processes
{
    public class Node
    {
        public List<NodeRedNode> createNode(object createNodeJSONObject, string dbConnectionString, string dbName, string nodeRedRepo)
        {
            Capabilities capabilities = new Capabilities();
            List<NodeRedNode> capabilitiesList = capabilities.getCapabilitiesList(dbConnectionString, dbName);

            if (capabilitiesList.Count != 0)
            {
                foreach (NodeRedNode capability in capabilitiesList)
                {
                    // What identifier(s) do we look for in the object to determine it exists?
                }
            }

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
