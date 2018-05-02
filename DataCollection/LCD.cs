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
    public partial class LCD : Form
    {
        
        byte contrast;
        byte backlight;
        public AdjustLCD adjuster;
        private bool check = false;
        
        public LCD()
        {
            InitializeComponent();
 
        }

        public LCD(byte contr, byte bcklght)
        {
            InitializeComponent();
            contrast = contr;
            backlight = bcklght;
            trk_Contrast.Value = contrast;
            trk_Backlight.Value = backlight;
            check = true;
            lbl_Contrast.Text = "Contrast = " + contrast.ToString();
            lbl_Backlight.Text = "Backlight = " + backlight.ToString();

        }
        #region Stuff


        #endregion

        public void Backlight()
        {
            
            AdjustEventArgs fred = new AdjustEventArgs();
            fred.Cmd = 0x0e;
            backlight = (byte)trk_Backlight.Value;
            fred.Data = backlight;
            lbl_Backlight.Text = "Backlight = " + backlight.ToString();
            adjuster(fred);
        }

        public void Contrast()
        {

            AdjustEventArgs fred = new AdjustEventArgs();
            fred.Cmd = 0x0f;
            contrast = (byte)trk_Contrast.Value;
            fred.Data = contrast;
            lbl_Contrast.Text = "Contrast = " + contrast.ToString();
            adjuster(fred);
        }




        private void trk_Contrast_ValueChanged(object sender, EventArgs e)
        {
            if (check == false)
            {
                return;
            }
            Contrast();
        }

        private void trk_Backlight_ValueChanged(object sender, EventArgs e)
        {
            if (check == false)
            {
                return;
            }
            Backlight();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {

            Properties.Settings.Default.Backlight = backlight;
            Properties.Settings.Default.Contrast = contrast;
            Properties.Settings.Default.Save();

            this.Close();
        }
    }
}
