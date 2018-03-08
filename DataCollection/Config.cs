using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataCollection
{
    public partial class Config : Form
    {
        private string _update = "UPDATE S_LIST SET";
        List<string> forCombos = new List<string>();
        public UpdateLabels Updater;

        public Config()
        {
            InitializeComponent();
            populate();
            loadThem();
        }

        private void loadThem()
        {
            numCrunch pluto = new numCrunch();
            DataTable result = pluto.configLoad();
            try
            {
                int count = result.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    comboBox1.SelectedIndex = comboBox1.FindStringExact(result.Rows[0][3].ToString());
                    comboBox2.SelectedIndex = comboBox2.FindStringExact(result.Rows[1][3].ToString());
                    comboBox3.SelectedIndex = comboBox3.FindStringExact(result.Rows[2][3].ToString());
                    comboBox4.SelectedIndex = comboBox4.FindStringExact(result.Rows[3][3].ToString());
                    comboBox5.SelectedIndex = comboBox5.FindStringExact(result.Rows[4][3].ToString());
                    comboBox6.SelectedIndex = comboBox6.FindStringExact(result.Rows[5][3].ToString());
                    comboBox7.SelectedIndex = comboBox7.FindStringExact(result.Rows[6][3].ToString());
                    comboBox8.SelectedIndex = comboBox8.FindStringExact(result.Rows[7][3].ToString());
                    comboBox9.SelectedIndex = comboBox9.FindStringExact(result.Rows[8][3].ToString());
                    comboBox10.SelectedIndex = comboBox10.FindStringExact(result.Rows[9][3].ToString());
                    comboBox11.SelectedIndex = comboBox11.FindStringExact(result.Rows[10][3].ToString());
                    comboBox12.SelectedIndex = comboBox12.FindStringExact(result.Rows[11][3].ToString());
                    comboBox13.SelectedIndex = comboBox13.FindStringExact(result.Rows[12][3].ToString());
                    comboBox14.SelectedIndex = comboBox14.FindStringExact(result.Rows[13][3].ToString());
                    comboBox15.SelectedIndex = comboBox15.FindStringExact(result.Rows[14][3].ToString());
                    comboBox16.SelectedIndex = comboBox16.FindStringExact(result.Rows[15][3].ToString());
                    comboBox17.SelectedIndex = comboBox17.FindStringExact(result.Rows[16][3].ToString());
                    comboBox18.SelectedIndex = comboBox18.FindStringExact(result.Rows[17][3].ToString());
                    comboBox19.SelectedIndex = comboBox19.FindStringExact(result.Rows[18][3].ToString());
                    comboBox20.SelectedIndex = comboBox20.FindStringExact(result.Rows[19][3].ToString());
                    comboBox21.SelectedIndex = comboBox21.FindStringExact(result.Rows[20][3].ToString());
                    comboBox22.SelectedIndex = comboBox22.FindStringExact(result.Rows[21][3].ToString());
                    comboBox23.SelectedIndex = comboBox23.FindStringExact(result.Rows[22][3].ToString());
                    comboBox24.SelectedIndex = comboBox24.FindStringExact(result.Rows[23][3].ToString());
                    comboBox25.SelectedIndex = comboBox25.FindStringExact(result.Rows[24][3].ToString());
                    comboBox26.SelectedIndex = comboBox26.FindStringExact(result.Rows[25][3].ToString());
                    comboBox27.SelectedIndex = comboBox27.FindStringExact(result.Rows[26][3].ToString());
                    comboBox28.SelectedIndex = comboBox28.FindStringExact(result.Rows[27][3].ToString());
                    comboBox29.SelectedIndex = comboBox29.FindStringExact(result.Rows[28][3].ToString());
                    comboBox30.SelectedIndex = comboBox30.FindStringExact(result.Rows[29][3].ToString());
                    comboBox31.SelectedIndex = comboBox31.FindStringExact(result.Rows[30][3].ToString());
                    comboBox32.SelectedIndex = comboBox32.FindStringExact(result.Rows[31][3].ToString());
                    //
                    textBox1.Text = result.Rows[0][1].ToString();
                    textBox2.Text = result.Rows[1][1].ToString();
                    textBox3.Text = result.Rows[2][1].ToString();
                    textBox4.Text = result.Rows[3][1].ToString();
                    textBox5.Text = result.Rows[4][1].ToString();
                    textBox6.Text = result.Rows[5][1].ToString();
                    textBox7.Text = result.Rows[6][1].ToString();
                    textBox8.Text = result.Rows[7][1].ToString();
                    textBox9.Text = result.Rows[8][1].ToString();
                    textBox10.Text = result.Rows[9][1].ToString();
                    textBox11.Text = result.Rows[10][1].ToString();
                    textBox12.Text = result.Rows[11][1].ToString();
                    textBox13.Text = result.Rows[12][1].ToString();
                    textBox14.Text = result.Rows[13][1].ToString();
                    textBox15.Text = result.Rows[14][1].ToString();
                    textBox16.Text = result.Rows[15][1].ToString();
                    textBox17.Text = result.Rows[16][1].ToString();
                    textBox18.Text = result.Rows[17][1].ToString();
                    textBox19.Text = result.Rows[18][1].ToString();
                    textBox20.Text = result.Rows[19][1].ToString();
                    textBox21.Text = result.Rows[20][1].ToString();
                    textBox22.Text = result.Rows[21][1].ToString();
                    textBox23.Text = result.Rows[22][1].ToString();
                    textBox24.Text = result.Rows[23][1].ToString();
                    textBox25.Text = result.Rows[24][1].ToString();
                    textBox26.Text = result.Rows[25][1].ToString();
                    textBox27.Text = result.Rows[26][1].ToString();
                    textBox28.Text = result.Rows[27][1].ToString();
                    textBox29.Text = result.Rows[28][1].ToString();
                    textBox30.Text = result.Rows[29][1].ToString();
                    textBox31.Text = result.Rows[30][1].ToString();
                    textBox32.Text = result.Rows[31][1].ToString();
                    //
                    checkBox1.Checked = (bool)result.Rows[0][4];
                    checkBox2.Checked = (bool)result.Rows[1][4];
                    checkBox3.Checked = (bool)result.Rows[2][4];
                    checkBox4.Checked = (bool)result.Rows[3][4];
                    checkBox5.Checked = (bool)result.Rows[4][4];
                    checkBox6.Checked = (bool)result.Rows[5][4];
                    checkBox7.Checked = (bool)result.Rows[6][4];
                    checkBox8.Checked = (bool)result.Rows[7][4];
                    checkBox9.Checked = (bool)result.Rows[8][4];
                    checkBox10.Checked = (bool)result.Rows[9][4];
                    checkBox11.Checked = (bool)result.Rows[10][4];
                    checkBox12.Checked = (bool)result.Rows[11][4];
                    checkBox13.Checked = (bool)result.Rows[12][4];
                    checkBox14.Checked = (bool)result.Rows[13][4];
                    checkBox15.Checked = (bool)result.Rows[14][4];
                    checkBox16.Checked = (bool)result.Rows[15][4];
                    checkBox17.Checked = (bool)result.Rows[16][4];
                    checkBox18.Checked = (bool)result.Rows[17][4];
                    checkBox19.Checked = (bool)result.Rows[18][4];
                    checkBox20.Checked = (bool)result.Rows[19][4];
                    checkBox21.Checked = (bool)result.Rows[20][4];
                    checkBox22.Checked = (bool)result.Rows[21][4];
                    checkBox23.Checked = (bool)result.Rows[22][4];
                    checkBox24.Checked = (bool)result.Rows[23][4];
                    checkBox25.Checked = (bool)result.Rows[24][4];
                    checkBox26.Checked = (bool)result.Rows[25][4];
                    checkBox27.Checked = (bool)result.Rows[26][4];
                    checkBox28.Checked = (bool)result.Rows[27][4];
                    checkBox29.Checked = (bool)result.Rows[28][4];
                    checkBox30.Checked = (bool)result.Rows[29][4];
                    checkBox31.Checked = (bool)result.Rows[30][4];
                    checkBox32.Checked = (bool)result.Rows[31][4];
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to load Controls \r \r"
                    + "Here's Why.... \r \r" + e.ToString());
            }
        }

        private string Validate(string textBox)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            if (textBox.Length < 21)
            {
                if (regexItem.IsMatch(textBox))
                {
                    return textBox;
                }
                else
                {
                    return "Letters or Numbers";
                }
            }
            else
            {
                return "Name was too long";
            }
        }

        private void gather()
        {
            
            string s;
            numCrunch crunch = new numCrunch();
            s = Validate(textBox1.Text);
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox1.Text), comboBox1.SelectedItem.ToString(), checkBox1.Checked, 1));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox2.Text), comboBox2.SelectedItem.ToString(), checkBox2.Checked, 2));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox3.Text), comboBox3.SelectedItem.ToString(), checkBox3.Checked, 3));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox4.Text), comboBox4.SelectedItem.ToString(), checkBox4.Checked, 4));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox5.Text), comboBox5.SelectedItem.ToString(), checkBox5.Checked, 5));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox6.Text), comboBox6.SelectedItem.ToString(), checkBox6.Checked, 6));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox7.Text), comboBox7.SelectedItem.ToString(), checkBox7.Checked, 7));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox8.Text), comboBox8.SelectedItem.ToString(), checkBox8.Checked, 8));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox9.Text), comboBox9.SelectedItem.ToString(), checkBox9.Checked, 9));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox10.Text), comboBox10.SelectedItem.ToString(), checkBox10.Checked, 10));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox11.Text), comboBox11.SelectedItem.ToString(), checkBox11.Checked, 11));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox12.Text), comboBox12.SelectedItem.ToString(), checkBox12.Checked, 12));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox13.Text), comboBox13.SelectedItem.ToString(), checkBox13.Checked, 13));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox14.Text), comboBox14.SelectedItem.ToString(), checkBox14.Checked, 14));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox15.Text), comboBox15.SelectedItem.ToString(), checkBox15.Checked, 15));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox16.Text), comboBox16.SelectedItem.ToString(), checkBox16.Checked, 16));
            crunch.updateS_List(makeQuery(_update, textBox17.Text, comboBox17.SelectedItem.ToString(), checkBox17.Checked, 17));
            crunch.updateS_List(makeQuery(_update, textBox18.Text, comboBox18.SelectedItem.ToString(), checkBox18.Checked, 18));
            crunch.updateS_List(makeQuery(_update, textBox19.Text, comboBox19.SelectedItem.ToString(), checkBox19.Checked, 19));
            crunch.updateS_List(makeQuery(_update, textBox20.Text, comboBox20.SelectedItem.ToString(), checkBox20.Checked, 20));
            crunch.updateS_List(makeQuery(_update, textBox21.Text, comboBox21.SelectedItem.ToString(), checkBox21.Checked, 21));
            crunch.updateS_List(makeQuery(_update, textBox22.Text, comboBox22.SelectedItem.ToString(), checkBox22.Checked, 22));
            crunch.updateS_List(makeQuery(_update, textBox23.Text, comboBox23.SelectedItem.ToString(), checkBox23.Checked, 23));
            crunch.updateS_List(makeQuery(_update, textBox24.Text, comboBox24.SelectedItem.ToString(), checkBox24.Checked, 24));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox25.Text), comboBox25.SelectedItem.ToString(), checkBox25.Checked, 25));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox26.Text), comboBox26.SelectedItem.ToString(), checkBox26.Checked, 26));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox27.Text), comboBox27.SelectedItem.ToString(), checkBox27.Checked, 27));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox28.Text), comboBox28.SelectedItem.ToString(), checkBox28.Checked, 28));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox29.Text), comboBox29.SelectedItem.ToString(), checkBox29.Checked, 29));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox30.Text), comboBox30.SelectedItem.ToString(), checkBox30.Checked, 30));
            crunch.updateS_List(makeQuery(_update, s = Validate (textBox31.Text), comboBox31.SelectedItem.ToString(), checkBox31.Checked, 31));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox32.Text), comboBox32.SelectedItem.ToString(), checkBox32.Checked, 32));
        }

        private string makeQuery(string first, string second, string third, bool fourth, int x)
        {
            int a = 89;
            if (fourth) { a = 1;  }
            if (!fourth) { a = 0;  }
            StringBuilder query = new StringBuilder();
            query.Append(first);
            query.Append(" SensorName = '");
            query.Append(second);
            query.Append("', Zone =  '");
            query.Append(third);
            query.Append("', Enable = " );
            query.Append(a);
            query.Append(" WHERE SensorID = ");
            query.Append(x.ToString());
            return query.ToString();
        }
        private void populate()
        {
            forCombos.Add("Zone-1");
            forCombos.Add("Zone-2");
            forCombos.Add("Zone-3");
            forCombos.Add("Zone-4");

            foreach (string a in forCombos)
            {
                comboBox1.Items.Add(a);
                comboBox2.Items.Add(a);
                comboBox3.Items.Add(a);
                comboBox4.Items.Add(a);
                comboBox5.Items.Add(a);
                comboBox6.Items.Add(a);
                comboBox7.Items.Add(a);
                comboBox8.Items.Add(a);
                comboBox9.Items.Add(a);
                comboBox10.Items.Add(a);
                comboBox11.Items.Add(a);
                comboBox12.Items.Add(a);
                comboBox13.Items.Add(a);
                comboBox14.Items.Add(a);
                comboBox15.Items.Add(a);
                comboBox16.Items.Add(a);
                comboBox17.Items.Add(a);
                comboBox18.Items.Add(a);
                comboBox19.Items.Add(a);
                comboBox20.Items.Add(a);
                comboBox21.Items.Add(a);
                comboBox22.Items.Add(a);
                comboBox23.Items.Add(a);
                comboBox24.Items.Add(a);
                comboBox25.Items.Add(a);
                comboBox26.Items.Add(a);
                comboBox27.Items.Add(a);
                comboBox28.Items.Add(a);
                comboBox29.Items.Add(a);
                comboBox30.Items.Add(a);
                comboBox31.Items.Add(a);
                comboBox32.Items.Add(a);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gather();

            Updater();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


    
}
