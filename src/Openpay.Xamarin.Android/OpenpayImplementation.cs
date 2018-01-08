using Android.App;
using Android.Provider;
using Android.Webkit;
using Java.Util;
using Openpay.Xamarin.Abstractions;
using System;
using System.Threading.Tasks;

namespace Openpay.Xamarin
{
    public class OpenpayImplementation : OpenpayBaseImplementation
    {
        protected override Task<string> CreateDeviceSessionIdInternal(string merchantId, string apiKey, string baseUrl)
        {
            if (null == Activity)
            {
                throw new InvalidOperationException("Activity has not been initialized.");
            }

            var sessionId = UUID.RandomUUID().ToString();
            sessionId = sessionId.Replace("-", string.Empty);

            var identifierForVendor = Settings.Secure.GetString(Activity.ContentResolver, Settings.Secure.AndroidId);
            var identifierForVendorScript = $"var identifierForVendor = '{identifierForVendor}';";

            using (var webView = new WebView(Activity))
            {
                webView.SetWebViewClient(new WebViewClient());
                webView.Settings.JavaScriptEnabled = true;
                webView.EvaluateJavascript(identifierForVendorScript, null);

                var url = $"{baseUrl}/oa/logo.htm?m={merchantId}&s={sessionId}";
                webView.LoadUrl(url);

                return Task.FromResult(sessionId);
            }
        }

        internal static Activity Activity { get; set; }
    }
}
