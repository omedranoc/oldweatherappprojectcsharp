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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace weather_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        

        public int MyProperty { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            string cityname = (ComboCity.SelectedItem as ComboBoxItem).Content.ToString();
            conectionc.conection_database(cityname, 1);

            Backgroundc.backg = cityname;
            conectionc.conection_database(cityname, 0);
           
      

            // jump into new window
           Window1 winweather = new Window1();
           winweather.ShowDialog();
           //MainWindow winm = new MainWindow();
           //winm.Close();
          //*-----------------
            
        }

      
    }
}
