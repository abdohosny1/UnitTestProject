namespace IdealWeightCalculator
{
    public class WeightCalculator
    {
        public double Height { get; set; }
        public char Sexe { get; set; }

        public double GetIdealBodyWeight()
        {
            switch(Sexe)
            {
                case 'm':
                    return (Height -100) - ((Height - 150) /4);
                case 'w':
                    return (Height - 100) - ((Height - 150) / 4);
                default: return 0;
            }
        }
    }
}
