using CaptureInformation.Filters;
using System;
using System.Collections.Generic;
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
        [HttpPost]
        public bool SaveTestData([FromBody]TestData data)
        {
            return true;
        }

        public TestData GetTestData(string id)
        {
            return new TestData() { Value1 = "TestData1", Value2 = "TestData2" };
        }


    }

    /// <summary>
    /// Test Data
    /// </summary>
    /// <remarks>
    /// { Value1: "test value", Value2: "test value 2" }
    /// </remarks>
    public class TestData
    {
        public string Value1 { get; set; }
        public string Value2 { get; set; }
    }
}
