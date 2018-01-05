using Openpay.Xamarin.Abstractions;
using System;
using System.Threading.Tasks;

namespace Openpay.Xamarin
{
    public class OpenpayImplementation : IOpenpay
    {
        public bool IsIntialized { get; private set; }

        public void Initialize(string merchantId, string apiKey, bool productionMode)
        {
            IsIntialized = true;
        }

        public Task<string> CreateDeviceSessionId(int timeout)
        {
            return Task.FromResult(Guid.NewGuid().ToString());
        }
    }
}
