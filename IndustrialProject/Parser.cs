using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.ComponentModel;

namespace IndustrialProject
{
    class Parser
    {
        public Parser()
        {

        }

        public TrafficSample parse(string filePath, BackgroundWorker backgroundWorker1)
        {
            TrafficSample sample = new TrafficSample();
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
                int percentage = (int)Math.Floor(((float)lineCount / lines.Count) * 100);
                backgroundWorker1.ReportProgress(percentage);

                if (line.Length > 0)
                {
                    //richTextBox1.AppendText(line);

                    if (lineCount == 0)
                    {
                        try
                        {
                            fileTime = DateTime.Parse(line);
                        }
                        catch(FormatException e)
                        {
                            fileTime = new DateTime(0);
                        }
                    }
                    else if (lineCount == 1)
                    {
                        try
                        {
                            sourcePort = Convert.ToInt32(line);
                        }
                        catch (FormatException e)
                        {
                            sourcePort = -1;
                        }
                    }
                    else
                    {
                        DateTime packetTime = DateTime.Now;
                        try
                        {
                            if (line.Trim() != "E")
                            {
                                packetTime = DateTime.Parse(line);

                                List<int> bytes = new List<int>();
                                if (lines.Count - lineCount > 3)
                                {
                                    string dataLine = lines[lineCount + 1].ToString() + lines[lineCount + 2].ToString() + lines[lineCount + 3].ToString().Trim();

                                    if (dataLine.StartsWith("P") && (dataLine.EndsWith("EOP") || dataLine.EndsWith("EEP") || dataLine.EndsWith("None")))
                                    {
                                        bool eep = false;
                                        bool none = false;
                                        bool invalid = false;
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
                                            String thisByte = byteStr.Trim().ToLower();

                                            if (invalid == false)
                                            {
                                                invalid = !sample.isByteStrValid(thisByte);
                                            }

                                            int dataByte = 0;
                                            try
                                            {
                                                dataByte = Convert.ToInt32(thisByte, 16);
                                            }
                                            catch (FormatException exception)
                                            {
                                                //Invalid format such as "ZZ"
                                                //Leave this byte as 0
                                            }
                                            catch (ArgumentOutOfRangeException exception)
                                            {
                                                //Empty strings after splitting due to extra spaces in the data string
                                            }

                                            bytes.Add(dataByte);
                                        }

                                        Packet packet = new Packet(packetTime, bytes, dataLine, sourcePort);
                                        packet.setEEP(eep);
                                        packet.setNone(none);
                                        packet.setInvalid(invalid);
                                        packets.Add(packet);
                                    }
                                    else
                                    {
                                        //Invalid line
                                    }
                                }
                            }

                            if (line.Trim() == "E" && lines[lineCount + 1].ToString().Trim().Equals("Disconnect"))
                            {
                                //Disconnect found
                                try
                                {
                                    if (lineCount + 2 > lines.Count - 1)
                                    {
                                        throw new FormatException("End date missing");
                                    }
                                    endTime = DateTime.Parse(lines[lineCount + 2].ToString().Trim());
                                }
                                catch (FormatException ex)
                                {
                                    endTime = new DateTime(0);
                                }
                            }
                        }
                        catch (FormatException exception)
                        {
                            Console.Write("Parse Exception: " + exception.Message);
                            //this.Close();
                        }
                    }
                }

                lineCount++;
            }

            reader.Close();

            sample = new TrafficSample(fileTime, endTime, sourcePort);
            sample.setPackets(packets);

            return sample;
        }
    }
}
