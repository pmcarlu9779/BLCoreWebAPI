using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BLCoreWebAPI
{
    public class BLCoreWorkerService : BackgroundService
    {
        private readonly ILogger<BLCoreWorkerService> _logger;
        public static string ApiCommand { get; set; }

        public BLCoreWorkerService(ILogger<BLCoreWorkerService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("BLCoreWorkerService running at: {time}, command: {string}", DateTimeOffset.Now, ApiCommand);
                await Task.Delay(6000, stoppingToken);
            }
        }
    }
}
