// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace CityMap.iOS.Views.Cities
{
    [Register ("CitiesViewController")]
    partial class CitiesViewController
    {
        [Outlet]
        UIKit.UIActivityIndicatorView activityIndicator { get; set; }

        [Outlet]
        UIKit.UICollectionView collectionView { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (collectionView != null)
            {
                collectionView.Dispose();
                collectionView = null;
            }

            if (activityIndicator != null)
            {
                activityIndicator.Dispose();
                activityIndicator = null;
            }
        }
    }
}