namespace DataCollection
{
    partial class Chart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.getDataBtn = new System.Windows.Forms.Button();
            this.chkBoxSensor1 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor2 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkBoxSensor3 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor4 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor7 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor8 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor5 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor6 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor15 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor16 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor13 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor14 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor11 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor12 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor9 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor10 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 12);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(945, 500);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // getDataBtn
            // 
            this.getDataBtn.Location = new System.Drawing.Point(12, 552);
            this.getDataBtn.Name = "getDataBtn";
            this.getDataBtn.Size = new System.Drawing.Size(75, 23);
            this.getDataBtn.TabIndex = 1;
            this.getDataBtn.Text = "Get Data";
            this.getDataBtn.UseVisualStyleBackColor = true;
            this.getDataBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkBoxSensor1
            // 
            this.chkBoxSensor1.AutoSize = true;
            this.chkBoxSensor1.Location = new System.Drawing.Point(6, 29);
            this.chkBoxSensor1.Name = "chkBoxSensor1";
            this.chkBoxSensor1.Size = new System.Drawing.Size(95, 17);
            this.chkBoxSensor1.TabIndex = 2;
            this.chkBoxSensor1.Text = "Temperature 1";
            this.chkBoxSensor1.UseVisualStyleBackColor = true;
            // 
            // chkBoxSensor2
            // 
            this.chkBoxSensor2.AutoSize = true;
            this.chkBoxSensor2.Location = new System.Drawing.Point(6, 52);
            this.chkBoxSensor2.Name = "chkBoxSensor2";
            this.chkBoxSensor2.Size = new System.Drawing.Size(95, 17);
            this.chkBoxSensor2.TabIndex = 3;
            this.chkBoxSensor2.Text = "Temperature 2";
            this.chkBoxSensor2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkBoxSensor15);
            this.groupBox1.Controls.Add(this.chkBoxSensor16);
            this.groupBox1.Controls.Add(this.chkBoxSensor13);
            this.groupBox1.Controls.Add(this.chkBoxSensor14);
            this.groupBox1.Controls.Add(this.chkBoxSensor11);
            this.groupBox1.Controls.Add(this.chkBoxSensor12);
            this.groupBox1.Controls.Add(this.chkBoxSensor9);
            this.groupBox1.Controls.Add(this.chkBoxSensor10);
            this.groupBox1.Controls.Add(this.chkBoxSensor7);
            this.groupBox1.Controls.Add(this.chkBoxSensor8);
            this.groupBox1.Controls.Add(this.chkBoxSensor5);
            this.groupBox1.Controls.Add(this.chkBoxSensor6);
            this.groupBox1.Controls.Add(this.chkBoxSensor3);
            this.groupBox1.Controls.Add(this.chkBoxSensor4);
            this.groupBox1.Controls.Add(this.chkBoxSensor1);
            this.groupBox1.Controls.Add(this.chkBoxSensor2);
            this.groupBox1.Location = new System.Drawing.Point(93, 530);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 119);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Check to Include in Chart";
            // 
            // chkBoxSensor3
            // 
            this.chkBoxSensor3.AutoSize = true;
            this.chkBoxSensor3.Location = new System.Drawing.Point(6, 75);
            this.chkBoxSensor3.Name = "chkBoxSensor3";
            this.chkBoxSensor3.Size = new System.Drawing.Size(95, 17);
            this.chkBoxSensor3.TabIndex = 4;
            this.chkBoxSensor3.Text = "Temperature 3";
            this.chkBoxSensor3.UseVisualStyleBackColor = true;
            // 
            // chkBoxSensor4
            // 
            this.chkBoxSensor4.AutoSize = true;
            this.chkBoxSensor4.Location = new System.Drawing.Point(6, 98);
            this.chkBoxSensor4.Name = "chkBoxSensor4";
            this.chkBoxSensor4.Size = new System.Drawing.Size(95, 17);
            this.chkBoxSensor4.TabIndex = 5;
            this.chkBoxSensor4.Text = "Temperature 4";
            this.chkBoxSensor4.UseVisualStyleBackColor = true;
            // 
            // chkBoxSensor7
            // 
            this.chkBoxSensor7.AutoSize = true;
            this.chkBoxSensor7.Location = new System.Drawing.Point(107, 75);
            this.chkBoxSensor7.Name = "chkBoxSensor7";
            this.chkBoxSensor7.Size = new System.Drawing.Size(95, 17);
            this.chkBoxSensor7.TabIndex = 8;
            this.chkBoxSensor7.Text = "Temperature 7";
            this.chkBoxSensor7.UseVisualStyleBackColor = true;
            // 
            // chkBoxSensor8
            // 
            this.chkBoxSensor8.AutoSize = true;
            this.chkBoxSensor8.Location = new System.Drawing.Point(107, 98);
            this.chkBoxSensor8.Name = "chkBoxSensor8";
            this.chkBoxSensor8.Size = new System.Drawing.Size(95, 17);
            this.chkBoxSensor8.TabIndex = 9;
            this.chkBoxSensor8.Text = "Temperature 8";
            this.chkBoxSensor8.UseVisualStyleBackColor = true;
            // 
            // chkBoxSensor5
            // 
            this.chkBoxSensor5.AutoSize = true;
            this.chkBoxSensor5.Location = new System.Drawing.Point(107, 29);
            this.chkBoxSensor5.Name = "chkBoxSensor5";
            this.chkBoxSensor5.Size = new System.Drawing.Size(95, 17);
            this.chkBoxSensor5.TabIndex = 6;
            this.chkBoxSensor5.Text = "Temperature 5";
            this.chkBoxSensor5.UseVisualStyleBackColor = true;
            // 
            // chkBoxSensor6
            // 
            this.chkBoxSensor6.AutoSize = true;
            this.chkBoxSensor6.Location = new System.Drawing.Point(107, 52);
            this.chkBoxSensor6.Name = "chkBoxSensor6";
            this.chkBoxSensor6.Size = new System.Drawing.Size(95, 17);
            this.chkBoxSensor6.TabIndex = 7;
            this.chkBoxSensor6.Text = "Temperature 6";
            this.chkBoxSensor6.UseVisualStyleBackColor = true;
            // 
            // chkBoxSensor15
            // 
            this.chkBoxSensor15.AutoSize = true;
            this.chkBoxSensor15.Location = new System.Drawing.Point(309, 75);
            this.chkBoxSensor15.Name = "chkBoxSensor15";
            this.chkBoxSensor15.Size = new System.Drawing.Size(101, 17);
            this.chkBoxSensor15.TabIndex = 16;
            this.chkBoxSensor15.Text = "Temperature 15";
            this.chkBoxSensor15.UseVisualStyleBackColor = true;
            // 
            // chkBoxSensor16
            // 
            this.chkBoxSensor16.AutoSize = true;
            this.chkBoxSensor16.Location = new System.Drawing.Point(309, 98);
            this.chkBoxSensor16.Name = "chkBoxSensor16";
            this.chkBoxSensor16.Size = new System.Drawing.Size(101, 17);
            this.chkBoxSensor16.TabIndex = 17;
            this.chkBoxSensor16.Text = "Temperature 16";
            this.chkBoxSensor16.UseVisualStyleBackColor = true;
            // 
            // chkBoxSensor13
            // 
            this.chkBoxSensor13.AutoSize = true;
            this.chkBoxSensor13.Location = new System.Drawing.Point(309, 29);
            this.chkBoxSensor13.Name = "chkBoxSensor13";
            this.chkBoxSensor13.Size = new System.Drawing.Size(101, 17);
            this.chkBoxSensor13.TabIndex = 14;
            this.chkBoxSensor13.Text = "Temperature 13";
            this.chkBoxSensor13.UseVisualStyleBackColor = true;
            // 
            // chkBoxSensor14
            // 
            this.chkBoxSensor14.AutoSize = true;
            this.chkBoxSensor14.Location = new System.Drawing.Point(309, 52);
            this.chkBoxSensor14.Name = "chkBoxSensor14";
            this.chkBoxSensor14.Size = new System.Drawing.Size(101, 17);
            this.chkBoxSensor14.TabIndex = 15;
            this.chkBoxSensor14.Text = "Temperature 14";
            this.chkBoxSensor14.UseVisualStyleBackColor = true;
            // 
            // chkBoxSensor11
            // 
            this.chkBoxSensor11.AutoSize = true;
            this.chkBoxSensor11.Location = new System.Drawing.Point(208, 75);
            this.chkBoxSensor11.Name = "chkBoxSensor11";
            this.chkBoxSensor11.Size = new System.Drawing.Size(101, 17);
            this.chkBoxSensor11.TabIndex = 12;
            this.chkBoxSensor11.Text = "Temperature 11";
            this.chkBoxSensor11.UseVisualStyleBackColor = true;
            // 
            // chkBoxSensor12
            // 
            this.chkBoxSensor12.AutoSize = true;
            this.chkBoxSensor12.Location = new System.Drawing.Point(208, 98);
            this.chkBoxSensor12.Name = "chkBoxSensor12";
            this.chkBoxSensor12.Size = new System.Drawing.Size(101, 17);
            this.chkBoxSensor12.TabIndex = 13;
            this.chkBoxSensor12.Text = "Temperature 12";
            this.chkBoxSensor12.UseVisualStyleBackColor = true;
            // 
            // chkBoxSensor9
            // 
            this.chkBoxSensor9.AutoSize = true;
            this.chkBoxSensor9.Location = new System.Drawing.Point(208, 29);
            this.chkBoxSensor9.Name = "chkBoxSensor9";
            this.chkBoxSensor9.Size = new System.Drawing.Size(95, 17);
            this.chkBoxSensor9.TabIndex = 10;
            this.chkBoxSensor9.Text = "Temperature 9";
            this.chkBoxSensor9.UseVisualStyleBackColor = true;
            // 
            // chkBoxSensor10
            // 
            this.chkBoxSensor10.AutoSize = true;
            this.chkBoxSensor10.Location = new System.Drawing.Point(208, 52);
            this.chkBoxSensor10.Name = "chkBoxSensor10";
            this.chkBoxSensor10.Size = new System.Drawing.Size(101, 17);
            this.chkBoxSensor10.TabIndex = 11;
            this.chkBoxSensor10.Text = "Temperature 10";
            this.chkBoxSensor10.UseVisualStyleBackColor = true;
            // 
            // Chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 661);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.getDataBtn);
            this.Controls.Add(this.chart1);
            this.Name = "Chart";
            this.Text = "Chart";
            this.Load += new System.EventHandler(this.Chart_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button getDataBtn;
        private System.Windows.Forms.CheckBox chkBoxSensor1;
        private System.Windows.Forms.CheckBox chkBoxSensor2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkBoxSensor15;
        private System.Windows.Forms.CheckBox chkBoxSensor16;
        private System.Windows.Forms.CheckBox chkBoxSensor13;
        private System.Windows.Forms.CheckBox chkBoxSensor14;
        private System.Windows.Forms.CheckBox chkBoxSensor11;
        private System.Windows.Forms.CheckBox chkBoxSensor12;
        private System.Windows.Forms.CheckBox chkBoxSensor9;
        private System.Windows.Forms.CheckBox chkBoxSensor10;
        private System.Windows.Forms.CheckBox chkBoxSensor7;
        private System.Windows.Forms.CheckBox chkBoxSensor8;
        private System.Windows.Forms.CheckBox chkBoxSensor5;
        private System.Windows.Forms.CheckBox chkBoxSensor6;
        private System.Windows.Forms.CheckBox chkBoxSensor3;
        private System.Windows.Forms.CheckBox chkBoxSensor4;
    }
}