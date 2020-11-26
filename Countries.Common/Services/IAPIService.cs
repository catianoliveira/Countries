using Countries.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Countries.Common.Services
{
    public interface IAPIService
    {
        Task<Response> GetCountries(string urlBase, string controller);

        Task<Response> GetListAsync<T>(string urlBase, string servicePrefix, string controller);

        string CheckStringCountries(string property);

        List<string> CheckStringCountriesList(List<string> propertiesList);
    }
}