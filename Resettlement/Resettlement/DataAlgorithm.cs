using System.Collections.Generic;

namespace Resettlement
{
    public class DataAlgorithm
    {
        public List<double> ListSquaresOneBedroomApartment;
        public List<double> ListSquaresTwoBedroomApartment;
        public List<double> ListSquaresThreeBedroomApartment;

        public int TotalCountApartments;
        public int CountFloor { get; set;}
        public double SumDelta { get; set; }
        public double Step { get; set; }
        public double Entryway { get; set; }

        public List<double> ListSquaresOneBedroomApartmentBringingToMin;
        public List<double> ListSquaresTwoBedroomApartmentBringingToMin;
        public List<double> ListSquaresThreeBedroomApartmentBringingToMin;

        public double SumSquaresOriginal;
        public double SumSquaresAfterBrindingToMin;
        public int TotalCountSections;

        public List<double> ListLengthOneBedroomApartment;
        public List<double> ListLengthTwoBedroomApartment;

        public List<double> ListLengthOneBedroomApartnentWithoutFormats;
        public List<double> ListLengthTwoBedroomApartnentWithoutFormats;

        


    }
}
