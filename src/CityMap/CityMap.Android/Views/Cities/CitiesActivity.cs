using System.Linq;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Android.Runtime;
using CityMap.Models;
using CityMap.Services;

namespace CityMap.Droid.Views.Cities
{
    [Activity(Label = "@string/activity_sities_title")]
    public class CitiesActivity : AppCompatActivity
    {
        private const string CityNameAttribute = "CityName";
        private const string CountryNameAttribute = "CountryName";

        private ListView _citiesListView;

        private IEnumerable<City> Cities { get; } = new CityService().Capitals;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_cities);

            InitializeListView();
        }

        private void InitializeListView()
        {
            var data = new JavaList<IDictionary<string, object>>();
            foreach (var city in Cities)
            {
                data.Add(new JavaDictionary<string, object>
                {
                    {CityNameAttribute, city.Name},
                    {CountryNameAttribute, city.Country.Name}
                });
            }

            var from = new[] { CityNameAttribute, CountryNameAttribute };
            var to = new[] { Android.Resource.Id.Text1, Android.Resource.Id.Text2 };

            _citiesListView = FindViewById<ListView>(Resource.Id.list_view_main_cities_list);
            _citiesListView.Adapter = new SimpleAdapter(this, data, Android.Resource.Layout.SimpleListItem2, from, to);
            _citiesListView.ItemClick += CitiesListViewOnItemClick;
        }

        private void CitiesListViewOnItemClick(object sender, AdapterView.ItemClickEventArgs args)
        {
            var cityModel = Cities.ToArray()[args.Position];

            // TODO: navigate to details
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _citiesListView.ItemClick -= CitiesListViewOnItemClick;
            }

            base.Dispose(disposing);
        }
    }
}