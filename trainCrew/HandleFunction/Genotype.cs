using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace trainCrew.HandleFunction
{
    public class Genotype//基因族群
    {
        private int currentDude;
        private int currentGen;
        private int popSize;
        private int cantGen;

        private float PROGRESS;

        private float GPROGRESS;
        private int sfyCount;
        Genotype() 
        {
            currentDude = 0;
            currentGen = 0;
            popSize = 500;
            cantGen = 500;
            PROGRESS = 0.0f;
            GPROGRESS = popSize * cantGen;//500*500
            sfyCount = 0;

        }

/*
     public  static float evaluator() 
        {
            string genome;
            for (int i = 0; i < Common.routelines.Count(); i++)
            realDude.gene(i);
           genome = os.str();

            


        }
 
 */

    

   }
 
}