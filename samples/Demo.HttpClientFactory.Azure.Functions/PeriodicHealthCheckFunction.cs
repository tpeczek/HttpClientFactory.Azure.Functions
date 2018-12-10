using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Demo.HttpClientFactory.Azure.Functions
{
    public static class PeriodicHealthCheckFunction
    {
        [FunctionName("PeriodicHealthCheckFunction")]
        public static async Task Run(
            [TimerTrigger("0 */1 * * * *")]TimerInfo healthCheckTimer,
            [HttpClientFactory]HttpClient httpClient,
            ILogger log)
        {
            string status = await httpClient.GetStringAsync("https://localhost:5001/healthcheck");

            log.LogInformation($"Health check performed at: {DateTime.UtcNow} | Status: {status}");
        }
    }
}
