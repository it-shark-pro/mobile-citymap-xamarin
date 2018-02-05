using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;
using CityMap.Models;
using CityMap.Services;

namespace CityMap.iOS.Views.Cities
{
    public partial class CitiesViewController : UITableViewController
    {
        private const string ShowCityDetailIdentifier = "ShowCityDetails";

        private IEnumerable<City> Cities { get; } = new CityService().Capitals;

        public CitiesViewController(IntPtr handler) : base(handler)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TableView.TableFooterView = new UIView();
            TableView.Source = new CitiesTableViewSource(Cities.ToArray());
        }
    }
}

