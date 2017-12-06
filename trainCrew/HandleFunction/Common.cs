using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using trainCrew.Models.Train;

namespace trainCrew.HandleFunction
{
    public class Common
    {
        public static List<TimeInterval> fats;

        public static List<Station> stations;

        public static List<RouteLine> routelines;

        public static List<Service> services;

        public static List<double> fitData;

        public static Dictionary<string, TimeSpan> generalIntervals;


        static Common()
        {
            fats = new List<TimeInterval>
                {

                
                    new TimeInterval {TimeIntervalID = 1,type = "clearance",initTime = new TimeSpan(5,50,0),endTime = new TimeSpan(8,30,0) ,fat=5 },
                    new TimeInterval {TimeIntervalID = 2,type = "clearance",initTime = new TimeSpan(18,0,0),endTime = new TimeSpan(23,0,0) ,fat=3 }
                
                };

            stations = new List<Station> ();

            routelines = new List<RouteLine>();//作业段集合

            services = new List<Service>();

            fitData = new List<double>();



            generalIntervals = new Dictionary<string, TimeSpan>();
            generalIntervals["maxTimeDriving"] = new TimeSpan(0, 8, 0);
            generalIntervals["maxTimeContinuousDriving"] = new TimeSpan(0, 3, 0);
            generalIntervals["maxTimeDrivingBeforeLunch"] = new TimeSpan(0, 3, 0);
            generalIntervals["restLength"] = new TimeSpan(0, 25, 0);
            generalIntervals["lunchLength"] = new TimeSpan(0, 55, 0);
        }

    }
}