using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace IndustrialProject
{
    public partial class Form1 : Form
    {
        LoadingForm alert; // Loading window when processing
        string fileName = "";
        Parser parser;
        TrafficSample sample;
        List<Packet> packets;
        List<List<Panel>> linePanels = new List<List<Panel>>();
        string debugFolderPath;
        List<Tuple<TabPage, TrafficSample>> tabpages = new List<Tuple<TabPage, TrafficSample>>();
        string consolelog;
        private delegate void DelegateOpenFile(String s);
        DelegateOpenFile _openFileDelegate;

        public Form1()
        {
            InitializeComponent();

            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
            _openFileDelegate = new DelegateOpenFile(this.OpenFile);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //webBrowser1.Navigate(@"C:\Users\AlexanderGrey\Documents\Visual Studio 2013\Projects\IndustrialProject\IndustrialProject\bin\Debug\test.html");
            //webBrowser1.Navigate("http://www.highcharts.com/demo/bar-stacked");

            //
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Drawing.Icon myIcon = new System.Drawing.Icon(System.Drawing.SystemIcons.Information, 32, 32);
            aboutToolStripMenuItem.Image = myIcon.ToBitmap();

            dataRateOverTimeToolStripMenuItem.Checked = true;

            packetListView.View = View.Details;
            tabControl1.SelectedIndexChanged += new EventHandler(tabViewSelectedIndexChanged);

            string[] columns = { "Time", "Address", "Port", "Sequence Number", "Protocol", "Length", "Errors" };
            ColumnHeader columnHeader;

            foreach (string column in columns)
            {
                columnHeader = new ColumnHeader();
                columnHeader.Text = column;
                this.packetListView.Columns.Add(columnHeader);
            }

            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);

            consoleSavingWorker.DoWork += new DoWorkEventHandler(consoleSavingWorker_DoWork);
            consoleSavingWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            consoleSavingWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(consoleSavingWorker_RunWorkerCompleted);

            while (linePanels.Count < tabControl1.TabCount)
            {
                linePanels.Add(new List<Panel>());
            }

            debugFolderPath = System.AppDomain.CurrentDomain.BaseDirectory;
            
            webBrowserPort1.Navigate(debugFolderPath + "index_written.html");


            // Drawing quick buttons
            assignMenuImages();

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            parser = new Parser();
            sample = parser.parse(fileName, backgroundWorker1);
        }

        /// <summary>
        /// This event handler updates the progress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            alert.Message = "In progress, please wait... " + e.ProgressPercentage.ToString() + "%"; // Update label
            alert.ProgressValue = e.ProgressPercentage; // Update progress bar
        }

        /// <summary>
        /// This event handler deals with the results of the background operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                MessageBox.Show("Cancelled!");
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Error: " + e.Error.Message);
            }
            else
            {
                tabControl1.SelectedIndex = tabControl1.TabCount - 1;

                /*
                packetContentTextBox.AppendText("File start time: " + sample.getStartTime().ToString() + "\n");
                packetContentTextBox.AppendText("File end time: " + sample.getEndTime().ToString() + "\n");
                packetContentTextBox.AppendText("File source port: " + sample.getSourcePort() + "\n");
                */

                int count = 0;
                int errorCount = 0;
                packets = sample.getPackets();

                foreach (Packet packet in sample.getPackets())
                {
                    packetCountLabel.Text = packets.Count.ToString();

                    if (sample.getStartTime().Equals(new DateTime(0)))
                    {
                        startTimeLabel.Text = sample.getPackets()[0].getTime() + " (Missing, used first packet time instead)";
                    }
                    else
                    {
                        startTimeLabel.Text = sample.getStartTime().ToString();
                    }

                    if (sample.getEndTime().Equals(new DateTime(0)))
                    {
                        endTimeLabel.Text = packets[packets.Count - 1].getTime() + " (Missing, used last packet time instead)";
                    }
                    else
                    {
                        endTimeLabel.Text = sample.getEndTime().ToString();
                    }

                    lblAverageDataRate.Text = sample.getDataRate().ToString() + " (bit/s)";

                    /*
                    packetContentTextBox.AppendText("Packet:\n");
                    packetContentTextBox.AppendText("Time: " + packet.getTime().ToString() + " " + packet.getTime().Millisecond.ToString() + "\n");
                    packetContentTextBox.AppendText("Data: " + packet.getByteStr() + "\n");
                    packetContentTextBox.AppendText("EEP: " + packet.getEEP().ToString() + "\n");
                    packetContentTextBox.AppendText("None: " + packet.getNone().ToString() + "\n");
                    */

                    //"Time", "Address", "Port", "Sequence Number", "Protocol", "Length", "Errors"
                    ListViewItem item = new ListViewItem();
                    item.Text = packet.getTime().ToString() + "." + packet.getTime().Millisecond.ToString();
                    List<ListViewItem.ListViewSubItem> subItems = new List<ListViewItem.ListViewSubItem>();
                    subItems.Add(new ListViewItem.ListViewSubItem());
                    subItems[0].Text = packet.getAddressStr();
                    subItems.Add(new ListViewItem.ListViewSubItem());
                    int sourcePort = packet.getPort();
                    if(sourcePort == -1)
                    {
                        subItems[1].Text = "Not found (missing from recording file)";
                    }
                    else
                    {
                        subItems[1].Text = sourcePort.ToString();
                    }
                    subItems.Add(new ListViewItem.ListViewSubItem());
                    subItems[2].Text = packet.getSequenceNumber().ToString();

                    subItems.Add(new ListViewItem.ListViewSubItem());
                    subItems[3].Text = packet.getProtocol().ToString();
                    subItems.Add(new ListViewItem.ListViewSubItem());
                    
                    subItems[4].Text = packet.getDataLength().ToString();
                    subItems.Add(new ListViewItem.ListViewSubItem());
                    string errorStr = "";

                    if (packet.getEEP() == true)
                    {
                        errorStr += "EEP, ";
                    }
                    if (packet.getNone() == true)
                    {
                        errorStr += "None, ";
                    }
                    if (packet.getInvalidAddress() == true)
                    {
                        errorStr += "Invalid Address, ";
                    }
                    if(packet.getInvalid() == true)
                    {
                        errorStr += "Invalid data, ";
                    }
                    if (count > 0)
                    {
                        if (packets[count - 1].getSequenceNumber() != packet.getSequenceNumber() - 1)
                        {
                            if (packets[count - 1].getSequenceNumber() == packet.getSequenceNumber())
                            {
                                errorStr += "Repeat, ";
                                packet.setRepeat(true);
                            }
                            else
                            {
                                errorStr += "Out of sequence, ";
                                packet.setOutOfSequence(true);
                            }
                        }
                    }

                    if (errorStr.EndsWith(", "))
                    {
                        errorStr = errorStr.Remove(errorStr.Length - 2, 2);
                    }
                    subItems[5].Text = errorStr;

                    if (errorStr != "")
                    {
                        item.BackColor = Color.Red;

                        //Draw a red line above the scrollbar
                        int x = packetListView.Parent.Location.X + packetListView.Location.X + packetListView.Width - 1;
                        int y = packetListView.Parent.Location.Y + packetListView.Location.Y + 80;
                        int drawY = (int)((float)(packetListView.Height - 45) * ((float)count / (float)sample.getPackets().Count));

                        /*
                        http://www.codeproject.com/Questions/301044/Drawing-line-above-all-the-controls-in-the-form
                        */
                        Panel pan = new Panel();
                        pan.Enabled = false;
                        pan.Width = 15;
                        pan.Height = 1;
                        pan.Location = new Point(x, y + drawY);
                        pan.BackColor = Color.Red;
                        Controls.Add(pan);
                        pan.BringToFront();

                        //Store the panel as such that it can be hidden when we switch tabs
                        linePanels[tabControl1.SelectedIndex].Add(pan);
                    }

                    foreach (ListViewItem.ListViewSubItem subItem in subItems)
                    {
                        item.SubItems.Add(subItem);
                    }
                       

                    if (packet.hasError()) errorCount++;

                    packetListView.Items.Add(item);
                    count++;
                }
                tabpages.Add(new Tuple<TabPage, TrafficSample>(createNewTab(sample.getSourcePort(), sample), sample));
            }
            // Close the AlertForm
            alert.Close();
        }

        /// <summary>
        /// This is what actually saves the text file 
        /// </summary>
        private void consoleSavingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Create a folder in the mydocuments folder for the project and a logfolder too if they dont' exist
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\IndustrialProject");
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\IndustrialProject\\logs");
            //Write the new file
            StreamWriter file = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\IndustrialProject\\logs\\logfile_" + DateTime.Now.Ticks + ".log");
            file.WriteLine(consolelog);
            file.Close();
        }

        /// <summary>
        /// This event handler deals with the results of saving the text file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void consoleSavingWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                MessageBox.Show("Cancelled writing to the log!");
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Error: " + e.Error.Message);
            }
            else
            {
                MessageBox.Show("Logfile successfully saved in MyDocuments\\IndustrialProject\\logs!");
            }
            // Close the AlertForm
            alert.Close();
        }


        /// <summary>
        /// This event handler cancels the backgroundworker, fired from Cancel button in AlertForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorker1.CancelAsync();
                // Close the AlertForm
                alert.Close();
            }
        }

        private void errorLocationsInTeTrafficToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This method creates a new tab and all the controls for that tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private TabPage createNewTab(int portnum, TrafficSample trafficsample)
        {
            ControlFactory controlfactory = new ControlFactory(trafficsample);
            TabPage tpNewTabPage = new TabPage();
            //Declare all the controls we need 
            GroupBox grpBox1_NewTab, grpBox2_NewTab, grpBox3_NewTab, grpBox4_NewTab;
            Label lblNoOfPackets_NewTab, lblNoOfPacketErrors_NewTab, lblStartTime_NewTab, lblEndTime_NewTab, lblAverageDataRate_NewTab, lblPacketCountResult_NewTab, lblErrorCountResult_NewTab, lblDataRateResult_NewTab, lblStartTimeResult_NewTab, lblEndTimeResult_NewTab;
            //Chart stuff
            Chart chartVisulation_NewTab;
            //WebBrowser
            WebBrowser webVisualisation_NewTab;
            //Packet view
            ListView lstviewPacketView_NewTab;
            //Packet details view
            RichTextBox txtPacketDetails_NewTab;
            //Instantiate labels
            lblNoOfPacketErrors_NewTab = controlfactory.labelFactory(true, new Point(17, 51), "lblNoOfPacketErrorsPort" + portnum, new Size(129, 13), 1, "Number of packet errors:");
            lblNoOfPackets_NewTab = controlfactory.labelFactory(true, new Point(17, 26), "lblNoOfPacketsPort" + portnum, new Size(100, 13), 0, "Number of packets:");
            lblStartTime_NewTab = controlfactory.labelFactory(true, new Point(17, 76), "lblStartTimePort" + portnum, new Size(54, 13), 4, "Start time:");
            lblEndTime_NewTab = controlfactory.labelFactory(true, new Point(17, 99), "lblEndTimePort" + portnum, new Size(51, 13), 5, "End time:");
            lblAverageDataRate_NewTab = controlfactory.labelFactory(true, new Point(17, 123), "lblAverageDataRatePort" + portnum, new Size(0, 13), 10, "Data Rate:");
            lblPacketCountResult_NewTab = controlfactory.labelFactory(true, new Point(123, 26), "lblPacketCountResultPort" + portnum, new Size(0, 13), 2, "");
            lblErrorCountResult_NewTab = controlfactory.labelFactory(true, new Point(152, 51), "lblErrorCountResultPort" + portnum, new Size(0, 13), 3, "");
            lblDataRateResult_NewTab = controlfactory.labelFactory(true, new Point(111, 123), "lblDataRateResultPort" + portnum, new Size(0, 13), 10, "");
            lblStartTimeResult_NewTab = controlfactory.labelFactory(true, new Point(68, 76), "lblStartTimeResultPort" + portnum, new Size(0, 13), 7, "");
            lblEndTimeResult_NewTab = controlfactory.labelFactory(true, new Point(68, 99), "lblEndTimeResultPort" + portnum, new Size(0, 13), 8, "");
            //Instantiate listview
            lstviewPacketView_NewTab = controlfactory.listviewFactory(new Point(6, 19), "lstviewPacketViewPort" + portnum, new Size(661, 215), 10, false);
            lstviewPacketView_NewTab.View = View.Details;
            string[] columns = { "Time", "Address", "Port", "Sequence Number", "Protocol", "Length", "Errors" };
            ColumnHeader columnHeader;
            foreach (string column in columns)
            {
                columnHeader = new ColumnHeader();
                columnHeader.Text = column;
                lstviewPacketView_NewTab.Columns.Add(columnHeader);
            }
            //Instantiate Web Browser
            webVisualisation_NewTab = controlfactory.webbrowserFactory(new Point(429, 25), new Size(20, 20), "webVisualisationPort" + portnum, new Size(250, 250), 14);
            //Instantiate the chart
            chartVisulation_NewTab = controlfactory.chartFactory(new ChartArea(), "chartareaVisualisationPort" + portnum, new Legend(), "legendVisualisationPort" + portnum, new Point(6, 19), "chartVisualisationPort" + portnum, new Series(), "seriesVisualisationPort" + portnum, new Size(683, 264), 9, "chart1");
            //Instantiate the textbox
            txtPacketDetails_NewTab = controlfactory.richtextboxFactory(new Point(6, 19), "txtPacketDetailsPort" + portnum, new Size(689, 215), 8, "");
            //Instantiate groupboxes
            grpBox1_NewTab = controlfactory.groupboxFactory(new List<Control> { lblAverageDataRate_NewTab, lblEndTime_NewTab, lblNoOfPacketErrors_NewTab, lblNoOfPackets_NewTab, lblStartTime_NewTab, lblDataRateResult_NewTab, lblPacketCountResult_NewTab, lblErrorCountResult_NewTab, lblStartTimeResult_NewTab, lblEndTimeResult_NewTab }, new Point(6, 6), "grpBox1Port" + portnum, new Size(416, 289), 0, false, "Details");
            grpBox2_NewTab = controlfactory.groupboxFactory(new List<Control> { chartVisulation_NewTab }, new Point(691, 6), "grpBox2Port" + portnum, new Size(695, 289), 12, false, "Visualisation");
            grpBox3_NewTab = controlfactory.groupboxFactory(new List<Control> { lstviewPacketView_NewTab }, new Point(6, 301), "grpBox3Port" + portnum, new Size(673, 240), 11, false, "Packet list");
            grpBox4_NewTab = controlfactory.groupboxFactory(new List<Control> { txtPacketDetails_NewTab }, new Point(685, 301), "grpBox4Port" + portnum, new Size(705, 240), 13, false, "Packet contents");
            //And finally.. instantiate the tab page
            tpNewTabPage.Controls.AddRange(new Control[] { grpBox1_NewTab, grpBox2_NewTab, grpBox3_NewTab, grpBox4_NewTab });
            tpNewTabPage.Name = "tpPort" + portnum + "TabPage";
            tpNewTabPage.Text = "Port " + portnum;
            tpNewTabPage.TabIndex = 1;
            tpNewTabPage.UseVisualStyleBackColor = true;
            tpNewTabPage.Padding = new System.Windows.Forms.Padding(3);
            tabControl1.TabPages.Add(tpNewTabPage);
            //Fill the things in we need filled in
            TabFiller tabfiller = new TabFiller(sample);
            //Fill in the packet details and the packet contents
            Control[] packetdetailsandcontents = tabfiller. fillPackeListAndContentBox(txtPacketDetails_NewTab, lstviewPacketView_NewTab, grpBox3_NewTab.Location);
            txtPacketDetails_NewTab = (RichTextBox)packetdetailsandcontents[0];
            lstviewPacketView_NewTab = (ListView)packetdetailsandcontents[1];
            //Fill in the labels that need filling in
            Label[] filledlabels = tabfiller.fillTabLabels(lblDataRateResult_NewTab, lblErrorCountResult_NewTab, lblPacketCountResult_NewTab, lblStartTimeResult_NewTab, lblEndTimeResult_NewTab);
            lblDataRateResult_NewTab = filledlabels[0];
            lblPacketCountResult_NewTab = filledlabels[2];
            lblStartTimeResult_NewTab = filledlabels[3];
            lblEndTimeResult_NewTab = filledlabels[4];
            //Return the tabpage
            return tpNewTabPage;
        }

        private void tabViewSelectedIndexChanged(object sender, EventArgs e)
        {
            while (linePanels.Count < tabControl1.TabCount)
            {
                linePanels.Add(new List<Panel>());
            }

            for (int i = 0; i < linePanels.Count; i++)
            {
                if (i == tabControl1.SelectedIndex)
                {
                    foreach (Panel panel in linePanels[i])
                    {
                        panel.Show();
                    }
                }
                else
                {
                    foreach (Panel panel in linePanels[i])
                    {
                        panel.Hide();
                    }
                }
            }
        }

        private void packetListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (packetListView.SelectedIndices.Count > 0)
            {
                packetContentTextBox.Text = "";
                string byteStr = sample.getPackets()[packetListView.SelectedIndices[0]].getOriginalData();
                string[] parts = byteStr.Split(' ');

                foreach(string part in parts)
                {
                    packetContentTextBox.Select(packetContentTextBox.TextLength, 0);

                    if (part.Length > 2 || !sample.isByteStrValid(part))
                    {
                        packetContentTextBox.SelectionBackColor = Color.Red;
                    }

                    packetContentTextBox.AppendText(part);
                    packetContentTextBox.Select(packetContentTextBox.TextLength, 0);
                    packetContentTextBox.SelectionBackColor = Color.White;
                    packetContentTextBox.AppendText(" ");
                }
            }
        }

        private void nextErrorButton_Click(object sender, EventArgs e)
        {
            int current = 0;
            if(packetListView.SelectedIndices.Count > 0)
            {
                current = packetListView.SelectedIndices[0];

                if(current == sample.getPackets().Count - 1)
                {
                    current = 0;
                }
            }

            if (sample != null)
            {
                for (int i = current + 1; i < sample.getPackets().Count; i++)
                {
                    if (sample.getPackets()[i].hasError())
                    {
                        packetListView.Items[i].Selected = true;
                        packetListView.Items[i].Focused = true;
                        packetListView.EnsureVisible(i);
                        packetListView.Select();

                        break;
                    }

                    if(i == sample.getPackets().Count - 1)
                    {
                        MessageBox.Show("The currently open traffic sample does not contain any errors.", "No errors found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please open a traffic recording in order to view the errors contained within.", "No errors to view", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonLoadBrowser_Click(object sender, EventArgs e)
        {
            // Compose a string that consists of three lines.
            string lines = 
                "<!DOCTYPE html><html><head><meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\"/><script   src=\"https://code.jquery.com/jquery-3.1.0.min.js\"   integrity=\"sha256-cCueBR6CsyA4/9szpPfrX3s49M9vUU5BgtiJj06wt/s=\"   crossorigin=\"anonymous\"></script><script src=\"https://code.highcharts.com/highcharts.js\"></script><script src=\"https://code.highcharts.com/modules/data.js\"></script><script src=\"https://code.highcharts.com/modules/exporting.js\"></script><script src=\"https://www.highcharts.com/samples/static/highslide-full.min.js\"></script><script src=\"https://www.highcharts.com/samples/static/highslide.config.js\" charset=\"utf-8\"></script><link rel=\"stylesheet\" type=\"text/css\" href=\"https://www.highcharts.com/samples/static/highslide.css\" /></head><body><script>$(document).ready(function() {var options = {chart: {renderTo: 'container',type: 'spline'},series: [{}]};var data =" +
                "[[1,12],[2,5],[3,18],[4,13],[5,7],[6,4],[7,9],[8,10],[9,15],[10,22]]" + // JSON data goes here
                ";options.series[0].data = data;var chart = new Highcharts.Chart(options);});</script><div id=\"container\" style=\"min-width: 310px; height: 400px; margin: 0 auto\"></div></body></html>";
  
            // Write the string to a file.
            System.IO.StreamWriter file = new System.IO.StreamWriter(debugFolderPath + "index_written.html");
            file.WriteLine(lines);

            file.Close();

            webBrowserPort1_single.Navigate(debugFolderPath + "index_written.html");
        }

        private void webBrowserPort1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowserPort1.Document.Body.Style = "zoom:75%;";
        }

        private void exportConsoleLoglogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtConsoleLog.Text == null)
            {
                MessageBox.Show("There is no text in the log to save!", "Cannot save log!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (consoleSavingWorker.IsBusy != true)
                {
                    consolelog = txtConsoleLog.Text;
                    alert = new LoadingForm(); // LoadingForm
                    alert.Canceled += new EventHandler<EventArgs>(button1_Click); // Event handler for the Cancel button in LoadingForm
                    alert.Show(); // Show LoadingForm
                    Console.WriteLine("Before background worker");
                    consoleSavingWorker.RunWorkerAsync(); // Start the asynchronous operation
                }
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            //we're only interested if a FILE was dropped on the form
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                Array a = (Array)e.Data.GetData(DataFormats.FileDrop);
                if (a != null)
                {
                    string s = a.GetValue(0).ToString();
                    this.BeginInvoke(_openFileDelegate, new Object[] { s });
                    this.Activate();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Loading file: " + ex.Message);

            }
        }

        private void OpenFile(string sFile)
        {
            fileName = sFile;

            if (backgroundWorker1.IsBusy != true)
            {
                alert = new LoadingForm(); // LoadingForm
                alert.Canceled += new EventHandler<EventArgs>(button1_Click); // Event handler for the Cancel button in LoadingForm
                alert.Show(); // Show LoadingForm
                Console.WriteLine("Before background worker");
                backgroundWorker1.RunWorkerAsync(); // Start the asynchronous operation
            }
        }

        void assignMenuImages()
        {
            // ALL ICON IMAGES SOURCED FROM https://www.iconfinder.com/

            // ###
            // BUTTONS
            // ###

            // Quick Load Button
            string loadImagePath = retrieveResourcePath() + "loadicon.png";
            buttonQuickLoad.Image = Image.FromFile(loadImagePath);                      // Retrieve Load Icon path
            buttonQuickLoad.ImageAlign = ContentAlignment.MiddleRight;
            buttonQuickLoad.TextAlign = ContentAlignment.MiddleLeft;

            // Quick Save Button
            string saveImagePath = retrieveResourcePath() + "saveicon.png";             // Retrieve Save Icon path
            buttonQuickSave.Image = Image.FromFile(saveImagePath);
            buttonQuickSave.ImageAlign = ContentAlignment.MiddleRight;
            buttonQuickSave.TextAlign = ContentAlignment.MiddleLeft;

            // Quick Print Button
            string printImagePath = retrieveResourcePath() + "printicon.png";           // Retrieve Print icon path
            buttonQuickPrint.Image = Image.FromFile(printImagePath);
            buttonQuickPrint.ImageAlign = ContentAlignment.MiddleRight;
            buttonQuickPrint.TextAlign = ContentAlignment.MiddleLeft;

            // Quick Manual Button
            string manualImagePath = retrieveResourcePath() + "manualicon.png";         // Retrieve Manual icon path
            buttonQuickManual.Image = Image.FromFile(manualImagePath);
            buttonQuickManual.ImageAlign = ContentAlignment.MiddleRight;
            buttonQuickManual.TextAlign = ContentAlignment.MiddleLeft;

            // Quick About Button
            string aboutImagePath = retrieveResourcePath() + "helpicon.png";            // Retrieve Help icon path
            buttonQuickAbout.Image = Image.FromFile(aboutImagePath);
            buttonQuickAbout.ImageAlign = ContentAlignment.MiddleRight;
            buttonQuickAbout.TextAlign = ContentAlignment.MiddleLeft;

            // Quick Exit Button
            // TESTING ONLY
            string exitImagePath = retrieveResourcePath() + "exiticon.png";             // Retrieve Exit icon path
            buttonQuickExit.Image = Image.FromFile(exitImagePath);
            buttonQuickExit.ImageAlign = ContentAlignment.MiddleRight;
            buttonQuickExit.TextAlign = ContentAlignment.MiddleLeft;



            // ###
            // Menu Strips
            // ###

            // ## File
            // Open file Menu Strip
            openToolStripMenuItem.Image = Image.FromFile(loadImagePath);
            // JSON Export Menu Strip
            exportToolStripMenuItem.Image = Image.FromFile(@"C:\Users\rhysmcdonald\Documents\GitHub\IndustrialProject\IndustrialProject\Resources\loadicon.png");
            // Print file Menu Strip
            quitToolStripMenuItem.Image = Image.FromFile(printImagePath);
            // Exit Menu Strip
            quitToolStripMenuItem.Image = Image.FromFile(exitImagePath);

            // ## Edit

            // ## View
            // Data Rate Over Time Menu Strip
            string overtimeImagePath = retrieveResourcePath() + "rateicon.png";            // Retrieve Help icon path
            dataRateOverTimeToolStripMenuItem.Image = Image.FromFile(overtimeImagePath);
            // Error Locations Menu Strip
            string errorLocImagePath = retrieveResourcePath() + "erroricon.png";            // Retrieve Help icon path
            errorLocationsInTeTrafficToolStripMenuItem.Image = Image.FromFile(errorLocImagePath);
            // Unxpected Data Values Menu Strip
            unexpectedDataValuesToolStripMenuItem.Image = Image.FromFile(aboutImagePath);
            // Packet Rate Menu Strip
            string packetRatePath = retrieveResourcePath() + "overtimeicon.png";            // Retrieve Help icon path
            packetRateToolStripMenuItem.Image = Image.FromFile(packetRatePath);

            // ## Help                     
            // Manual Menu Strip
            userManualToolStripMenuItem.Image = Image.FromFile(manualImagePath);
            // About Menu Strip
            aboutToolStripMenuItem.Image = Image.FromFile(aboutImagePath);


        }

        public string retrieveResourcePath()
        {
            //code
            // Source :- https://msdn.microsoft.com/en-us/library/system.appdomain.basedirectory(v=vs.110).aspx
            string debugFolderPath = System.AppDomain.CurrentDomain.BaseDirectory;
            debugFolderPath += @"Resources\";
            Console.WriteLine(debugFolderPath);
            return debugFolderPath;
        }


        void menuAboutclicked()
        {
            // Hides the current form until the Dialog result from the new form returns ok; Then this form is unhidden
            Help_About help_about = new Help_About();
            this.Hide();
            help_about.ShowDialog();
            this.Show();
        }


        // Quick Load Button
        private void buttonQuickLoad_Click(object sender, EventArgs e)
        {
            // code here
            menuLoadFile();
        }

        // Quick Save Button
        private void buttonQuickSave_Click(object sender, EventArgs e)
        {
            // code
        }

        // Quick Print Button
        private void buttonQuickPrint_Click(object sender, EventArgs e)
        {


            //MessageBox.Show(appFolderPath);
        }

        // Quick About Button
        private void buttonQuickAbout_Click(object sender, EventArgs e)
        {
            menuAboutclicked();
        }

        // Quick Exit Button
        // DEV PURPOSES ONLY
        private void buttonQuickExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // #########
        // Methods for dealing with actions (Load, print etc)
        // #########

        // Loading files method
        void menuLoadFile()
        {
            OpenFileDialog packetCaptureDialog = new OpenFileDialog();
            packetCaptureDialog.Filter = "Packet Capture Files (.rec) | *.rec";
            packetCaptureDialog.FilterIndex = 1;
            packetCaptureDialog.Multiselect = false;

            // Call the ShowDialog method to show the dialog box.
            DialogResult result = packetCaptureDialog.ShowDialog();

            // Process input if the user clicked OK.
            if (result == DialogResult.OK)
            {
                fileName = packetCaptureDialog.FileName;
                txtConsoleLog.AppendText("Succesfully opened " + fileName + "\n");
            }

            if (backgroundWorker1.IsBusy != true)
            {
                alert = new LoadingForm(); // LoadingForm
                alert.Canceled += new EventHandler<EventArgs>(button1_Click); // Event handler for the Cancel button in LoadingForm
                alert.Show(); // Show LoadingForm
                backgroundWorker1.RunWorkerAsync(); // Start the asynchronous operation
            }
        }

        // Printing charts (to printer or image file) method
        void menuPrintFile()
        {
            // code here
        }

        // Save data to files
        void menuSaveFile()
        {
            // code
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuLoadFile();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Code goes here  
            try
            {
                MessageBoxButtons confirm = MessageBoxButtons.YesNo; // Setup Messagebox to yes/no format
                string exitconfirm = "You are about to close the application. Any information might be lost.\n\n Proceed?"; // Giving the Messagebox a custom message
                string exitconfirm2 = "Exit"; // Assigning the messagebox a header/title
                DialogResult confirmexit; // Creates a form dialog result for recording the result from the button press

                confirmexit = MessageBox.Show(exitconfirm, exitconfirm2, confirm); // Giving the dialog result a value based on the messagebox results

                if (confirmexit == System.Windows.Forms.DialogResult.Yes) //Checking if the yes button was pressed and closing the application if so.
                {
                    Application.Exit();
                }
            }
            catch
            {
            }
            // Possibly add a save dialog before exiting?
            // - Pop up, output stream etc...
        }

        private void userManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                MessageBoxButtons userManconfirm = MessageBoxButtons.YesNoCancel;
                string exitconfirm = "This file will open in the broswer. \n Continue?"; // Giving the Messagebox a custom message
                string exitconfirm2 = "Confirm"; // Assigning the messagebox a header/title
                DialogResult confirmexit; // Creates a form dialog result for recording the result from the button press

                confirmexit = MessageBox.Show(exitconfirm, exitconfirm2, userManconfirm); // Giving the dialog result a value based on the messagebox results

                if (confirmexit == System.Windows.Forms.DialogResult.Yes) //Checking if the yes button was pressed and closing the application if so.
                {
                    System.Diagnostics.Process.Start(@"C:\Users\rhysmcdonald\Documents\GitHub\IndustrialProject\IndustrialProject\bin\Debug\user.html");
                    // Causes the system to start the users default browser
                }

            }
            catch { }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuAboutclicked();
        }

        private void buttonQuickExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonQuickLoad_Click_1(object sender, EventArgs e)
        {
            // code here
            menuLoadFile();
        }

        private void buttonQuickSave_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonQuickPrint_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonQuickManual_Click(object sender, EventArgs e)
        {

        }

        private void buttonQuickAbout_Click_1(object sender, EventArgs e)
        {
            menuAboutclicked();
        }

	private void Form1_Resize(object sender, EventArgs e)
        {
            Console.WriteLine(this.Width + ", " + this.Height);

            //https://msdn.microsoft.com/en-us/library/ms951306.aspx
            // Arrange the groupBoxes in a grid formation
            GroupBox[] groupBoxes = new GroupBox[] { groupBoxPort1, groupBox4, groupBox5, groupBox6, groupBox7, groupBox9, groupBox10, groupBox8 };
            int cx = tabControl1.Width / 4;
            int cy = (tabControl1.Height - 20) / 2;
            for (int row = 0; row != 4; ++row)
            {
                for (int col = 0; col != 2; ++col)
                {
                    GroupBox groupBox = groupBoxes[col * 4 + row];
                    groupBox.SetBounds(cx * row, cy * col, cx - 10, cy - 10);
                }
            }
        }
    }
}
