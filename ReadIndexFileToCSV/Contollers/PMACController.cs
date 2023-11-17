using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace ReadIndexFileToCSV.Contollers
{
    public class PMACController
    {
        string OriginPath { get; set; }
        string DestinationPath { get; set; }
        string OriginPathIndex { get; set; }
        string DestinationPathIndex { get; set; }
        public PMACController()
        {
            

            OriginPath = ConfigurationManager.AppSettings["dat"];
            DestinationPath = ConfigurationManager.AppSettings["dat"];
            OriginPathIndex = ConfigurationManager.AppSettings["index"];
            DestinationPathIndex = ConfigurationManager.AppSettings["index"];
        }
        public string SiteName(string ChannelID)
        {
            try
            {
                string fileName = DestinationPath;
                fileName = Path.Combine(fileName, ChannelID + ".dat");
                if (File.Exists(fileName))
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                    {
                        reader.BaseStream.Position = 0;
                        char ch;
                        string stTemp = "";
                        for (int i = 0; i < 30; i++)
                        {
                            ch = (char)reader.ReadChar();
                            stTemp = stTemp.Insert(stTemp.Length, Convert.ToString(ch));
                        }
                        return stTemp;
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public byte Strategy(string ChannelID)
        {
            try
            {
                string fileName = DestinationPath;
                fileName = Path.Combine(fileName, ChannelID + ".dat");
                if (File.Exists(fileName))
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                    {
                        reader.BaseStream.Position = 30;
                        return reader.ReadByte();

                    }
                }
                else
                    return 255;
            }
            catch
            {
                return 255;
            }
        }
        public int Year(string ChannelID)
        {
            try
            {
                string fileName = DestinationPath;
                fileName = Path.Combine(fileName, ChannelID + ".dat");
                if (File.Exists(fileName))
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                    {
                        reader.BaseStream.Position = 31;
                        return reader.ReadUInt16();
                    }
                }
                return -8888;
            }
            catch
            {
                return -8888;
            }
        }
        public int Month(string ChannelID)
        {
            try
            {
                string fileName = DestinationPath;
                fileName = Path.Combine(fileName, ChannelID + ".dat");
                if (File.Exists(fileName))
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                    {
                        reader.BaseStream.Position = 33;
                        return reader.ReadUInt16();
                    }
                }
                return -8888;
            }
            catch
            {
                return -8888;
            }
        }
        public int Day(string ChannelID)
        {
            try
            {
                string fileName = DestinationPath;
                fileName = Path.Combine(fileName, ChannelID + ".dat");
                if (File.Exists(fileName))
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                    {
                        reader.BaseStream.Position = 35;
                        return reader.ReadUInt16();
                    }
                }
                return -8888;
            }
            catch
            {
                return -8888;
            }
        }
        public int Hour(string ChannelID)
        {
            try
            {
                string fileName = DestinationPath;
                fileName = Path.Combine(fileName, ChannelID + ".dat");
                if (File.Exists(fileName))
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                    {
                        reader.BaseStream.Position = 37;
                        return reader.ReadUInt16();
                    }
                }
                return -8888;
            }
            catch
            {
                return -8888;
            }
        }
        public int Minute(string ChannelID)
        {
            try
            {
                string fileName = DestinationPath;
                fileName = Path.Combine(fileName, ChannelID + ".dat");
                if (File.Exists(fileName))
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                    {
                        reader.BaseStream.Position = 39;
                        return reader.ReadUInt16();
                    }
                }
                return -8888;
            }
            catch
            {
                return -8888;
            }
        }
        public int Second(string ChannelID)
        {
            try
            {
                string fileName = DestinationPath;
                fileName = Path.Combine(fileName, ChannelID + ".dat");
                if (File.Exists(fileName))
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                    {
                        reader.BaseStream.Position = 41;
                        return reader.ReadUInt16();
                    }
                }
                return -8888;
            }
            catch
            {
                return -8888;
            }
        }
        /// <summary>
        /// The Rate value is return in second(S)
        /// </summary>
        public int Rate(string ChannelID)
        {
            try
            {
                string fileName = DestinationPath;
                fileName = Path.Combine(fileName, ChannelID + ".dat");
                if (File.Exists(fileName))
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                    {
                        reader.BaseStream.Position = 43;
                        return reader.ReadUInt16() / 10;
                    }
                }
                return -8888;
            }
            catch
            {
                return -8888;
            }
        }
        /// <summary>
        /// Return the ChannelName
        /// </summary>
        public string Meansurand(string ChannelID)
        {
            try
            {
                string fileName = DestinationPath;
                fileName = Path.Combine(fileName, ChannelID + ".dat");
                if (File.Exists(fileName))
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                    {
                        reader.BaseStream.Position = 45;
                        char ch;
                        string stTemp = "";
                        for (int i = 0; i < 15; i++)
                        {
                            ch = (char)reader.ReadChar();
                            stTemp = stTemp.Insert(stTemp.Length, Convert.ToString(ch));
                        }
                        return stTemp;
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public string Unit(string ChannelID)
        {
            try
            {
                string fileName = DestinationPath;
                fileName = Path.Combine(fileName, ChannelID + ".dat");
                if (File.Exists(fileName))
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                    {
                        reader.BaseStream.Position = 60;
                        char ch;
                        string stTemp = "";
                        for (int i = 0; i < 10; i++)
                        {
                            ch = (char)reader.ReadChar();
                            stTemp = stTemp.Insert(stTemp.Length, Convert.ToString(ch));
                        }
                        return stTemp;
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public double Range(string ChannelID)
        {
            try
            {
                string fileName = DestinationPath;
                fileName = Path.Combine(fileName, ChannelID + ".dat");
                if (File.Exists(fileName))
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                    {
                        reader.BaseStream.Position = 70;
                        return reader.ReadSingle();
                    }
                }
                return -8888;
            }
            catch
            {
                return -8888;
            }
        }
        public double Offset(string ChannelID)
        {
            try
            {
                string fileName = DestinationPath;
                fileName = Path.Combine(fileName, ChannelID + ".dat");
                if (File.Exists(fileName))
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                    {
                        reader.BaseStream.Position = 74;
                        return reader.ReadSingle();
                    }
                }
                return -8888;
            }
            catch
            {
                return -8888;
            }
        }
        /// <summary>
        /// Return the TimeStamp of first recorded
        /// </summary>
        public Nullable<DateTime> Ftime(string ChannelID)
        {
            try
            {
                string fileName = DestinationPath;
                fileName = Path.Combine(fileName, ChannelID + ".dat");
                if (File.Exists(fileName))
                {
                    var ntn = new DateTime(Year(ChannelID), Month(ChannelID), Day(ChannelID), Hour(ChannelID), Minute(ChannelID), Second(ChannelID));
                    return ntn;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Return the TimeStamp of last recorded 
        /// </summary>
        public Nullable<DateTime> Ltime(string ChannelID)
        {
            try
            {
                string fileName = DestinationPath;
                fileName = Path.Combine(fileName, ChannelID + ".dat");
                if (File.Exists(fileName))
                {
                    //Check type of recording
                    int byes_per_reading = Byes_Per_Reading(ChannelID);
                    if (byes_per_reading <= 0) return null;
                    //==== END ====
                    DateTime dtFtime = (System.DateTime)Ftime(ChannelID);
                    int intRate = Rate(ChannelID);
                    using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                    {
                        double dseconds = (double)(((reader.BaseStream.Length - 78) / byes_per_reading) - 1) * intRate;
                        return dtFtime.AddSeconds(dseconds);
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Return the recorded value at specified timestamp
        /// </summary>
        public double Read(string ChannelID, DateTime TimeStamp)
        {
            try
            {
                string fileName = DestinationPath;
                fileName = Path.Combine(fileName, ChannelID + ".dat");
                if (File.Exists(fileName))
                {
                    DateTime? ftime = Ftime(ChannelID);
                    //Check timespan from begin logging time to reading timestamp
                    TimeSpan spanForSeconds = (TimeSpan)(TimeStamp - ftime);
                    long diff = (long)spanForSeconds.TotalSeconds;
                    if (diff < 0) return -8888;
                    //==== END ====

                    //Check type of recording
                    int byes_per_reading = Byes_Per_Reading(ChannelID);
                    if (byes_per_reading <= 0) return -8888;
                    //==== END ====

                    if (diff % Rate(ChannelID) == 0)
                    {
                        double dbRange = Range(ChannelID), bbb;
                        double dbOffset = Offset(ChannelID);
                        int intRate = Rate(ChannelID);
                        using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                        {
                            reader.BaseStream.Position = 78 + ((diff / intRate) * byes_per_reading);// -byes_per_reading;
                            switch (byes_per_reading)
                            {
                                case 1:// like Pressure
                                    bbb = reader.ReadByte();
                                    if (bbb == 255)
                                        return 0;
                                    return Math.Round((double)((Convert.ToDouble(bbb) * dbRange) / 254.0 + dbOffset), 2);
                                case 2: //Like flow
                                        // bbb = reader.ReadUInt16();
                                    bbb = reader.ReadUInt16();
                                    //if (bbb > 65000)
                                    //    return 0;
                                    if (bbb == 32767)
                                        return -9999.9;
                                    else
                                    {
                                        return Math.Round((double)((Convert.ToDouble(bbb) * dbRange) / 32767.0 + dbOffset), 2);
                                    }

                                case 4://Like Regulo outlet pressure (Max, Min, Mean, Std Dev) read only Mean
                                    reader.BaseStream.Position = 79 + (diff / intRate) * byes_per_reading;
                                    //bbb = reader.ReadByte();
                                    if (reader.ReadByte() == 255)
                                        return 0;
                                    return Math.Round((double)((Convert.ToDouble(reader.ReadByte()) * dbRange) / 254.0 + dbOffset), 2);
                                case 20:
                                    string ccc = reader.ReadString();
                                    if (ccc == "ope")
                                    {
                                        return -3333.3;
                                    }
                                    return -4444.4;
                                default:
                                    return -8888;
                            }
                        }
                    }
                }
                return -8888;
            }
            catch
            {
                return -8888;
            }
        }
        /// <summary>
        /// Return the last recorded value 
        /// </summary>
        public double Lvalue(string ChannelID)
        {
            try
            {
                string fileName = DestinationPath;
                fileName = Path.Combine(fileName, ChannelID + ".dat");
                if (File.Exists(fileName))
                {
                    //Check type of recording
                    int byes_per_reading = Byes_Per_Reading(ChannelID);
                    if (byes_per_reading <= 0) return -8888;
                    //==== END ====
                    double dbRange = Range(ChannelID);
                    double dbOffset = Offset(ChannelID);
                    using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                    {
                        reader.BaseStream.Position = (long)(reader.BaseStream.Length - 2 * byes_per_reading);
                        switch (byes_per_reading)
                        {
                            case 1:// like Pressure
                                if (reader.ReadByte() == 255)
                                    return 0;
                                return Math.Round((double)((Convert.ToDouble(reader.ReadByte()) * dbRange) / 254.0 + dbOffset), 2);
                            case 2: //Like flow
                                if (reader.ReadUInt16() == 32767)
                                    return 0;
                                return Math.Round((double)((Convert.ToDouble(reader.ReadUInt16()) * dbRange) / 32766.0 + dbOffset), 2);
                            case 4://Like Regulo outlet pressure (Max, Min, Mean, Std Dev) read only Mean
                                reader.BaseStream.Position = reader.BaseStream.Position + 1;
                                if (reader.ReadByte() == 255)
                                    return 0;
                                return Math.Round((double)((Convert.ToDouble(reader.ReadByte()) * dbRange) / 254.0 + dbOffset), 2);
                            default:
                                return -8888;
                        }

                    }
                }
                return -8888;
            }
            catch
            {
                return -8888;
            }
        }
        /// <summary>
        /// Return the first recorded value 
        /// </summary>
        public double Fvalue(string ChannelID)
        {
            try
            {
                string fileName = DestinationPath;
                fileName = Path.Combine(fileName, ChannelID + ".dat");
                if (File.Exists(fileName))
                {
                    //Check type of recording
                    int byes_per_reading = Byes_Per_Reading(ChannelID);
                    if (byes_per_reading <= 0) return -8888;
                    //==== END ====
                    double dbRange = Range(ChannelID);
                    double dbOffset = Offset(ChannelID);
                    using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                    {

                        switch (byes_per_reading)
                        {
                            case 1:// like Pressure
                                reader.BaseStream.Position = 77;
                                if (reader.ReadByte() == 255)
                                    return 0;
                                return Math.Round((double)((Convert.ToDouble(reader.ReadByte()) * dbRange) / 254.0 + dbOffset), 2);
                            case 2: //Like flow
                                reader.BaseStream.Position = 76;
                                if (reader.ReadUInt16() == 32767)
                                    return 0;
                                return Math.Round((double)((Convert.ToDouble(reader.ReadUInt16()) * dbRange) / 32766.0 + dbOffset), 2);
                            case 4://Like Regulo outlet pressure (Max, Min, Mean, Std Dev) read only Mean
                                reader.BaseStream.Position = 79;
                                if (reader.ReadByte() == 255)
                                    return 0;
                                return Math.Round((double)((Convert.ToDouble(reader.ReadByte()) * dbRange) / 254.0 + dbOffset), 2);
                            default:
                                return -8888;
                        }

                    }
                }
                return -8888;
            }
            catch
            {
                return -8888;
            }
        }
        /// <summary>
        /// Return the number of bye(s) per record
        /// </summary>
        public int Byes_Per_Reading(string ChannelID)
        {
            try
            {
                switch (Strategy(ChannelID))
                {
                    case 2: return 1;
                    case 3: return 4;
                    case 8: return 2;
                    case 10: return 2;
                    default: return 0;
                }
            }
            catch
            {
                return -8888;
            }
        }
        //===========================================================
        // INDEX FUNCTIONS:
        //===========================================================
        /// <summary>
        /// Return the flow factor
        /// </summary>
        public double Factor(string ChannelID)
        {
            try
            {
                string fileName = DestinationPath;
                fileName = Path.Combine(fileName, ChannelID + ".dat");

                if (File.Exists(fileName))
                {
                    int intRate = Rate(ChannelID);
                    double dbRange = Range(ChannelID);
                    int intByesPerReading = Byes_Per_Reading(ChannelID);
                    using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                    {
                        switch (intByesPerReading)
                        {
                            case 1: return Math.Round((double)(dbRange / 254.0) / (3600.0 / (Convert.ToDouble(intRate))), 3);
                            case 2: return Math.Round((double)(dbRange / 32766.0) / (3600.0 / (Convert.ToDouble(intRate))), 3);
                            case 4: return Math.Round((double)(dbRange / 254.0) / (3600.0 / (Convert.ToDouble(intRate))), 3);
                            default: return -8888;
                        }
                    }
                }
                return -8888;
            }
            catch
            {
                return -8888;
            }
        }
        /// <summary>
        /// Return the first recorded Index value
        /// </summary>
        public double FValueIndex(string ChannelID)
        {
            try
            {
                string fileName = DestinationPathIndex;
                fileName = Path.Combine(fileName, ChannelID + ".IIF");

                if (File.Exists(fileName))
                {
                    double dbFactor = Factor(ChannelID);
                    if (dbFactor != -8888.8)
                    {
                        using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                        {
                            reader.BaseStream.Position = 312; //=313-1
                            return Math.Round((double)(Convert.ToDouble(reader.ReadInt32()) * dbFactor), 2);
                        }
                    }
                }
                return -8888;
            }
            catch
            {
                return -8888;
            }
        }
        /// <summary>
        /// Return the last recorded Index value
        /// </summary>
        public double LValueIndex(string ChannelID)
        {
            try
            {
                string fileName = DestinationPathIndex;
                fileName = Path.Combine(fileName, ChannelID + ".IIF");

                if (File.Exists(fileName))
                {
                    double dbFactor = Factor(ChannelID);
                    if (dbFactor != -8888.8)
                    {
                        using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                        {
                            reader.BaseStream.Position = reader.BaseStream.Length - 4;
                            return Math.Round((double)(Convert.ToDouble(reader.ReadInt32()) * dbFactor), 2);
                        }
                    }
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// Return the TimeStamp of lastrecorded
        /// </summary>
        public Nullable<DateTime> LTimeIndex(string ChannelID)
        {
            try
            {
                string fileName = DestinationPathIndex;
                fileName = Path.Combine(fileName, ChannelID + ".IIF");

                if (File.Exists(fileName))
                {

                    using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                    {
                        reader.BaseStream.Position = reader.BaseStream.Length - 20;
                        int year = reader.ReadUInt16();
                        int month = reader.ReadUInt16();
                        int dayofweek = reader.ReadUInt16();
                        int day = reader.ReadUInt16();
                        int hour = reader.ReadUInt16();
                        int minute = reader.ReadUInt16();
                        int second = reader.ReadUInt16();
                        DateTime dtTemp = new DateTime(year, month, day, hour, minute, second);
                        //reader.BaseStream.Position = reader.BaseStream.Position - 4;
                        //Console.WriteLine("Value :" + reader.ReadInt64());
                        return dtTemp;
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Return the TimeStamp of first recorded
        /// </summary>
        public Nullable<DateTime> FTimeIndex(string ChannelID)
        {
            try
            {
                string fileName = DestinationPathIndex;
                fileName = Path.Combine(fileName, ChannelID + ".IIF");

                if (File.Exists(fileName))
                {

                    using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                    {
                        reader.BaseStream.Position = 296;
                        int year = reader.ReadUInt16();
                        int month = reader.ReadUInt16();
                        int dayofweek = reader.ReadUInt16();
                        int day = reader.ReadUInt16();
                        int hour = reader.ReadUInt16();
                        int minute = reader.ReadUInt16();
                        int second = reader.ReadUInt16();
                        int milisecond = reader.ReadUInt16();
                        DateTime dtTemp = new DateTime(year, month, day, hour, minute, second);
                        //reader.BaseStream.Position = reader.BaseStream.Position - 4;
                        //Console.WriteLine("Value :" + reader.ReadInt64());
                        return dtTemp;
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Return the TimeStamp of the Next recored in compare with given timestamp
        /// </summary>
        public Nullable<DateTime> NextTimeIndex(string ChannelID, DateTime TimeStamp)
        {
            try
            {
                string fileName = DestinationPathIndex;
                fileName = Path.Combine(fileName, ChannelID + ".IIF");

                if (File.Exists(fileName))
                {
                    DateTime dtFirstTime = (DateTime)FTimeIndex(ChannelID);
                    if (dtFirstTime == null) return null;
                    if (TimeStamp < dtFirstTime) return dtFirstTime;
                    using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                    {
                        reader.BaseStream.Position = 296;
                        int year = reader.ReadUInt16();
                        int month = reader.ReadUInt16();
                        int dayofweek = reader.ReadUInt16();
                        int day = reader.ReadUInt16();
                        int hour = reader.ReadUInt16();
                        int minute = reader.ReadUInt16();
                        int second = reader.ReadUInt16();
                        reader.BaseStream.Position += 6;
                        DateTime dtTemp = new DateTime(year, month, day, hour, minute, second);
                        do
                        {
                            year = reader.ReadUInt16();
                            month = reader.ReadUInt16();
                            dayofweek = reader.ReadUInt16();
                            day = reader.ReadUInt16();
                            hour = reader.ReadUInt16();
                            minute = reader.ReadUInt16();
                            second = reader.ReadUInt16();
                            dtTemp = new DateTime(year, month, day, hour, minute, second);
                            reader.BaseStream.Position += 6;
                        }
                        while ((dtTemp <= TimeStamp) && (reader.BaseStream.Position <= reader.BaseStream.Length - 20));
                        if (dtTemp <= TimeStamp) return null;
                        return dtTemp;
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Return the recorded index value at specified timestamp
        /// </summary>
        public double RValueIndex(string ChannelID, DateTime TimeStamp)
        {
            try
            {
                string fileName = DestinationPathIndex;
                fileName = Path.Combine(fileName, ChannelID + ".IIF");

                if (File.Exists(fileName))
                {
                    DateTime dtLastTime = (DateTime)LTimeIndex(ChannelID);
                    DateTime dtFirstTime = (DateTime)FTimeIndex(ChannelID);
                    if ((dtLastTime == null) || (dtFirstTime == null)) return -8888;
                    if ((TimeStamp < dtFirstTime) || (TimeStamp > dtLastTime)) return -8888;
                    double dbFactor = Factor(ChannelID);
                    using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                    {
                        reader.BaseStream.Position = reader.BaseStream.Length - 20;
                        int year = reader.ReadUInt16();
                        int month = reader.ReadUInt16();
                        int dayofweek = reader.ReadUInt16();
                        int day = reader.ReadUInt16();
                        int hour = reader.ReadUInt16();
                        int minute = reader.ReadUInt16();
                        int second = reader.ReadUInt16();
                        reader.BaseStream.Position += 6;
                        DateTime dtTemp = new DateTime(year, month, day, hour, minute, second);
                        do
                        {
                            reader.BaseStream.Position -= 20;
                            year = reader.ReadUInt16();
                            month = reader.ReadUInt16();
                            dayofweek = reader.ReadUInt16();
                            day = reader.ReadUInt16();
                            hour = reader.ReadUInt16();
                            minute = reader.ReadUInt16();
                            second = reader.ReadUInt16();
                            dtTemp = new DateTime(year, month, day, hour, minute, second);
                            reader.BaseStream.Position -= 14;
                            // Console.WriteLine("Do bay a");
                        }
                        while ((dtTemp > TimeStamp) && (reader.BaseStream.Position > 297));
                        if (dtTemp == TimeStamp)
                        {
                            reader.BaseStream.Position += 16;
                            return Math.Round((double)(Convert.ToDouble(reader.ReadInt32()) * dbFactor), 2);
                        }
                        return -8888;
                    }
                }
                return -8888;
            }
            catch
            {
                return -8888;
            }
        }

        public double? GetValue(string channelid, DateTime timeStamp)
        {
            var val = this.Read(channelid, timeStamp);
            if (val == -8888 || val == -9999.9)
            {
                return null;
            }
            else if (val == -3333.3)
            {
                return 1;
            }
            else if (val == -4444.4)
            {
                return 0;
            }
            return val;
        }

        public double? GetIndex(string channelid, DateTime timeStamp)
        {
            var val = this.RValueIndex(channelid, timeStamp);
            if (val == -8888 || val == -9999.9)
            {
                return null;
            }
            return val;
        }
    }
}
