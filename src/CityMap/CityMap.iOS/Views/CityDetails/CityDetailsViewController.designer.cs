// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace CityMap.iOS.Views.CityDetails
{
    [Register ("CityDetailsViewController")]
    partial class CityDetailsViewController
    {
        [Outlet]
        UIKit.UILabel descriptionLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (descriptionLabel != null) {
                descriptionLabel.Dispose ();
                descriptionLabel = null;
            }
        }
    }
}