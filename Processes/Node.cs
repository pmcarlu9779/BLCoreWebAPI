using BLCoreWebAPI.Models;
using System.Diagnostics;

namespace BLCoreWebAPI.Processes
{
    public class Node
    {
        public NodeRedNode createNode(object createNodeJSONObject, string nodeRedRepo)
        {
            // First, query for capability in MongoDB.

            // Search for capability in results.

            // If found, return some message stating this.  If not found, create the NodeRedNode.

            // Then, insert that NodeRedNode object into MongoDB.

            NodeRedNode nodeRedNode = new NodeRedNode();
            return nodeRedNode;
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
