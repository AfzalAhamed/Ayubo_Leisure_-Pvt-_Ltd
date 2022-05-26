using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Ayubo_Leisure__Pvt__Ltd
{
    class LongHire
    {
        public int[] LongHireCalculation(int vehicleNo, String packageType, DateTime startDate, DateTime endDate, int startKm, int endKm)
        {
            int[] fee = new int[3];

            int days = ((endDate - startDate).Days) + 1;

            int packagePrice = 0;
            int maxKm = 0;
            int maxHour = 0;
            int extraKm = 0;
            int dFeeD = 0;
            int vParFee = 0;
            int dOverFee = 0;

            int noKm = (endKm - startKm);

            string connectionString = @"Data Source = DESKTOP-UU7JK7R; Initial Catalog = Ayubo_db; Integrated Security= true;";
            string query = "SELECT packages.packagePrice, packages.maxKm, packages.maxHour, packages.extraCharge, vehicle.vParFeeN, vehicle.dFeeD, vehicle.dOverFeeN FROM ayubo_db.packages, ayubo_db.vehicle WHERE packages.vehicleNo = vehicle.vehicleNo AND packages.packageName = '" + packageType + "' AND vehicle.vehicleNo = " + vehicleNo + "; ";

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
                        packagePrice = reader.GetInt32(0);
                        maxKm = reader.GetInt32(1);
                        maxHour = reader.GetInt32(2);
                        extraKm = reader.GetInt32(3);
                        vParFee = reader.GetInt32(4);
                        dFeeD = reader.GetInt32(5);
                        dOverFee = reader.GetInt32(6);
                        databaseConnection.Close();
                    }
                }
                else
                {
                    databaseConnection.Close();
                    fee[0] = -1;
                    return fee;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            fee[0] = (dFeeD * days) + packagePrice;
            
            if (days> 2)
            {
                int fee2 = days - 2;
                fee[1] = (dOverFee * fee2)+(vParFee * fee2);
            }

            if (noKm > maxKm)
            {
                fee[2] = (noKm - maxKm) * extraKm;
            }

            return fee;
        }
    }
}
