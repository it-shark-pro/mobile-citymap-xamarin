using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;
using CityMap.Models;
using CityMap.Services;
using CityMap.iOS.Views.CityDetails;

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

        public override void PrepareForSegue(UIStoryboardSegue segue, Foundation.NSObject sender)
        {
            if (segue.Identifier.Equals(ShowCityDetailIdentifier)
                && segue.DestinationViewController is CityDetailsViewController detailsController
                && sender is CityTableViewCell selectedCell)
            {
                detailsController.City = selectedCell.City;
            }
        }
    }
}

