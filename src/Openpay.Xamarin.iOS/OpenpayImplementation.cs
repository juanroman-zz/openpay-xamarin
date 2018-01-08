using CoreGraphics;
using Foundation;
using Openpay.Xamarin.Abstractions;
using System;
using System.Threading.Tasks;
using UIKit;
using WebKit;

namespace Openpay.Xamarin
{
    public class OpenpayImplementation : OpenpayBaseImplementation
    {
        protected override Task<string> CreateDeviceSessionIdInternal(string merchantId, string apiKey, string baseUrl)
        {
            var sessionId = Guid.NewGuid().ToString().Replace("-", string.Empty);

            var identifierForVendor = UIDevice.CurrentDevice.IdentifierForVendor.AsString().Replace("-", string.Empty);
            var identifierForVendorScript = $"var identifierForVendor = '{identifierForVendor}';";

            using (WKWebView webView = new WKWebView(CGRect.Empty, new WKWebViewConfiguration()))
            {
                webView.EvaluateJavaScript(identifierForVendor, null);

                var url = $"{baseUrl}/oa/logo.htm?m={merchantId}&s={sessionId}";
                webView.LoadRequest(new NSUrlRequest(new NSUrl(url)));
            }

            return Task.FromResult(sessionId);
        }
    }
}
