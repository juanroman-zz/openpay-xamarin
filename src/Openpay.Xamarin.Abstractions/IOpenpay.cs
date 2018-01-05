using System.Threading.Tasks;

namespace Openpay.Xamarin.Abstractions
{
    public interface IOpenpay
    {
        void Initialize(string merchantId, string publicApiKey, bool productionMode);

        Task<string> CreateDeviceSessionId();

        Task<Token> CreateTokenFromCard(Card card);

        Task<Token> GetTokenFromId(string id);
    }
}
