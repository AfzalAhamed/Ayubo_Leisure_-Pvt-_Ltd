using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Ayubo_Leisure__Pvt__Ltd.Rent;

namespace Ayubo_Leisure__Pvt__Ltd
{
    public partial class CalculateRent : Form
    {
        public CalculateRent()
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

        private void button7_Click(object sender, EventArgs e)
        {
            Boolean driver;
            if (checkBox1.Checked)
            {
                driver = true;
            }
            else {
                driver = false;
            }

            
            if (textBox1.Text != string.Empty)
            {
                int r = 0;
                Rent rent = new Rent();
                r=rent.RentCalculation(int.Parse(textBox1.Text), dateTimePicker1.Value, dateTimePicker2.Value, driver);
                if (r == -1)
                {
                    MessageBox.Show("Invalid Vehicle Number or Date");
                }
                else {
                    label6.Text = r.ToString();

                    textBox1.Text = String.Empty;
                    checkBox1.Checked = false;
                }
            }
            else
            {
                MessageBox.Show("Insert a Vehicle Number");
            }
            
        }

        private void CalculateRent_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Packages f1 = new Packages();
            f1.Show();
        }
    }
}
