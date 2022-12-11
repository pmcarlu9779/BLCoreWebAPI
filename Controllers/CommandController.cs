using BLCoreWebAPI.Models;
using BLCoreWebAPI.Processes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BLCoreWebAPI.Controllers
{
    [ApiController]
    //[Route("Command/{apiCommand}")]
    [Route("Command/")]
    public class CommandController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string RunningMessage() => $"apiCommand: {BLCoreWorkerService.ApiCommand}";

        public CommandController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Capabilities")]
        public string Capabilities()
        {
            //BLCoreWorkerService.ApiCommand = apiCommand;
            _logger.LogInformation(RunningMessage());
            return RunningMessage();
        }

        // The acceptance of whatever command should be dynamic. It should be a HttpPost, and it should check against the capabilities list, first.

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes("application/json")]
        [Route("CreateNode")]
        public ActionResult<NodeRedNode> CreateNode(string createNodeJSONObject)
        {
            BLCoreWorkerService.ApiCommand = "CreateNode";
            _logger.LogInformation(RunningMessage());

            // Call createNode to do the work.
            Node node = new Node();
            NodeRedNode nodeRedNode = node.createNode(createNodeJSONObject);

            // Return the node JSON, for testing purposes, but the node should automatically be applied to the NodeRed server.
            return nodeRedNode;
        }
    }
}
