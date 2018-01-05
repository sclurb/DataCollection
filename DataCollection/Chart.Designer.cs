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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chart));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnGetData = new System.Windows.Forms.Button();
            this.chkBoxSensor1 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor2 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkBoxSensor15 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor16 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor13 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor14 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor11 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor12 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor9 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor10 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor7 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor8 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor5 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor6 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor3 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor4 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkBoxSensor21 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor23 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor17 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor19 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor22 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor24 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor18 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor20 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkBoxSensor31 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor32 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor29 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor30 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor27 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor28 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor25 = new System.Windows.Forms.CheckBox();
            this.chkBoxSensor26 = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.cmbStartYear = new System.Windows.Forms.ComboBox();
            this.cmbStartMonth = new System.Windows.Forms.ComboBox();
            this.cmbStartDay = new System.Windows.Forms.ComboBox();
            this.cmbStartTime = new System.Windows.Forms.ComboBox();
            this.cmbEndTime = new System.Windows.Forms.ComboBox();
            this.cmbEndDay = new System.Windows.Forms.ComboBox();
            this.cmbEndMonth = new System.Windows.Forms.ComboBox();
            this.cmbEndYear = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 12);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(1160, 500);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(902, 619);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(75, 23);
            this.btnGetData.TabIndex = 1;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.button1_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 530);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 120);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Temperature Sensors";
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkBoxSensor21);
            this.groupBox2.Controls.Add(this.chkBoxSensor23);
            this.groupBox2.Controls.Add(this.chkBoxSensor17);
            this.groupBox2.Controls.Add(this.chkBoxSensor19);
            this.groupBox2.Controls.Add(this.chkBoxSensor22);
            this.groupBox2.Controls.Add(this.chkBoxSensor24);
            this.groupBox2.Controls.Add(this.chkBoxSensor18);
            this.groupBox2.Controls.Add(this.chkBoxSensor20);
            this.groupBox2.Location = new System.Drawing.Point(438, 530);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(216, 120);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sensors with Humidity and Temperature";
            // 
            // chkBoxSensor21
            // 
            this.chkBoxSensor21.AutoSize = true;
            this.chkBoxSensor21.Location = new System.Drawing.Point(129, 72);
            this.chkBoxSensor21.Name = "chkBoxSensor21";
            this.chkBoxSensor21.Size = new System.Drawing.Size(62, 17);
            this.chkBoxSensor21.TabIndex = 24;
            this.chkBoxSensor21.Text = "Temp 3";
            this.chkBoxSensor21.UseVisualStyleBackColor = true;
            // 
            // chkBoxSensor23
            // 
            this.chkBoxSensor23.AutoSize = true;
            this.chkBoxSensor23.Location = new System.Drawing.Point(129, 95);
            this.chkBoxSensor23.Name = "chkBoxSensor23";
            this.chkBoxSensor23.Size = new System.Drawing.Size(62, 17);
            this.chkBoxSensor23.TabIndex = 25;
            this.chkBoxSensor23.Text = "Temp 4";
            this.chkBoxSensor23.UseVisualStyleBackColor = true;
            // 
            // chkBoxSensor17
            // 
            this.chkBoxSensor17.AutoSize = true;
            this.chkBoxSensor17.Location = new System.Drawing.Point(129, 26);
            this.chkBoxSensor17.Name = "chkBoxSensor17";
            this.chkBoxSensor17.Size = new System.Drawing.Size(62, 17);
            this.chkBoxSensor17.TabIndex = 22;
            this.chkBoxSensor17.Text = "Temp-1";
            this.chkBoxSensor17.UseVisualStyleBackColor = true;
            // 
            // chkBoxSensor19
            // 
            this.chkBoxSensor19.AutoSize = true;
            this.chkBoxSensor19.Location = new System.Drawing.Point(129, 49);
            this.chkBoxSensor19.Name = "chkBoxSensor19";
            this.chkBoxSensor19.Size = new System.Drawing.Size(62, 17);
            this.chkBoxSensor19.TabIndex = 23;
            this.chkBoxSensor19.Text = "Temp-2";
            this.chkBoxSensor19.UseVisualStyleBackColor = true;
            // 
            // chkBoxSensor22
            // 
            this.chkBoxSensor22.AutoSize = true;
            this.chkBoxSensor22.Location = new System.Drawing.Point(28, 72);
            this.chkBoxSensor22.Name = "chkBoxSensor22";
            this.chkBoxSensor22.Size = new System.Drawing.Size(75, 17);
            this.chkBoxSensor22.TabIndex = 20;
            this.chkBoxSensor22.Text = "Humidity-3";
            this.chkBoxSensor22.UseVisualStyleBackColor = true;
            // 
            // chkBoxSensor24
            // 
            this.chkBoxSensor24.AutoSize = true;
            this.chkBoxSensor24.Location = new System.Drawing.Point(28, 95);
            this.chkBoxSensor24.Name = "chkBoxSensor24";
            this.chkBoxSensor24.Size = new System.Drawing.Size(75, 17);
            this.chkBoxSensor24.TabIndex = 21;
            this.chkBoxSensor24.Text = "Humidity-4";
            this.chkBoxSensor24.UseVisualStyleBackColor = true;
            // 
            // chkBoxSensor18
            // 
            this.chkBoxSensor18.AutoSize = true;
            this.chkBoxSensor18.Location = new System.Drawing.Point(28, 26);
            this.chkBoxSensor18.Name = "chkBoxSensor18";
            this.chkBoxSensor18.Size = new System.Drawing.Size(75, 17);
            this.chkBoxSensor18.TabIndex = 18;
            this.chkBoxSensor18.Text = "Humidity-1";
            this.chkBoxSensor18.UseVisualStyleBackColor = true;
            // 
            // chkBoxSensor20
            // 
            this.chkBoxSensor20.AutoSize = true;
            this.chkBoxSensor20.Location = new System.Drawing.Point(28, 49);
            this.chkBoxSensor20.Name = "chkBoxSensor20";
            this.chkBoxSensor20.Size = new System.Drawing.Size(75, 17);
            this.chkBoxSensor20.TabIndex = 19;
            this.chkBoxSensor20.Text = "Humidity-2";
            this.chkBoxSensor20.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkBoxSensor31);
            this.groupBox3.Controls.Add(this.chkBoxSensor32);
            this.groupBox3.Controls.Add(this.chkBoxSensor29);
            this.groupBox3.Controls.Add(this.chkBoxSensor30);
            this.groupBox3.Controls.Add(this.chkBoxSensor27);
            this.groupBox3.Controls.Add(this.chkBoxSensor28);
            this.groupBox3.Controls.Add(this.chkBoxSensor25);
            this.groupBox3.Controls.Add(this.chkBoxSensor26);
            this.groupBox3.Location = new System.Drawing.Point(660, 530);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(223, 120);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Voltage Sensors";
            // 
            // chkBoxSensor31
            // 
            this.chkBoxSensor31.AutoSize = true;
            this.chkBoxSensor31.Location = new System.Drawing.Point(129, 72);
            this.chkBoxSensor31.Name = "chkBoxSensor31";
            this.chkBoxSensor31.Size = new System.Drawing.Size(71, 17);
            this.chkBoxSensor31.TabIndex = 24;
            this.chkBoxSensor31.Text = "Voltage-7";
            this.chkBoxSensor31.UseVisualStyleBackColor = true;
            // 
            // chkBoxSensor32
            // 
            this.chkBoxSensor32.AutoSize = true;
            this.chkBoxSensor32.Location = new System.Drawing.Point(129, 95);
            this.chkBoxSensor32.Name = "chkBoxSensor32";
            this.chkBoxSensor32.Size = new System.Drawing.Size(71, 17);
            this.chkBoxSensor32.TabIndex = 25;
            this.chkBoxSensor32.Text = "Voltage-8";
            this.chkBoxSensor32.UseVisualStyleBackColor = true;
            // 
            // chkBoxSensor29
            // 
            this.chkBoxSensor29.AutoSize = true;
            this.chkBoxSensor29.Location = new System.Drawing.Point(129, 26);
            this.chkBoxSensor29.Name = "chkBoxSensor29";
            this.chkBoxSensor29.Size = new System.Drawing.Size(71, 17);
            this.chkBoxSensor29.TabIndex = 22;
            this.chkBoxSensor29.Text = "Voltage-5";
            this.chkBoxSensor29.UseVisualStyleBackColor = true;
            // 
            // chkBoxSensor30
            // 
            this.chkBoxSensor30.AutoSize = true;
            this.chkBoxSensor30.Location = new System.Drawing.Point(129, 49);
            this.chkBoxSensor30.Name = "chkBoxSensor30";
            this.chkBoxSensor30.Size = new System.Drawing.Size(71, 17);
            this.chkBoxSensor30.TabIndex = 23;
            this.chkBoxSensor30.Text = "Voltage-6";
            this.chkBoxSensor30.UseVisualStyleBackColor = true;
            // 
            // chkBoxSensor27
            // 
            this.chkBoxSensor27.AutoSize = true;
            this.chkBoxSensor27.Location = new System.Drawing.Point(28, 72);
            this.chkBoxSensor27.Name = "chkBoxSensor27";
            this.chkBoxSensor27.Size = new System.Drawing.Size(71, 17);
            this.chkBoxSensor27.TabIndex = 20;
            this.chkBoxSensor27.Text = "Voltage-3";
            this.chkBoxSensor27.UseVisualStyleBackColor = true;
            // 
            // chkBoxSensor28
            // 
            this.chkBoxSensor28.AutoSize = true;
            this.chkBoxSensor28.Location = new System.Drawing.Point(28, 95);
            this.chkBoxSensor28.Name = "chkBoxSensor28";
            this.chkBoxSensor28.Size = new System.Drawing.Size(71, 17);
            this.chkBoxSensor28.TabIndex = 21;
            this.chkBoxSensor28.Text = "Voltage-4";
            this.chkBoxSensor28.UseVisualStyleBackColor = true;
            // 
            // chkBoxSensor25
            // 
            this.chkBoxSensor25.AutoSize = true;
            this.chkBoxSensor25.Location = new System.Drawing.Point(28, 26);
            this.chkBoxSensor25.Name = "chkBoxSensor25";
            this.chkBoxSensor25.Size = new System.Drawing.Size(71, 17);
            this.chkBoxSensor25.TabIndex = 18;
            this.chkBoxSensor25.Text = "Voltage-1";
            this.chkBoxSensor25.UseVisualStyleBackColor = true;
            // 
            // chkBoxSensor26
            // 
            this.chkBoxSensor26.AutoSize = true;
            this.chkBoxSensor26.Location = new System.Drawing.Point(28, 49);
            this.chkBoxSensor26.Name = "chkBoxSensor26";
            this.chkBoxSensor26.Size = new System.Drawing.Size(71, 17);
            this.chkBoxSensor26.TabIndex = 19;
            this.chkBoxSensor26.Text = "Voltage-2";
            this.chkBoxSensor26.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(983, 619);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save Image";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1064, 619);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear Image";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cmbStartYear
            // 
            this.cmbStartYear.FormattingEnabled = true;
            this.cmbStartYear.Location = new System.Drawing.Point(889, 541);
            this.cmbStartYear.Name = "cmbStartYear";
            this.cmbStartYear.Size = new System.Drawing.Size(71, 21);
            this.cmbStartYear.TabIndex = 9;
            // 
            // cmbStartMonth
            // 
            this.cmbStartMonth.FormattingEnabled = true;
            this.cmbStartMonth.Location = new System.Drawing.Point(966, 541);
            this.cmbStartMonth.Name = "cmbStartMonth";
            this.cmbStartMonth.Size = new System.Drawing.Size(71, 21);
            this.cmbStartMonth.TabIndex = 10;
            this.cmbStartMonth.SelectedIndexChanged += new System.EventHandler(this.Start_MonthDrop_SelectedIndexChanged);
            // 
            // cmbStartDay
            // 
            this.cmbStartDay.FormattingEnabled = true;
            this.cmbStartDay.Location = new System.Drawing.Point(1043, 541);
            this.cmbStartDay.Name = "cmbStartDay";
            this.cmbStartDay.Size = new System.Drawing.Size(48, 21);
            this.cmbStartDay.TabIndex = 11;
            // 
            // cmbStartTime
            // 
            this.cmbStartTime.FormattingEnabled = true;
            this.cmbStartTime.Location = new System.Drawing.Point(1097, 541);
            this.cmbStartTime.Name = "cmbStartTime";
            this.cmbStartTime.Size = new System.Drawing.Size(42, 21);
            this.cmbStartTime.TabIndex = 12;
            // 
            // cmbEndTime
            // 
            this.cmbEndTime.FormattingEnabled = true;
            this.cmbEndTime.Location = new System.Drawing.Point(1097, 586);
            this.cmbEndTime.Name = "cmbEndTime";
            this.cmbEndTime.Size = new System.Drawing.Size(42, 21);
            this.cmbEndTime.TabIndex = 16;
            // 
            // cmbEndDay
            // 
            this.cmbEndDay.FormattingEnabled = true;
            this.cmbEndDay.Location = new System.Drawing.Point(1043, 586);
            this.cmbEndDay.Name = "cmbEndDay";
            this.cmbEndDay.Size = new System.Drawing.Size(48, 21);
            this.cmbEndDay.TabIndex = 15;
            // 
            // cmbEndMonth
            // 
            this.cmbEndMonth.FormattingEnabled = true;
            this.cmbEndMonth.Location = new System.Drawing.Point(966, 586);
            this.cmbEndMonth.Name = "cmbEndMonth";
            this.cmbEndMonth.Size = new System.Drawing.Size(71, 21);
            this.cmbEndMonth.TabIndex = 14;
            this.cmbEndMonth.SelectedIndexChanged += new System.EventHandler(this.End_MonthDrop_SelectedIndexChanged);
            // 
            // cmbEndYear
            // 
            this.cmbEndYear.FormattingEnabled = true;
            this.cmbEndYear.Location = new System.Drawing.Point(889, 586);
            this.cmbEndYear.Name = "cmbEndYear";
            this.cmbEndYear.Size = new System.Drawing.Size(71, 21);
            this.cmbEndYear.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(886, 525);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Start Year";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(963, 525);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Start Month";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1040, 525);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Start Day";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1097, 525);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Start Hour";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(886, 570);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "End Year";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(971, 570);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "End Month";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1043, 570);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "End Day";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1094, 570);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "End Hour";
            // 
            // Chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 711);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbEndTime);
            this.Controls.Add(this.cmbEndDay);
            this.Controls.Add(this.cmbEndMonth);
            this.Controls.Add(this.cmbEndYear);
            this.Controls.Add(this.cmbStartTime);
            this.Controls.Add(this.cmbStartDay);
            this.Controls.Add(this.cmbStartMonth);
            this.Controls.Add(this.cmbStartYear);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.chart1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Chart";
            this.Text = "Chart";
            this.Load += new System.EventHandler(this.Chart_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnGetData;
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkBoxSensor21;
        private System.Windows.Forms.CheckBox chkBoxSensor23;
        private System.Windows.Forms.CheckBox chkBoxSensor17;
        private System.Windows.Forms.CheckBox chkBoxSensor19;
        private System.Windows.Forms.CheckBox chkBoxSensor22;
        private System.Windows.Forms.CheckBox chkBoxSensor24;
        private System.Windows.Forms.CheckBox chkBoxSensor18;
        private System.Windows.Forms.CheckBox chkBoxSensor20;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkBoxSensor31;
        private System.Windows.Forms.CheckBox chkBoxSensor32;
        private System.Windows.Forms.CheckBox chkBoxSensor29;
        private System.Windows.Forms.CheckBox chkBoxSensor30;
        private System.Windows.Forms.CheckBox chkBoxSensor27;
        private System.Windows.Forms.CheckBox chkBoxSensor28;
        private System.Windows.Forms.CheckBox chkBoxSensor25;
        private System.Windows.Forms.CheckBox chkBoxSensor26;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox cmbStartYear;
        private System.Windows.Forms.ComboBox cmbStartMonth;
        private System.Windows.Forms.ComboBox cmbStartDay;
        private System.Windows.Forms.ComboBox cmbStartTime;
        private System.Windows.Forms.ComboBox cmbEndTime;
        private System.Windows.Forms.ComboBox cmbEndDay;
        private System.Windows.Forms.ComboBox cmbEndMonth;
        private System.Windows.Forms.ComboBox cmbEndYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}