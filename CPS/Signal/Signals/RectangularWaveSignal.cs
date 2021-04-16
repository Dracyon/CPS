using System;
using CPS;
using CPS.Signal;

namespace CPS.Signal
{
    [Serializable]
    public class RectangularWaveSignal : BaseSignal
    {
        override public string Name { get => "prostokatny"; }

        public RectangularWaveSignal()
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
            int k = (int)((x / Params.T) - (Params.StartTime / Params.T));
            if (x >= (k * Params.T + Params.StartTime) && x < (Params.DutyCycle * Params.T + k * Params.T + Params.StartTime))
            {
                return Params.Amplitude;
            }

            return 0;
        }
    }
}