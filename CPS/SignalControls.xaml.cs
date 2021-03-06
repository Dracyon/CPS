using CPS.Signal;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CPS
{
    [Serializable]
    public class SignalWrapper
    {
        public string Name { get; set; }
        public BaseSignal Signal { get; set; }
    }

    public partial class SignalControls : UserControl
    {
        public static List<SignalWrapper> SignalList { get; } = new List<SignalWrapper>
        {
            new SignalWrapper {Name = "Sygnał sinusoidalny", Signal = new SinusoidalSignal()},
            new SignalWrapper {Name = "Szum gaussowski", Signal = new GaussianNoise()},
            new SignalWrapper {Name = "Szum o rozkładzie jednostajnym", Signal = new UniformDistributionNoise()},
            new SignalWrapper
                {Name = "Sygnał sinusoidalny \nwyprostowany jednopołówkowo", Signal = new SineWaveHalfRectified()},
            new SignalWrapper
                {Name = "Sygnał sinusoidalny \nwyprostowany dwupołówkowo", Signal = new SineWaveFullRectified()},
            new SignalWrapper {Name = "Sygnał prostokątny", Signal = new RectangularWaveSignal()},
            new SignalWrapper {Name = "Sygnał prostokątny symetryczny", Signal = new RectangularWaveSymetricalSignal()},
            new SignalWrapper {Name = "Sygnał trójkątny", Signal = new TriangleWave()},
            new SignalWrapper {Name = "Skok jednostkowy", Signal = new UnitStep()},
            new SignalWrapper {Name = "Impuls jednostkowy", Signal = new UnitImpulse()},
            new SignalWrapper {Name = "Szum impulsowy", Signal = new ImpulseNoise()},
        };

        public string Title { get; set; } = "Parametry sygnału";
        public int SignalSlot { get; set; } = 0;
        public double Frequency { get; set; } = 200;
        public ChartWrapper ChartWrapper { get; set; } = null;
        public HistogramWrapper HistogramWrapper { get; set; } = null;
        public SignalWrapper SelectedSignal { get; set; } = null;
        public DiscreteSignal Signal { get; set; } = null;
        public Parameters Params { get; set; } = new Parameters();
        public SignalStatsController StatsController { get; } = new SignalStatsController();

        public SignalControls()
        {
            InitializeComponent();
            this.DataContext = this;
            ParamsGrid.DataContext = Params;
            SelectedSignal = SignalList[0];
        }

        public void Generate(object sender, RoutedEventArgs e)
        {
            BaseSignal s = (BaseSignal) SelectedSignal.Signal.Clone();
            s.Params = Params;
            Signal = s.ToDiscrete(Frequency);
            ChartWrapper.SetSignal(SignalSlot, Signal);
            ChartWrapper.Replot();
            HistogramWrapper.SetSignal(SignalSlot, Signal);
            HistogramWrapper.Replot();
            StatsController.CalculateSignalsStats(Signal, Params);
        }

        public void ClearSignal(object sender, RoutedEventArgs e)
        {
            Signal = null;
            ChartWrapper.SetSignal(SignalSlot, null);
            HistogramWrapper.SetSignal(SignalSlot, null);
            ChartWrapper.Replot();
            HistogramWrapper.Replot();
        }

        public void SaveSignal(object sender, RoutedEventArgs e)
        {
            string path = Serializer.FilePath(false);
            if (string.IsNullOrEmpty(path)) return;
            BinaryWrapper binaryWrapper = new BinaryWrapper
            {
                SelectedSignal = SelectedSignal,
                SignalParams = Params,
                DiscreteSignal = Signal
            };
            Serializer.SaveToBinaryFile(binaryWrapper, path);
        }

        public void LoadSignal(object sender, RoutedEventArgs e)
        {
            string path = Serializer.FilePath(true);
            if (string.IsNullOrEmpty(path)) return;
            BinaryWrapper binaryWrapper = Serializer.ReadFromBinaryFile(path);
            Signal = binaryWrapper.DiscreteSignal;
            ChartWrapper.SetSignal(SignalSlot, Signal);
            ChartWrapper.Replot();
            HistogramWrapper.SetSignal(SignalSlot, Signal);
            HistogramWrapper.Replot();
        }
    }
}
