using Countries.Common.Models;
using Countries.Views;
using Prism.Commands;
using Prism.Navigation;

namespace Countries.ViewModels
{
    public class CountryItemViewModel : CountryResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectCountryCommand;

        public CountryItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        
        public DelegateCommand SelectCountryCommand =>
            _selectCountryCommand ?? (_selectCountryCommand = new DelegateCommand(SelectCountryAsync));

        /// <summary>
        /// gets selected country
        /// </summary>
        private async void SelectCountryAsync()
        {
            NavigationParameters parameters = new NavigationParameters
            {
                {"country", this}
            };
            await _navigationService.NavigateAsync(nameof(CountryDetailsPage), parameters);
        }

    }
}
