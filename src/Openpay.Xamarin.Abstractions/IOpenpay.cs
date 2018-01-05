using System.Threading.Tasks;

namespace Openpay.Xamarin.Abstractions
{
    public interface IOpenpay
    {
        bool IsIntialized { get; }

        void Initialize(string merchantId, string apiKey, bool productionMode);

        Task<string> CreateDeviceSessionId(int timeout);
    }
}
