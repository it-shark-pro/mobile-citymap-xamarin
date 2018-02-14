using CityMap.Mvvm;
using CityMap.Models;

namespace CityMap.ViewModels
{
    public class CityDetailsViewModel : BindableObject
    {
        private City _city;

        public City City
        {
            get => _city;
            set => SetPropertyValue(ref _city, value);
        }

        public CityDetailsViewModel(City city)
        {
            City = city;
        }
    }
}
