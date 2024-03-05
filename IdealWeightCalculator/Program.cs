using System;

namespace IdealWeightCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
          WeightCalculator weightCalculator = new WeightCalculator() { Height =180 ,Sexe='m'};
            var weight=weightCalculator.GetIdealBodyWeight();

            Console.WriteLine(  $" The Ideal Weight Body is : {weight}");
            Console.ReadKey();
        }
    }
}
