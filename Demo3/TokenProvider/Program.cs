using IdentityModel.Client;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TokenProvider
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();

            Console.ReadLine();
        }

        private static async Task RunAsync()
        {
            //get the token
            var disco = await DiscoveryClient.GetAsync("http://localhost:17034/");

            var tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("helloapi");

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }
            else
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:13036");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);
                var response = await client.GetAsync("api/hello?name=Maria");
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
            
        }
    }
}
