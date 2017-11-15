using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trainCrew.Models.Train
{
    public class Station
    {
        public int StationID { get; set; }

        [Display(Name = "站名")]
        public string StationName {get;set;}//站名

        [Display(Name = "是否允许休息")]
        public Boolean RestAllowed {get;set;}//是否允许换乘/休息

      
    }
}