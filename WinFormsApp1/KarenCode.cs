using System;
using System.Collections.Generic;
using System.IO;

namespace WinFormsApp1
{
    public class KarenCode
    {
        public List<TimeZoneInfo> ReadZonesCsv(string filePath)
        {
            List<TimeZoneInfo> timeZones = new List<TimeZoneInfo>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains("IsFixed"))
                        continue;
                    string[] values = line.Split(',');

                    string timeZoneId = values[0];
                    string displayName = values[1];
                    
                    //TimeSpan minOffset = TimeSpan.Parse(values[3]);
                    //TimeSpan maxOffset = TimeSpan.Parse(values[4]);

                    //TimeZoneInfo timeZone = 
                    //    TimeZoneInfo.CreateCustomTimeZone(timeZoneId, minOffset, displayName, displayName, displayName, new TimeZoneInfo.AdjustmentRule[0], isFixed);
                    //timeZones.Add(timeZone);
                }
            }

            return timeZones;
        }
    }
}
