// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace CityMap.iOS.Views.Cities
{
	[Register ("CityViewCell")]
	partial class CityViewCell
	{
		[Outlet]
		UIKit.UIImageView cityImage { get; set; }

		[Outlet]
		UIKit.UILabel cityLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (cityImage != null) {
				cityImage.Dispose ();
				cityImage = null;
			}

			if (cityLabel != null) {
				cityLabel.Dispose ();
				cityLabel = null;
			}
		}
	}
}
