using System.Collections.Generic;

namespace Resettlement
{
    public class Building
    {
        public List<Flat> Flats { get; set; }
        public List<Flat> FlatsExcess { get; set; }
        public int CountFloor { get; set; }
        public int CountFlat { get; set; }
        public double SumSquare { get; set; }


        public Building()
        {
            Flats = new List<Flat>();
            FlatsExcess = new List<Flat>();
            CountFloor = 0;
            CountFlat = 0;
            SumSquare = 0.0;
        }
    }
}
