namespace gui
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.setupPage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.connectButton = new System.Windows.Forms.Button();
            this.baudRateDropdown = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comPortDropdown = new System.Windows.Forms.ComboBox();
            this.digIOPage = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tickPC7 = new System.Windows.Forms.CheckBox();
            this.tickPC6 = new System.Windows.Forms.CheckBox();
            this.tickPC5 = new System.Windows.Forms.CheckBox();
            this.tickPC4 = new System.Windows.Forms.CheckBox();
            this.tickPC3 = new System.Windows.Forms.CheckBox();
            this.tickPC2 = new System.Windows.Forms.CheckBox();
            this.tickPC1 = new System.Windows.Forms.CheckBox();
            this.tickPC0 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.portsLightsPage = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lampPercentDisplay = new System.Windows.Forms.TextBox();
            this.lampIntensityScroll = new System.Windows.Forms.VScrollBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tempControl = new System.Windows.Forms.TabPage();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.motorSpeedDisplay = new System.Windows.Forms.TextBox();
            this.actualTempDisplay = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tempChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label16 = new System.Windows.Forms.Label();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.appTimer = new System.Windows.Forms.Timer(this.components);
            this.serialPortStatusLED = new Bulb.LedBulb();
            this.pa4LED = new Bulb.LedBulb();
            this.pa5LED = new Bulb.LedBulb();
            this.pa3LED = new Bulb.LedBulb();
            this.pa6LED = new Bulb.LedBulb();
            this.pa7LED = new Bulb.LedBulb();
            this.pa2LED = new Bulb.LedBulb();
            this.pa1LED = new Bulb.LedBulb();
            this.pa0LED = new Bulb.LedBulb();
            this.sevenSegment2 = new DmitryBrant.CustomControls.SevenSegment();
            this.sevenSegment1 = new DmitryBrant.CustomControls.SevenSegment();
            this.lightDisplay = new AquaControls.AquaGauge();
            this.pot2VoltageDisplay = new AquaControls.AquaGauge();
            this.pot1VoltageDisplay = new AquaControls.AquaGauge();
            this.kiTuning = new System.Windows.Forms.NumericUpDown();
            this.kpTuning = new System.Windows.Forms.NumericUpDown();
            this.setpointTemp = new System.Windows.Forms.NumericUpDown();
            this.tabControl1.SuspendLayout();
            this.setupPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.digIOPage.SuspendLayout();
            this.portsLightsPage.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tempControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tempChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kiTuning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpTuning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.setpointTemp)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.setupPage);
            this.tabControl1.Controls.Add(this.digIOPage);
            this.tabControl1.Controls.Add(this.portsLightsPage);
            this.tabControl1.Controls.Add(this.tempControl);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(436, 642);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.appTabs_SelectedIndexChanged);
            // 
            // setupPage
            // 
            this.setupPage.Controls.Add(this.groupBox2);
            this.setupPage.Controls.Add(this.groupBox1);
            this.setupPage.Location = new System.Drawing.Point(4, 22);
            this.setupPage.Name = "setupPage";
            this.setupPage.Padding = new System.Windows.Forms.Padding(3);
            this.setupPage.Size = new System.Drawing.Size(428, 616);
            this.setupPage.TabIndex = 0;
            this.setupPage.Text = "Setup";
            this.setupPage.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(6, 210);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(416, 400);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Database Server Connection";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.serialPortStatusLED);
            this.groupBox1.Controls.Add(this.disconnectButton);
            this.groupBox1.Controls.Add(this.connectButton);
            this.groupBox1.Controls.Add(this.baudRateDropdown);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comPortDropdown);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 198);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Port Connection";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Serial Port Status";
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(236, 116);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(120, 23);
            this.disconnectButton.TabIndex = 5;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(50, 116);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(120, 23);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // baudRateDropdown
            // 
            this.baudRateDropdown.BackColor = System.Drawing.SystemColors.Window;
            this.baudRateDropdown.FormattingEnabled = true;
            this.baudRateDropdown.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.baudRateDropdown.Location = new System.Drawing.Point(110, 70);
            this.baudRateDropdown.Name = "baudRateDropdown";
            this.baudRateDropdown.Size = new System.Drawing.Size(121, 21);
            this.baudRateDropdown.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Baud Rate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "COM Port";
            // 
            // comPortDropdown
            // 
            this.comPortDropdown.FormattingEnabled = true;
            this.comPortDropdown.Location = new System.Drawing.Point(111, 31);
            this.comPortDropdown.Name = "comPortDropdown";
            this.comPortDropdown.Size = new System.Drawing.Size(121, 21);
            this.comPortDropdown.TabIndex = 0;
            // 
            // digIOPage
            // 
            this.digIOPage.Controls.Add(this.label13);
            this.digIOPage.Controls.Add(this.label12);
            this.digIOPage.Controls.Add(this.label11);
            this.digIOPage.Controls.Add(this.label10);
            this.digIOPage.Controls.Add(this.label9);
            this.digIOPage.Controls.Add(this.label8);
            this.digIOPage.Controls.Add(this.label7);
            this.digIOPage.Controls.Add(this.label6);
            this.digIOPage.Controls.Add(this.tickPC7);
            this.digIOPage.Controls.Add(this.tickPC6);
            this.digIOPage.Controls.Add(this.tickPC5);
            this.digIOPage.Controls.Add(this.tickPC4);
            this.digIOPage.Controls.Add(this.tickPC3);
            this.digIOPage.Controls.Add(this.tickPC2);
            this.digIOPage.Controls.Add(this.tickPC1);
            this.digIOPage.Controls.Add(this.tickPC0);
            this.digIOPage.Controls.Add(this.label5);
            this.digIOPage.Controls.Add(this.label4);
            this.digIOPage.Controls.Add(this.pa4LED);
            this.digIOPage.Controls.Add(this.pa5LED);
            this.digIOPage.Controls.Add(this.pa3LED);
            this.digIOPage.Controls.Add(this.pa6LED);
            this.digIOPage.Controls.Add(this.pa7LED);
            this.digIOPage.Controls.Add(this.pa2LED);
            this.digIOPage.Controls.Add(this.pa1LED);
            this.digIOPage.Controls.Add(this.pa0LED);
            this.digIOPage.Controls.Add(this.sevenSegment2);
            this.digIOPage.Controls.Add(this.sevenSegment1);
            this.digIOPage.Location = new System.Drawing.Point(4, 22);
            this.digIOPage.Name = "digIOPage";
            this.digIOPage.Padding = new System.Windows.Forms.Padding(3);
            this.digIOPage.Size = new System.Drawing.Size(428, 616);
            this.digIOPage.TabIndex = 1;
            this.digIOPage.Text = "Digital I/O";
            this.digIOPage.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(91, 307);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(27, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "PA7";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(91, 277);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "PA6";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(91, 248);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "PA5";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(91, 190);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "PA3";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(91, 219);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "PA4";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(91, 161);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "PA2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(91, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "PA1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(91, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "PA0";
            // 
            // tickPC7
            // 
            this.tickPC7.AutoSize = true;
            this.tickPC7.Location = new System.Drawing.Point(215, 305);
            this.tickPC7.Name = "tickPC7";
            this.tickPC7.Size = new System.Drawing.Size(46, 17);
            this.tickPC7.TabIndex = 11;
            this.tickPC7.Text = "PC7";
            this.tickPC7.UseVisualStyleBackColor = true;
            // 
            // tickPC6
            // 
            this.tickPC6.AutoSize = true;
            this.tickPC6.Location = new System.Drawing.Point(215, 275);
            this.tickPC6.Name = "tickPC6";
            this.tickPC6.Size = new System.Drawing.Size(46, 17);
            this.tickPC6.TabIndex = 10;
            this.tickPC6.Text = "PC6";
            this.tickPC6.UseVisualStyleBackColor = true;
            // 
            // tickPC5
            // 
            this.tickPC5.AutoSize = true;
            this.tickPC5.Location = new System.Drawing.Point(215, 246);
            this.tickPC5.Name = "tickPC5";
            this.tickPC5.Size = new System.Drawing.Size(46, 17);
            this.tickPC5.TabIndex = 9;
            this.tickPC5.Text = "PC5";
            this.tickPC5.UseVisualStyleBackColor = true;
            // 
            // tickPC4
            // 
            this.tickPC4.AutoSize = true;
            this.tickPC4.Location = new System.Drawing.Point(215, 217);
            this.tickPC4.Name = "tickPC4";
            this.tickPC4.Size = new System.Drawing.Size(46, 17);
            this.tickPC4.TabIndex = 8;
            this.tickPC4.Text = "PC4";
            this.tickPC4.UseVisualStyleBackColor = true;
            // 
            // tickPC3
            // 
            this.tickPC3.AutoSize = true;
            this.tickPC3.Location = new System.Drawing.Point(215, 188);
            this.tickPC3.Name = "tickPC3";
            this.tickPC3.Size = new System.Drawing.Size(46, 17);
            this.tickPC3.TabIndex = 7;
            this.tickPC3.Text = "PC3";
            this.tickPC3.UseVisualStyleBackColor = true;
            // 
            // tickPC2
            // 
            this.tickPC2.AutoSize = true;
            this.tickPC2.Location = new System.Drawing.Point(215, 159);
            this.tickPC2.Name = "tickPC2";
            this.tickPC2.Size = new System.Drawing.Size(46, 17);
            this.tickPC2.TabIndex = 6;
            this.tickPC2.Text = "PC2";
            this.tickPC2.UseVisualStyleBackColor = true;
            // 
            // tickPC1
            // 
            this.tickPC1.AutoSize = true;
            this.tickPC1.Location = new System.Drawing.Point(215, 130);
            this.tickPC1.Name = "tickPC1";
            this.tickPC1.Size = new System.Drawing.Size(46, 17);
            this.tickPC1.TabIndex = 5;
            this.tickPC1.Text = "PC1";
            this.tickPC1.UseVisualStyleBackColor = true;
            // 
            // tickPC0
            // 
            this.tickPC0.AutoSize = true;
            this.tickPC0.Location = new System.Drawing.Point(215, 101);
            this.tickPC0.Name = "tickPC0";
            this.tickPC0.Size = new System.Drawing.Size(46, 17);
            this.tickPC0.TabIndex = 4;
            this.tickPC0.Text = "PC0";
            this.tickPC0.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(258, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "PORTC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(90, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "PINA";
            // 
            // portsLightsPage
            // 
            this.portsLightsPage.Controls.Add(this.groupBox4);
            this.portsLightsPage.Controls.Add(this.groupBox3);
            this.portsLightsPage.Location = new System.Drawing.Point(4, 22);
            this.portsLightsPage.Name = "portsLightsPage";
            this.portsLightsPage.Padding = new System.Windows.Forms.Padding(3);
            this.portsLightsPage.Size = new System.Drawing.Size(428, 616);
            this.portsLightsPage.TabIndex = 2;
            this.portsLightsPage.Text = "Ports-Lights";
            this.portsLightsPage.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lampPercentDisplay);
            this.groupBox4.Controls.Add(this.lampIntensityScroll);
            this.groupBox4.Controls.Add(this.lightDisplay);
            this.groupBox4.Location = new System.Drawing.Point(6, 322);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(416, 288);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Light";
            // 
            // lampPercentDisplay
            // 
            this.lampPercentDisplay.Location = new System.Drawing.Point(139, 225);
            this.lampPercentDisplay.Name = "lampPercentDisplay";
            this.lampPercentDisplay.ReadOnly = true;
            this.lampPercentDisplay.Size = new System.Drawing.Size(45, 20);
            this.lampPercentDisplay.TabIndex = 6;
            // 
            // lampIntensityScroll
            // 
            this.lampIntensityScroll.Location = new System.Drawing.Point(94, 55);
            this.lampIntensityScroll.Maximum = 9;
            this.lampIntensityScroll.Minimum = -100;
            this.lampIntensityScroll.Name = "lampIntensityScroll";
            this.lampIntensityScroll.Size = new System.Drawing.Size(31, 190);
            this.lampIntensityScroll.TabIndex = 5;
            this.lampIntensityScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.lampIntensityScroll_Scroll);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pot2VoltageDisplay);
            this.groupBox3.Controls.Add(this.pot1VoltageDisplay);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(416, 310);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ports";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(227, 31);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(147, 25);
            this.label15.TabIndex = 1;
            this.label15.Text = "Pot2 Voltage";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(36, 31);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(147, 25);
            this.label14.TabIndex = 0;
            this.label14.Text = "Pot1 Voltage";
            // 
            // tempControl
            // 
            this.tempControl.Controls.Add(this.setpointTemp);
            this.tempControl.Controls.Add(this.kpTuning);
            this.tempControl.Controls.Add(this.kiTuning);
            this.tempControl.Controls.Add(this.label21);
            this.tempControl.Controls.Add(this.label20);
            this.tempControl.Controls.Add(this.motorSpeedDisplay);
            this.tempControl.Controls.Add(this.actualTempDisplay);
            this.tempControl.Controls.Add(this.label19);
            this.tempControl.Controls.Add(this.label18);
            this.tempControl.Controls.Add(this.label17);
            this.tempControl.Controls.Add(this.tempChart);
            this.tempControl.Controls.Add(this.label16);
            this.tempControl.Location = new System.Drawing.Point(4, 22);
            this.tempControl.Name = "tempControl";
            this.tempControl.Padding = new System.Windows.Forms.Padding(3);
            this.tempControl.Size = new System.Drawing.Size(428, 616);
            this.tempControl.TabIndex = 3;
            this.tempControl.Text = "Temp Control";
            this.tempControl.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(23, 281);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(85, 13);
            this.label21.TabIndex = 11;
            this.label21.Text = "Motor Speed [%]";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(25, 228);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(83, 13);
            this.label20.TabIndex = 10;
            this.label20.Text = "Actual Temp [C]";
            // 
            // motorSpeedDisplay
            // 
            this.motorSpeedDisplay.Enabled = false;
            this.motorSpeedDisplay.Location = new System.Drawing.Point(15, 297);
            this.motorSpeedDisplay.Name = "motorSpeedDisplay";
            this.motorSpeedDisplay.ReadOnly = true;
            this.motorSpeedDisplay.Size = new System.Drawing.Size(100, 20);
            this.motorSpeedDisplay.TabIndex = 9;
            this.motorSpeedDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // actualTempDisplay
            // 
            this.actualTempDisplay.Enabled = false;
            this.actualTempDisplay.Location = new System.Drawing.Point(15, 244);
            this.actualTempDisplay.Name = "actualTempDisplay";
            this.actualTempDisplay.ReadOnly = true;
            this.actualTempDisplay.Size = new System.Drawing.Size(100, 20);
            this.actualTempDisplay.TabIndex = 8;
            this.actualTempDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(18, 151);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(16, 13);
            this.label19.TabIndex = 7;
            this.label19.Text = "Ki";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(16, 118);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(20, 13);
            this.label18.TabIndex = 6;
            this.label18.Text = "Kp";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(34, 87);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 13);
            this.label17.TabIndex = 5;
            this.label17.Text = "PI Tuning";
            // 
            // tempChart
            // 
            chartArea2.Name = "ChartArea1";
            this.tempChart.ChartAreas.Add(chartArea2);
            this.tempChart.Location = new System.Drawing.Point(131, 47);
            this.tempChart.Name = "tempChart";
            this.tempChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series2.IsXValueIndexed = true;
            series2.Name = "Series1";
            series2.YValuesPerPoint = 4;
            this.tempChart.Series.Add(series2);
            this.tempChart.Size = new System.Drawing.Size(292, 300);
            this.tempChart.TabIndex = 2;
            this.tempChart.Text = "chart1";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(12, 21);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(109, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "Setpoint Temp [C]";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // serialPortStatusLED
            // 
            this.serialPortStatusLED.Location = new System.Drawing.Point(185, 153);
            this.serialPortStatusLED.Name = "serialPortStatusLED";
            this.serialPortStatusLED.On = true;
            this.serialPortStatusLED.Size = new System.Drawing.Size(75, 23);
            this.serialPortStatusLED.TabIndex = 6;
            this.serialPortStatusLED.Text = "ledBulb1";
            // 
            // pa4LED
            // 
            this.pa4LED.Color = System.Drawing.Color.Red;
            this.pa4LED.Location = new System.Drawing.Point(51, 214);
            this.pa4LED.Name = "pa4LED";
            this.pa4LED.On = true;
            this.pa4LED.Size = new System.Drawing.Size(75, 23);
            this.pa4LED.TabIndex = 19;
            // 
            // pa5LED
            // 
            this.pa5LED.Color = System.Drawing.Color.Red;
            this.pa5LED.Location = new System.Drawing.Point(51, 243);
            this.pa5LED.Name = "pa5LED";
            this.pa5LED.On = true;
            this.pa5LED.Size = new System.Drawing.Size(75, 23);
            this.pa5LED.TabIndex = 18;
            // 
            // pa3LED
            // 
            this.pa3LED.Color = System.Drawing.Color.Red;
            this.pa3LED.Location = new System.Drawing.Point(51, 185);
            this.pa3LED.Name = "pa3LED";
            this.pa3LED.On = true;
            this.pa3LED.Size = new System.Drawing.Size(75, 23);
            this.pa3LED.TabIndex = 17;
            // 
            // pa6LED
            // 
            this.pa6LED.Color = System.Drawing.Color.Red;
            this.pa6LED.Location = new System.Drawing.Point(51, 272);
            this.pa6LED.Name = "pa6LED";
            this.pa6LED.On = true;
            this.pa6LED.Size = new System.Drawing.Size(75, 23);
            this.pa6LED.TabIndex = 16;
            // 
            // pa7LED
            // 
            this.pa7LED.Color = System.Drawing.Color.Red;
            this.pa7LED.Location = new System.Drawing.Point(51, 302);
            this.pa7LED.Name = "pa7LED";
            this.pa7LED.On = true;
            this.pa7LED.Size = new System.Drawing.Size(75, 23);
            this.pa7LED.TabIndex = 15;
            // 
            // pa2LED
            // 
            this.pa2LED.Color = System.Drawing.Color.Red;
            this.pa2LED.Location = new System.Drawing.Point(51, 156);
            this.pa2LED.Name = "pa2LED";
            this.pa2LED.On = true;
            this.pa2LED.Size = new System.Drawing.Size(75, 23);
            this.pa2LED.TabIndex = 14;
            // 
            // pa1LED
            // 
            this.pa1LED.Color = System.Drawing.Color.Red;
            this.pa1LED.Location = new System.Drawing.Point(51, 127);
            this.pa1LED.Name = "pa1LED";
            this.pa1LED.On = true;
            this.pa1LED.Size = new System.Drawing.Size(75, 23);
            this.pa1LED.TabIndex = 13;
            // 
            // pa0LED
            // 
            this.pa0LED.Color = System.Drawing.Color.Red;
            this.pa0LED.Location = new System.Drawing.Point(51, 98);
            this.pa0LED.Name = "pa0LED";
            this.pa0LED.On = true;
            this.pa0LED.Size = new System.Drawing.Size(75, 23);
            this.pa0LED.TabIndex = 12;
            // 
            // sevenSegment2
            // 
            this.sevenSegment2.BackColor = System.Drawing.Color.Transparent;
            this.sevenSegment2.ColorBackground = System.Drawing.Color.DarkGray;
            this.sevenSegment2.ColorDark = System.Drawing.Color.DimGray;
            this.sevenSegment2.ColorLight = System.Drawing.Color.Red;
            this.sevenSegment2.CustomPattern = 0;
            this.sevenSegment2.DecimalOn = false;
            this.sevenSegment2.DecimalShow = true;
            this.sevenSegment2.ElementWidth = 10;
            this.sevenSegment2.ItalicFactor = 0F;
            this.sevenSegment2.Location = new System.Drawing.Point(344, 99);
            this.sevenSegment2.Name = "sevenSegment2";
            this.sevenSegment2.Padding = new System.Windows.Forms.Padding(4);
            this.sevenSegment2.Size = new System.Drawing.Size(37, 64);
            this.sevenSegment2.TabIndex = 3;
            this.sevenSegment2.TabStop = false;
            this.sevenSegment2.Value = null;
            // 
            // sevenSegment1
            // 
            this.sevenSegment1.BackColor = System.Drawing.Color.Transparent;
            this.sevenSegment1.ColorBackground = System.Drawing.Color.DarkGray;
            this.sevenSegment1.ColorDark = System.Drawing.Color.DimGray;
            this.sevenSegment1.ColorLight = System.Drawing.Color.Red;
            this.sevenSegment1.CustomPattern = 0;
            this.sevenSegment1.DecimalOn = false;
            this.sevenSegment1.DecimalShow = true;
            this.sevenSegment1.ElementWidth = 10;
            this.sevenSegment1.ItalicFactor = 0F;
            this.sevenSegment1.Location = new System.Drawing.Point(301, 99);
            this.sevenSegment1.Name = "sevenSegment1";
            this.sevenSegment1.Padding = new System.Windows.Forms.Padding(4);
            this.sevenSegment1.Size = new System.Drawing.Size(37, 64);
            this.sevenSegment1.TabIndex = 2;
            this.sevenSegment1.TabStop = false;
            this.sevenSegment1.Value = null;
            // 
            // lightDisplay
            // 
            this.lightDisplay.BackColor = System.Drawing.Color.Transparent;
            this.lightDisplay.DialColor = System.Drawing.Color.Lavender;
            this.lightDisplay.DialText = "Measured";
            this.lightDisplay.Glossiness = 11.36364F;
            this.lightDisplay.Location = new System.Drawing.Point(224, 55);
            this.lightDisplay.MaxValue = 255F;
            this.lightDisplay.MinValue = 0F;
            this.lightDisplay.Name = "lightDisplay";
            this.lightDisplay.RecommendedValue = 0F;
            this.lightDisplay.Size = new System.Drawing.Size(150, 150);
            this.lightDisplay.TabIndex = 4;
            this.lightDisplay.ThresholdPercent = 0F;
            this.lightDisplay.Value = 0F;
            // 
            // pot2VoltageDisplay
            // 
            this.pot2VoltageDisplay.BackColor = System.Drawing.Color.Transparent;
            this.pot2VoltageDisplay.DialColor = System.Drawing.Color.Lavender;
            this.pot2VoltageDisplay.DialText = "Potentiometer 2";
            this.pot2VoltageDisplay.Glossiness = 11.36364F;
            this.pot2VoltageDisplay.Location = new System.Drawing.Point(225, 95);
            this.pot2VoltageDisplay.MaxValue = 5F;
            this.pot2VoltageDisplay.MinValue = 0F;
            this.pot2VoltageDisplay.Name = "pot2VoltageDisplay";
            this.pot2VoltageDisplay.RecommendedValue = 0F;
            this.pot2VoltageDisplay.Size = new System.Drawing.Size(150, 150);
            this.pot2VoltageDisplay.TabIndex = 3;
            this.pot2VoltageDisplay.ThresholdPercent = 0F;
            this.pot2VoltageDisplay.Value = 0F;
            // 
            // pot1VoltageDisplay
            // 
            this.pot1VoltageDisplay.BackColor = System.Drawing.Color.Transparent;
            this.pot1VoltageDisplay.DialColor = System.Drawing.Color.Lavender;
            this.pot1VoltageDisplay.DialText = "Potentiometer 1";
            this.pot1VoltageDisplay.Glossiness = 11.36364F;
            this.pot1VoltageDisplay.Location = new System.Drawing.Point(34, 95);
            this.pot1VoltageDisplay.MaxValue = 5F;
            this.pot1VoltageDisplay.MinValue = 0F;
            this.pot1VoltageDisplay.Name = "pot1VoltageDisplay";
            this.pot1VoltageDisplay.RecommendedValue = 0F;
            this.pot1VoltageDisplay.Size = new System.Drawing.Size(150, 150);
            this.pot1VoltageDisplay.TabIndex = 2;
            this.pot1VoltageDisplay.ThresholdPercent = 0F;
            this.pot1VoltageDisplay.Value = 0F;
            // 
            // kiTuning
            // 
            this.kiTuning.Location = new System.Drawing.Point(42, 147);
            this.kiTuning.Name = "kiTuning";
            this.kiTuning.Size = new System.Drawing.Size(73, 20);
            this.kiTuning.TabIndex = 12;
            this.kiTuning.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.kiTuning.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // kpTuning
            // 
            this.kpTuning.Location = new System.Drawing.Point(42, 114);
            this.kpTuning.Name = "kpTuning";
            this.kpTuning.Size = new System.Drawing.Size(73, 20);
            this.kpTuning.TabIndex = 13;
            this.kpTuning.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.kpTuning.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // setpointTemp
            // 
            this.setpointTemp.Location = new System.Drawing.Point(15, 47);
            this.setpointTemp.Name = "setpointTemp";
            this.setpointTemp.Size = new System.Drawing.Size(100, 20);
            this.setpointTemp.TabIndex = 14;
            this.setpointTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.setpointTemp.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 666);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "AUT Application Board Control";
            this.tabControl1.ResumeLayout(false);
            this.setupPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.digIOPage.ResumeLayout(false);
            this.digIOPage.PerformLayout();
            this.portsLightsPage.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tempControl.ResumeLayout(false);
            this.tempControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tempChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kiTuning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpTuning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.setpointTemp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage setupPage;
        private System.Windows.Forms.TabPage digIOPage;
        private System.Windows.Forms.TabPage portsLightsPage;
        private System.Windows.Forms.TabPage tempControl;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox baudRateDropdown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comPortDropdown;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Button connectButton;
        private Bulb.LedBulb serialPortStatusLED;
        private System.Windows.Forms.Label label3;
        private DmitryBrant.CustomControls.SevenSegment sevenSegment2;
        private DmitryBrant.CustomControls.SevenSegment sevenSegment1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox tickPC7;
        private System.Windows.Forms.CheckBox tickPC6;
        private System.Windows.Forms.CheckBox tickPC5;
        private System.Windows.Forms.CheckBox tickPC4;
        private System.Windows.Forms.CheckBox tickPC3;
        private System.Windows.Forms.CheckBox tickPC2;
        private System.Windows.Forms.CheckBox tickPC1;
        private System.Windows.Forms.CheckBox tickPC0;
        private Bulb.LedBulb pa4LED;
        private Bulb.LedBulb pa5LED;
        private Bulb.LedBulb pa3LED;
        private Bulb.LedBulb pa6LED;
        private Bulb.LedBulb pa7LED;
        private Bulb.LedBulb pa2LED;
        private Bulb.LedBulb pa1LED;
        private Bulb.LedBulb pa0LED;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox lampPercentDisplay;
        private System.Windows.Forms.VScrollBar lampIntensityScroll;
        private AquaControls.AquaGauge lightDisplay;
        private System.Windows.Forms.GroupBox groupBox3;
        private AquaControls.AquaGauge pot2VoltageDisplay;
        private AquaControls.AquaGauge pot1VoltageDisplay;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Timer appTimer;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataVisualization.Charting.Chart tempChart;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox motorSpeedDisplay;
        private System.Windows.Forms.TextBox actualTempDisplay;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown setpointTemp;
        private System.Windows.Forms.NumericUpDown kpTuning;
        private System.Windows.Forms.NumericUpDown kiTuning;
    }
}
