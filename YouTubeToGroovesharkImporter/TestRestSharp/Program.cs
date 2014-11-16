using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRestSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            RestClient client = new RestClient("https://api.grooveshark.com");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("/ws/3.0/?sig=8e7afd3b2ed4e83371d354c032b9b527", Method.POST);
            //request.AddUrlSegment("id", 123); // replaces matching token in request.Resource
           //request.
            // easily add HTTP Headers
            request.AddHeader("wsKey", "conv_youtube");
            //request.AddParameter("wsKey", "conv_youtube"); // adds to POST or URL querystring based on Method
            //request.AddParameter("secret", "756963c4026437dab03d09ca81df3ac7");
            request.AddParameter("selectedMethod", "startSession");
            request.AddParameter("protocol", "https");
            // add files to upload (works with compatible verbs)
            //request.AddFile(path);
            // execute the request
            RestResponse response = (RestResponse)client.Execute(request);
            var content = response.Content; // raw content as string
            Console.WriteLine(content);
            // or automatically deserialize result
            // return content type is sniffed but can be explicitly set via RestClient.AddHandler();
            //RestResponse<Person> response2 = client.Execute<Person>(request);
            //var name = response2.Data.Name;

            // easy async support
            //client.ExecuteAsync(request, response =>
            //{
            //    Console.WriteLine(response.Content);
            //});

            //// async with deserialization
            //var asyncHandle = client.ExecuteAsync<Person>(request, response =>
            //{
            //    Console.WriteLine(response.Data.Name);
            //});

            // abort the request on demand
            //asyncHandle.Abort();
        }
    }
}
