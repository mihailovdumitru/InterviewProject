using System.Threading.Tasks;

namespace Service.Infrastructure
{
    public interface IRestHttpClient
    {
        Task<T> Get<T>(string baseUrl, string url, string accessToken = null);
    }
}
