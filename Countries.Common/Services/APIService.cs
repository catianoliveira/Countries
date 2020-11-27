using Countries.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Countries.Common.Services
{
    public class APIService : IAPIService
    {
        
        public string CheckStringCountries(string property)
        {
            if (!string.IsNullOrEmpty(property))
            {
                return property;
            }

            return "N/A";
        }

        
        public List<string> CheckStringCountriesList(List<string> propertiesList)
        {
            if (propertiesList.Count == 0)
            {
                propertiesList.Add("N/A");

                return propertiesList;
            }

            return propertiesList;
        }

        //public async Task<Response> GetCountries(string urlBase, string controller)
        //{
        //    try
        //    {
        //        var client = new HttpClient();

        //        client.BaseAddress = new Uri(urlBase);

        //        var response = await client.GetAsync(controller);

        //        var result = await response.Content.ReadAsStringAsync();

        //        if (!response.IsSuccessStatusCode)
        //        {
        //            return new Response
        //            {
        //                IsSuccess = false,
        //                Message = result,
        //            };
        //        }


        //        var jsonSettings = new JsonSerializerSettings
        //        {
        //            NullValueHandling = NullValueHandling.Ignore
        //        };

        //        var countries = JsonConvert.DeserializeObject<List<CountryResponse>>(result, jsonSettings);

        //        return new Response
        //        {
        //            IsSuccess = true,
        //            Result = countries
        //        };
        //    }
        //    catch (Exception ex)
        //    {

        //        return new Response
        //        {
        //            IsSuccess = false,
        //            Message = ex.Message
        //        };
        //    }
        //}

        
        
        
        public async Task<Response> GetListAsync<T>(
        string urlBase,
        string servicePrefix,
        string controller)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase),
                };


                var jsonSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                };


                string url = $"{servicePrefix}{controller}";

                HttpResponseMessage response = await client.GetAsync(url);
                string result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                List<T> list = JsonConvert.DeserializeObject<List<T>>(result, jsonSettings);
                return new Response
                {
                    IsSuccess = true,
                    Result = list
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
