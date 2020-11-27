using Countries.Common.Models;
using Prism.Navigation;

namespace Countries.ViewModels
{
    public class CountryDetailsPageViewModel : ViewModelBase
    {
        private CountryResponse _country;

        public CountryDetailsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Country Details";
        }

        public CountryResponse Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }


        /// <summary>
        /// gets countrys details
        /// </summary>
        /// <param name="parameters"></param>
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
