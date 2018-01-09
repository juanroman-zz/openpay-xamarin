using System;
using Openpay.Xamarin;
using Xamarin.Forms;

namespace OpenpayXamarinSample
{
    public partial class App : Application
    {
        private const string MerchantId = "mi93pk0cjumoraf08tqt";
        private const string ApiKey = "pk_92e31f7c77424179b7cd451d21fbb771";

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Pages.MainPage());
        }

        protected override void OnStart()
        {
            base.OnStart();

            // Initialize Openpay
            if (CrossOpenpay.IsSupported)
            {
                CrossOpenpay.Current.Initialize(MerchantId, ApiKey, false);
            }
        }
    }
}
