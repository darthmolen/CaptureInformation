# CaptureInformation

1. Message Handlers are an extensibility only Web API can take advantage of (check your controller for system.web.http)
2. Filters are for both web api and MVC
3. Filters only fire if the route matches
4. Filters in MVC are quite limited through filterContext
5. If a filter is registered globally (FilterConfig.cs, called by WebApiConfig.cs), it will fire for any MVC Controller Action
6. Decorate your Web API controller with your system.web.http filter for it to fire for that controllerb
