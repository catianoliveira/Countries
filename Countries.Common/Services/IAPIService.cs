using Countries.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Countries.Common.Services
{
    public interface IAPIService
    {
        // Task<Response> GetCountries(string urlBase, string controller);

        /// <summary>
        /// gets countries list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="urlBase"></param>
        /// <param name="servicePrefix"></param>
        /// <param name="controller"></param>
        /// <returns></returns>
        Task<Response> GetListAsync<T>(string urlBase, string servicePrefix, string controller);

        /// <summary>
        /// checks if value is null and replaces it "N/A"
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        string CheckStringCountries(string property);

        /// <summary>
        /// checks if value is null and replaces it "N/A"
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        List<string> CheckStringCountriesList(List<string> propertiesList);
    }
}