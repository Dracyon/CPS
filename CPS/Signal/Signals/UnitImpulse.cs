using System;
using System.Collections.Generic;

namespace CPS.Signal
{
    [Serializable]
    public class UnitImpulse : BaseSignal
    {
        override public string Name { get => "unitImpulse"; }

        public UnitImpulse()
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
            if (x == Params.StepResponse)  
                return Params.Amplitude;   

            return 0;
        }

        public override DiscreteSignal ToDiscrete(double Frequency)
        {
            List<Tuple<double, double>> Values = new List<Tuple<double, double>>();
            double from = Params.StartTime;
            double to = from + Params.Duration;
            double step = 1 / Frequency;
            for (var x = from; x <= to; x += step)
            {
                if (Math.Abs(x - Params.StepResponse) < 0.0000001)
                    Values.Add(Tuple.Create(x, Params.Amplitude));
                else
                    Values.Add(Tuple.Create(x, 0.0));
            }
            return DiscreteSignal.ForParameters(Name, Frequency, Values);
        }
    }
}