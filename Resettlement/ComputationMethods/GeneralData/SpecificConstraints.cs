using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputationMethods.GeneralData
{
    public class SpecificConstraints
    {
        public const double MinSquareOneBedroomApartment = 35.00;
        public const double MinSquareTwoBedroomApartment = 44.00;
        public const double MinSquareThreeBedroomApartment = 52.00;

        public const double MaxSquareSection = 500.00;
        public const double MaxSquareHalfSection = MaxSquareSection / 2.0;
        public const double MaxLengthСorridor = 30.00;
        public const double СorridorWidth = 1.45;
        public const double ThinWallsWidth = 0.12;
    }
}
