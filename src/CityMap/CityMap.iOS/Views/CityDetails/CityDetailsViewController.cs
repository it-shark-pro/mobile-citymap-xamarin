using System;
using UIKit;
using FFImageLoading;
using CityMap.Models;

namespace CityMap.iOS.Views.CityDetails
{
    public partial class CityDetailsViewController : UIViewController
    {
        public City City { get; set; }

        public CityDetailsViewController(IntPtr handler) : base(handler)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            SetupData();
        }

        private void SetupData()
        {
            Title = City.Title;
            descriptionLabel.Text = City.Description;

            ImageService.Instance
                        .LoadUrl(City.Url)
                        .Into(cityImage);
        }
    }
}

