using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ayubo_Leisure__Pvt__Ltd
{
    public partial class Packages : Form
    {
        public Packages()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home f1 = new Home();
            f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            RentData f1 = new RentData();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DayHireData f1 = new DayHireData();
            f1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            LongHireData f1 = new LongHireData();
            f1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            CalculateRent f1 = new CalculateRent();
            f1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            CalculateDayHire f1 = new CalculateDayHire();
            f1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            CalculateLongHire f1 = new CalculateLongHire();
            f1.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Drivervehiclefee f1 = new Drivervehiclefee();
            f1.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Packages f1 = new Packages();
            f1.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void updateTable()
        {
            string connectionString = @"Data Source = DESKTOP-UU7JK7R; Initial Catalog = Ayubo_db; Integrated Security= true;";
            string query = "SELECT * FROM ayubo_db.packages";

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
                        string[] row = { reader.GetInt32(0).ToString(), reader.GetString(1), reader.GetInt32(2).ToString(), reader.GetInt32(3).ToString(), reader.GetInt32(4).ToString(), reader.GetInt32(5).ToString(), reader.GetInt32(6).ToString(), reader.GetInt32(7).ToString() };
                        var listViewItem = new ListViewItem(row);
                        listView1.Items.Add(listViewItem);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Packages_Load(object sender, EventArgs e)
        {
            updateTable();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                label10.Text = item.SubItems[0].Text;
                textBox1.Text = item.SubItems[1].Text;
                textBox2.Text = item.SubItems[2].Text;
                textBox3.Text = item.SubItems[3].Text;
                textBox4.Text = item.SubItems[4].Text;
                textBox5.Text = item.SubItems[5].Text;
                textBox6.Text = item.SubItems[6].Text;
                textBox7.Text = item.SubItems[7].Text;
            }
            else
            {
                label10.Text = string.Empty;
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
                textBox5.Text = string.Empty;
                textBox6.Text = string.Empty;
                textBox7.Text = string.Empty;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty || textBox2.Text != string.Empty || textBox3.Text != string.Empty || textBox4.Text != string.Empty || textBox5.Text != string.Empty ||
                textBox6.Text != string.Empty || textBox7.Text != string.Empty)
            {
                string connectionString = @"Data Source = DESKTOP-UU7JK7R; Initial Catalog = Ayubo_db; Integrated Security= true;";
                string query = "INSERT INTO ayubo_db.packages (packageName, vehicleNo, packagePrice, maxKm, maxHour, extraCharge, waitingCharge) VALUES ('" + textBox1.Text+ "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "');";


                SqlConnection databaseConnection = new SqlConnection(connectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;

                try
                {
                    databaseConnection.Open();
                    SqlDataReader myReader = commandDatabase.ExecuteReader();

                    MessageBox.Show("Package succesfully Added");

                    databaseConnection.Close();
                    label10.Text = string.Empty;
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    textBox3.Text = string.Empty;
                    textBox4.Text = string.Empty;
                    textBox5.Text = string.Empty;
                    textBox6.Text = string.Empty;
                    textBox7.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                listView1.Items.Clear();
                updateTable();

            }
            else
            {
                MessageBox.Show("Please Recheck the details");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (label10.Text != string.Empty)
            {
                string connectionString = @"Data Source = DESKTOP-UU7JK7R; Initial Catalog = Ayubo_db; Integrated Security= true;";
                string query = "UPDATE ayubo_db.packages SET packageName='" + textBox1.Text + "', vehicleNo='" + textBox2.Text + "', packagePrice='" + textBox3.Text + "', maxKm='" + textBox4.Text + "', maxHour='" + textBox5.Text + "', extraCharge='" + textBox6.Text + "', waitingCharge='" + textBox7.Text + "' WHERE packageNo = " + label10.Text + "";

                SqlConnection databaseConnection = new SqlConnection(connectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;

                try
                {
                    databaseConnection.Open();
                    reader = commandDatabase.ExecuteReader();
                    databaseConnection.Close();
                    MessageBox.Show("Package succesfully Updated");
                    label10.Text = string.Empty;
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    textBox3.Text = string.Empty;
                    textBox4.Text = string.Empty;
                    textBox5.Text = string.Empty;
                    textBox6.Text = string.Empty;
                    textBox7.Text = string.Empty;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                listView1.Items.Clear();
                updateTable();
            }
            else
            {
                MessageBox.Show("Please select any record");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (label10.Text != string.Empty)
            {
                string connectionString = @"Data Source = DESKTOP-UU7JK7R; Initial Catalog = Ayubo_db; Integrated Security= true;";
                string query = "DELETE FROM ayubo_db.packages WHERE packageNo = " + label10.Text + "";

                SqlConnection databaseConnection = new SqlConnection(connectionString);
                SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                SqlDataReader reader;

                DialogResult dialogResult = MessageBox.Show("This Data Will Be Deleted Permanently", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        databaseConnection.Open();
                        reader = commandDatabase.ExecuteReader();
                        databaseConnection.Close();
                        MessageBox.Show("Package succesfully Deleted");
                        label10.Text = string.Empty;
                        textBox1.Text = string.Empty;
                        textBox2.Text = string.Empty;
                        textBox3.Text = string.Empty;
                        textBox4.Text = string.Empty;
                        textBox5.Text = string.Empty;
                        textBox6.Text = string.Empty;
                        textBox7.Text = string.Empty;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    listView1.Items.Clear();
                    updateTable();
                }
            }
            else
            {
                MessageBox.Show("Please select any record");
            }
        }
    }
}
