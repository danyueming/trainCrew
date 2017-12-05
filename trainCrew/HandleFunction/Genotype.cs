using AForge.Genetic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AForge;

namespace trainCrew.HandleFunction
{
    public class Genotype//基因族群
    {

        /*
        * 0：EliteSelection算法
        * 1：RankSelection算法
        * 其他：RouletteWheelSelection 算法
        */


        public static void bodyofgenetic()

        {
            trainFitnessFunction FitnessFunction = new trainFitnessFunction(Common.routelines);

            int populationSize = 500; //种群最大规模

            int selectionMethod = 0;

            //适应度函数使用自定义的FitnessFunction，编码使用二进制编码，染色体长度为车次的的数目，每个世代个体数目为500，选择方式为“精英取舍”。

            Population population = new Population(populationSize,
                new BinaryChromosome(Common.routelines.Count()), FitnessFunction,
             (selectionMethod == 0) ? (ISelectionMethod)new EliteSelection() :
             (selectionMethod == 1) ? (ISelectionMethod)new RankSelection() :
             (ISelectionMethod)new RouletteWheelSelection()
             );
            // iterations
            int iter = 1;
            int iterations = 500; //迭代最大周期
            population.CrossoverRate = 0.9;
            population.MutationRate = 0.03;         

         while (iter < iterations)
            {     
               population.Crossover();//交叉
               population.Mutate();//变异
               population.RunEpoch();//执行
               iter++;
            }
              string resultbest = population.BestChromosome.ToString();//最佳的染色体
          //      Common.services.Clear();
            Phenotype bestResult = new Phenotype();
            bestResult.init(resultbest);//解码，重新转化为车次链
            double resulefit = bestResult.getFitness();//最佳的适应度        

        }


    }

}