using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace trainCrew.HandleFunction
{
    public class Phenotype
    {
       
     public   Phenotype() { }

       // Applies the translation algorithm from the genotype to the phenotype(将基因转化为染色体)
      // calling the stacking heuristic using 'push'

        public void init(string genotype)
        {
            
            int i;

            for (i = 0; i < genotype.Length; i++)
            {
                if (genotype[i] == '1')
                    _push(i);
            }

            for (i = 0; i < genotype.Length; i++)
            {
                if (genotype[i] == '0')
                    _push(i);
            }

        }

        // Look for a service within a service List where the Trip fits incoming, //在车次链列表中寻找到一个车次链，使RouteLine能接上
        // if it does not fit in any, create a new service and stack it there
        public void _push(int daTrip)
        {
            int i;
            for (i = 0; i < Common.services.Count(); i++)
            {
                if (Common.services[i].push(daTrip))
                    return;
            }
            //Then it does not fit in any then a new one is added，如果不符合，则添加一个新的车次链

            Service newService = new Service();
            newService.ServiceID = Common.services.Count();
            Common.services.Add(newService);
            Common.services[Common.services.Count() - 1].push(daTrip);
        }




        //service代表车次链
        // Calculate and return the fitness of the individual  according to the number of that you  consume.
        //It is also combined with the average time of rest of the entire service
        public double getFitness()
        {
            double countservice = Common.services.Count();//车次链的个数
            double lesiureservice = 0.0D;

            //计算每个车次链的平均闲暇时间
            for (int i = 0; i < Common.services.Count(); i++)
                lesiureservice += Common.services[i].timeLeisure.TotalMinutes /
                        (double)Common.services.Count();
           

            //适应度 ：service数量的比重大，平均时间比重小
            countservice = countservice * 0.8;
            lesiureservice = lesiureservice * 0.2;

            return countservice + lesiureservice;

        }

       
    }
  
}