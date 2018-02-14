using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;
using MonkeyCache;
using Plugin.Connectivity.Abstractions;

using CityMap.Models;

namespace CityMap.Services
{
    public interface ICityService
    {
        Task<IEnumerable<City>> LoadCitiesAsync();
    }

    public class CityService : ICityService
    {
        private const string ApiUrl = "https://api.myjson.com/bins/7ybe5";

        private readonly IConnectivity _connectivityService;
        private readonly IBarrel _cacheService;

        public CityService(IConnectivity connectivityService, IBarrel cacheService)
        {
            _connectivityService = connectivityService;
            _cacheService = cacheService;
        }

        public async Task<IEnumerable<City>> LoadCitiesAsync()
        {
            // handle online/offline scenario
            if (!_connectivityService.IsConnected)
            {
                return _cacheService.Get<IEnumerable<City>>(key: ApiUrl);
            }

            // handles checking if cache is expired
            if (!_cacheService.IsExpired(key: ApiUrl))
            {
                return _cacheService.Get<IEnumerable<City>>(key: ApiUrl);
            }

            using (var httpClient = new HttpClient())
            {
                var jsonResponse = await httpClient.GetStringAsync(ApiUrl);
                var response = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
                var cities = response.Photos;

                _cacheService.Add(key: ApiUrl, data: cities, expireIn: TimeSpan.FromDays(1));

                return cities;
            }
        }
    }
}
