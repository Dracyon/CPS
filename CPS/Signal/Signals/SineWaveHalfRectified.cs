using System;

namespace CPS.Signal
{
    [Serializable]
    public class SineWaveHalfRectified : BaseSignal
    {
        override public string Name { get => "sinHalfRectified"; }

        public SineWaveHalfRectified()
        {
            Params.Amplitude = 1;
            Params.Duration = 10;
            Params.T = 1;
            Params.StartTime = 0;
        }

        protected override double YRange(double x)
        {
            return 0.5 * Params.Amplitude * (Math.Sin((2 * Math.PI / Params.T) * (x - Params.StartTime)) +
                                Math.Abs(Math.Sin((2 * Math.PI / Params.T) * (x - Params.StartTime))));
        }
    }
}