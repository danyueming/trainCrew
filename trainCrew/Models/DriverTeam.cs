using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace trainCrew.Models
{
    public class DriverTeam

    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "机队")]
        public int DriverTeamID { get; set; }//机队ID      

        [Display(Name = "机队名称"), StringLength(50, MinimumLength = 1)]
        public string TeamName { get; set; }//机队名称


        [Display(Name = "机班数目")]
        public int GroupNumber { get; set; }

        [Display(Name = "备注"), StringLength(50, MinimumLength = 1)]
        public string remark { get; set; }

        public virtual ICollection<DriverGroup> DriverGroups { get; set; }//机队有任意数量机班
       
           
    }
}