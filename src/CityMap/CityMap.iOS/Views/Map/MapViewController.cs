using System;
using System.Collections.Generic;
using System.Linq;
using CoreLocation;
using Foundation;
using MapKit;
using UIKit;
using CityMap.Models;

namespace CityMap.iOS.Views.Map
{
    public partial class MapViewController : UIViewController, IMKMapViewDelegate
    {
        public IEnumerable<City> Cities { get; set; } = Enumerable.Empty<City>();

        public MapViewController(IntPtr handler) : base(handler)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            SetupUI();
        }

        private void SetupUI()
        {
            mapView.Delegate = this;

            var defaultCoordinateSpan = new MKCoordinateSpan(latitudeDelta: 40,
                                                             longitudeDelta: 40);
            
            var defaultRegion = new MKCoordinateRegion(center: mapView.CenterCoordinate,
                                                       span: defaultCoordinateSpan);
            
            mapView.SetRegion(defaultRegion, animated: false);

            NavigationItem.LargeTitleDisplayMode = UINavigationItemLargeTitleDisplayMode.Never;
        }

        // IMKMapViewDelegate

        [Export("mapViewDidFinishRenderingMap:fullyRendered:")]
        public void DidFinishRenderingMap(MKMapView mapView, bool fullyRendered)
        {
            mapView.RemoveAnnotations(mapView.Annotations);

            foreach (var city in Cities)
            {
                var location = new CLLocationCoordinate2D(latitude: city.Latitude,
                                                          longitude: city.Longitude);

                var pointAnnotation = new MKPointAnnotation
                {
                    Coordinate = location,
                    Title = city.Title
                };

                mapView.AddAnnotation(pointAnnotation);
            }
        }
    }
}

