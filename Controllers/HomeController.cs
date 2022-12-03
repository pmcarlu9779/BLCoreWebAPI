using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BLCoreWebAPI.Controllers
{
    [ApiController]
    [Route("Home")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private const string runningMessage = "BLCoreWorkerService is running...";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            _logger.LogInformation(runningMessage);
            return runningMessage;
        }
    }
}
