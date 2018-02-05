using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using CityMap.Models;

namespace CityMap.iOS.Views.Cities
{
    public class CitiesTableViewSource : UITableViewSource
    {
        private readonly IReadOnlyList<City> _cities;

        public CitiesTableViewSource(IReadOnlyList<City> cities)
        {
            _cities = cities;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            if (tableView.DequeueReusableCell(ViewConstants.CityCellIdentifier, indexPath) is CityTableViewCell cityCell)
            {
                cityCell.City = _cities[indexPath.Row];

                return cityCell;
            }

            return new UITableViewCell();
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _cities.Count;
        }
    }
}
