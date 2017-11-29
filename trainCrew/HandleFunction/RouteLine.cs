using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace trainCrew.HandleFunction
{
    public class RouteLine
    {
        public int RouteLineID { get; set; }

        public string Line { get; set; }//线路

        public TimeSpan InitTime { get; set; }//出发时间

        public string InitStation { get; set; }//出发站名

        public TimeSpan EndTime { get; set; }//结束时间

        public string EndStation { get; set; }//到达站名


        public RouteLine()
        { 

        }



        public TimeSpan Timelength()
        {
            TimeSpan result;
            result = EndTime.Subtract(InitTime);
            return result;

        }

        // 行程的开始时间在fats时间段内
        public TimeSpan preFat()
        {
            bool detected = false; // 默认不松弛
            TimeSpan outtime = new TimeSpan(0, 0, 0);

            for (int i = 0; i < Common.fats.Count() && detected == false; i++)
            {//高峰时刻
                if ((InitTime > Common.fats[i].initTime) && (InitTime <= Common.fats[i].endTime))
                {
                    TimeSpan temp = new TimeSpan(0, Common.fats[i].fat, 0);
                    outtime = temp;
                    detected = true;
                }
            }
            // 默认为3分钟
            if (detected == false)
            {
                TimeSpan temp = new TimeSpan(0, 3, 0);
                outtime = temp;
            }
            return outtime;
        }

        //  行程的结束时间在fats时间段内
        public TimeSpan posFat()
        {
            bool detected = false; //// 默认不松弛
            TimeSpan outtime = new TimeSpan(0, 0, 0);

            for (int i = 0; i < Common.fats.Count() && detected == false; i++)
            {
                if ((EndTime >= Common.fats[i].initTime) && (EndTime < Common.fats[i].endTime))
                {
                    TimeSpan temp = new TimeSpan(0, Common.fats[i].fat, 0);
                    outtime = temp;
                    detected = true;
                }
            }
            // 在3分钟时的默认清除
            if (detected == false)
            {
                TimeSpan temp = new TimeSpan(0, 3, 0);
                outtime = temp;
            }
            return outtime;
        }


    }


}