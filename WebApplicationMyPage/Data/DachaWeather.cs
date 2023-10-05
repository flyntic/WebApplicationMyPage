using static WebApplicationMyPage.Services.WeatherApiService;

namespace WebApplicationMyPage.Data
{
   
    public class DachaWeather
    {
        public int temp { get; set; }
        public int feels_like { get; set; }
        public int temp_min { get; set; }
        public int temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
      
        public void setValues(Weatherobject weatherobject)
        {
            temp =(int)weatherobject.main.temp;
            feels_like = (int)weatherobject.main.feels_like;
            temp_min = (int)weatherobject.main.temp_min;
            temp_max = (int)weatherobject.main.temp_max;
            pressure = weatherobject.main.pressure;
            humidity = weatherobject.main.humidity;

            description = weatherobject.weather[0].description;
            icon = weatherobject.weather[0].icon;

    }
}
}
