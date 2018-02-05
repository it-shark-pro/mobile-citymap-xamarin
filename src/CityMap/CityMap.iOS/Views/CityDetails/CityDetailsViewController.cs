using System;
using UIKit;
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

            Title = City.Name;
            descriptionLabel.Text = City.Description;
        }
    }
}

