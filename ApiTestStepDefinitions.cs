using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using TechTalk.SpecFlow;


namespace AngloAmericanAPITest
{
    [Binding]
   
    public class ApiTestStepDefinitions: Test
    {
        RestSharp.IRestResponse<List<CarData>> restResponse;

        public ApiTestStepDefinitions()
        {
        }

        [Given(@"When I call the GET endpoint with ""(.*)""")]
        public void GivenWhenICallTheGETEndpointWith(string carName)
        {
             Test test = new Test();
            restResponse = test.TestMethod1(carName);
        }

        [Then(@"The expected output as below")]
        public void ThenTheExpectedOutputAsBelow(Table table)
        {
            string data = restResponse.Content;
            var _carinfo = JsonConvert.DeserializeObject<List<CarData>>(data);
            int i = 0;
         
                foreach(TableRow row in table.Rows)
                {
                    Assert.AreEqual(row["Make"], _carinfo[i].make);
                    Assert.AreEqual(row["Model"], _carinfo[i].model);
                    Assert.AreEqual(row["Year"], _carinfo[i].year);
                    Assert.AreEqual(row["Type"], _carinfo[i].type);
                    Assert.AreEqual(row["ZeroToSixty"], _carinfo[i].zeroToSixty.ToString());
                    Assert.AreEqual(row["Price"], _carinfo[i].price.ToString());
                    i++;
                }

            
        }

        [Then(@"I should see the response status code as ""(.*)""")]
        public void ThenIShouldSeeTheResponseStatusCodeAs(string _statuscode)
        {
            System.Net.HttpStatusCode statusCode = restResponse.StatusCode;
            Assert.AreEqual(_statuscode, statusCode.ToString());
        }


        [Given(@"I dont pass an authentication token")]
        public void GivenIDontPassAnAuthenticationToken()
        {
            //Manual Execution
        }

        [Given(@"The Server encountered an unexpected condition")]
        public void GivenTheServerEncounteredAnUnexpectedCondition()
        {
            //Manual Execution
        }

        [Given(@"The Server is not available")]
        public void GivenTheServerIsNotAvailable()
        {
            //Manual Execution
        }


    }
}
