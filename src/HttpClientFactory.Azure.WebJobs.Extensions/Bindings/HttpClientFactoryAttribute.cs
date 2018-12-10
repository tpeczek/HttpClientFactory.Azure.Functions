using System;
using System.Net.Http;
using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs
{
    /// <summary>
    /// Attribute used to bind to a <see cref="HttpClient"/> instance.
    /// </summary>
    [Binding]
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    public sealed class HttpClientFactoryAttribute : Attribute
    { }
}
