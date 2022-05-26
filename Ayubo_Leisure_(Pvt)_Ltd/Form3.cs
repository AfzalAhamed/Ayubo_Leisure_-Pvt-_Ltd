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
    public partial class DayHireData : Form
    {
        public DayHireData()
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

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void DayHireData_Load(object sender, EventArgs e)
        {
            dateTimePicker2.Visible = false;
            label4.Visible = false;
            label11.Visible = false;
            textBox6.Visible = false;
            updateTable();
        }

        private void updateTable()
        {
            string connectionString = @"Data Source = DESKTOP-UU7JK7R; Initial Catalog = Ayubo_db; Integrated Security= true;";
            string query = "SELECT * FROM ayubo_db.dayhire";

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
                        string[] row = { reader.GetInt32(0).ToString(), reader.GetInt32(1).ToString(), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5).ToString(), reader.GetInt32(6).ToString(), reader.GetString(7), reader.GetString(8), reader.GetInt32(9).ToString() };
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

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty || textBox2.Text != string.Empty || textBox3.Text != string.Empty || textBox4.Text != string.Empty || textBox5.Text != string.Empty)
            {
                if (checkBox2.Checked)
                {

                    int[] h = new int[3];
                    DateTime startTime = Convert.ToDateTime(dateTimePicker1.Value);
                    DateTime endTime = Convert.ToDateTime(dateTimePicker2.Value);

                    DayHire hire = new DayHire();
                    h = hire.DayHireCalculation(int.Parse(textBox1.Text), textBox2.Text, startTime, endTime, int.Parse(textBox5.Text), int.Parse(textBox6.Text));
                    int total = h[0] + h[1] + h[2];
                    if (h[0] == -1)
                    {
                        MessageBox.Show("Invalid Vehicle Number or Date");
                    }
                    else
                    {
                        string connectionString = @"Data Source = DESKTOP-UU7JK7R; Initial Catalog = Ayubo_db; Integrated Security= true;";
                        string query = "INSERT INTO ayubo_db.dayhire (vehicleNo, packageName, customerNic, customerName, startKm, endKm, rentTime, returnTime, hireFee) VALUES ('" + textBox1.Text+ "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + startTime + "', '" + endTime + "', '" + total + "');";


                        SqlConnection databaseConnection = new SqlConnection(connectionString);
                        SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                        commandDatabase.CommandTimeout = 60;

                        try
                        {
                            databaseConnection.Open();
                            SqlDataReader myReader = commandDatabase.ExecuteReader();

                            MessageBox.Show("Hire succesfully Added");

                            databaseConnection.Close();

                            textBox1.Text = string.Empty;
                            textBox2.Text = string.Empty;
                            textBox3.Text = string.Empty;
                            textBox4.Text = string.Empty;
                            textBox5.Text = string.Empty;
                            textBox6.Text = string.Empty;
                            checkBox2.Checked = false;
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
                    DateTime startTime = Convert.ToDateTime(dateTimePicker1.Value);

                    string connectionString = @"Data Source = DESKTOP-UU7JK7R; Initial Catalog = Ayubo_db; Integrated Security= true;";
                    string query = "INSERT INTO ayubo_db.dayhire (vehicleNo, packageName, customerNic, customerName, startKm, rentTime, endKm, returnTime, hireFee) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + startTime + "',0,'',0);";


                    SqlConnection databaseConnection = new SqlConnection(connectionString);
                    SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                    commandDatabase.CommandTimeout = 60;

                    try
                    {
                        databaseConnection.Open();
                        SqlDataReader myReader = commandDatabase.ExecuteReader();

                        MessageBox.Show("Hire succesfully Added");

                        databaseConnection.Close();

                        textBox1.Text = string.Empty;
                        textBox2.Text = string.Empty;
                        textBox3.Text = string.Empty;
                        textBox4.Text = string.Empty;
                        
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
                MessageBox.Show("Please Recheck the details");
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                label7.Text = item.SubItems[0].Text;
                textBox1.Text = item.SubItems[1].Text;
                textBox2.Text = item.SubItems[2].Text;
                textBox3.Text = item.SubItems[3].Text;
                textBox4.Text = item.SubItems[4].Text;
                textBox5.Text = item.SubItems[5].Text;
                textBox6.Text = item.SubItems[6].Text;
                dateTimePicker1.Value = Convert.ToDateTime(item.SubItems[7].Text);
                if (item.SubItems[8].Text != "")
                {
                    checkBox2.Checked = true;
                    dateTimePicker2.Value = Convert.ToDateTime(item.SubItems[8].Text);
                }
            }
            else
            {
                label7.Text = string.Empty;
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
                textBox5.Text = string.Empty;
                textBox6.Text = string.Empty;
                checkBox2.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                dateTimePicker2.Visible = true;
                label4.Visible = true;
                label11.Visible = true;
                textBox6.Visible = true; 
            }
            else
            {
                dateTimePicker2.Visible = false;
                label4.Visible = false;
                label11.Visible = false;
                textBox6.Visible = false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty || textBox2.Text != string.Empty || textBox3.Text != string.Empty || textBox4.Text != string.Empty || textBox5.Text != string.Empty)
            {
                if (checkBox2.Checked)
                {

                    int[] h = new int[3];
                    DateTime startTime = Convert.ToDateTime(dateTimePicker1.Value);
                    DateTime endTime = Convert.ToDateTime(dateTimePicker2.Value);

                    DayHire hire = new DayHire();
                    h = hire.DayHireCalculation(int.Parse(textBox1.Text), textBox2.Text, startTime, endTime, int.Parse(textBox5.Text), int.Parse(textBox6.Text));
                    int total = h[0] + h[1] + h[2];
                    if (h[0] == -1)
                    {
                        MessageBox.Show("Invalid Vehicle Number or Date");
                    }
                    else
                    {
                        string connectionString = @"Data Source = DESKTOP-UU7JK7R; Initial Catalog = Ayubo_db; Integrated Security= true;";
                        string query = "UPDATE ayubo_db.dayhire SET vehicleNo='" + textBox1.Text + "', packageName='" + textBox2.Text + "', customerNic='" + textBox3.Text + "', customerName='" + textBox4.Text + "', startKm='" + textBox5.Text + "', endKm='" + textBox6.Text + "', rentTime='" + startTime + "', returnTime='" + endTime + "', hireFee='" + total + "' WHERE hireNo='" + label7.Text + "'";
                        

                        SqlConnection databaseConnection = new SqlConnection(connectionString);
                        SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                        commandDatabase.CommandTimeout = 60;

                        try
                        {
                            databaseConnection.Open();
                            SqlDataReader myReader = commandDatabase.ExecuteReader();

                            MessageBox.Show("Hire succesfully Updated");

                            databaseConnection.Close();

                            label7.Text = string.Empty;
                            textBox1.Text = string.Empty;
                            textBox2.Text = string.Empty;
                            textBox3.Text = string.Empty;
                            textBox4.Text = string.Empty;
                            textBox5.Text = string.Empty;
                            textBox6.Text = string.Empty;
                            checkBox2.Checked = false;
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
                    DateTime startTime = Convert.ToDateTime(dateTimePicker1.Value);

                    string connectionString = @"Data Source = DESKTOP-UU7JK7R; Initial Catalog = Ayubo_db; Integrated Security= true;";
                    string query = "UPDATE ayubo_db.dayhire SET vehicleNo='" + textBox1.Text + "', packageName='" + textBox2.Text + "', customerNic='" + textBox3.Text + "', customerName='" + textBox4.Text + "', startKm='" + textBox5.Text + "', endKm=0, returnTime='', hirefee=0, rentTime='" + startTime + "' WHERE hireNo='" + label7.Text + "'";


                    SqlConnection databaseConnection = new SqlConnection(connectionString);
                    SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                    commandDatabase.CommandTimeout = 60;

                    try
                    {
                        databaseConnection.Open();
                        SqlDataReader myReader = commandDatabase.ExecuteReader();

                        MessageBox.Show("Hire succesfully Updated");

                        databaseConnection.Close();

                        label7.Text = string.Empty;
                        textBox1.Text = string.Empty;
                        textBox2.Text = string.Empty;
                        textBox3.Text = string.Empty;
                        textBox4.Text = string.Empty;
                        textBox5.Text = string.Empty;
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
                MessageBox.Show("Please Recheck the details");
            }
        }
    }
}
