using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace weather_app
{
    public static class conectionc
    {

        public static void conection_database(string cityname, int cleardata)
        {

            using (SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='c:\users\saul\documents\visual studio 2013\Projects\weather_app\weather_app\User.mdf';Integrated Security=True"))
            {
                Connection.Open();
                if (Connection.State == ConnectionState.Open) // if connection.Open was successful
                {

                   
                    if (cleardata == 1)
                    {
                        SqlCommand cmdD = new SqlCommand("DELETE FROM login;", Connection);
                        cmdD.ExecuteNonQuery();
                        Connection.Close();

                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO login VALUES ('admin','" + cityname + "');", Connection);
                        cmd.ExecuteNonQuery();
                        Connection.Close();
                    }

                }
              
            }
           

        }
        public  static string retrieve_data()
        {
            string valued= "vacio";
            using (SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='c:\users\saul\documents\visual studio 2013\Projects\weather_app\weather_app\User.mdf';Integrated Security=True"))
            {
                
                Connection.Open();



                SqlCommand cmdr = new SqlCommand("select * from login ;", Connection);
                SqlDataReader queryCommandReader = cmdr.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(queryCommandReader);
                
                foreach (DataRow row in dataTable.Rows)
                {
                    valued = row.ItemArray[1].ToString();
                   
                }

                  
                
            }

            return valued;
           
            
        }

    }
}
