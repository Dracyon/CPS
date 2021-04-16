using System;

namespace CPS.Signal
{
    [Serializable]
    public class Parameters
    {
        public double Amplitude { get; set; } = 1;
        //okres
        public double T { get; set; } = 1;
        public double StartTime { get; set; } = 0;
        public double Duration { get; set; } = 4;
        //kw
        public double DutyCycle { get; set; } = 0.5;
        //czas skoku
        public double StepResponse { get; set; } = 2;
        public double Probalitity { get; set; } = 0.5;

    }
}
