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
    public partial class RentData : Form
    {
        public RentData()
        {
            InitializeComponent();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home f1 = new Home();
            f1.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void RentData_Load(object sender, EventArgs e)
        {
            dateTimePicker2.Visible = false;
            label4.Visible = false;
            updateTable();
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Value = DateTime.Today;
        }

        private void updateTable()
        {
            string connectionString = @"Data Source = DESKTOP-UU7JK7R; Initial Catalog = Ayubo_db; Integrated Security= true;";
            string query = "SELECT * FROM ayubo_db.rent";

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
                        string[] row = { reader.GetInt32(0).ToString(), reader.GetInt32(1).ToString(), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetInt32(6).ToString() };
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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                dateTimePicker2.Visible = true;
                label4.Visible = true;
            }
            else {
                dateTimePicker2.Visible = false;
                label4.Visible = false;
            }
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                label7.Text = item.SubItems[0].Text;
                textBox1.Text = item.SubItems[1].Text;
                textBox2.Text = item.SubItems[2].Text;
                textBox3.Text = item.SubItems[3].Text;
                dateTimePicker1.Value = Convert.ToDateTime(item.SubItems[4].Text);
                if (item.SubItems[5].Text != "")
                {
                    checkBox2.Checked = true;
                    dateTimePicker2.Value = Convert.ToDateTime(item.SubItems[5].Text);
                }
            }
            else
            {
                label7.Text = string.Empty;
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty || textBox2.Text != string.Empty || textBox3.Text != string.Empty)
            {
                Boolean driver;
                if (checkBox1.Checked)
                {
                    driver = true;
                }
                else
                {
                    driver = false;
                }

                if (checkBox2.Checked)
                {
                    DateTime iDate;
                    iDate = dateTimePicker1.Value;
                    DateTime iDate2;
                    iDate2 = dateTimePicker2.Value;

                    int r = 0;
                    Rent rent = new Rent();
                    r = rent.RentCalculation(int.Parse(textBox1.Text), dateTimePicker1.Value, dateTimePicker2.Value, driver);
                    if (r == -1)
                    {
                        MessageBox.Show("Invalid Vehicle Number or Date");
                    }
                    else
                    {
                        string connectionString = @"Data Source = DESKTOP-UU7JK7R; Initial Catalog = Ayubo_db; Integrated Security= true;";
                        string query = "INSERT INTO ayubo_db.rent(vehicleNo, customerNic, CustomerName, rentDate, returnDate, rentFee) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + iDate + "', '" + iDate2 + "', '" +r+ "')";


                        SqlConnection databaseConnection = new SqlConnection(connectionString);
                        SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                        commandDatabase.CommandTimeout = 60;

                        try
                        {
                            databaseConnection.Open();
                            SqlDataReader myReader = commandDatabase.ExecuteReader();

                            MessageBox.Show("Rent succesfully Added");

                            databaseConnection.Close();

                            label7.Text = string.Empty;
                            textBox1.Text = string.Empty;
                            textBox2.Text = string.Empty;
                            textBox3.Text = string.Empty;
                            checkBox2.Checked = false;
                            checkBox1.Checked = false;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        listView1.Items.Clear();
                        updateTable();

                    }
                }
                else {
                    DateTime iDate;
                    iDate = dateTimePicker1.Value;


                    string connectionString = @"Data Source = DESKTOP-UU7JK7R; Initial Catalog = Ayubo_db; Integrated Security= true;";
                    string query = "INSERT INTO ayubo_db.rent(vehicleNo, customerNic, CustomerName, rentDate, returnDate, rentFee) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" +iDate+ "', '', '0')";


                    SqlConnection databaseConnection = new SqlConnection(connectionString);
                    SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                    commandDatabase.CommandTimeout = 60;

                    try
                    {
                        databaseConnection.Open();
                        SqlDataReader myReader = commandDatabase.ExecuteReader();

                        MessageBox.Show("Rent succesfully Added");

                        databaseConnection.Close();

                        label7.Text = string.Empty;
                        textBox1.Text = string.Empty;
                        textBox2.Text = string.Empty;
                        textBox3.Text = string.Empty;
                        checkBox2.Checked = false;
                        checkBox1.Checked = false;
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

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty || textBox2.Text != string.Empty || textBox3.Text != string.Empty)
            {
                Boolean driver;
                if (checkBox1.Checked)
                {
                    driver = true;
                }
                else
                {
                    driver = false;
                }

                if (checkBox2.Checked)
                {
                    DateTime iDate;
                    iDate = dateTimePicker1.Value;
                    DateTime iDate2;
                    iDate2 = dateTimePicker2.Value;

                    int r = 0;
                    Rent rent = new Rent();
                    r = rent.RentCalculation(int.Parse(textBox1.Text), dateTimePicker1.Value, dateTimePicker2.Value, driver);
                    if (r == -1)
                    {
                        MessageBox.Show("Invalid Vehicle Number or Date");
                    }
                    else
                    {
                        string connectionString = @"Data Source = DESKTOP-UU7JK7R; Initial Catalog = Ayubo_db; Integrated Security= true;";
                        string query = "UPDATE ayubo_db.rent SET vehicleNo= '" + textBox1.Text + "', customerNic= '" + textBox2.Text + "', CustomerName= '" + textBox3.Text + "', rentDate= '" + iDate + "', returnDate= '" + iDate2 + "', rentFee= '" + r + "' where rent_id= " + label7.Text + "";
                        

                        SqlConnection databaseConnection = new SqlConnection(connectionString);
                        SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                        commandDatabase.CommandTimeout = 60;

                        try
                        {
                            databaseConnection.Open();
                            SqlDataReader myReader = commandDatabase.ExecuteReader();

                            MessageBox.Show("VRent Succesfully Updated");

                            databaseConnection.Close();
                            label7.Text = string.Empty;
                            textBox1.Text = string.Empty;
                            textBox2.Text = string.Empty;
                            textBox3.Text = string.Empty;
                            checkBox2.Checked = false;
                            checkBox1.Checked = false;
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
                    DateTime iDate;
                    iDate = dateTimePicker1.Value;


                    string connectionString = @"Data Source = DESKTOP-UU7JK7R; Initial Catalog = Ayubo_db; Integrated Security= true;";
                    string query = "UPDATE ayubo_db.rent SET vehicleNo= '" + textBox1.Text + "', customerNic= '" + textBox2.Text + "', CustomerName= '" + textBox3.Text + "', rentDate= '" + iDate + "', returnDate= '', rentFee= '0' WHERE rent_id= " + label7.Text + "";

                    SqlConnection databaseConnection = new SqlConnection(connectionString);
                    SqlCommand commandDatabase = new SqlCommand(query, databaseConnection);
                    commandDatabase.CommandTimeout = 60;

                    try
                    {
                        databaseConnection.Open();
                        SqlDataReader myReader = commandDatabase.ExecuteReader();

                        MessageBox.Show("Rent Succesfully Updated");

                        databaseConnection.Close();
                        label7.Text = string.Empty;
                        textBox1.Text = string.Empty;
                        textBox2.Text = string.Empty;
                        textBox3.Text = string.Empty;
                        checkBox2.Checked = false;
                        checkBox1.Checked = false;

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

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
           
        }
    }
}
