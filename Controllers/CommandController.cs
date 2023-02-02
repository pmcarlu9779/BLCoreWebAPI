using BLCoreWebAPI.Models;
using BLCoreWebAPI.Processes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;

namespace BLCoreWebAPI.Controllers
{
    [ApiController]
    [Route("Command/")]
    public class CommandController : Controller
    {
        private readonly ILogger<HomeController> _logger;
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
        public List<dynamic> Capabilities()
        {
            Capabilities capabilities = new Capabilities();
            List<dynamic> capabilitiesList = capabilities.getCapabilitiesList(_connectionStrings.dbConnectionString, _connectionStrings.dbName);
            _logger.LogInformation($"Capabilities list: {capabilitiesList}");
            return capabilitiesList;
        }

        [HttpPost]
        [Route("Node")]
        public HttpResponseMessage Node(string createNodeJSONString)
        {
            Node node = new Node();
            HttpResponseMessage createNodeMessage = node.createNode(createNodeJSONString, _connectionStrings.dbConnectionString, _connectionStrings.dbName);
            _logger.LogInformation(createNodeMessage.ReasonPhrase);
            return createNodeMessage;
        }
    }
}
