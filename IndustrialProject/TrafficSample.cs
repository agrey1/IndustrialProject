using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialProject
{
    class TrafficSample
    {
        DateTime startTime;
        DateTime endTime;
        int sourcePort;
        List<Packet> packets = new List<Packet>();

        public TrafficSample()
        {

        }

        public TrafficSample(DateTime startTime, DateTime endTime, int sourcePort)
        {
            this.startTime = startTime;
            this.endTime = endTime;
            this.sourcePort = sourcePort;
        }

        public void setPackets(List<Packet> packets)
        {
            int sequencePosition = -1;

            //Attempt to find a sequence number
            for (int i = 0; i < packets.Count; i++)
            {
                //Check each byte in the packet until we find it
                List<int> bytes = packets[i].getBytes();
                for (int j = 0; j < bytes.Count; j++)
                {
                    //Look for incrementing bytes in the next 5 packets
                    int sequence = bytes[j];
                    for (int k = 0; k < 5; k++)
                    {
                        if (i + k < packets.Count)
                        {
                            if (packets[i + k].getBytes()[j] == sequence + 1)
                            {
                                if (k == 4)
                                {
                                    //Sequence number found
                                    sequencePosition = j;
                                    break;
                                }

                                sequence++;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (sequencePosition != -1) break;
                }

                if (sequencePosition != -1) break;
            }

            if (sequencePosition != -1)
            {
                foreach (Packet packet in packets)
                {
                    packet.setSequenceNumber(packet.getBytes()[sequencePosition]);
                }
            }

            this.packets = packets.ToList();
        }

        public List<Packet> getPackets()
        {
            return this.packets;
        }

        public DateTime getStartTime()
        {
            return this.startTime;
        }

        /// <summary>
        ///  This function retuns the data rate in bitx per second. 
        /// </summary>
        public double getDataRate()
        {
            return Math.Round((getTotalPacketListSize() / ((packets[packets.Count - 1].getTime()) - packets[0].getTime()).TotalMilliseconds) * 1000, 2);
        }

        /// <summary>
        /// This method retrusn the total size of all the packets in the traffic sample in bits
        /// </summary>
        public int getTotalPacketListSize()
        {
            int totalsize = 0;
            packets.ForEach(packet => totalsize += packet.getTotalBits());
            return totalsize;
        }

        public DateTime getEndTime()
        {
            return this.endTime;
        }

        public int getSourcePort()
        {
            return this.sourcePort;
        }

        public bool isByteStrValid(String str)
        {
            char[] validHex = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };

            if (str.Length == 2)
            {
                foreach (char c in str)
                {
                    if (validHex.Contains(c) == false)
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
