using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.V4.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Newtonsoft.Json;
using CityMap.Models;

namespace CityMap.Droid.Views.Map
{
    [Activity]
    public class MapActivity : FragmentActivity, IOnMapReadyCallback
    {
        private IEnumerable<City> Cities { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_map);

            LoadNavigationParameters();

            SetupMap();
        }

        private void LoadNavigationParameters()
        {
            var citiesSerialized = Intent.GetStringExtra(ViewConstants.ExtraCities);

            // TODO: only for simple example
            Cities = JsonConvert.DeserializeObject<IEnumerable<City>>(citiesSerialized);
        }

        private void SetupMap()
        {
            var mapFragment = (SupportMapFragment)SupportFragmentManager.FindFragmentById(Resource.Id.map);
            mapFragment.GetMapAsync(this);
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            foreach (var city in Cities)
            {
                var cityCoordinates = new LatLng(city.Latitude, city.Longitude);

                googleMap.AddMarker(new MarkerOptions()
                    .SetPosition(cityCoordinates)
                    .SetTitle(city.Title));
            }
        }
    }
}