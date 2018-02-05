using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Connectivity;
using CityMap.Models;

namespace CityMap.Services
{
    public class CityService : ICityService
    {
        private const string ApiUrl = "https://api.myjson.com/bins/upt7z";
        private const string NoInternetExceptionMessage = "No internet connection!";

        public async Task<IEnumerable<City>> LoadCitiesAsync()
        {
            if (!CrossConnectivity.Current.IsConnected)
                throw new Exception(NoInternetExceptionMessage);

            using (var httpClient = new HttpClient())
            {
                var jsonResponse = await httpClient.GetStringAsync(ApiUrl);
                var response = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);

                return response.Photos;
            }
        }
    }
}
