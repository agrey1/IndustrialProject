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

        public TrafficSample(DateTime startTime, DateTime endTime, int sourcePort)
        {
            this.startTime = startTime;
            this.endTime = endTime;
            this.sourcePort = sourcePort;
        }

        public void setPackets(List<Packet> packets)
        {
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

        public DateTime getEndTime()
        {
            return this.endTime;
        }

        public int getSourcePort()
        {
            return this.sourcePort;
        }
    }
}
