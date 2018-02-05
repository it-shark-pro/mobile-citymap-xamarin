using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Content;
using Android.Support.V7.Widget;
using Newtonsoft.Json;
using CityMap.Models;
using CityMap.Services;
using CityMap.Droid.Views.CityDetails;
using CityMap.Droid.Views.Map;

namespace CityMap.Droid.Views.Cities
{
    [Activity(Label = "@string/activity_sities_title")]
    public class CitiesActivity : AppCompatActivity
    {
        private readonly ICityService _cityService = new CityService();

        private CityAdapter _cityAdapter;
        private ProgressDialog _progressDialog;

        private IEnumerable<City> Cities { get; set; } = Enumerable.Empty<City>();

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_cities);

            _progressDialog = CreateProgressDialog();

            SetupAdapter();

            SetupRecyclerView();

            await LoadDataAsync();
        }

        private void SetupRecyclerView()
        {
            var citiesLayoutManager = new GridLayoutManager(ApplicationContext, ViewConstants.GridLayoutSpanCount);

            var citiesRecyclerView = FindViewById<RecyclerView>(Resource.Id.recycler_view_main_cities_list);

            citiesRecyclerView.SetLayoutManager(citiesLayoutManager);
            citiesRecyclerView.SetAdapter(_cityAdapter);
        }

        private void SetupAdapter()
        {
            _cityAdapter = new CityAdapter();
            _cityAdapter.ItemClicked += CityAdapterOnItemClicked;
        }

        private async Task LoadDataAsync()
        {
            _progressDialog.Show();

            try
            {
                Cities = await _cityService.LoadCitiesAsync();

                _cityAdapter.Update(Cities);
            }
            catch (Exception exception)
            {
                ShowAlert("Error", exception.Message);
            }
            finally
            {
                _progressDialog.Hide();
            }
        }

        private void CityAdapterOnItemClicked(object sender, int position)
        {
            var cityModel = Cities.ToArray()[position];

            var detailedActivityIntent = new Intent(this, typeof(CityDetailsActivity));
            detailedActivityIntent.PutExtra(ViewConstants.ExtraCityName, cityModel.Title);
            detailedActivityIntent.PutExtra(ViewConstants.ExtraCityDescription, cityModel.Description);
            detailedActivityIntent.PutExtra(ViewConstants.ExtraCityImageUrl, cityModel.Url);

            StartActivity(detailedActivityIntent);
        }

        private void ShowAlert(string title, string message)
        {
            new Android.Support.V7.App.AlertDialog.Builder(this)
                .SetTitle(title)
                .SetMessage(message)
                .SetNegativeButton("Ok", delegate {})
                .SetCancelable(true)
                .Show();
        }

        private ProgressDialog CreateProgressDialog() => new ProgressDialog(this) { Indeterminate = true };

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.cities_menu, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.show_on_map:
                    // TODO: only for simple example
                    var mapActivityIntent = new Intent(this, typeof(MapActivity));
                    mapActivityIntent.PutExtra(ViewConstants.ExtraCities, JsonConvert.SerializeObject(Cities));
                    StartActivity(mapActivityIntent);
                    break;
            }
            return true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _cityAdapter.ItemClicked -= CityAdapterOnItemClicked;
            }

            base.Dispose(disposing);
        }
    }
}