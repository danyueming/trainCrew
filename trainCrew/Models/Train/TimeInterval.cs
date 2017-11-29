using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace trainCrew.Models.Train
{
    public class TimeInterval
    {
        public int TimeIntervalID { get; set; }

        public string type { get; set; }
        public TimeSpan initTime { get; set; }
        public TimeSpan endTime { get; set; }

        public int fat { get; set; }

        public TimeSpan cc;

        public TimeSpan c;

        public TimeInterval()
        {

        }

        public TimeInterval(List<TimeInterval> daFats, TimeSpan now)
        {
            int i;
            TimeSpan lb, ub, final;

            for (i = 0; i < daFats.Count(); i++)
            {
                lb = daFats[i].initTime;
                ub = daFats[i].endTime;
                if (now >= lb && now <= ub)//   当前时间在时间间隔之内，则增加fat
                {
                    final = new TimeSpan(0, daFats[i].fat, 0);
                    initTime = now;
                    endTime = now + final;
                    return;
                }
            }
            endTime = new TimeSpan(0, 5, 0);
            initTime = now;
            endTime = now + endTime;//默认增加5分钟


        }


        /*时间差*/
        public TimeSpan Timelength()
        {
            TimeSpan result;
            result = endTime.Subtract(initTime);
            return result;

        }

    }


}