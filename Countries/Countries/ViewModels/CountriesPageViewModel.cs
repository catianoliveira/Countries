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


        /// <summary>
        /// countries search
        /// </summary>
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


        /// <summary>
        /// loads countries
        /// </summary>
        private async void LoadCountriesAsync()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Connection to the server has failed", "Ok");
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


        /// <summary>
        /// gets every countre's info
        /// </summary>
        private void ShowCountries()
        {
            if (string.IsNullOrEmpty(Search))
            {
                Countries = new ObservableCollection<CountryItemViewModel>(_myCountries.Select(n =>
            new CountryItemViewModel(_navigationService)
            {
                Name = n.Name,
                NativeName = _apiService.CheckStringCountries(n.NativeName),
                NumericCode = _apiService.CheckStringCountries(n.NumericCode),
                Population = n.Population,
                Region = _apiService.CheckStringCountries(n.Region),
                Subregion = _apiService.CheckStringCountries(n.Subregion),
                Timezones = _apiService.CheckStringCountriesList(n.Timezones),
                TopLevelDomain = _apiService.CheckStringCountriesList(n.TopLevelDomain),
                Translations = n.Translations,
                Alpha2Code = _apiService.CheckStringCountries(n.Alpha2Code),
                Alpha3Code = _apiService.CheckStringCountries(n.Alpha3Code),
                AltSpellings = _apiService.CheckStringCountriesList(n.AltSpellings),
                Area = n.Area,
                Borders = _apiService.CheckStringCountriesList(n.Borders),
                CallingCodes = _apiService.CheckStringCountriesList(n.CallingCodes),
                Capital = _apiService.CheckStringCountries(n.Capital),
                Cioc = _apiService.CheckStringCountries(n.Cioc),
                Currencies = n.Currencies,
                Demonym = _apiService.CheckStringCountries(n.Demonym),
                Flag = n.Flag,
                Gini = n.Gini,
                Languages = n.Languages,
                Latlng = n.Latlng,
                
            })
                .ToList());
            }
            else
            {
                Countries = new ObservableCollection<CountryItemViewModel>(_myCountries.Select(n =>
            new CountryItemViewModel(_navigationService)
            {
                Name = n.Name,
                NativeName = _apiService.CheckStringCountries(n.NativeName),
                NumericCode = _apiService.CheckStringCountries(n.NumericCode),
                Population = n.Population,
                Region = _apiService.CheckStringCountries(n.Region),
                Subregion = _apiService.CheckStringCountries(n.Subregion),
                Timezones = _apiService.CheckStringCountriesList(n.Timezones),
                TopLevelDomain = _apiService.CheckStringCountriesList(n.TopLevelDomain),
                Translations = n.Translations,
                Alpha2Code = _apiService.CheckStringCountries(n.Alpha2Code),
                Alpha3Code = _apiService.CheckStringCountries(n.Alpha3Code),
                AltSpellings = _apiService.CheckStringCountriesList(n.AltSpellings),
                Area = n.Area,
                Borders = _apiService.CheckStringCountriesList(n.Borders),
                CallingCodes = _apiService.CheckStringCountriesList(n.CallingCodes),
                Capital = _apiService.CheckStringCountries(n.Capital),
                Cioc = _apiService.CheckStringCountries(n.Cioc),
                Currencies = n.Currencies,
                Demonym = _apiService.CheckStringCountries(n.Demonym),
                Flag = n.Flag,
                Gini = n.Gini,
                Languages = n.Languages,
                Latlng = n.Latlng,
            })
                    .Where(p => p.Name.ToLower().Contains(Search.ToLower()))
                    .ToList());
            }
        }

    }
}
