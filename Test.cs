using RestSharp;
using System.Collections.Generic;
using System.Net;

namespace AngloAmericanAPITest
{
    /// <summary>
    ///  This class performs the GET call and retuns the response
    /// </summary>
    public class Test
    {
        //This create a CarData object
        public class CarData
        {
            public string make { get; set; }
            public string model { get; set; }
            public string year { get; set; }
            public string type { get; set; }
            public double zeroToSixty { get; set; }
            public int price { get; set; }

        }
        //This method used the Rest sharper to make a get call amd returns the response
        public IRestResponse<List<CarData>> TestMethod1(string carName)
        {
            //Buidling the client uri
            var client = new RestClient("http://localhost:54356/");
            //Setting the Request to make a GET call using the 
            var request = new RestRequest("/api/Cars/{car}", Method.GET);
            //Adidng the url segment from the specfile
            request.AddUrlSegment("car", carName);
            //Creating the CardData object from the reesponse
            var response = client.Execute<List<CarData>>(request);
            //Reading the Status code
            HttpStatusCode statusCode = response.StatusCode;
            //Returns the response
            return response;
           
        }
    }
}
