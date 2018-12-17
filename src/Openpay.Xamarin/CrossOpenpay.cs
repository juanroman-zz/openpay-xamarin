using Openpay.Xamarin.Abstractions;
using System;
using System.Threading;

namespace Openpay.Xamarin
{
    public static class CrossOpenpay
    {
        private static Lazy<IOpenpay> _implementation = new Lazy<IOpenpay>(CreateOpenpay, LazyThreadSafetyMode.PublicationOnly);

        public static bool IsSupported => null != _implementation.Value;
        public static IOpenpay Current => _implementation.Value ?? throw NotImplementedInReferenceAssembly();

        private static IOpenpay CreateOpenpay()
        {
#if NETSTANDARD2_0
            return null;
#else
            return new OpenpayImplementation();
#endif
        }

        private static Exception NotImplementedInReferenceAssembly() =>
            new NotImplementedException("This functionality is not implemented in the portable version of this assembly. You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
    }
}
