using System;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.Description;

namespace HttpClientFactory.Azure.WebJobs.Extensions.Config
{
    [Extension("HttpClientFactory")]
    internal class HttpClientFactoryExtensionConfigProvider : IExtensionConfigProvider
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpClientFactoryExtensionConfigProvider(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public void Initialize(ExtensionConfigContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            // HttpClientFactory Bindings
            var bindingAttributeBindingRule = context.AddBindingRule<HttpClientFactoryAttribute>();
            bindingAttributeBindingRule.BindToInput<HttpClient>((httpClientFactoryAttribute) =>
            {
                return _httpClientFactory.CreateClient();
            });
        }
    }
}
