using System;
using CPS;
using CPS.Signal;

namespace CPS.Signal
{
    [Serializable]
    public class ImpulseNoise : BaseSignal
    {
        override public string Name { get => "szum impulsowy"; }

        public ImpulseNoise()
        {
            Params.Amplitude = 1;
            Params.Duration = 10;
            Params.T = 1;
            Params.StartTime = 0;
            
            Params.DutyCycle = 0.5;
            Params.StepResponse = 2;
        }

        protected override double YRange(double x)
        {
            if (Params.Probalitity > MainWindow.Random.NextDouble())
            {
                return Params.Amplitude;
            }

            return 0;
        }
    }
}