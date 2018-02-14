using Android.App;
using Android.Content.PM;
using Android.OS;

using FFImageLoading.Forms.Droid;

namespace CityMap.Droid
{
    [Activity(Theme = "@style/AppTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            Xamarin.FormsMaps.Init(this, bundle);

            CachedImageRenderer.Init(enableFastRenderer: true);

            LoadApplication(new App());
        }
    }
}