using Model.Elements;
using Services.Infrastructure;
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
