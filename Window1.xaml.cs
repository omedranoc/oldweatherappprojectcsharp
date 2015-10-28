using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace weather_app
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public  partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
           
            inter();
         

           
        }
        
        public void inter()
        {
            // retrieve city from main window
            
            string city = Backgroundc.backg;
            var weatherData = WeatherApiClient.GetWeatherForecast(city);
            //change label city country
            string wecountry = weatherData.city.country.ToString();
            string wecity = weatherData.city.name.ToString();
            country.Content = wecity + " , " + wecountry;
            //-temperature label
            
            string wetemp = weatherData.list[0].temp.day.ToString();
            ltemperature.Content = wetemp + " C";
            // wind speed
            string windv = weatherData.list[0].speed.ToString();
            lwind.Content = "Wind Speed: "+ windv +"mps";
            //---      description
            string descriptionv = weatherData.list[0].weather[0].description.ToString();
            string icon = weatherData.list[0].weather[0].icon.ToString();
            description.Content = descriptionv;
            //--image
           
            string urlmain = "http://openweathermap.org/img/w/{0}.png";
            var url = string.Format(urlmain, icon);
            var uri = new Uri(url);
            var bitmap = new BitmapImage(uri);
            iconi.Source = bitmap;
            //--day
            DateTime thisDay = DateTime.Today;
            string day= thisDay.DayOfWeek.ToString();
            lday.Content = day ;
            //-day1
                      
            DateTime day1 = thisDay.AddDays(1);
            string daylabel1 = day1.DayOfWeek.ToString();
            string wetemp1 = weatherData.list[1].temp.day.ToString();
            day1l.Content = daylabel1 + " : " + wetemp1+ " C";

            //-day2
            DateTime day2 = thisDay.AddDays(2);
            string daylabel2 = day2.DayOfWeek.ToString();
            string wetemp2 = weatherData.list[2].temp.day.ToString();
            day2l.Content = daylabel2 + " : " + wetemp2 + " C";
            //-day3
            DateTime day3 = thisDay.AddDays(3);
            string daylabel3 = day3.DayOfWeek.ToString();
            string wetemp3 = weatherData.list[3].temp.day.ToString();
            day3l.Content = daylabel3 + " : " + wetemp3 + " C";
            //-day4
            DateTime day4 = thisDay.AddDays(4);
            string daylabel4 = day4.DayOfWeek.ToString();
            string wetemp4 = weatherData.list[4].temp.day.ToString();
            day4l.Content = daylabel4 + " : " + wetemp4 + " C";
           
            //conection database
            
            string cityindatabase= conectionc.retrieve_data();

            

        }
       
        
       

        private void b_clear_Click(object sender, RoutedEventArgs e)
        {
            conectionc.conection_database("baltimore", 1);
            MessageBox.Show("your city has been deleted, please close the app and insert a new city");
            Application.Current.Shutdown();
           
        }
    }
}
