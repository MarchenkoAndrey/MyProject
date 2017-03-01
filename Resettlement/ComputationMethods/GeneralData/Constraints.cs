namespace ComputationMethods.GeneralData
{
    public static class Constraints
    {
        public const double EntrywayLength = 2.7;
        public static readonly double[] WidthOfApartmentVariants =
        {
            5.7,
            5.6,
            5.65,
            5.75,
            5.8,
            5.85,
            5.9,
            5.95,
            6
        };

        public const int CountFloor = 3;

        public const double WallsWidth = 0.3;

        public const double ApartureLength = 1.25;
        public const double DefaultH = 0.3; // step for rounding of squares
        public const int NumberOfIteration = 5;

        public const int СountBranch = 3;

        public const double AddingA = 3 * WallsWidth + EntrywayLength;
        public const double AddingB = 2 * WallsWidth;

    }
}
