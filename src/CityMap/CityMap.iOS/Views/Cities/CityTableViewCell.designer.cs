// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace CityMap.iOS.Views.Cities
{
    [Register ("CityTableViewCell")]
    partial class CityTableViewCell
    {
        [Outlet]
        UIKit.UILabel cityLabel { get; set; }


        [Outlet]
        UIKit.UILabel countryLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (cityLabel != null) {
                cityLabel.Dispose ();
                cityLabel = null;
            }

            if (countryLabel != null) {
                countryLabel.Dispose ();
                countryLabel = null;
            }
        }
    }
}