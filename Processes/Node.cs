using BLCoreWebAPI.Models;

namespace BLCoreWebAPI.Processes
{
    public class Node
    {
        public NodeRedNode createNode(object createNodeJSONObject)
        {
            // First, query for capability in MongoDB.

            // Search for capabilityy in results.

            // If found, return some message stating this.  If not found, create the NodeRedNode.

            // Then, insert that NodeRedNode object into MongoDB.

            NodeRedNode nodeRedNode = new NodeRedNode();
            return nodeRedNode;
        }

        public void addNodeToNodeRedRepo()
        {
            // Merge new node object into NodeRed repo file.
        }
    }
}
