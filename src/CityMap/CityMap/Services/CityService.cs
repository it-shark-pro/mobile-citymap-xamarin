using System.Collections.Generic;
using CityMap.Models;

namespace CityMap.Services
{
    public class CityService
    {
        public IEnumerable<City> Capitals { get; } = new[]
        {
            new City { Name = "Minsk", Country = new Country { Name = "Belarus" }},
            new City { Name = "Warsaw", Country = new Country { Name = "Poland" }},
            new City { Name = "Berlin", Country = new Country { Name = "Germany" }},
            new City { Name = "Amsterdam", Country = new Country { Name = "Netherland" }},
            new City { Name = "Oslo", Country = new Country { Name = "Norway" }},
            new City { Name = "Lisbon", Country = new Country { Name = "Portugal" }},
            new City { Name = "Madrid", Country = new Country { Name = "Spain" }},
            new City { Name = "Moskow", Country = new Country { Name = "Russia" }},
            new City { Name = "Kiev", Country = new Country { Name = "Ukraine" }},
            new City { Name = "Stockholm", Country = new Country { Name = "Sweden" }},
        };
    }
}
