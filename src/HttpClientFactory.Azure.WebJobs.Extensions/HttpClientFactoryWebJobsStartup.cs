using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;
using HttpClientFactory.Azure.WebJobs.Extensions;
using HttpClientFactory.Azure.WebJobs.Extensions.Config;

[assembly: WebJobsStartup(typeof(HttpClientFactoryWebJobsStartup))]

namespace HttpClientFactory.Azure.WebJobs.Extensions
{
    /// <summary>
    /// Class defining a startup configuration action for HttpClientFactory binding extensions, which will be performed as part of host startup.
    /// </summary>
    public class HttpClientFactoryWebJobsStartup : IWebJobsStartup
    {
        /// <summary>
        /// Performs the startup configuration action for HttpClientFactory binding extensions.
        /// </summary>
        /// <param name="builder">The <see cref="IWebJobsBuilder"/> that can be used to configure the host.</param>
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddExtension<HttpClientFactoryExtensionConfigProvider>();

            builder.Services.AddHttpClient();
        }
    }
}
