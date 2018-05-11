using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataCollectionCustomInstaller
{
    public partial class TripPoint : Form
    {
        public TripPoint()
        {
            InitializeComponent();
            loadControls();
        }



        private void loadControls()
        {
            //Relay-1
            if (Properties.Settings.Default.Enable1 == true)
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
            if (Properties.Settings.Default.OverUnder1 == true)
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
            //Relay-2
            if (Properties.Settings.Default.Enable2 == true)
            {
                checkBox2.Checked = true;
            }
            else
            {
                checkBox2.Checked = false;
            }
            if (Properties.Settings.Default.OverUnder2 == true)
            {
                radioButton3.Checked = true;
            }
            else
            {
                radioButton4.Checked = true;
            }
            //Relay-3
            if (Properties.Settings.Default.Enable3 == true)
            {
                checkBox3.Checked = true;
            }
            else
            {
                checkBox3.Checked = false;
            }
            if (Properties.Settings.Default.OverUnder3 == true)
            {
                radioButton5.Checked = true;
            }
            else
            {
                radioButton6.Checked = true;
            }

            textBox1.Text = Properties.Settings.Default.TripPoint1.ToString();
            textBox2.Text = Properties.Settings.Default.TripPoint2.ToString();
            textBox3.Text = Properties.Settings.Default.TripPoint3.ToString();
            loadCombos();
        }


        private void loadCombos()
        {
            numCrunch mars = new numCrunch();
            DataTable result = mars.configLoad();
            try
            {
                int count = result.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    comboBox1.Items.Add(result.Rows[i][1].ToString());
                    comboBox2.Items.Add(result.Rows[i][1].ToString());
                    comboBox3.Items.Add(result.Rows[i][1].ToString());
                }

                comboBox1.SelectedIndex = Properties.Settings.Default.Index1;
                comboBox2.SelectedIndex = Properties.Settings.Default.Index2;
                comboBox3.SelectedIndex = Properties.Settings.Default.Index3;
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to load Combo Boxes \r \r"
                    + "Here's Why.... \r \r" + e.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double val;
            if (!Double.TryParse(textBox1.Text, out val))
            {
                MessageBox.Show("Enter numbers only with the format xxx.xx");
            }
            else
            {
                Properties.Settings.Default.TripPoint1 = val;
                label3.Text = val.ToString();
            }
            if (checkBox1.Checked )
            {
                Properties.Settings.Default.Enable1 = true;
            }
            else
            {
                Properties.Settings.Default.Enable1 = false;
            }
            if (radioButton1.Checked == true)
            {
                Properties.Settings.Default.OverUnder1 = true;
            }
            if (radioButton2.Checked == true)
            {
                Properties.Settings.Default.OverUnder1 = false;
            }
            Properties.Settings.Default.Index1 = comboBox1.SelectedIndex;

            Properties.Settings.Default.Save();
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            double val;
            if (!Double.TryParse(textBox2.Text, out val))
            {
                MessageBox.Show("Enter numbers only with the format xxx.xx");
            }
            else
            {
                Properties.Settings.Default.TripPoint2 = val;
                label4.Text = val.ToString();
            }
            if (checkBox2.Checked )
            {
                Properties.Settings.Default.Enable2 = true;
            }
            else
            {
                Properties.Settings.Default.Enable2 = false;
            }
            if (radioButton3.Checked == true)
            {
                Properties.Settings.Default.OverUnder2 = true;
            }
            if (radioButton4.Checked == true)
            {
                Properties.Settings.Default.OverUnder2 = false;
            }
            Properties.Settings.Default.Index2 = comboBox2.SelectedIndex;

            Properties.Settings.Default.Save();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            double val;
            if (!Double.TryParse(textBox3.Text, out val))
            {
                MessageBox.Show("Enter numbers only with the format xxx.xx");
            }
            else
            {

                Properties.Settings.Default.TripPoint3 = val;
                label7.Text = val.ToString();
            }
            if (checkBox3.Checked )
            {
                Properties.Settings.Default.Enable3 = true;
            }
            else
            {
                Properties.Settings.Default.Enable3 = false;
            }
            if (radioButton5.Checked == true)
            {
                Properties.Settings.Default.OverUnder3 = true;
            }
            if (radioButton6.Checked == true)
            {
                Properties.Settings.Default.OverUnder3 = false;
            }
            Properties.Settings.Default.Index3 = comboBox3.SelectedIndex;

            Properties.Settings.Default.Save();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
