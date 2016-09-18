using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndustrialProject
{
    class TabFiller
    {
        private TrafficSample sample;

        public TabFiller(TrafficSample sample)
        {
            this.sample = sample;
        }


        public Label[] fillTabLabels(Label dataRateLabel, Label noOfPacketsLabel, Label packetCountLabel, Label startTimeLabel, Label endTimeLabel)
        {
            //Fill in all the labels
            dataRateLabel.Text = sample.getDataRate().ToString() + " (bit/s)";
            //noOfPacketErrorsLabel.Text = 
            packetCountLabel.Text = sample.getPackets().Count.ToString();
            startTimeLabel.Text = sample.getStartTime().ToString();
            endTimeLabel.Text = sample.getEndTime().ToString();
            //Return the filled in labels
            return new Label[] { dataRateLabel, noOfPacketsLabel, packetCountLabel, startTimeLabel, endTimeLabel };
        }

        public Control[] fillPackeListAndContentBox(RichTextBox packetContentTextBox, ListView packetListView, Point parentLocation)
        {
            if (packetContentTextBox != null && packetListView != null)
            {
                //tabControl1.SelectedIndex = tabControl1.TabCount - 1;
                
                int count = 0;
                int errorCount = 0;
                List<Packet> packets = sample.getPackets();
                foreach (Packet packet in packets)
                {
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
                        int y = packetListView.Parent.Location.Y + packetListView.Location.Y + 40;
                        int drawY = (int)((float)(packetListView.Height) * ((float)count / (float)sample.getPackets().Count));

                        /*
                        http://www.codeproject.com/Questions/301044/Drawing-line-above-all-the-controls-in-the-form
                        */
                        Panel pan = new Panel();
                        pan.Enabled = false;
                        pan.Width = 15;
                        pan.Height = 1;
                        pan.Location = new Point(x, y + drawY);
                        pan.BackColor = Color.Red;
                        packetListView.Controls.Add(pan);
                        pan.BringToFront();

                        //Store the panel as such that it can be hidden when we switch tabs
                        //linePanels[tabControl1.SelectedIndex].Add(pan);
                    }

                    foreach (ListViewItem.ListViewSubItem subItem in subItems)
                    {
                        item.SubItems.Add(subItem);
                    }

                    if (packet.hasError()) errorCount++;

                    packetListView.Items.Add(item);
                    count++;
                }
                //Todo: Display average data rate (After data rate has been found)
                return new Control[] { packetContentTextBox, packetListView };
            }
            else
            {
                return null;
            }
        }
    }
}

