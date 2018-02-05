using System;
using UIKit;
using FFImageLoading;
using CityMap.Models;

namespace CityMap.iOS.Views.Cities
{
    public partial class CityViewCell : UICollectionViewCell
    {
        protected CityViewCell(IntPtr handle) : base(handle)
        {
        }

        private City _city;

        public City City
        {
            get => _city;
            set
            {
                _city = value; 

                cityLabel.Text = value.Title;

                ImageService.Instance
                            .LoadUrl(value.Url)
                            .Into(cityImage);
            }
        }
    }
}
