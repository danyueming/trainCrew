using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace trainCrew.Models.Train
{
    public class Train
    {
        public int TrainID { get; set; }

        public string name { get; set; }

        public Train()
        {
 
        }
        public Train(int TrainID, string name)
        {
            this.TrainID = TrainID;
            this.name = name;
        }

    }
}