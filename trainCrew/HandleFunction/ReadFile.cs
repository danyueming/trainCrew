using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using trainCrew.Models.Train;

namespace trainCrew.HandleFunction
{
    public class ReadFile
    {
        public void Read()
        {
            int lid = 1;

            StreamReader sR = File.OpenText(@"F:\trainCrew\trainCrew\DAL\test.txt");

            string nextLine;

            while ((nextLine = sR.ReadLine()) != null)
            {
                string[] arr = nextLine.Split('\t');//分割每个字段

                RouteLine result = new RouteLine { RouteLineID = lid, Line = arr[1], InitTime = TimeSpan.Parse(arr[2]), InitStation = arr[3], EndTime = TimeSpan.Parse(arr[4]), EndStation = arr[5] };
                if (result.Timelength().TotalMinutes > 2.5)//超过2分钟
                {
                    Common.routelines.Add(result);//这是个合理的时间段
                    lid++;
                }

            }

            sR.Close();
        }

    }
}