using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using CityMap.Droid.Views.Cities;

namespace CityMap.Droid
{
    [Activity(MainLauncher = true, Theme = "@style/SplashTheme")]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            new CityMap.App().Initialize();

            StartActivity(new Intent(this, typeof(CitiesActivity)));
            Finish();
        }
    }
}