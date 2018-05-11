namespace DataCollectionCustomInstaller
{
    partial class LCD
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_Contrast = new System.Windows.Forms.Label();
            this.lbl_Backlight = new System.Windows.Forms.Label();
            this.trk_Contrast = new System.Windows.Forms.TrackBar();
            this.trk_Backlight = new System.Windows.Forms.TrackBar();
            this.btn_Close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trk_Contrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_Backlight)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Contrast
            // 
            this.lbl_Contrast.AutoSize = true;
            this.lbl_Contrast.Location = new System.Drawing.Point(128, 37);
            this.lbl_Contrast.Name = "lbl_Contrast";
            this.lbl_Contrast.Size = new System.Drawing.Size(35, 13);
            this.lbl_Contrast.TabIndex = 4;
            this.lbl_Contrast.Text = "label1";
            // 
            // lbl_Backlight
            // 
            this.lbl_Backlight.AutoSize = true;
            this.lbl_Backlight.Location = new System.Drawing.Point(128, 130);
            this.lbl_Backlight.Name = "lbl_Backlight";
            this.lbl_Backlight.Size = new System.Drawing.Size(35, 13);
            this.lbl_Backlight.TabIndex = 5;
            this.lbl_Backlight.Text = "label2";
            // 
            // trk_Contrast
            // 
            this.trk_Contrast.Location = new System.Drawing.Point(39, 69);
            this.trk_Contrast.Maximum = 100;
            this.trk_Contrast.Name = "trk_Contrast";
            this.trk_Contrast.Size = new System.Drawing.Size(204, 45);
            this.trk_Contrast.TabIndex = 6;
            this.trk_Contrast.ValueChanged += new System.EventHandler(this.trk_Contrast_ValueChanged);
            // 
            // trk_Backlight
            // 
            this.trk_Backlight.Location = new System.Drawing.Point(39, 173);
            this.trk_Backlight.Maximum = 100;
            this.trk_Backlight.Name = "trk_Backlight";
            this.trk_Backlight.Size = new System.Drawing.Size(204, 45);
            this.trk_Backlight.TabIndex = 7;
            this.trk_Backlight.ValueChanged += new System.EventHandler(this.trk_Backlight_ValueChanged);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(99, 225);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 8;
            this.btn_Close.Text = "Save & Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // LCD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.trk_Backlight);
            this.Controls.Add(this.trk_Contrast);
            this.Controls.Add(this.lbl_Backlight);
            this.Controls.Add(this.lbl_Contrast);
            this.Name = "LCD";
            this.Text = "LCD";
            ((System.ComponentModel.ISupportInitialize)(this.trk_Contrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_Backlight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_Contrast;
        private System.Windows.Forms.Label lbl_Backlight;
        private System.Windows.Forms.TrackBar trk_Contrast;
        private System.Windows.Forms.TrackBar trk_Backlight;
        private System.Windows.Forms.Button btn_Close;
    }
}