using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;

namespace weather_app
{
    public static class WeatherApiClient
    {

        
        private const string baseUrl = "http://api.openweathermap.org/data/2.5/forecast/daily?q={0}&mode=json&units=metric&cnt=7";//create the url and the parameters we will pass
        
        public static WeatherData GetWeatherForecast(string city)
        {
            var url = string.Format(baseUrl, city);
            //SYNCRONIOUS Consumption
            var syncClient = new WebClient();
            var content = syncClient.DownloadString(url);
            
            // json serializer
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(WeatherData));
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(content))) // load content in ms
            {
                WeatherData weatherData = (WeatherData)serializer.ReadObject(ms);// serialize the class weatherdata 
                //List<string> weatherapi = weatherData.list[0];
                return weatherData;

            }

        }

 

       
    }
}
