//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace trainCrew.HandleFunction
//{
//    public class ProblemChecks
//    {
//        /*验证routeline在对应的service中是否是唯一的*/
//        public ProblemChecks()
//        {

//        }

//        public float uniqueTrip(ref Phenotype dude)
//        {
//            bool valid = true;
//            double fitness = 0;

//            //遍历所有的service
//            for (int i = 0; i < (Common.services.Count()) && (valid == true); i++)
//            {

//                // 遍历在service中的每个routeline
//                for (int j = 0; j < Common.services[i].blocks.Count(); j++)
//                {

//                    RouteLine tripI = Common.services[i].blocks[j];

//                //遍历service中的每个routeline
//                    for (int k = i + 1; k < dude.services[i]; k++)
//                    {

//                        // Compare with each trip l of the service k (after i).
//                        // Added && (valid == true)
//                        for (int l = 0; l < (dude.services.at(k).tripList.size()) && (valid == true); l++)
//                        {

//                            RouteLine tripL = trips.at(dude.services.at(k).tripList.at(l));

//                            if (tripI.initTime.toSeg() == tripL.initTime.toSeg())
//                            {
//                                valid = false;
//                                dude.services.at(i).partialFitness += 5000;
//                                fitness += 5000;
//                            }
//                        }
//                    }
//                }
//            }
//            return fitness;
//        }


//    }
//}


