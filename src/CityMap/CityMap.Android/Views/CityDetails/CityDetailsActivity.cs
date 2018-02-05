using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace CityMap.Droid.Views.CityDetails
{
    [Activity]
    public class CityDetailsActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_city_details);

            InitializeToolbar();
        }

        public override bool OnSupportNavigateUp()
        {
            OnBackPressed();
            return true;
        }

        private void InitializeToolbar()
        {
            var actionbar = SupportActionBar;
            actionbar.SetDisplayHomeAsUpEnabled(true);
            actionbar.SetDisplayShowHomeEnabled(true);
        }
    }
}