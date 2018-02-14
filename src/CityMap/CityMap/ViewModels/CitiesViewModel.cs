using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

using CityMap.Models;
using CityMap.Services;
using CityMap.Mvvm;

namespace CityMap.ViewModels
{
    public class CitiesViewModel : BindableObject
    {
        private readonly INavigationService _navigationService;
        private readonly ICityService _cityService;
        private readonly IDialogService _dialogService;

        private bool _isBusy;
        private IEnumerable<City> _cities = Enumerable.Empty<City>();

        public bool IsBusy
        {
            get => _isBusy;
            private set => SetPropertyValue(ref _isBusy, value);
        }
        
        public IEnumerable<City> Cities
        {
            get => _cities;
            private set => SetPropertyValue(ref _cities, value);
        }

        public ICommand LoadDataCommand { get; }

        public ICommand GoToDetailsCommand { get; }

        public ICommand GoToMapCommand { get; }

        public CitiesViewModel(
            INavigationService navigationService,
            ICityService cityService,
            IDialogService dialogService)
        {
            _navigationService = navigationService;
            _cityService = cityService;
            _dialogService = dialogService;

            LoadDataCommand = new DelegateCommand(
                async () => await LoadDataAsync(),
                () => !IsBusy || !Cities.Any());

            GoToDetailsCommand = new DelegateCommand<City>(
                city => navigationService.NavigateTo<CityDetailsViewModel>(city));

            GoToMapCommand = new DelegateCommand(
                x => navigationService.NavigateTo<MapViewModel>(Cities));
        }

        private async Task LoadDataAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Cities = new List<City>(await _cityService.LoadCitiesAsync());
            }
            catch (Exception exception)
            {
                _dialogService.ShowAlert("Error", exception.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
