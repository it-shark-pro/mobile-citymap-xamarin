using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

using Plugin.Connectivity;
using MonkeyCache.SQLite;

using CityMap.Models;
using CityMap.Services;
using CityMap.ViewModels;
using CityMap.Pages;

using NavigationPage = Xamarin.Forms.NavigationPage;
using Page = Xamarin.Forms.Page;

namespace CityMap
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : Application
    {
        public static void Initialize()
        {
            Barrel.ApplicationId = "CityMap";
        }

        public App()
        {
            InitializeComponent();

            var navigationMap = new Dictionary<Type, Func<object, Task>>
            {
                { typeof(CityDetailsViewModel), NavigateToDetails },
                { typeof(MapViewModel), NavigateToMap }
            };

            var dialogService = new DialogService((title, message) => MainPage.DisplayAlert(title, message, "Ok"));

            var navigationService = new NavigationService(navigationMap);
            var cityService = new CityService(CrossConnectivity.Current, Barrel.Current);

            MainPage = CreateRootPage();

            NavigationPage CreateRootPage()
            {
                var navigationPage = new NavigationPage(CreateMainPage());
                navigationPage.On<iOS>().SetPrefersLargeTitles(true);
                return navigationPage;
            }

            Page CreateMainPage()
            {
                return new CitiesPage(
                    new CitiesViewModel(navigationService, cityService, dialogService));
            }
        }

        private async Task NavigateToDetails(object parameter)
        {
            await MainPage.Navigation.PushAsync(
                new CityDetailsPage(
                    new CityDetailsViewModel(
                        (City)parameter)));
        }

        private async Task NavigateToMap(object parameter)
        {
            await MainPage.Navigation.PushAsync(
                new MapPage(
                    new MapViewModel((IEnumerable<City>)parameter)));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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