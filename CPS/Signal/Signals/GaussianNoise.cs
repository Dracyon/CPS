using System;

namespace CPS.Signal
{
    [Serializable]
    public class GaussianNoise : BaseSignal
    {
        override public string Name { get => "szum gaussowski"; }

        public GaussianNoise()
        {
            Params.Amplitude = 1;
            Params.Duration = 10;
            Params.T = 1;
            Params.StartTime = 0;
        }

        protected override double YRange(double x)
        {
            double stdDev = Params.Amplitude / 3;
            double u1 = 1.0 - MainWindow.Random.NextDouble();
            double u2 = 1.0 - MainWindow.Random.NextDouble();
            double normal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);

            return normal * stdDev;
        }
    }
}