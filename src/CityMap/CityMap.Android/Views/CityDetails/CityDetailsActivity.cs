using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;

namespace CityMap.Droid.Views.CityDetails
{
    [Activity]
    public class CityDetailsActivity : AppCompatActivity
    {
        private string _cityName;
        private string _cityDescription;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_city_details);

            LoadNavigationParameters();

            InitializeToolbar();
            InitializeViews();
        }

        public override bool OnSupportNavigateUp()
        {
            OnBackPressed();
            return true;
        }

        private void LoadNavigationParameters()
        {
            var extras = Intent.Extras;

            _cityName = extras.GetString(ViewConstants.ExtraCityName, string.Empty);
            _cityDescription = extras.GetString(ViewConstants.ExtraCityDescription, string.Empty);
        }

        private void InitializeToolbar()
        {
            var actionbar = SupportActionBar;
            actionbar.SetDisplayHomeAsUpEnabled(true);
            actionbar.SetDisplayShowHomeEnabled(true);
            actionbar.Title = _cityName;
        }

        private void InitializeViews()
        {
            var descriptionTextView = FindViewById<TextView>(Resource.Id.text_view_city_details_description);

            descriptionTextView.Text = _cityDescription;
        }
    }
}