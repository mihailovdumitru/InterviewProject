using Model.Elements;
using Service.Infrastructure;
using Service.Interfaces;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Service.Implementation
{
    /// <summary>
    /// Service for Bitcoin HTTP calls
    /// </summary>
    /// <seealso cref="Service.Interfaces.IBitcoinService" />
    public class BitcoinService : IBitcoinService
    {
        private readonly IRestHttpClient restHttpClient;

        public BitcoinService(IRestHttpClient restClient)
        {
            this.restHttpClient = restClient;
        }

        /// <summary>
        /// Gets the bitcoin real data.
        /// </summary>
        /// <returns>Bitcoin Real Time Data</returns>
        public async Task<BitcoinRealTimeData> GetBitcoinRealData()
        {
            return await restHttpClient.Get<BitcoinRealTimeData>
                              ("https://www.bitstamp.net/api/", "ticker/");
        }
    }
}
