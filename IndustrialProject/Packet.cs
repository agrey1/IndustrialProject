using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialProject
{
    class Packet
    {
        DateTime timeReceived;
        List<int> bytes = new List<int>();
        List<int> address = new List<int>();
        string originalBytes = "";
        int addressType;
        bool eep = false;
        bool none = false;
        bool invalidAddress = false;
        bool outOfSequence = false;
        bool repeat = false;
        bool invalid = false;

        int port;
        int protocol;
        int sequenceNumber = -1;

        const int ADDRESS_TYPE_PATH = 0;
        const int ADDRESS_TYPE_LOGICAL = 1;

        public Packet(DateTime timeReceived, List<int> bytes, string byteStr, int port)
        {
            this.timeReceived = timeReceived;
            this.bytes = bytes;
            this.port = port;
            this.originalBytes = byteStr;

            if (bytes[0] < 32)
            {
                //Path address byte, look for 254
                addressType = ADDRESS_TYPE_LOGICAL;

                int count = 0;
                foreach (int value in bytes)
                {
                    if (value == 254)
                    {
                        protocol = bytes[count + 1];
                        address.Add(value);
                        break;
                    }
                    else
                    {
                        address.Add(value);
                    }

                    count++;
                }
            }
            else if (bytes[0] < 256)
            {
                //Logical address
                addressType = ADDRESS_TYPE_PATH;
                address.Add(bytes[0]);
                protocol = bytes[1];
            }
            else
            {
                //Invalid address
                invalidAddress = true;
            }
        }

        public string getByteStr()
        {
            string byteStr = "";
            foreach (byte b in bytes)
            {
                byteStr += b.ToString() + " ";
            }

            return byteStr;
        }

        public string getHexStr()
        {
            string hexStr = "";

            foreach(int b in bytes)
            {
                hexStr += Convert.ToByte(b).ToString("X") + " ";
            }

            return hexStr.Trim();
        }

        public string getOriginalData()
        {
            return this.originalBytes;
        }

        public int getDataLength()
        {
            return bytes.Count;
        }

        public DateTime getTime()
        {
            return timeReceived;
        }

        public void setEEP(bool value)
        {
            this.eep = value;
        }

        public bool getEEP()
        {
            return this.eep;
        }

        public void setNone(bool value)
        {
            this.none = value;
        }

        public int getTotalBits()
        {
            return this.bytes.Count * 10;
        }

        public bool getNone()
        {
            return this.none;
        }

        public int getPort()
        {
            return this.port;
        }

        public int getProtocol()
        {
            return protocol;
        }

        public string getAddressStr()
        {
            string addresses = "";

            foreach (int a in address)
            {
                addresses += a.ToString() + ", ";
            }

            if (addresses.EndsWith(", "))
            {
                addresses = addresses.Remove(addresses.Length - 2, 2);
            }

            return addresses;
        }

        public int getSequenceNumber()
        {
            return sequenceNumber;
        }

        public void setSequenceNumber(int number)
        {
            this.sequenceNumber = number;
        }

        public bool getInvalidAddress()
        {
            return invalidAddress;
        }

        public bool getOutOfSequence()
        {
            return outOfSequence;
        }

        public bool getRepeat()
        {
            return repeat;
        }

        public void setRepeat(bool value)
        {
            this.repeat = value;
        }

        public void setOutOfSequence(bool value)
        {
            outOfSequence = value;
        }

        public void setInvalid(bool value)
        {
            this.invalid = value;
        }

        public bool getInvalid()
        {
            return this.invalid;
        }

        public bool hasError()
        {
            return (invalidAddress || outOfSequence || eep || none || repeat || invalid);
        }

        public List<int> getBytes()
        {
            return this.bytes;
        }
    }
}
