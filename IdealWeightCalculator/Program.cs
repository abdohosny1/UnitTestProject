using System;

namespace IdealWeightCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
          WeightCalculator weightCalculator = new WeightCalculator() { Height =175 ,Sex='w'};
          WeightCalculator weightCalculator2 = new WeightCalculator() { Height =167 ,Sex='m'};
          WeightCalculator weightCalculator3 = new WeightCalculator() { Height =182 ,Sex='m'};
            var weight=weightCalculator.GetIdealBodyWeight();
            var weight2= weightCalculator2.GetIdealBodyWeight();
            var weight3= weightCalculator3.GetIdealBodyWeight();

            Console.WriteLine(  $" The Ideal Weight Body is : {weight}");
            Console.WriteLine(  $" The Ideal Weight Body is : {weight2}");
            Console.WriteLine(  $" The Ideal Weight Body is : {weight3}");
            Console.ReadKey();
        }
    }
}
