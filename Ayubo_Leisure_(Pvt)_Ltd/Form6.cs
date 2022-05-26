using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Ayubo_Leisure__Pvt__Ltd.DayHire;

namespace Ayubo_Leisure__Pvt__Ltd
{
    public partial class CalculateDayHire : Form
    {
        public CalculateDayHire()
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

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty || textBox2.Text != string.Empty || textBox3.Text != string.Empty || textBox4.Text != string.Empty)
            {
                int[] h = new int[3];
                DateTime startTime = Convert.ToDateTime(dateTimePicker1.Value);
                DateTime endTime = Convert.ToDateTime(dateTimePicker2.Value);

                DayHire hire = new DayHire();
                h = hire.DayHireCalculation(int.Parse(textBox1.Text), textBox2.Text, startTime, endTime, int.Parse(textBox3.Text), int.Parse(textBox4.Text));
                if (h[0] == -1)
                {
                    MessageBox.Show("Invalid Vehicle Number or Date");
                }
                else
                {
                    label6.Text = h[0].ToString();
                    label10.Text = h[1].ToString();
                    label11.Text = h[2].ToString();

                    textBox1.Text = String.Empty;
                    textBox2.Text = String.Empty;
                    textBox3.Text = String.Empty;
                    textBox4.Text = String.Empty;
                }
                
            }
            else
            {
                MessageBox.Show("Insert a Vehicle Number");
            }
            
        }

        private void CalculateDayHire_Load(object sender, EventArgs e)
        {
            
        }
    }
}
