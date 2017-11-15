using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace trainCrew.Models.Train
{
 public class Trip
    {
   /*     public Trip()
        {

            this.InitStations = new List<Station>();
            this.EndStations = new List<Station>();
        
        }


       [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Identifier { get; set; }

    */

        public int TripID { get; set; }

        public string Line { get; set; }//线路

        public TimeSpan InitTime { get; set; }//出发时间

        public  virtual Station InitStation { get; set; }//出发站名

        public TimeSpan EndTime { get; set; }//结束时间

        public virtual Station EndStation { get; set; }//到达站名


        
             

    }
}