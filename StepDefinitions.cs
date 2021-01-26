using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using System.Data;


namespace AngloAmericanAPITest
{
    [Binding]
   
    public class StepDefinitions: UnitTest1
    {
        private readonly ScenarioContext scenarioContext;
        RestSharp.IRestResponse<List<CarData>> restResponse;
        private CarData _carsdata;

        public StepDefinitions(ScenarioContext scenarioContext, CarData carsdata)
        {
            this.scenarioContext = scenarioContext;
            _carsdata = carsdata;

        }

    

        [Given(@"When I call the GET endpoint with ""(.*)""")]
        public void GivenWhenICallTheGETEndpointWith(string carName)
        {
            UnitTest1 test = new UnitTest1();
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

    }
}
