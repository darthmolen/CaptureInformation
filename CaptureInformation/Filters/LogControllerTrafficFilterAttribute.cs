using NLog;
using System;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;

namespace CaptureInformation.Filters
{
    public class LogMvcTrafficFilterAttributeAttribute: ActionFilterAttribute
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public LogMvcTrafficFilterAttributeAttribute(): base()
        { }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log("OnActionExecuting", filterContext.RouteData);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log("OnActionExecuted", filterContext.RouteData);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Log("OnResultExecuting", filterContext.RouteData);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Log("OnResultExecuted", filterContext.RouteData);
        }


        private void Log(string methodName, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = String.Format("{0} controller:{1} action:{2}", methodName, controllerName, actionName);
            logger.Debug(message, "Action Filter Log");
        }

    }
}