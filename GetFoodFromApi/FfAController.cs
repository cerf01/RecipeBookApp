using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GetFoodFromApi
{


    public class FfAController
    {
        private string _apiUrl => "https://api.api-ninjas.com/v1/nutrition?query=";
        private string _myApiKey => "45RGf3RviA5wjRuRRXjCNg==ByFTDMF1XYVufn44";

        public  List<FoodFromApi>? FoodFromApi {  get;}
        public FfAController(string query) 
        {

            var httpClient = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, _apiUrl+query);

            request.Headers.Add("X-Api-Key", _myApiKey);

            var response = httpClient.SendAsync(request).Result;

            var resJson = response.Content.ReadAsStringAsync().Result;

            FoodFromApi = JsonConvert.DeserializeObject<List<FoodFromApi>>(resJson);
        }
    }
}
