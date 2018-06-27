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

namespace DataCollectionCustomInstaller
{
    public partial class Config : Form
    {
        private string _update = "UPDATE S_LIST SET";
        List<string> forCombos = new List<string>();
        public UpdateLabels Updater;

        public Config()
        {
            InitializeComponent();
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
                    textBox101.Text = result.Rows[0][3].ToString();
                    textBox102.Text = result.Rows[1][3].ToString();
                    textBox103.Text = result.Rows[2][3].ToString();
                    textBox104.Text = result.Rows[3][3].ToString();
                    textBox105.Text = result.Rows[4][3].ToString();
                    textBox106.Text = result.Rows[5][3].ToString();
                    textBox107.Text = result.Rows[6][3].ToString();
                    textBox108.Text = result.Rows[7][3].ToString();
                    textBox109.Text = result.Rows[8][3].ToString();
                    textBox110.Text = result.Rows[9][3].ToString();
                    textBox111.Text = result.Rows[10][3].ToString();
                    textBox112.Text = result.Rows[11][3].ToString();
                    textBox113.Text = result.Rows[12][3].ToString();
                    textBox114.Text = result.Rows[13][3].ToString();
                    textBox115.Text = result.Rows[14][3].ToString();
                    textBox116.Text = result.Rows[15][3].ToString();
                    textBox117.Text = result.Rows[16][3].ToString();
                    textBox118.Text = result.Rows[17][3].ToString();
                    textBox119.Text = result.Rows[18][3].ToString();
                    textBox120.Text = result.Rows[19][3].ToString();
                    textBox121.Text = result.Rows[20][3].ToString();
                    textBox122.Text = result.Rows[21][3].ToString();
                    textBox123.Text = result.Rows[22][3].ToString();
                    textBox124.Text = result.Rows[23][3].ToString();
                    textBox125.Text = result.Rows[24][3].ToString();
                    textBox126.Text = result.Rows[25][3].ToString();
                    textBox127.Text = result.Rows[26][3].ToString();
                    textBox128.Text = result.Rows[27][3].ToString();
                    textBox129.Text = result.Rows[28][3].ToString();
                    textBox130.Text = result.Rows[29][3].ToString();
                    textBox131.Text = result.Rows[30][3].ToString();
                    textBox132.Text = result.Rows[31][3].ToString();
                    
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
                    textBox33.Text = result.Rows[32][1].ToString();
                    textBox34.Text = result.Rows[33][1].ToString();
                    textBox35.Text = result.Rows[34][1].ToString();
                    textBox36.Text = result.Rows[35][1].ToString();



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
                    checkBox33.Checked = (bool)result.Rows[32][4];
                    checkBox34.Checked = (bool)result.Rows[33][4];
                    checkBox35.Checked = (bool)result.Rows[34][4];
                    checkBox36.Checked = (bool)result.Rows[35][4];
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
            string nullString = "Re-Enter";
            //var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            var regexItem = new Regex("^[a-zA-Z0-9 _.-]*$");
            if (textBox.Length < 21)
            {
                if (regexItem.IsMatch(textBox))
                {
                    return textBox;
                }
                else
                {
                    return nullString;
                }
            }
            else
            {
                return nullString;
            }
        }

