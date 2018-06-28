using System.Web;
using System.Web.Mvc;
using CaptureInformation.Filters;

namespace CaptureInformation
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            /// INFO: By registering here, this filter is automatically applied to all MVC actions (not web api)
            /// https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/controllers-and-routing/understanding-action-filters-cs
            filters.Add(new LogMvcTrafficFilterAttributeAttribute());
        }
    }
}
