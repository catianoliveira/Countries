using Countries.Common.Models;
using Countries.Common.Services;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace Countries.ViewModels
{
    public class CountriesPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IAPIService _apiService;

        private bool _isRunning;

        private string _search;
        private List<CountryResponse> _myCountries;
        private DelegateCommand _searchCommand;

        private ObservableCollection<CountryItemViewModel> _countries;

        public CountriesPageViewModel(INavigationService navigationService,
            IAPIService apiService) : base(navigationService)
        {
            Title = "Countries";

            _navigationService = navigationService;
            _apiService = apiService;

            LoadCountriesAsync();
        }

        public DelegateCommand SearchCommand => _searchCommand ?? (_searchCommand = new DelegateCommand(ShowCountries));

        public string Search
        {
            get => _search;
            set
            {
                SetProperty(ref _search, value);
                ShowCountries();
            }
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public ObservableCollection<CountryItemViewModel> Countries
        {
            get => _countries;
            set => SetProperty(ref _countries, value);
        }



        private async void LoadCountriesAsync()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Connection to the server has failed", "Ok"); //Todo change this
                return;
            }

            IsRunning = true;

            string url = App.Current.Resources["UrlAPI"].ToString();
            Response response = await _apiService.GetListAsync<CountryResponse>(
                url,
                "/rest/v2",
                "/all");


            IsRunning = false;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Server could not provide a response", "Ok"); //Todo change this
                return;
            }

            _myCountries = (List<CountryResponse>)response.Result;
            ShowCountries();

        }

        private void ShowCountries()
        {
            if (string.IsNullOrEmpty(Search))
            {
                Countries = new ObservableCollection<CountryItemViewModel>(_myCountries.Select(n =>
            new CountryItemViewModel(_navigationService)
            {
                Name = n.Name,
                TopLevelDomain = n.TopLevelDomain,
                Alpha2Code = n.Alpha2Code,
                Alpha3Code = n.Alpha3Code,
                CallingCodes = n.CallingCodes,
                Capital = n.Capital,
                AltSpellings = n.AltSpellings,
                Region = n.Region,
                Subregion = n.Subregion,
                Population = n.Population,
                Latlng = n.Latlng,
                Demonym = n.Demonym,
                Area = n.Area,
                Gini = n.Gini,
                Timezones = n.Timezones,
                Borders = n.Borders,
                NativeName = n.NativeName,
                NumericCode = n.NumericCode,
                Currencies = n.Currencies,
                Languages = n.Languages,
                Translations = n.Translations,
                Flag = n.Flag,
                RegionalBlocs = n.RegionalBlocs,
                Cioc = n.Cioc
            })
                .ToList());
            }
            else
            {
                Countries = new ObservableCollection<CountryItemViewModel>(_myCountries.Select(n =>
            new CountryItemViewModel(_navigationService)
            {
                Name = n.Name,
                TopLevelDomain = n.TopLevelDomain,
                Alpha2Code = n.Alpha2Code,
                Alpha3Code = n.Alpha3Code,
                CallingCodes = n.CallingCodes,
                Capital = n.Capital,
                AltSpellings = n.AltSpellings,
                Region = n.Region,
                Subregion = n.Subregion,
                Population = n.Population,
                Latlng = n.Latlng,
                Demonym = n.Demonym,
                Area = n.Area,
                Gini = n.Gini,
                Timezones = n.Timezones,
                Borders = n.Borders,
                NativeName = n.NativeName,
                NumericCode = n.NumericCode,
                Currencies = n.Currencies,
                Languages = n.Languages,
                Translations = n.Translations,
                Flag = n.Flag,
                RegionalBlocs = n.RegionalBlocs,
                Cioc = n.Cioc
            })
                    .Where(p => p.Name.ToLower().Contains(Search.ToLower()))
                    .ToList());
            }
        }

    }
}