        private void gather()
        {
            
            string s;
            numCrunch crunch = new numCrunch();
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox1.Text), Convert.ToDecimal(textBox101.Text), checkBox1.Checked, 1));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox2.Text), Convert.ToDecimal(textBox102.Text), checkBox2.Checked, 2));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox3.Text), Convert.ToDecimal(textBox103.Text), checkBox3.Checked, 3));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox4.Text), Convert.ToDecimal(textBox104.Text), checkBox4.Checked, 4));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox5.Text), Convert.ToDecimal(textBox105.Text), checkBox5.Checked, 5));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox6.Text), Convert.ToDecimal(textBox106.Text), checkBox6.Checked, 6));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox7.Text), Convert.ToDecimal(textBox107.Text), checkBox7.Checked, 7));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox8.Text), Convert.ToDecimal(textBox108.Text), checkBox8.Checked, 8));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox9.Text), Convert.ToDecimal(textBox109.Text), checkBox9.Checked, 9));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox10.Text), Convert.ToDecimal(textBox110.Text), checkBox10.Checked, 10));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox11.Text), Convert.ToDecimal(textBox111.Text), checkBox11.Checked, 11));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox12.Text), Convert.ToDecimal(textBox112.Text), checkBox12.Checked, 12));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox13.Text), Convert.ToDecimal(textBox113.Text), checkBox13.Checked, 13));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox14.Text), Convert.ToDecimal(textBox114.Text), checkBox14.Checked, 14));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox15.Text), Convert.ToDecimal(textBox115.Text), checkBox15.Checked, 15));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox16.Text), Convert.ToDecimal(textBox116.Text), checkBox16.Checked, 16));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox17.Text), Convert.ToDecimal(textBox117.Text), checkBox17.Checked, 17));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox18.Text), Convert.ToDecimal(textBox118.Text), checkBox18.Checked, 18));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox19.Text), Convert.ToDecimal(textBox119.Text), checkBox19.Checked, 19));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox20.Text), Convert.ToDecimal(textBox120.Text), checkBox20.Checked, 20));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox21.Text), Convert.ToDecimal(textBox121.Text), checkBox21.Checked, 21));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox22.Text), Convert.ToDecimal(textBox122.Text), checkBox22.Checked, 22));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox23.Text), Convert.ToDecimal(textBox123.Text), checkBox23.Checked, 23));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox24.Text), Convert.ToDecimal(textBox124.Text), checkBox24.Checked, 24));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox25.Text), Convert.ToDecimal(textBox125.Text), checkBox25.Checked, 25));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox26.Text), Convert.ToDecimal(textBox126.Text), checkBox26.Checked, 26));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox27.Text), Convert.ToDecimal(textBox127.Text), checkBox27.Checked, 27));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox28.Text), Convert.ToDecimal(textBox128.Text), checkBox28.Checked, 28));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox29.Text), Convert.ToDecimal(textBox129.Text), checkBox29.Checked, 29));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox30.Text), Convert.ToDecimal(textBox130.Text), checkBox30.Checked, 30));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox31.Text), Convert.ToDecimal(textBox131.Text), checkBox31.Checked, 31));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox32.Text), Convert.ToDecimal(textBox132.Text), checkBox32.Checked, 32));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox33.Text), 0, checkBox33.Checked, 33));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox34.Text), 0, checkBox34.Checked, 34));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox35.Text), 0, checkBox35.Checked, 35));
            crunch.updateS_List(makeQuery(_update, s = Validate(textBox36.Text), 0, checkBox36.Checked, 36));
        }

        private string makeQuery(string first, string second, decimal third, bool fourth, int x)
        {
            int a = 89;
            if (fourth) { a = 1;  }
            if (!fourth) { a = 0;  }
            StringBuilder query = new StringBuilder();
            query.Append(first);
            query.Append(" SensorName = '");
            query.Append(second);
            query.Append("', Trim =  ");
            query.Append(third.ToString("0.0"));
            query.Append(", Enable = " );
            query.Append(a);
            query.Append(" WHERE SensorID = ");
            query.Append(x.ToString());
            return query.ToString();
        }

        private string makeQuery(string first, string second, string third, bool fourth, int x)
        {
            int a = 89;
            if (fourth) { a = 1; }
            if (!fourth) { a = 0; }
            StringBuilder query = new StringBuilder();
            query.Append(first);
            query.Append(" SensorName = '");
            query.Append(second);
            query.Append("', Zone =  '");
            query.Append(third);
            query.Append("', Enable = ");
            query.Append(a);
            query.Append(" WHERE SensorID = ");
            query.Append(x.ToString());
            return query.ToString();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            gather();
            Updater();
            this.Close();

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


    
}
