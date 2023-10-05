using System.Numerics;
using System.Text.Json;
using WebApplicationMyPage.Data;
using WebApplicationMyPage.Services;
using static WebApplicationMyPage.Services.WeatherApiService;

namespace WebApplicationMyPage.Models
{
    public class Dachaobject
    {
        public string city { get; set; }
    }

    public class HomeViewModel
    {
        public const string fileNameMyDacha = "MyDacha.json";
        public Weatherobject weather { get; set; } 
        public DachaWeather Weather { get; set; }=new DachaWeather();
        public string city { get; set; }
        public List<ItemGeo> geo { get; set; }
        public HomeViewModel()
        {
            Initialization = InitializeAsync();
        }

        public Task Initialization { get; private set; }

        private async Task InitializeAsync()
        {
            // Asynchronously initialize this instance.
             FileStream openStream = File.OpenRead(fileNameMyDacha);
             city = JsonSerializer.Deserialize<Dachaobject>(openStream).city;
             geo=await new GeoApiService().SearchByCity(city);
             weather=await new WeatherApiService().SearchByGeo(geo[0]);
             Weather.setValues(weather);
        }


    }
}
