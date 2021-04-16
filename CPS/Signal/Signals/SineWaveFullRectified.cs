using System;

namespace CPS.Signal
{
    [Serializable]
    public class SineWaveFullRectified : BaseSignal
    {
        override public string Name { get => "sinFullRectified"; }

        public SineWaveFullRectified()
        {
            Params.Amplitude = 1;
            Params.Duration = 10;
            Params.T = 1;
            Params.StartTime = 0;
        }

        protected override double YRange(double x)
        {
            return Params.Amplitude * Math.Abs(Math.Sin((2 * Math.PI / Params.T) * (x - Params.StartTime)));
        }
    }
}