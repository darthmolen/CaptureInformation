using CaptureInformation.Attributes;
using CaptureInformation.Filters;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CaptureInformation.Controllers
{
    /// INFO: This is a web api controller, this filter will fire for each action since it has been decorated
    [LogWebApiTrafficFilter]
    [RoutePrefix("api/[controller]")]
    public class TestDataController : ApiController
    {
        public TestDataController()
        { }

        /// <summary>
        /// Returns a simple boolean. Used for Action Testing
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>
        /// { "Value1" : "Value1", "Value2": "Value2" }
        /// </remarks>
        [HttpPost]
        public bool SaveTestData([FromBody]TestData data)
        {
            return true;
        }

        /// <summary>
        /// Return a Test Data Object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.OK, Type=typeof(TestData))]
        [HttpGet]
        public HttpResponseMessage GetTestData(string id)
        {
            return Request.CreateResponse<TestData>(new TestData() { Value1 = "TestData1", Value2 = "TestData2" });
        }

        /// <summary>
        /// Returns a TestData File
        /// </summary>
        /// <returns>TestData File</returns>
        [SwaggerFileResponse(HttpStatusCode.OK, "File Response", Type=typeof(Stream))]
        [HttpGet]
        public HttpResponseMessage GetTestFile()
        {
            //FileWebResponse resp = new FileWebResponse()
            MemoryStream stream = new MemoryStream();
            Stream fileStream = File.Open(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/FileTestData.json"), FileMode.Open);

            fileStream.CopyTo(stream);
            stream.Position = 0;

            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "FileTestData.json";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;
        }


    }

    /// <summary>
    /// Test Data
    /// </summary>
    /// <remarks>
    /// { "Value1": "test value", "Value2": "test value 2" }
    /// </remarks>
    public class TestData
    {
        public string Value1 { get; set; }
        public string Value2 { get; set; }
    }
}
