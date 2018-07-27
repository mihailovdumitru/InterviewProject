using Model.Elements;
using Service.Infrastructure;
using Service.Interfaces;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class BitcoinService : IBitcoinService
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
