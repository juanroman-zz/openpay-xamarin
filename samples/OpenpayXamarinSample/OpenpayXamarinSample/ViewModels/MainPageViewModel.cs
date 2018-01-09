using Acr.UserDialogs;
using Openpay.Xamarin;
using Openpay.Xamarin.Abstractions;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OpenpayXamarinSample.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private Token _token;
        private string _deviceSessionId;
        private bool _tokenIdAvailable;

        public MainPageViewModel()
        {
            Title = "Sample";

            LoadDeviceSessionCommand = new Command(async () => await ExecuteLoadDeviceSessionCommand());
            TokenizeCardCommand = new Command(async () => await ExecuteTokenizeCardCommand());
            TokenFromIdCommand = new Command(async () => await ExexuteTokenFromIdCommand());
        }


        public Command LoadDeviceSessionCommand { get; }
        public Command TokenizeCardCommand { get; }
        public Command TokenFromIdCommand { get; }

        public bool TokenIdAvailable
        {
            get => _tokenIdAvailable;
            set => SetProperty(ref _tokenIdAvailable, value);
        }

        private async Task ExecuteLoadDeviceSessionCommand()
        {
            if (CrossOpenpay.IsSupported)
            {
                if (IsBusy)
                {
                    return;
                }

                try
                {
                    IsBusy = true;

                    _deviceSessionId = await CrossOpenpay.Current.CreateDeviceSessionId();
                    UserDialogs.Instance.Toast("Device Session Id success");
                }
                catch (Exception exception)
                {
                    await UserDialogs.Instance.AlertAsync($"Error: {exception.Message}", "Error", "Ok");
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }

        private async Task ExecuteTokenizeCardCommand()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;

if (CrossOpenpay.IsSupported)
{
    Card card = new Card
    {
        HolderName = "Francisco Pantera",
        Number = "4111111111111111",
        ExpirationMonth = "12",
        ExpirationYear = "21",
        Cvv2 = 132
    };

    _token = await CrossOpenpay.Current.CreateTokenFromCard(card);
    TokenIdAvailable = true;

    await UserDialogs.Instance.AlertAsync($"Token created successfully: {_token.Id} for card '{_token.Card.Number}'.", "Success", "Ok");
}
            }
            catch (Exception exception)
            {
                await UserDialogs.Instance.AlertAsync($"Error: {exception.Message}", "Error", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task ExexuteTokenFromIdCommand()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;

                if (CrossOpenpay.IsSupported)
                {
                    _token = await CrossOpenpay.Current.GetTokenFromId(_token.Id);
                    TokenIdAvailable = true;

                    await UserDialogs.Instance.AlertAsync($"Token created successfully: {_token.Id} for card '{_token.Card.Number}'.", "Success", "Ok");
                }
            }
            catch (Exception exception)
            {
                await UserDialogs.Instance.AlertAsync($"Error: {exception.Message}", "Error", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
