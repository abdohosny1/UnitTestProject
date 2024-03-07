using System.Collections.Generic;

namespace IdealWeightCalculator
{
    public interface IDataRepository
    {
        public IEnumerable<WeightCalculator> GetWeightCalculator();

    }
}
