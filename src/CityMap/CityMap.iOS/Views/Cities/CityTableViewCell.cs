using System;
using UIKit;
using CityMap.Models;

namespace CityMap.iOS.Views.Cities
{
    public partial class CityTableViewCell : UITableViewCell
    {
        protected CityTableViewCell(IntPtr handle) : base(handle)
        {
        }

        private City _city;

        public City City
        {
            get => _city;
            set
            {
                _city = value;

                cityLabel.Text = value.Name;
                countryLabel.Text = value.Country.Name;
            }
        }
    }
}
