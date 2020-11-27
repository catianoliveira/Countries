using Countries.Common.Models;

namespace Countries.Common.Services
{
    public interface INetworkService
    {

        /// <summary>
        /// checks if theres an internet connection
        /// </summary>
        /// <returns></returns>
        Response CheckConnection();
    }
}
