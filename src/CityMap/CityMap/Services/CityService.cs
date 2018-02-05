using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CityMap.Models;

namespace CityMap.Services
{
    public class CityService : ICityService
    {
        private const string ApiUrl = "https://api.myjson.com/bins/upt7z";

        public async Task<IEnumerable<City>> LoadCitiesAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var jsonResponse = await httpClient.GetStringAsync(ApiUrl);
                var response = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);

                return response.Photos;
            }
        }
    }
}
