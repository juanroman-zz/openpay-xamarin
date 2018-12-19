using Openpay.Xamarin.Abstractions;
using System;
using System.Threading;

namespace Openpay.Xamarin
{
    /// <summary>
    /// Librería multiplataforma para Openpay con Xamarin
    /// </summary>
    public static class CrossOpenpay
    {
        private static Lazy<IOpenpay> _implementation = new Lazy<IOpenpay>(CreateOpenpay, LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:Openpay.Xamarin.CrossOpenpay"/> is supported.
        /// </summary>
        /// <value><c>true</c> if is supported; otherwise, <c>false</c>.</value>
        public static bool IsSupported => null != _implementation.Value;

        /// <summary>
        /// La sesión única de la librería
        /// </summary>
        /// <value>The current.</value>
        public static IOpenpay Current => _implementation.Value ?? throw NotImplementedInReferenceAssembly();

        private static IOpenpay CreateOpenpay()
        {
#if NETSTANDARD1_0 || NETSTANDARD2_0
            return null;
#else
            return new OpenpayImplementation();
#endif
        }

        private static Exception NotImplementedInReferenceAssembly() =>
            new NotImplementedException("This functionality is not implemented in the portable version of this assembly. You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
    }
}