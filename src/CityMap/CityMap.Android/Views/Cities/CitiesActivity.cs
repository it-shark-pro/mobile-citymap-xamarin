using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace CityMap.Droid.Views.Cities
{
    [Activity(Label = "@string/activity_sities_title")]
    public class CitiesActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_cities);
        }
    }
}