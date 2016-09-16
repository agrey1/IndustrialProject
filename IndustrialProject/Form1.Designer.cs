namespace IndustrialProject
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataRateOverTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorLocationsInTeTrafficToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unexpectedDataValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.packetRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBoxPort1 = new System.Windows.Forms.GroupBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.webBrowserPort1_single = new System.Windows.Forms.WebBrowser();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.packetContentTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.nextErrorButton = new System.Windows.Forms.Button();
            this.packetListView = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAverageDataRate = new System.Windows.Forms.Label();
            this.endTimeLabel = new System.Windows.Forms.Label();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.errorCountLabel = new System.Windows.Forms.Label();
            this.packetCountLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonLoadBrowser = new System.Windows.Forms.Button();
            this.webBrowserPort1 = new System.Windows.Forms.WebBrowser();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBoxPort1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.editToolStripMenuItem1,
            this.viewToolStripMenuItem1,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1370, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator2,
            this.exportToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.printToolStripMenuItem});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.openToolStripMenuItem.Text = "Open recorded traffic file(s)";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(216, 6);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.exportToolStripMenuItem.Text = "Export as JSON";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(219, 22);
            this.toolStripMenuItem1.Text = "Print";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(216, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.printToolStripMenuItem.Text = "Quit";
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            this.editToolStripMenuItem1.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem1.Text = "Edit";
            // 
            // viewToolStripMenuItem1
            // 
            this.viewToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataRateOverTimeToolStripMenuItem,
            this.errorLocationsInTeTrafficToolStripMenuItem,
            this.unexpectedDataValuesToolStripMenuItem,
            this.packetRateToolStripMenuItem});
            this.viewToolStripMenuItem1.Name = "viewToolStripMenuItem1";
            this.viewToolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem1.Text = "View";
            this.viewToolStripMenuItem1.Click += new System.EventHandler(this.viewToolStripMenuItem1_Click);
            // 
            // dataRateOverTimeToolStripMenuItem
            // 
            this.dataRateOverTimeToolStripMenuItem.Name = "dataRateOverTimeToolStripMenuItem";
            this.dataRateOverTimeToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.dataRateOverTimeToolStripMenuItem.Text = "Data rate over time";
            // 
            // errorLocationsInTeTrafficToolStripMenuItem
            // 
            this.errorLocationsInTeTrafficToolStripMenuItem.Name = "errorLocationsInTeTrafficToolStripMenuItem";
            this.errorLocationsInTeTrafficToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.errorLocationsInTeTrafficToolStripMenuItem.Text = "Error locations in the traffic";
            this.errorLocationsInTeTrafficToolStripMenuItem.Click += new System.EventHandler(this.errorLocationsInTeTrafficToolStripMenuItem_Click);
            // 
            // unexpectedDataValuesToolStripMenuItem
            // 
            this.unexpectedDataValuesToolStripMenuItem.Name = "unexpectedDataValuesToolStripMenuItem";
            this.unexpectedDataValuesToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.unexpectedDataValuesToolStripMenuItem.Text = "Unexpected data values";
            // 
            // packetRateToolStripMenuItem
            // 
            this.packetRateToolStripMenuItem.Name = "packetRateToolStripMenuItem";
            this.packetRateToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.packetRateToolStripMenuItem.Text = "Packet rate";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userManualToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // userManualToolStripMenuItem
            // 
            this.userManualToolStripMenuItem.Name = "userManualToolStripMenuItem";
            this.userManualToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.userManualToolStripMenuItem.Text = "User manual";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 36);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1423, 573);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox8);
            this.tabPage1.Controls.Add(this.groupBox10);
            this.tabPage1.Controls.Add(this.groupBox9);
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBoxPort1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1415, 547);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Overview";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Location = new System.Drawing.Point(1050, 264);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(342, 252);
            this.groupBox8.TabIndex = 8;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Port 8";
            // 
            // groupBox10
            // 
            this.groupBox10.Location = new System.Drawing.Point(702, 264);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(342, 252);
            this.groupBox10.TabIndex = 8;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Port 7";
            // 
            // groupBox9
            // 
            this.groupBox9.Location = new System.Drawing.Point(354, 264);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(342, 252);
            this.groupBox9.TabIndex = 8;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Port 6";
            // 
            // groupBox7
            // 
            this.groupBox7.Location = new System.Drawing.Point(6, 263);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(342, 252);
            this.groupBox7.TabIndex = 9;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Port 5";
            // 
            // groupBox6
            // 
            this.groupBox6.Location = new System.Drawing.Point(1050, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(342, 252);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Port 4";
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(702, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(342, 252);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Port 3";
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(354, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(342, 252);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Port 2";
            // 
            // groupBoxPort1
            // 
            this.groupBoxPort1.Controls.Add(this.webBrowserPort1);
            this.groupBoxPort1.Location = new System.Drawing.Point(6, 6);
            this.groupBoxPort1.Name = "groupBoxPort1";
            this.groupBoxPort1.Size = new System.Drawing.Size(342, 252);
            this.groupBoxPort1.TabIndex = 0;
            this.groupBoxPort1.TabStop = false;
            this.groupBoxPort1.Text = "Port 1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox13);
            this.tabPage2.Controls.Add(this.groupBox12);
            this.tabPage2.Controls.Add(this.groupBox11);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1415, 547);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Port 1";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // webBrowserPort1_single
            // 
            this.webBrowserPort1_single.AllowNavigation = false;
            this.webBrowserPort1_single.Location = new System.Drawing.Point(6, 19);
            this.webBrowserPort1_single.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserPort1_single.Name = "webBrowserPort1_single";
            this.webBrowserPort1_single.ScriptErrorsSuppressed = true;
            this.webBrowserPort1_single.ScrollBarsEnabled = false;
            this.webBrowserPort1_single.Size = new System.Drawing.Size(436, 264);
            this.webBrowserPort1_single.TabIndex = 14;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.packetContentTextBox);
            this.groupBox13.Location = new System.Drawing.Point(685, 301);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(705, 240);
            this.groupBox13.TabIndex = 13;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Packet contents";
            // 
            // packetContentTextBox
            // 
            this.packetContentTextBox.Location = new System.Drawing.Point(6, 19);
            this.packetContentTextBox.Name = "packetContentTextBox";
            this.packetContentTextBox.Size = new System.Drawing.Size(689, 215);
            this.packetContentTextBox.TabIndex = 8;
            this.packetContentTextBox.Text = "";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.buttonLoadBrowser);
            this.groupBox12.Controls.Add(this.webBrowserPort1_single);
            this.groupBox12.Location = new System.Drawing.Point(691, 6);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(695, 289);
            this.groupBox12.TabIndex = 12;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Visualisation";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.nextErrorButton);
            this.groupBox11.Controls.Add(this.packetListView);
            this.groupBox11.Location = new System.Drawing.Point(6, 301);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(673, 240);
            this.groupBox11.TabIndex = 11;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Packet list";
            // 
            // nextErrorButton
            // 
            this.nextErrorButton.Location = new System.Drawing.Point(592, 211);
            this.nextErrorButton.Name = "nextErrorButton";
            this.nextErrorButton.Size = new System.Drawing.Size(75, 23);
            this.nextErrorButton.TabIndex = 15;
            this.nextErrorButton.Tag = "#";
            this.nextErrorButton.Text = "Next Error";
            this.nextErrorButton.UseVisualStyleBackColor = true;
            this.nextErrorButton.Click += new System.EventHandler(this.nextErrorButton_Click);
            // 
            // packetListView
            // 
            this.packetListView.FullRowSelect = true;
            this.packetListView.Location = new System.Drawing.Point(6, 19);
            this.packetListView.MultiSelect = false;
            this.packetListView.Name = "packetListView";
            this.packetListView.Size = new System.Drawing.Size(661, 186);
            this.packetListView.TabIndex = 10;
            this.packetListView.UseCompatibleStateImageBehavior = false;
            this.packetListView.SelectedIndexChanged += new System.EventHandler(this.packetListView_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblAverageDataRate);
            this.groupBox1.Controls.Add(this.endTimeLabel);
            this.groupBox1.Controls.Add(this.startTimeLabel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.errorCountLabel);
            this.groupBox1.Controls.Add(this.packetCountLabel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 289);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // lblAverageDataRate
            // 
            this.lblAverageDataRate.AutoSize = true;
            this.lblAverageDataRate.Location = new System.Drawing.Point(111, 123);
            this.lblAverageDataRate.Name = "lblAverageDataRate";
            this.lblAverageDataRate.Size = new System.Drawing.Size(0, 13);
            this.lblAverageDataRate.TabIndex = 9;
            // 
            // endTimeLabel
            // 
            this.endTimeLabel.AutoSize = true;
            this.endTimeLabel.Location = new System.Drawing.Point(68, 99);
            this.endTimeLabel.Name = "endTimeLabel";
            this.endTimeLabel.Size = new System.Drawing.Size(0, 13);
            this.endTimeLabel.TabIndex = 8;
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.Location = new System.Drawing.Point(68, 76);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(0, 13);
            this.startTimeLabel.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Average data rate:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "End time:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Start time:";
            // 
            // errorCountLabel
            // 
            this.errorCountLabel.AutoSize = true;
            this.errorCountLabel.Location = new System.Drawing.Point(152, 51);
            this.errorCountLabel.Name = "errorCountLabel";
            this.errorCountLabel.Size = new System.Drawing.Size(0, 13);
            this.errorCountLabel.TabIndex = 3;
            // 
            // packetCountLabel
            // 
            this.packetCountLabel.AutoSize = true;
            this.packetCountLabel.Location = new System.Drawing.Point(123, 26);
            this.packetCountLabel.Name = "packetCountLabel";
            this.packetCountLabel.Size = new System.Drawing.Size(0, 13);
            this.packetCountLabel.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Number of packets errors:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of packets:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.richTextBox2);
            this.groupBox2.Location = new System.Drawing.Point(260, 615);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1094, 84);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Console";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox2.Location = new System.Drawing.Point(10, 19);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(1078, 59);
            this.richTextBox2.TabIndex = 6;
            this.richTextBox2.Text = "";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::IndustrialProject.Properties.Resources.STAR;
            this.pictureBox1.Location = new System.Drawing.Point(12, 615);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(242, 84);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // buttonLoadBrowser
            // 
            this.buttonLoadBrowser.Location = new System.Drawing.Point(459, 203);
            this.buttonLoadBrowser.Name = "buttonLoadBrowser";
            this.buttonLoadBrowser.Size = new System.Drawing.Size(93, 23);
            this.buttonLoadBrowser.TabIndex = 15;
            this.buttonLoadBrowser.Text = "Load browser";
            this.buttonLoadBrowser.UseVisualStyleBackColor = true;
            this.buttonLoadBrowser.Click += new System.EventHandler(this.buttonLoadBrowser_Click);
            // 
            // webBrowserPort1
            // 
            this.webBrowserPort1.Location = new System.Drawing.Point(6, 19);
            this.webBrowserPort1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserPort1.Name = "webBrowserPort1";
            this.webBrowserPort1.ScriptErrorsSuppressed = true;
            this.webBrowserPort1.ScrollBarsEnabled = false;
            this.webBrowserPort1.Size = new System.Drawing.Size(330, 227);
            this.webBrowserPort1.TabIndex = 10;
            this.webBrowserPort1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowserPort1_DocumentCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 711);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "STAR-SpaceWireTrafficViewerAnalyser";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBoxPort1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBoxPort1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem userManualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataRateOverTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem errorLocationsInTeTrafficToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unexpectedDataValuesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem packetRateToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView packetListView;
        private System.Windows.Forms.RichTextBox packetContentTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label errorCountLabel;
        private System.Windows.Forms.Label packetCountLabel;
        private System.Windows.Forms.Label lblAverageDataRate;
        private System.Windows.Forms.Label endTimeLabel;
        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.WebBrowser webBrowserPort1_single;
        private System.Windows.Forms.Button nextErrorButton;
        private System.Windows.Forms.Button buttonLoadBrowser;
        private System.Windows.Forms.WebBrowser webBrowserPort1;

        public object chart { get; internal set; }
    }
}

