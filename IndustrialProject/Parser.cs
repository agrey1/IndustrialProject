using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace IndustrialProject
{
    class Parser
    {
        public Parser()
        {

        }

        public TrafficSample parse(string filePath)
        {
            StreamReader reader = new StreamReader(filePath);

            DateTime fileTime = DateTime.Now;
            DateTime endTime = DateTime.Now;
            int sourcePort = 0;

            string tempLine;
            ArrayList lines = new ArrayList();
            while ((tempLine = reader.ReadLine()) != null)
            {
                if (tempLine.Length > 0)
                {
                    if (tempLine != "P")
                    {
                        tempLine += "\n";
                    }

                    if (tempLine == "EOP\n" || tempLine == "EEP\n")
                    {
                        lines[lines.Count - 1] = lines[lines.Count - 1].ToString().Trim();
                    }

                    lines.Add(tempLine);
                }
            }

            List<Packet> packets = new List<Packet>();
            int lineCount = 0;
            foreach (string line in lines)
            {
                if (line.Length > 0)
                {
                    //richTextBox1.AppendText(line);

                    if (lineCount == 0)
                    {
                        fileTime = DateTime.Parse(line);
                    }
                    else if (lineCount == 1)
                    {
                        sourcePort = Convert.ToInt32(line);
                    }
                    else
                    {
                        DateTime packetTime = DateTime.Now;
                        try
                        {
                            packetTime = DateTime.Parse(line);
                        }
                        catch (FormatException exception)
                        {
                            //Console.Write(exception.Message);
                            //this.Close();

                            if (line.Trim() == "E" && lines[lineCount + 1].ToString().Trim().Equals("Disconnect"))
                            {
                                //Disconnect found
                                endTime = DateTime.Parse(lines[lineCount + 2].ToString().Trim());
                            }
                        }

                        List<int> bytes = new List<int>();
                        if (lines.Count - lineCount > 3)
                        {
                            string dataLine = lines[lineCount + 1].ToString() + lines[lineCount + 2].ToString() + lines[lineCount + 3].ToString().Trim();

                            if (dataLine.StartsWith("P") && (dataLine.EndsWith("EOP") || dataLine.EndsWith("EEP") || dataLine.EndsWith("None")))
                            {
                                bool eep = false;
                                bool none = false;
                                if (dataLine.EndsWith("EEP"))
                                {
                                    eep = true;
                                }
                                else if (dataLine.EndsWith("None"))
                                {
                                    none = true;
                                    dataLine = dataLine.Remove(dataLine.Length - 1, 1);
                                }

                                dataLine = dataLine.Remove(0, 1);
                                dataLine = dataLine.Remove(dataLine.Length - 3, 3);
                                string[] byteParts = dataLine.Split(' ');
                                foreach (string byteStr in byteParts)
                                {
                                    Console.WriteLine(byteStr);
                                    int dataByte = Convert.ToInt32(byteStr.Trim(), 16);
                                    bytes.Add(dataByte);
                                }

                                Packet packet = new Packet(packetTime, bytes, sourcePort);
                                packet.setEEP(eep);
                                packet.setNone(none);
                                packets.Add(packet);
                            }
                            else
                            {
                                //Invalid line
                            }
                        }
                    }
                }

                lineCount++;
            }

            reader.Close();

            TrafficSample sample = new TrafficSample(fileTime, endTime, sourcePort);
            sample.setPackets(packets);

            return sample;
        }
    }
}
