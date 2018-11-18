using System.Collections.Generic;

namespace Resettlement.CorridorModel.Models
{
    public class Building
    {
        public List<Flat> Flats { get; set; }
        public List<Flat> FlatsExcess { get; private set; }
        public List<Floor> Floors { get; set; }
        public int CountFloor { get; set; }
        public int InputCountFlat { get; set; }
        public int CountFlat { get; set; }

        public double W1 { get; set; }
        public double W2 { get; set; }
        public double SumSquare { get; set; }
        public double Fine { get; set; }

        public Building()
        {
            Flats = new List<Flat>();
            FlatsExcess = new List<Flat>();
            Floors = new List<Floor>();
            CountFloor = 0;
            CountFlat = 0;
            W1 = 0;
            W2 = 0;
            SumSquare = 0.0;
            Fine = 0.0;
        }
    }
}
