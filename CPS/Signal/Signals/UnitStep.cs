using System;
using CPS;
using CPS.Signal;

namespace CPS.Signal
{
    [Serializable]
    public class UnitStep : BaseSignal
    {
        override public string Name { get => "unitStep"; }

        public UnitStep()
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
            if (x > Params.StepResponse)
            {
                return Params.Amplitude;
            }

            if (x.Equals(Params.StepResponse))
            {
                return 0.5 * Params.Amplitude;
            }

            return 0;
        }
    }
}