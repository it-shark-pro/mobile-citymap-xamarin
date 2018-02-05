using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using FFImageLoading.Views;

namespace CityMap.Droid.Views.Cities
{
    internal class CityViewHolder : RecyclerView.ViewHolder
    {
        public CityViewHolder(View itemView, Action<int> listener) : base(itemView)
        {
            TitleTextView = itemView.FindViewById<TextView>(Resource.Id.text_view_city_title);
            PhotoImageView = itemView.FindViewById<ImageViewAsync>(Resource.Id.image_view_city_photo);

            itemView.Click += (sender, e) => listener(LayoutPosition);
        }

        public TextView TitleTextView { get; }

        public ImageViewAsync PhotoImageView { get; set; }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                PhotoImageView?.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}