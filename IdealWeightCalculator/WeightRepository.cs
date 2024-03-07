using System.Collections.Generic;

namespace IdealWeightCalculator
{
    public class WeightRepository : IDataRepository
    {
        IEnumerable<WeightCalculator> Weight;

        public WeightRepository()
        {
            Weight=new List<WeightCalculator>()
            {
            new WeightCalculator() { Height = 175, Sex = 'w' },
            new WeightCalculator() { Height = 167, Sex = 'm' }, 
            new WeightCalculator() { Height = 182, Sex = 'm' }
            //new WeightCalculator() { Height = 140, Sex = 'w' },
            //new WeightCalculator() { Height = 160, Sex = 'm' },  
            };
        }

        public IEnumerable<WeightCalculator> GetWeightCalculator() => Weight;
    }
}
