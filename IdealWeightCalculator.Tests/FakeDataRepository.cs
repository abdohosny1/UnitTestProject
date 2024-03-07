using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdealWeightCalculator.Tests
{
    internal class FakeDataRepository : IDataRepository
    {
        IEnumerable<WeightCalculator> Weight;

        public FakeDataRepository()
        {
            Weight = new List<WeightCalculator>()
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
