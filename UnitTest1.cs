using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace AngloAmericanAPITest
{ 
   
    [TestClass]
    public class UnitTest1
    {

        public class CarData
        {
            public string make { get; set; }
            public string model { get; set; }
            public string year { get; set; }
            public string type { get; set; }
            public double zeroToSixty { get; set; }
            public int price { get; set; }

        }

        public class root
        {
            public List<CarData> cardata { get; set; }

        }

 
        [TestMethod]
        public IRestResponse<List<CarData>> TestMethod1(string carName)
        {
            var client = new RestClient("http://localhost:54356/");

            var request = new RestRequest("/api/Cars/{car}", Method.GET);
            request.AddUrlSegment("car", carName);
            var response = client.Execute<List<CarData>>(request);
            int statuscode =(int)response.StatusCode;
            if (response.StatusCode == HttpStatusCode.OK)
                return response;
            else
                throw new ApplicationException(response.ErrorMessage);
                
            
 
           
        }
    }
}
