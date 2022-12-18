using BLCoreWebAPI.Models;
using BLCoreWebAPI.Processes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BLCoreWebAPI.Controllers
{
    [ApiController]
    [Route("Command/")]
    public class CommandController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string RunningMessage() => $"apiCommand: {BLCoreWorkerService.ApiCommand}";
        private readonly ConnectionStrings _connectionStrings;
        private readonly GitRepositories _gitRepositories;

        public CommandController(ILogger<HomeController> logger, IOptions<ConnectionStrings> connectionStrings, IOptions<GitRepositories> gitRepositories)
        {
            _logger = logger;
            _connectionStrings = connectionStrings.Value;
            _gitRepositories = gitRepositories.Value;
        }

        [HttpGet]
        [Route("Capabilities")]
        public object Capabilities()
        {
            Capabilities capabilities = new Capabilities();
            object capabilitiesList = capabilities.getCapabilitiesList(_connectionStrings.dbConnectionString, _connectionStrings.dbName);
            _logger.LogInformation($"Capabilities list: {capabilitiesList}");
            return capabilitiesList;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes("application/json")]
        [Route("Node")]
        public ActionResult<NodeRedNode> Node(string createNodeJSONObject)
        {
            BLCoreWorkerService.ApiCommand = "Node";
            _logger.LogInformation(RunningMessage());

            // Call createNode to do the work.
            Node node = new Node();
            NodeRedNode nodeRedNode = node.createNode(createNodeJSONObject, _gitRepositories.nodeRedRepo);

            // Return the node JSON, for testing purposes, but the node should automatically be applied to the NodeRed server.
            return nodeRedNode;
        }
    }
}
