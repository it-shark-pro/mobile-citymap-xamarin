using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using UIKit;
using Foundation;
using CityMap.Models;
using CityMap.Services;
using CityMap.iOS.Views.CityDetails;
using CityMap.iOS.Views.Map;

namespace CityMap.iOS.Views.Cities
{
    public partial class CitiesViewController : UIViewController, IUICollectionViewDelegate, IUICollectionViewDataSource
    {
        private const string CityCellIdentifier = "CityCellIdentifier";
        private const string ShowCityDetailSegue = "ShowCityDetails";
        private const string ShowMapSegue = "ShowMap";

        private readonly ICityService _cityService = new CityService();
        private readonly IList<City> _cities = new List<City>();

        public CitiesViewController(IntPtr handler) : base(handler)
        {
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            collectionView.Delegate = this;
            collectionView.DataSource = this;
            collectionView.CollectionViewLayout = new CitiesCollectionLayout();

            await LoadDataAsync();
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            switch (segue.Identifier)
            {
                case ShowCityDetailSegue:

                    if (segue.DestinationViewController is CityDetailsViewController detailsController
                        && sender is CityViewCell selectedCell)
                    {
                        detailsController.City = selectedCell.City;
                    }
                    break;
                case ShowMapSegue:

                    if (segue.DestinationViewController is MapViewController mapController)
                    {
                        mapController.Cities = Cities;
                    }
                    break;
            }
        }

        private async Task LoadDataAsync()
        {
            activityIndicator.StartAnimating();

            try
            {
                var cities = await _cityService.LoadCitiesAsync();

                _cities.Clear();

                foreach (var city in cities)
                {
                    _cities.Add(city);
                }

                collectionView.ReloadData();
            }
            catch (Exception exception)
            {
                ShowAlert("Error", exception.Message);
            }
            finally
            {
                activityIndicator.StopAnimating();
            }
        }

        private void ShowAlert(string title, string message)
        {
            var okAlertController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
            okAlertController.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));

            PresentViewController(okAlertController, true, null);
        }

        // UICollectionViewDataSource

        public nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return _cities.Count;
        }

        public UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            if (collectionView.DequeueReusableCell(CityCellIdentifier, indexPath) is CityViewCell cityCell)
            {
                cityCell.City = _cities[indexPath.Row];

                return cityCell;
            }
            return new UICollectionViewCell();
        }
    }
}

