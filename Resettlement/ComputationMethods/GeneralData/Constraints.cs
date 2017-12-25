using System;
using System.CodeDom;

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

        public const int CountFloor = 1;

        public const double WallsWidth = 0.3;

        public const double ApartureLength = 1.25;
        public const double DefaultH = 0.3; // step for rounding of squares
        public const int NumberOfIteration = 5;

        public const int СountBranch = 3;

        public const double AddingA = 3 * WallsWidth + EntrywayLength;
        public const double AddingB = 2 * WallsWidth;

        /*
        public enum Version
        {
            Base2To2 = 1,
            Base2To2Extended = 2
        }
        */

        public const bool VersionExtended = true;

        //балкон
        public const double LengthBalcony = 2.4;
        public const double WidthBalcony = 0.9;
        public const double SquareBalcony = 2.16;
        
        //коридор
        public const double WidthCorridor = 1.5;
        public const double MinLengthCorridor = 4.5; // 2.7 + 0.9 * 2

        public const double CommonSquareWithEntryway = 4.05; // 2.7 * 1.5
        public const double MinSquareCorridor = 6.75; // CommonSquareWithEntryway + 2 * 0.9 * 1.5

        public const double SquareAboveCorridorFor2K = 3.78; // 0.9 * 4.2


    }
}
