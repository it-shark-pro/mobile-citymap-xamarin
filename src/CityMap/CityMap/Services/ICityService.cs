using System.Collections.Generic;
using System.Threading.Tasks;
using CityMap.Models;

namespace CityMap.Services
{
    public interface ICityService
    {
        Task<IEnumerable<City>> LoadCitiesAsync();
    }
}