using RestSharp;
using System.Collections.Generic;
using System.Net;

namespace AngloAmericanAPITest
{ 

    public class Test
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

        public class CarInformation
        {
            public List<CarData> cardata { get; set; }

        }

        public IRestResponse<List<CarData>> TestMethod1(string carName)
        {
            var client = new RestClient("http://localhost:54356/");
            var request = new RestRequest("/api/Cars/{car}", Method.GET);
            request.AddUrlSegment("car", carName);
            var response = client.Execute<List<CarData>>(request);
            HttpStatusCode statusCode = response.StatusCode;
            return response;
           
        }
    }
}
