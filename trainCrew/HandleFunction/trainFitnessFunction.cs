using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AForge.Genetic;
using trainCrew.Models.Train;


namespace trainCrew.HandleFunction
{
    public class trainFitnessFunction:IFitnessFunction
    {

        private List<RouteLine> routeline ;


    
        private int popSize = 500;//种群大小
        private int cantGen = 500;//迭代次数

        private double PROGRESS = 0.0D;
        private double GPROGRESS;

        private double[] bestOfAllTimes;////记录每个染色体的适应度

     
        public trainFitnessFunction() 
        {
            GPROGRESS = popSize * cantGen;
            bestOfAllTimes = new double [1000];

            routeline = new List<RouteLine>();

        }


        public trainFitnessFunction(List<RouteLine> Routeline)
            : this()
        {
            routeline = Routeline;
 
        }

        //评价染色体，计算它的适应度,输出迭代的进度 
        public double Evaluate(IChromosome chromosome)
        {
            Common.services.Clear();
            BinaryChromosome realDude = ((BinaryChromosome)chromosome);

            string genome;//基因组

            genome = realDude.Value.ToString();

            Phenotype p = new Phenotype();

            p.init(genome);

            double fit = p.getFitness();

/*
            PROGRESS += 1 / GPROGRESS;
            evolutionProgress = PROGRESS * 100;
*/

            return 1 / fit;



            
        }


        //将基因转化为 表现型 // Translate genotype to phenotype 

        public object Translate(IChromosome chromosome)
        {
            return chromosome.ToString();
        }




    }
}