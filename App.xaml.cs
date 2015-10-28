using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace weather_app
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //add some bootstrap or startup logic 

            string city = conectionc.retrieve_data() ;
            if (city == "vacio")
            {
                //LoginWindow login = new LoginWindow();
                //login.Show();
                MainWindow mainView = new MainWindow();
                mainView.ShowDialog();
              
            }
            else
            {
                Backgroundc.backg = city;
                Window1 winweather = new Window1();
                winweather.ShowDialog();
            }
        }
    }
}
