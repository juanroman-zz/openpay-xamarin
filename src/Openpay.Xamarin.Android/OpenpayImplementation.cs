using Android.App;
using Openpay.Xamarin.Abstractions;
using System;
using System.Threading.Tasks;
using Native = MX.Openpay.Android;

namespace Openpay.Xamarin
{
    public class OpenpayImplementation : IOpenpay
    {
        private static Native.Openpay _nativeOpenpay;

        public bool IsIntialized { get; private set; }

        public void Initialize(string merchantId, string apiKey, bool productionMode)
        {
            IsIntialized = true;
            _nativeOpenpay = new Native.Openpay(merchantId, apiKey, new Java.Lang.Boolean(productionMode));
        }

        public Task<string> CreateDeviceSessionId(int timeout)
        {
            // Assertions
            CheckIfInitialized();
            var deviceCollectorDefaultImpl = _nativeOpenpay.DeviceCollectorDefaultImpl ?? throw new InvalidOperationException("DeviceCollectorDefaultImpl is not initialized in Openpay Native API.");
            var activity = Activity ?? throw new InvalidOperationException("Activity not defined. You need to call OpenpayAndroidImpl.Init at the beginning of your project.");

            return Task.FromResult(deviceCollectorDefaultImpl.Setup(activity));
        }

        internal static Activity Activity { get; set; }

        private void CheckIfInitialized()
        {
            if (!IsIntialized || null == _nativeOpenpay)
            {
                throw new InvalidOperationException("Openpay instance has not been initialized.");
            }
        }
    }
}
