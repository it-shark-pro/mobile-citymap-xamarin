using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using FFImageLoading;
using CityMap.Models;

namespace CityMap.Droid.Views.Cities
{
    internal class CityAdapter : RecyclerView.Adapter
    {
        private readonly IList<City> _cities = new List<City>();

        public event EventHandler<int> ItemClicked;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is CityViewHolder cityViewHolder)
            {
                var cityModel = _cities[position];

                cityViewHolder.TitleTextView.Text = cityModel.Title;

                ImageService.Instance
                            .LoadUrl(cityModel.Url)
                            .Into(cityViewHolder.PhotoImageView);
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.adapter_city_item, parent, false);
            return new CityViewHolder(itemView, OnItemClicked);
        }

        public override int ItemCount => _cities.Count;

        public void Update(IEnumerable<City> cities)
        {
            _cities.Clear();

            foreach (var city in cities)
            {
                _cities.Add(city);
            }

            NotifyDataSetChanged();
        }

        protected virtual void OnItemClicked(int position)
        {
            ItemClicked?.Invoke(this, position);
        }
    }
}