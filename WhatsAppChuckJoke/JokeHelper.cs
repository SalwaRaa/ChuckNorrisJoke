using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp1
{
    class JokeHelper
    {
        public static async Task<string> GetJokeAsync()
        {
            var joke = "No joke for you.";

            using (var httpClient = new HttpClient())
            {

                var apiEndpoint = "https://api.chucknorris.io/jokes/random";
                httpClient.BaseAddress = new Uri(apiEndpoint);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var responseMessage = await httpClient.GetAsync(apiEndpoint);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonContent = await responseMessage.Content.ReadAsStringAsync();
                    dynamic data = JsonConvert.DeserializeObject(jsonContent);
                    joke = data.value;
                }
            }

            return joke;
        }

    }
}