using System;
using Openpay.Xamarin;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

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
            try
            {
                // Initialize Openpay
                if (CrossOpenpay.IsSupported)
                {
                    CrossOpenpay.Current.Initialize(MerchantId, ApiKey, false);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
