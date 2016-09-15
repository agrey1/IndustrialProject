using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public Form1()
        {
            InitializeComponent();
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

            while (linePanels.Count < tabControl1.TabCount)
            {
                linePanels.Add(new List<Panel>());
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
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
            }

            if (backgroundWorker1.IsBusy != true)
            {
                alert = new LoadingForm(); // LoadingForm
                alert.Canceled += new EventHandler<EventArgs>(button1_Click); // Event handler for the Cancel button in LoadingForm
                alert.Show(); // Show LoadingForm
                Console.WriteLine("Before background worker");
                backgroundWorker1.RunWorkerAsync(); // Start the asynchronous operation
            }
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
            Console.WriteLine("ProgressedChanged!");

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
                foreach (Packet packet in sample.getPackets())
                {
                    packets = sample.getPackets();
                    packetCountLabel.Text = packets.Count.ToString();

                    //Todo: Display number of erronous packets
                    startTimeLabel.Text = sample.getStartTime().ToString();
                    endTimeLabel.Text = sample.getEndTime().ToString();

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
                    subItems[1].Text = packet.getPort().ToString();
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
                    if (count > 0)
                    {
                        if (packets[count - 1].getSequenceNumber() != packet.getSequenceNumber() - 1)
                        {
                            errorStr += "Out of sequence, ";
                            packet.setOutOfSequence(true);
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
                        int x = packetListView.Parent.Location.X + packetListView.Location.X + 660;
                        int y = packetListView.Parent.Location.Y + packetListView.Location.Y + 78;
                        int drawY = (int)((float)(packetListView.Height - 35) * ((float)count / (float)sample.getPackets().Count));

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
                       

                    packetListView.Items.Add(item);
                    count++;
                }


                //Todo: Display average data rate (After data rate has been found)
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
                packetContentTextBox.Text = sample.getPackets()[packetListView.SelectedIndices[0]].getHexStr();
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
    }
}
