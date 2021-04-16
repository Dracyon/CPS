using System;

namespace CPS.Signal
{
    [Serializable]
    public class UniformDistributionNoise : BaseSignal
    {
        override public string Name { get => "szum jednostajny"; }

        public UniformDistributionNoise()
        {
            Params.Amplitude = 1;
            Params.Duration = 10;
            Params.T = 1;
            Params.StartTime = 0;
        }

        protected override double YRange(double x)
        {
            return 2* Params.Amplitude * MainWindow.Random.NextDouble() - Params.Amplitude;
        }
    }
}