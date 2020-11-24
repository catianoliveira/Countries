using Countries.Common.Models;
using Prism.Navigation;

namespace Countries.ViewModels
{
    public class CountryDetailsPageViewModel : ViewModelBase
    {
        private CountryResponse _nation;

        public CountryDetailsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Country Details";
        }

        public CountryResponse Country
        {
            get => _nation;
            set => SetProperty(ref _nation, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("country"))
            {
                Country = parameters.GetValue<CountryResponse>("country");
                Title = Country.Name;
            }
        }

    }
}
