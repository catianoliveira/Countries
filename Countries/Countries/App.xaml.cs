using Prism;
using Prism.Ioc;
using Countries.ViewModels;
using Countries.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using Countries.Common.Services;

namespace Countries
{
    public partial class App
    {

        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzU1NDUyQDMxMzgyZTMzMmUzMGRtSm9pTXNWZzA0MDlVTFpGUXVqOUFFd21oTnpEeXNmTDZqNXdSczUyZ1E9");
            InitializeComponent();

            await NavigationService.NavigateAsync($"NavigationPage/CountriesPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.Register<IAPIService, APIService>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<CountryDetailsPage, CountryDetailsPageViewModel>();
            containerRegistry.RegisterForNavigation<CountriesPage, CountriesPageViewModel>();
        }
    }
}
