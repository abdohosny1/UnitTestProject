using System;
using System.Collections;
using System.Collections.Generic;

namespace IdealWeightCalculator
{
    public class WeightCalculator
    {
        public double Height { get; set; }
        public char Sex { get; set; }
        private readonly IDataRepository _dataRepository;

        public WeightCalculator(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public WeightCalculator()
        {
                
        }

        public double GetIdealBodyWeight()
        {
            switch(Sex)
            {
                case 'm':
                    return (Height -100) - ((Height - 150) /4);
                case 'w':
                    return (Height - 100) - ((Height - 150) / 2);
                default: throw new  ArgumentException("The sex argument is not valid");
            }
        }

        public List<double> GetIdelBodyWithFromDateSource()
        {
            var result = new List<double>();

            IEnumerable<WeightCalculator> weights = _dataRepository.GetWeightCalculator();

            foreach( WeightCalculator weightCalculator in weights)
            {
                result.Add(weightCalculator.GetIdealBodyWeight());
            }
            return result;
        }

        public bool Validate()
        {
            return Sex == 'm' || Sex == 'w';
        }
    }
}
