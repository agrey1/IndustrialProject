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
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            
        }

        private void loadFileButton_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //webBrowser1.Navigate(@"C:\Users\AlexanderGrey\Documents\Visual Studio 2013\Projects\IndustrialProject\IndustrialProject\bin\Debug\test.html");
            //webBrowser1.Navigate("http://www.highcharts.com/demo/bar-stacked");

            //
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Drawing.Icon myIcon = new System.Drawing.Icon(System.Drawing.SystemIcons.Information,32,32);
            aboutToolStripMenuItem.Image = myIcon.ToBitmap();

            dataRateOverTimeToolStripMenuItem.Checked = true;

            packetListView.View = View.Details;

            string[] columns = { "Time", "Address", "Port", "Protocol", "Length", "Errors" };
            ColumnHeader columnHeader;

            foreach(string column in columns)
            {
                columnHeader = new ColumnHeader();
                columnHeader.Text = column;
                this.packetListView.Columns.Add(columnHeader);
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog packetCaptureDialog = new OpenFileDialog();
            packetCaptureDialog.Filter = "Packet Capture Files (.rec) | *.rec";
            packetCaptureDialog.FilterIndex = 1;
            packetCaptureDialog.Multiselect = false;

            // Call the ShowDialog method to show the dialog box.
            DialogResult result = packetCaptureDialog.ShowDialog();

            string fileName = "";
            // Process input if the user clicked OK.
            if (result == DialogResult.OK)
            {
                fileName = packetCaptureDialog.FileName;
            }

            Parser parser = new Parser();
            TrafficSample sample = parser.parse(fileName);

            packetContentTextBox.AppendText("File start time: " + sample.getStartTime().ToString() + "\n");
            packetContentTextBox.AppendText("File end time: " + sample.getEndTime().ToString() + "\n");
            packetContentTextBox.AppendText("File source port: " + sample.getSourcePort() + "\n");

            List < Packet > packets = sample.getPackets();
            packetCountLabel.Text = packets.Count.ToString();

            //Todo: Display number of erronous packets
            startTimeLabel.Text = sample.getStartTime().ToString();
            endTimeLabel.Text = sample.getEndTime().ToString();

            //Todo: Display average data rate (After data rate has been found)

            foreach (Packet packet in sample.getPackets())
            {
                packetContentTextBox.AppendText("Packet:\n");
                packetContentTextBox.AppendText("Time: " + packet.getTime().ToString() + " " + packet.getTime().Millisecond.ToString() + "\n");
                packetContentTextBox.AppendText("Data: " + packet.getByteStr() + "\n");
                packetContentTextBox.AppendText("EEP: " + packet.getEEP().ToString() + "\n");
                packetContentTextBox.AppendText("None: " + packet.getNone().ToString() + "\n");

                //"Time", "Address", "Port", "Protocol", "Length", "Errors"
                ListViewItem item = new ListViewItem();
                item.Text = packet.getTime().ToString() + "." + packet.getTime().Millisecond.ToString();
                List<ListViewItem.ListViewSubItem> subItems = new List<ListViewItem.ListViewSubItem>();
                subItems.Add(new ListViewItem.ListViewSubItem());
                subItems[0].Text = packet.getAddressStr();
                subItems.Add(new ListViewItem.ListViewSubItem());
                subItems[1].Text = packet.getPort().ToString();
                subItems.Add(new ListViewItem.ListViewSubItem());
                subItems[2].Text = packet.getProtocol().ToString();
                subItems.Add(new ListViewItem.ListViewSubItem());
                subItems[3].Text = packet.getDataLength().ToString();
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

                if (errorStr.EndsWith(", "))
                {
                    errorStr = errorStr.Remove(errorStr.Length - 2, 2);
                }
                subItems[4].Text = errorStr;

                foreach(ListViewItem.ListViewSubItem subItem in subItems)
                {
                    item.SubItems.Add(subItem);
                }

                packetListView.Items.Add(item);
            }

            
        }

        private void errorLocationsInTeTrafficToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
