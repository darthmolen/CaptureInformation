using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using NLog;

namespace CaptureInformation.Filters
{
    // https://damienbod.com/2014/01/04/web-api-2-using-actionfilterattribute-overrideactionfiltersattribute-and-ioc-injection/
    public class LogWebApiTrafficFilterAttribute: ActionFilterAttribute
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            // pre-processing
            logger.Debug("ACTION DEBUG pre-processing logging");
            logger.Debug("Content In Filter:");
            logger.Debug(actionContext.Request.Content.ReadAsStringAsync().GetAwaiter().GetResult());
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var objectContent = actionExecutedContext.Response.Content as ObjectContent;
            if (objectContent != null)
            {
                var type = objectContent.ObjectType; //type of the returned object
                var value = objectContent.Value; //holding the returned value
                logger.Debug("type: {0}, value: {1}", type, value);
            }

            logger.Debug("ACTION DEBUG  OnActionExecuted Response " + actionExecutedContext.Response.StatusCode.ToString());
        }
    }
}