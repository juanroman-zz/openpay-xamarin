using Android.App;
using System;

namespace Openpay.Xamarin
{
    public static class OpenpayAndroidImpl
    {
        public static void Init(Activity activity) => OpenpayImplementation.Activity = activity ?? throw new ArgumentNullException(nameof(activity));
    }
}