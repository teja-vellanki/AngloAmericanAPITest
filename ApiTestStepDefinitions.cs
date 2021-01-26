using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using TechTalk.SpecFlow;


namespace AngloAmericanAPITest
{
    [Binding]
    /// <summary>
    ///  This class performs all the step actions of the spec file
    /// </summary>
    public class ApiTestStepDefinitions: Test
    {
        RestSharp.IRestResponse<List<CarData>> restResponse;

        public ApiTestStepDefinitions()
        {
        }

        [Given(@"When I call the GET endpoint with ""(.*)""")]
        public void GivenWhenICallTheGETEndpointWith(string carName)
        {
            //Creating an instance of the class Test
             Test test = new Test();
            //Reading the responsf from test method into a Irest response
            restResponse = test.TestMethod1(carName);
        }

        [Then(@"The expected output as below")]
        public void ThenTheExpectedOutputAsBelow(Table table)
        {
            //Reading the response content
            string data = restResponse.Content;
            //deseraisizing the data into car data lsit
            var _carinfo = JsonConvert.DeserializeObject<List<CarData>>(data);
            int i = 0;
             //Running the loop to assert the al the car data with expected data from spec file
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
            //Reading the http status code
            System.Net.HttpStatusCode statusCode = restResponse.StatusCode;
            //Validating the status code 
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
