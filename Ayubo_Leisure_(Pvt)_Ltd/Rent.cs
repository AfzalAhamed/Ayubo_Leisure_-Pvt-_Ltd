using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Ayubo_Leisure__Pvt__Ltd
{
    class Rent
    {
        public int RentCalculation(int vehicleNo, DateTime rentDate, DateTime returnDate, Boolean driver) 
        {
            int totalRent=0;
            int vfeed = 0;
            int vfeew = 0;
            int vfeem = 0;
            int dfeed = 0;

            string connectionString = @"Data Source = DESKTOP-UU7JK7R; Initial Catalog = Ayubo_db; Integrated Security= true;";
            string query = "SELECT * FROM ayubo_db.vehicle WHERE vehicleNo = " + vehicleNo + "";

            SqlConnection databaseConnection = new SqlConnection(connectionString);
            SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            SqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        vfeed = reader.GetInt32(4);
                        vfeew = reader.GetInt32(5);
                        vfeem = reader.GetInt32(6);
                        dfeed = reader.GetInt32(10);
                        databaseConnection.Close();
                    }
                }
                else
                {
                    databaseConnection.Close();
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            int days = ((returnDate - rentDate).Days)+1;

            int nom = days / 30;
            int now = (days % 30) / 7;
            int nod = (days % 30) % 7;

            if (driver == true)
            {
                totalRent = (nom * vfeem) + (now * vfeew) + (nod * vfeed) + (days * dfeed);
            }
            else if (driver == false)
            {
                totalRent = (nom * vfeem) + (now * vfeew) + (nod * vfeed);
            }
            return totalRent;
        }
    }
}
