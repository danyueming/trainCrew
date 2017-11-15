using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace trainCrew.Models
{
    public class DriverGroup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "机班")]
        public int DriverGroupID { get; set; }//机班Id


        [Display(Name = "机队")]
         public int DriverTeamID { get; set; }

        [Display(Name = "机班名")]
        public string DriverGroupName { get; set; }//机班名

        [Display(Name = "机班人数")]
        public int GroupPeople { get; set; }

        public virtual DriverTeam DriverTeam { get; set; }

        public virtual ICollection<Driver> Drivers { get; set; }//机班有任意数量司机


     
    }
}