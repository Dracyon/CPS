using CPS.Signal;
using System.Collections.Generic;
using System.Linq;

namespace CPS
{
    public class SignalStatsController
    {
        public SignalStats Stats { get; } = new SignalStats();

        public void CalculateSignalsStats(DiscreteSignal signal, Parameters parameters)
        {
            if (signal != null)
            {
                List<double> samples = signal.Values.Select(tuple => tuple.Item2).ToList();
                double t1 = parameters.StartTime;
                double t2 = t1 + parameters.Duration;
                bool isDiscrete = false;
                Stats.AverageValue = StatsCalculator.AverageValue(samples, t1, t2, isDiscrete).ToString("0." + new string('#', 339));
                Stats.AverageAbsValue = StatsCalculator.AbsAverageValue(samples, t1, t2, isDiscrete).ToString("0." + new string('#', 339));
                Stats.RootMeanSquare = StatsCalculator.RootMeanSquare(samples, t1, t2, isDiscrete).ToString("0." + new string('#', 339));
                Stats.Variance = StatsCalculator.Variance(samples, t1, t2, isDiscrete).ToString("0." + new string('#', 339));
                Stats.AveragePower = StatsCalculator.AveragePower(samples, t1, t2, isDiscrete).ToString("0." + new string('#', 339));
            }
        }
    }
}
