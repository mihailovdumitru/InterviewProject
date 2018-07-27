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
    public class BitcoinService : IBitcoinService
    {
        private readonly IRestHttpClient restHttpClient;

        public BitcoinService(IRestHttpClient restClient)
        {
            this.restHttpClient = restClient;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | 
                                                    SecurityProtocolType.Tls | 
                                                    SecurityProtocolType.Tls11 | 
                                                    SecurityProtocolType.Tls12;
        }

        public async Task<BitcoinRealTimeData> GetBitcoinRealData()
        {
            return await restHttpClient.Get<BitcoinRealTimeData>
                              ("https://www.bitstamp.net/api/", "ticker/");
        }
    }
}
