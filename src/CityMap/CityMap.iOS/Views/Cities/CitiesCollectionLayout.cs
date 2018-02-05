using CoreGraphics;
using UIKit;

namespace CityMap.iOS.Views.Cities
{
    public class CitiesCollectionLayout : UICollectionViewFlowLayout
    {
        private const float CellsInRow = 3;
        private const float CellAspectRatio = 4 / 3f;

        public override void PrepareLayout()
        {
            base.PrepareLayout();

            var cellWidth = CollectionView.Bounds.Size.Width / CellsInRow - MinimumLineSpacing;
            var cellHeight = cellWidth * CellAspectRatio;

            ItemSize = new CGSize(width: cellWidth, height: cellHeight);
        }
    }
}
