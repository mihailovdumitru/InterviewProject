using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Infrastructure
{
    public interface IRestHttpClient
    {
        Task<T> Get<T>(string baseUrl, string url, string accessToken = null);
    }
}
