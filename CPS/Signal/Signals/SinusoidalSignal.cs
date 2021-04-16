using System;

namespace CPS.Signal
{
    [Serializable]
    class SinusoidalSignal : BaseSignal
    {
        override public string Name { get => "sinusoidalny"; }

        public SinusoidalSignal()
        {
            Params.Amplitude = 1;
            Params.Duration = 10;
            Params.T = 1;
            Params.StartTime = 0;
        }

        override protected double YRange(double x)
        {
            return Params.Amplitude * Math.Sin(2 * Math.PI / Params.T * (x - Params.StartTime));
        }
    }
}
