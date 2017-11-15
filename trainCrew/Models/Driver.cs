using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trainCrew.Models
{
    public enum Sex//性别
    {
        man = 0,
        woman = 1

    }

  
    public class Driver
    {
        public int DriverID { get; set; }

        [Display(Name = "机班")]
        public int DriverGroupID { get; set; }//机班Id


        [Display(Name = "司机名字")]

        public string DriverName { get; set; }//司机名字


        [Display(Name = "司机性别")]
        public Sex Sex { get; set; }//司机性别

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "司机生日")]
        public DateTime? Birthday { get; set; }//司机生日


        [Display(Name = "司机类型")]
        public string  DriveType { get; set; }//司机类型

       public virtual DriverGroup DriverGroup { get; set; }


    }
}