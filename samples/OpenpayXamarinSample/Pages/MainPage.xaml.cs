using OpenpayXamarinSample.ViewModels;
using Xamarin.Forms;

namespace OpenpayXamarinSample.Pages
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new MainPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewModel.LoadDeviceSessionCommand.Execute(null);
        }
    }
}
