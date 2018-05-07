using System.Collections.Generic;

namespace Resettlement
{
    public class Building
    {
        public List<Flat> Flats { get; set; }
        public List<Flat> FlatsExcess { get; set; }
        public List<double> Squares { get; set; }
        public int CountFloor { get; set; }
        public int InputCountFlat { get; set; }
        public int CountFlat { get; set; }
        public double SumSquareAfterCastToMin { get; set; }
        public Fine Fine { get; set; }

        public Building()
        {
            Flats = new List<Flat>();
            FlatsExcess = new List<Flat>();
            Squares = new List<double>();
            CountFloor = 0;
            CountFlat = 0;
            SumSquareAfterCastToMin = 0.0;
            Fine = new Fine {CastToMin = 0.0};
        }
    }
}
