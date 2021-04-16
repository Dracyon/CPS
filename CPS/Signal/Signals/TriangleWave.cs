using System;

namespace CPS.Signal
{
    [Serializable]
    public class TriangleWave : BaseSignal
    {
        override public string Name { get => "trojkatny"; }

        public TriangleWave()
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
            if (x >= k * Params.T + Params.StartTime && x < Params.DutyCycle * Params.T + k * Params.T + Params.StartTime)
            {
                return (Params.Amplitude / (Params.DutyCycle * Params.T)) * (x - k * Params.T - Params.StartTime);
            }

            return -Params.Amplitude / (Params.T * (1 - Params.DutyCycle)) * (x - k * Params.T - Params.StartTime) + (Params.Amplitude / (1 - Params.DutyCycle));
        }
    }
}