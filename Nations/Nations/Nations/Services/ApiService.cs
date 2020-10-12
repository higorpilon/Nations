using Nations.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Nations.Services
{
   public class ApiService : IApiService

    {
        public static async Task<Response> GetData(string url, string controller)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(url);

                var response = await client.GetAsync(controller);
                var result = await response.Content.ReadAsStringAsync();//Retrieve everything that is in the api

                if (response.IsSuccessStatusCode == false)//If there´s an error
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result
                    };
                }

                var jsonSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore//Handle nulls coming from api
                };

                var countries = JsonConvert.DeserializeObject<List<CountryResponse>>(result, jsonSettings);

                return new Response
                {
                    IsSuccess = true,
                    Result = countries
                };
            }
            catch (Exception e)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = e.Message
                };
            }
        }
    }
}
