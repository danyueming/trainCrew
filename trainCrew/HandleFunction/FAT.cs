using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace trainCrew.HandleFunction
{
    public class FAT
    {
        public int FATID { get; set; }
        public string name { get; set; }

        public TimeSpan startTime { get; set; }

        public TimeSpan endTime { get; set; }
    }
}