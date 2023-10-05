using Microsoft.AspNetCore.Authentication;
using System.Text.Json;
using WebApplicationMyPage.Data;

namespace WebApplicationMyPage.Services
{

    public class WeatherApiService
    { //

        public class Weatherobject
        {
            public Coord coord { get; set; }
            public Weather[] weather { get; set; }
            public string _base { get; set; }
            public Main main { get; set; }
            public int visibility { get; set; }
            public Wind wind { get; set; }
            public Clouds clouds { get; set; }
            public int dt { get; set; }
            public Sys sys { get; set; }
            public int timezone { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public int cod { get; set; }
        }

        public class Coord
        {
            public float lon { get; set; }
            public float lat { get; set; }
        }

        public class Main
        {
            public float temp { get; set; }
            public float feels_like { get; set; }
            public float temp_min { get; set; }
            public float temp_max { get; set; }
            public int pressure { get; set; }
            public int humidity { get; set; }
        }

        public class Wind
        {
            public int speed { get; set; }
            public int deg { get; set; }
        }

        public class Clouds
        {
            public int all { get; set; }
        }

        public class Sys
        {
            public int type { get; set; }
            public int id { get; set; }
            public string country { get; set; }
            public int sunrise { get; set; }
            public int sunset { get; set; }
        }

        public class Weather
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }


        private string BaseUrl;

        private string ApiKey;
        private HttpClient httpClient { get; set; }
        public WeatherApiService()
        {

            BaseUrl = "http://api.openweathermap.org/data/2.5/";
            ApiKey = "02a13a18996bf9f923b45ff313917809";
            httpClient = new HttpClient();

        }

        public async Task<Weatherobject> SearchByCity(string city)
        {

            var geo = await new GeoApiService().SearchByCity(city);

            var lat = geo[0].lat;
            var lon = geo[0].lon;
            var response_weather = await httpClient.GetAsync($"{BaseUrl}weather?lat={lat}&lon={lon}&appid={{API key}}");
            var weather_json = await response_weather.Content.ReadAsStreamAsync();
            Weatherobject weather_ = await JsonSerializer.DeserializeAsync< Weatherobject>(weather_json);
            return weather_;
        }
        public async Task<Weatherobject> SearchByGeo(ItemGeo geo)
        {
            var lat = geo.lat;
            var lon = geo.lon;
            var request = $"{BaseUrl}weather?lat={lat}&lon={lon}&lang=ru&units=metric&appid={ApiKey}";
            Console.WriteLine(request);
            var response_weather = await httpClient.GetAsync(request);
            var weather_json = await response_weather.Content.ReadAsStreamAsync();
            Weatherobject weather = await JsonSerializer.DeserializeAsync< Weatherobject>(weather_json);
            return weather;
        }
    }
}
