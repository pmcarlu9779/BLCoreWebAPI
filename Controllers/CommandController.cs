using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
            return RunningMessage();
        }
    }
}
