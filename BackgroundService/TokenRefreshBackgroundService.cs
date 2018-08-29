using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BackgroundService
{
    internal class TokenRefreshBackgroundService : Microsoft.Extensions.Hosting.BackgroundService
    {
        private readonly ILogger _logger;

        public TokenRefreshBackgroundService(ILogger<TokenRefreshBackgroundService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("后台服务开始...");

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation(DateTime.Now.ToLongTimeString() + ": Refresh Token!");//在此写需要执行的任务
                await Task.Delay(5000, stoppingToken);
            }

            _logger.LogInformation("后台服务停止...");
        }
    }
}
