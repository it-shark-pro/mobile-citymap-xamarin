using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using FFImageLoading;
using FFImageLoading.Views;

namespace CityMap.Droid.Views.CityDetails
{
    [Activity]
    public class CityDetailsActivity : AppCompatActivity
    {
        private string _cityName;
        private string _cityDescription;
        private string _cityImageUrl;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_city_details);

            LoadNavigationParameters();

            SetupToolbar();
            SetupUI();
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
            _cityImageUrl = extras.GetString(ViewConstants.ExtraCityImageUrl, string.Empty);
        }

        private void SetupToolbar()
        {
            var actionbar = SupportActionBar;
            actionbar.SetDisplayHomeAsUpEnabled(true);
            actionbar.SetDisplayShowHomeEnabled(true);
            actionbar.Title = _cityName;
        }

        private void SetupUI()
        {
            var descriptionTextView = FindViewById<TextView>(Resource.Id.text_view_city_details_description);
            var photoImageView = FindViewById<ImageViewAsync>(Resource.Id.image_view_city_details_photo);

            descriptionTextView.Text = _cityDescription;

            ImageService.Instance
                        .LoadUrl(_cityImageUrl)
                        .Into(photoImageView);
        }
    }
}