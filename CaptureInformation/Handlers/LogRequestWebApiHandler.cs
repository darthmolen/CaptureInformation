using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using NLog;

namespace CaptureInformation.Handlers
{
    /// <summary>
    /// This only triggers for Web API: https://stackoverflow.com/questions/18880306/asp-mvc-message-handlers-vs-web-api-message-handlers
    /// </summary>
    public class LogRequestWebApiHandler: DelegatingHandler
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        protected async override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            logger.Debug("Processing request in Message Handler");
            logger.Debug("Request URI: {0}", request.RequestUri);
            logger.Debug("Content:");
            logger.Debug(request.Content.ReadAsStringAsync().GetAwaiter().GetResult());
            // Call the inner handler.

            var response = await base.SendAsync(request, cancellationToken);
            logger.Debug("Processing response in message handler.");
            return response;
        }
    }
}