using Project.Controllers;
using Project.Models;
using Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class BitcoinService
    {
        private readonly IRestHttpClient restHttpClient;

        public BitcoinService(IRestHttpClient restClient)
        {
            this.restHttpClient = restClient;
        }

        public async Task<BitcoinRealTimeData> GetBitcoinRealData()
        {
            return await restHttpClient.Get<BitcoinRealTimeData>("https://www.bitstamp.net/api/", "ticker");
        }
    }
}
