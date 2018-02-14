using System.Collections.Generic;

using CityMap.Models;
using CityMap.Mvvm;

namespace CityMap.ViewModels
{
    public class MapViewModel : BindableObject
    {
        public IEnumerable<City> Cities { get; }

        public MapViewModel(IEnumerable<City> cities)
        {
            Cities = cities;
        }
    }
}
