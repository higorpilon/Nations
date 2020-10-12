using Nations.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Nations.Services
{
   public class NetworkService : INetworkService
    {

        public static Response CheckConnection()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.OpenRead("http://clients3.google.com/generate_204");

                    return new Response
                    {
                        IsSuccess = true
                    };
                }
            }
            catch
            {
                return new Response
                {
                    IsSuccess = false
                };
            }
        }
    }
}
