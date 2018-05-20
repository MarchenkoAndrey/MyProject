using System.Collections.Generic;

namespace Resettlement
{
    public class Building
    {
        public List<Flat> Flats { get; set; }
        public List<Flat> FlatsExcess { get; set; }
        public List<double> Squares { get; set; }

        public Dictionary<int, List<Flat>> Floors1;

        public List<Floor> Floors { get; set; }
        public int CountFloor { get; set; }
        public int InputCountFlat { get; set; }
        public int CountFlat { get; set; }
        public double SumSquare { get; set; }
        public Fine Fine { get; set; }

        public Building()
        {
            Flats = new List<Flat>();
            FlatsExcess = new List<Flat>();
            Squares = new List<double>();
            Floors = new List<Floor>();
            Floors1 = new Dictionary<int, List<Flat>>();
            CountFloor = 0;
            CountFlat = 0;
            SumSquare = 0.0;
            Fine = new Fine {CastToMin = 0.0};
        }
    }
}
