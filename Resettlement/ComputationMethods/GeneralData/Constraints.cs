namespace ComputationMethods.GeneralData
{
    public static class Constraints
    {
        public const double EntrywayLength = 2.7;
        public static readonly double[] WidthOfApartmentVariants =
        {
            5.6,
            5.65,
            5.7,
            5.75,
            5.8,
            5.85,
            5.9,
            5.95,
            6
        };

        public const double MinSquareOneBedroomApartment = 35.00;
        public const double MinSquareTwoBedroomApartment = 44.00;
        public const double MinSquareThreeBedroomApartment = 52.00;

        public const double MaxSquareSection = 500.00;
        public const double MaxSquareHalfSection = MaxSquareSection/2.0;

        public const int CountFloor = 4;

        public const double MaxLengthСorridor = 30.00;
        public const double СorridorWidth = 1.45;

        public const double ThickWallsWidth = 0.3;
        public const double ThinWallsWidth = 0.12;

        public const double ApartureLength = 1.25;
        public const double DefaultH = 0.3;
        public const double NumberOfIteration = 5;
    }
}
