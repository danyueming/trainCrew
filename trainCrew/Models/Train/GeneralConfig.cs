using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace trainCrew.Models.Train
{
    public class GeneralConfig
    {
        public int GeneralConfigID { get; set; }

        [Display(Name = "司机最大连续驾驶时间")]
        public TimeSpan maxTimeDriving { get; set; }//司机最大连续驾驶时间

         [Display(Name = "司机最大值乘时间")]
        public TimeSpan maxTimeTrip { get; set; }//司机最大值乘时间

         [Display(Name = "司机最大休息时间")]
         public TimeSpan maxTimeRest { get; set; }//司机最大休息时间

         [Display(Name = "就餐时间")]
         public TimeSpan lunchTime { get; set; }//就餐时间

        

        

    }
}