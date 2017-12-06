using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using trainCrew.Models.Train;


namespace trainCrew.HandleFunction
{
    public class Service
    {

        public int ServiceID { get; set; }

        public int RouteLineID { get; set; }//车次号

        public TimeSpan timeDriving { get; set; }//总开车时间 

        public TimeSpan timeContinuosDriving { get; set; }//连续驾驶时间

        public TimeSpan timeLeisure { get; set; }//空闲时间

        public bool hasLunch { get; set; }//午餐
        public FAT fat { get; set; }//高峰期

        public List<TimeInterval> blocks;//时间间隔



        public Service()
        {
            this.timeDriving = new TimeSpan(0, 0, 0);
            this.timeContinuosDriving = new TimeSpan(0, 0, 0);
            this.timeLeisure = new TimeSpan(0, 0, 0);
            this.hasLunch = false;
            this.blocks = new List<TimeInterval>();

        }

        public TimeSpan Timelength()//计算时间差 
        {
            TimeSpan result;
            result = blocks[blocks.Count() - 1].endTime.Subtract(blocks[0].initTime);
            return result;

        }

        public bool push(int dataTripID)//抓取一个车次，并尝试将其堆在此空间中，如果不能堆叠它，返回false，否则true
        {
            RouteLine candidate = Common.routelines[dataTripID];//要入栈的车次
            TimeSpan aux;//辅助变量

            //块为空
            if (blocks.Count() == 0)
            {//加载新快
                _push("Trip", candidate);
                _push("Fat", null);
                timeDriving = timeContinuosDriving = candidate.Timelength();//这个车次的时间差
                return true;

            }

            /****块不为空***/

            //是否插入午餐
            if (!hasLunch)
            {
                /*还没有午餐*/
                if (timeDriving >= Common.generalIntervals["maxTimeDrivingBeforeLunch"])//驾驶时间大于最大驾驶时间
                {
                    hasLunch = true;
                    _push("Lunch", null); // 插入午餐
                    timeContinuosDriving = new TimeSpan(0, 0, 0);//重置连续开车时间为 0

                }

            }

            //是否驾驶时间太长
            if (timeContinuosDriving >= Common.generalIntervals["maxTimeContinuousDriving"])
            {
                timeContinuosDriving = new TimeSpan(0, 0, 0);//重置连续开车时间为 0
                _push("Rest", null);//插入休息
            }

            /**重新初始化**/
            aux = candidate.Timelength();
            aux = timeDriving + aux;

            /*设置条件，看入栈的车次是否符合*/
            if (!(aux < Common.generalIntervals["maxTimeDriving"]))//比最大驾驶时间大
                return false;

            if (!(blocks[blocks.Count() - 1].endTime <= candidate.InitTime))//要入栈的车次的出发时间比原上一班的时间结束时间早
                return false;


            /*候选车次开始入栈*/
            //添加进车次集合
            if (blocks[blocks.Count() - 1].endTime < candidate.InitTime)
            {
                _push("Leisure", candidate.InitTime);//开车时间作为空闲的起始时间
                aux = blocks[blocks.Count() - 1].Timelength();
                timeLeisure = timeLeisure + aux;//空闲时间的长度
            }

            /**重新初始化**/
            aux = candidate.Timelength();
            timeDriving = timeDriving + aux;

            if (blocks[blocks.Count() - 1].type.Equals("Fat"))//正好轮到高峰期
            {
                aux = candidate.Timelength();
                timeContinuosDriving = timeContinuosDriving + aux;
            }
            else
                timeContinuosDriving = new TimeSpan(0, 0, 0);

            _push("RouteLine", candidate);
            _push("Fat", null);
            return true;


        }


        private void _push(string typeName, object source)
        {
            TimeInterval candidate = new TimeInterval();

            if (typeName.Equals("Trip"))//类型为车次
            {
                RouteLine tr = (RouteLine)source;
                candidate.TimeIntervalID = tr.RouteLineID;
                candidate.type = "RouteLine";
                candidate.initTime = tr.InitTime;
                candidate.endTime = tr.EndTime;
                candidate.cc = timeContinuosDriving;
                candidate.c = timeDriving;
                blocks.Add(candidate);
                return;
            }

            // Rest => source == NULL
            else if (typeName.Equals("Rest"))
            {//候选车次是休息模块
                TimeSpan basetime = new TimeSpan(0, 0, 0);
                basetime = blocks[blocks.Count() - 1].endTime;
                TimeSpan next = basetime + Common.generalIntervals["restLength"];
                candidate.TimeIntervalID = -1;
                candidate.type = "Rest";
                candidate.initTime = basetime;
                candidate.endTime = next;
                blocks.Add(candidate);
                return;
            }

        // Fat => source == NULL
            else if (typeName.Equals("Fat"))
            {//候选车次是高峰期模块
                TimeInterval daFat = new TimeInterval(Common.fats, blocks[blocks.Count() - 1].endTime);
                daFat.type = "Fat";
                daFat.TimeIntervalID = -1;
                blocks.Add(daFat);
                return;
            }

        // Leisure
            else if (typeName.Equals("Leisure"))
            {
                TimeSpan leend = new TimeSpan(0,0,0);
                leend = (TimeSpan)source;
                candidate.TimeIntervalID = -1;
                candidate.type = "Leisure";
                candidate.initTime = blocks[blocks.Count() - 1].endTime;
                candidate.endTime = leend;
                if (candidate.Timelength().TotalMinutes < 20)
                    candidate.type = "Fat";
                blocks.Add(candidate);
                return;
            }
            // Lunch => source == NULL
            else if (typeName.Equals("Lunch"))
            {
                TimeSpan basetime = new TimeSpan(0,0,0);
               int result= blocks.Count();
                basetime = blocks[blocks.Count() - 1].endTime;
                TimeSpan next = basetime + Common.generalIntervals["lunchLength"];
                candidate.TimeIntervalID = -1;
                candidate.type = "Lunch";
                candidate.initTime = basetime;
                candidate.endTime = next;
                blocks.Add(candidate);
                return;

            }


            else
            {
                Environment.Exit(0);
            }

        }

    }
}