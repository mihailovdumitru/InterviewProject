using Model.Elements;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IBitcoinService
    {
        Task<BitcoinRealTimeData> GetBitcoinRealData();
    }
}
