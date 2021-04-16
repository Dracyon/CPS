using System;
using System.Collections.Generic;

namespace CPS.Signal
{
    [Serializable]
    public abstract class BaseSignal : ICloneable
    {
        public abstract string Name { get; }

        public Parameters Params { get; set; } = new Parameters();

        public double YValue(double x)
        {
            if (x < Params.StartTime || x > Params.StartTime + Params.Duration)
            {
                return 0;
            }
            else return YRange(x);
        }
        virtual public DiscreteSignal ToDiscrete(double Frequency)
        {
            List<Tuple<double, double>> Values = new List<Tuple<double, double>>();
            double from = Params.StartTime;
            double to = from + Params.Duration;
            double step = 1 / Frequency;
            for (var x = from; x <= to; x += step)
            {
                Values.Add(Tuple.Create(x, YValue(x)));
            }
            return DiscreteSignal.ForParameters(Name, Frequency, Values);
        }

        protected abstract double YRange(double x);

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
