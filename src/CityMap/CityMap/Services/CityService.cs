using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Connectivity;
using MonkeyCache.SQLite;
using CityMap.Models;

namespace CityMap.Services
{
    public class CityService : ICityService
    {
        private const string ApiUrl = "https://api.myjson.com/bins/7ybe5";

        public async Task<IEnumerable<City>> LoadCitiesAsync()
        {
            // handle online/offline scenario
            if (!CrossConnectivity.Current.IsConnected)
            {
                return Barrel.Current.Get<IEnumerable<City>>(key: ApiUrl);
            }

            // handles checking if cache is expired
            if (!Barrel.Current.IsExpired(key: ApiUrl))
            {
                return Barrel.Current.Get<IEnumerable<City>>(key: ApiUrl);
            }

            using (var httpClient = new HttpClient())
            {
                var jsonResponse = await httpClient.GetStringAsync(ApiUrl);
                var response = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
                var cities = response.Photos;

                Barrel.Current.Add(key: ApiUrl, data: cities, expireIn: TimeSpan.FromDays(1));

                return cities;
            }
        }
    }
}
