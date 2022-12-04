using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection.Emit;

namespace BLCoreWebAPI.Controllers
{
    [ApiController]
    [Route("Command/{apiCommand}")]
    public class CommandController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string RunningMessage() => $"apiCommand: {BLCoreWorkerService.ApiCommand}";

        public CommandController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string SetCommand(string apiCommand)
        {
            BLCoreWorkerService.ApiCommand = apiCommand;
            _logger.LogInformation(RunningMessage());

            switch (apiCommand)
            {
                case "createNode":
                    // code block
                    break;
                default:
                    // code block
                    break;
            }

            return RunningMessage();
        }

        // The acceptance of whatever command should be dynamic. It should be a HttpPost, and it should check against the capabilities list, first.
    }
}
