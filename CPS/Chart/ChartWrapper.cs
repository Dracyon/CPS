using System;
using System.Linq;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using CPS.Signal;

namespace CPS
{
    public class ChartWrapper
    {
        public SeriesCollection SeriesCollection { get; } = new SeriesCollection();
        public Func<double, string> XFormatter { get; } = value => value.ToString();
        public Func<double, string> YFormatter { get; } = value => value.ToString();
        private readonly Series[] series = { null, null, null };

        public void Clear()
        {
            SeriesCollection.Clear();
        }

        public void SetSignal(int n, DiscreteSignal Signal)
        {
            if (Signal == null)
            {
                series[n] = null;
                return;
            }

            ChartValues<ObservablePoint> values = new ChartValues<ObservablePoint>();
            values.AddRange(
                Signal.Values.Select(
                    tuple => new ObservablePoint { X = tuple.Item1, Y = tuple.Item2 }
                )
            );

            if (Signal.Name.Equals("unitImpulse") || Signal.Name.Equals("impulseNoise"))
            {
                series[n] = new ScatterSeries
                {
                    Title = Signal.Name,
                    Values = values,
                    MaxPointShapeDiameter = 6,
                    Stroke = ChartColors.List[n]
                };
            }
            else
            {
                series[n] = new LineSeries
                {
                    Title = Signal.Name,
                    Values = values,
                    Fill = System.Windows.Media.Brushes.Transparent,
                    PointGeometry = null,
                    Stroke = ChartColors.List[n]
                };
            }

        }

        public void Replot()
        {
            SeriesCollection.Clear();
            foreach (var serie in series)
            {
                if (serie != null)
                    SeriesCollection.Add(serie);
            }
        }
    }
}
