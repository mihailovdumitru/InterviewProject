using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Service.Infrastructure
{
    /// <summary>
    /// Generic class for handling HTTP calls
    /// </summary>
    /// <seealso cref="Service.Infrastructure.IRestHttpClient" />
    public class RestHttpClient : IRestHttpClient
    {
        /// <summary>
        /// Gets the specified base URL.
        /// </summary>
        /// <typeparam name="T">Data Type returned</typeparam>
        /// <param name="baseUrl">The base URL.</param>
        /// <param name="url">The URL.</param>
        /// <param name="accessToken">The access token.</param>
        /// <returns>Data returned from API</returns>
        public async Task<T> Get<T>(string baseUrl, string url, string accessToken = null)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<T>(data);
                    }

                    return default(T);
                }
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }
}
