using Android.App;
using System;

namespace Openpay.Xamarin
{
    /// <summary>
    /// Helper class for Android initialization.
    /// </summary>
    public static class OpenpayAndroidImpl
    {
        /// <summary>
        /// Android specific initializer used to keep a reference of the Main Activity.
        /// </summary>
        /// <param name="activity">The main application's <see cref="Activity"/> instance.</param>
        public static void Init(Activity activity) => OpenpayImplementation.Activity = activity ?? throw new ArgumentNullException(nameof(activity));
    }
}
