using Countries.Common.Models;
using System;
using System.Net;

namespace Countries.Common.Services
{
    public class NetworkService : INetworkService
    {
        public Response CheckConnection()
        {
            var client = new WebClient();

            try
            {
                // ping - Google server
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return new Response
                    {
                        IsSuccess = true,
                    };
                }
            }
            catch (Exception)
            {

                return new Response
                {
                    IsSuccess = false,
                    Message = "Setup your Internet connection!",
                };
            }
        }
    }
}
