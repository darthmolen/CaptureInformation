//using Swashbuckle.AspNetCore.Swagger;
//using Swashbuckle.AspNetCore.SwaggerGen;
using CaptureInformation.Attributes;
using Swashbuckle.Swagger;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace CaptureInformation.Filters
{
    /// INFO: https://github.com/domaindrivendev/Swashbuckle/issues/324
    /// Took a blend of what gaui suggested and OzBob said 
    public class FileFilter: IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (apiDescription.GetControllerAndActionAttributes<SwaggerResponseRemoveDefaultsAttribute>().Any())
                operation.responses.Clear();

            var responseAttributes = apiDescription.GetControllerAndActionAttributes<SwaggerFileResponseAttribute>()
                .OrderBy(attr => attr.StatusCode);

            foreach (var attr in responseAttributes)
            {
                var statusCode = attr.StatusCode.ToString();

                operation.produces = new[] { "application/octet-stream" };
                operation.responses[statusCode] = new Response
                {
                    description = attr.Description ?? InferDescriptionFrom(statusCode),
                    schema = new Schema { format = "application/octet-stream", type = "file" }
                };
            }
        }

        private string InferDescriptionFrom(string statusCode)
        {
            HttpStatusCode enumValue;
            if (Enum.TryParse(statusCode, true, out enumValue))
            {
                return enumValue.ToString();
            }
            return null;
        }
    }
}
