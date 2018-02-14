using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

using CityMap.ViewModels;

namespace CityMap.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
		public MapPage(MapViewModel viewModel)
		{
			InitializeComponent ();

            On<iOS>().SetLargeTitleDisplay(LargeTitleDisplayMode.Never);

            BindingContext = viewModel;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            AddPins();
        }

        private void AddPins()
        {
            var viewModel = (MapViewModel)BindingContext;

            foreach (var city in viewModel.Cities)
            {
                GlobalMap.Pins.Add(new Pin
                {
                    Type = PinType.Place,
                    Position = new Position(city.Latitude, city.Longitude),
                    Label = city.Title
                });
            }
        }
    }
}