namespace ComputationMethods.GeneralData
{
    public static class Constraints
    {
        //General constraints for all models
        public const double EntrywayLength = 2.7;
        public static readonly double[] WidthFlat =
        {
            5.7,
            5.6,
            5.8,
            5.9,
            6
        };
        public const double StepH = 0.3; // step for rounding of squares
        //todo СДЕЛАТЬ редактируемым полем CountFloor
        public const int CountFloor = 3;
        public const double WallsWidth = 0.3;

        //Constraints for the model of container type
        public const double ApartureLength = 1.25;
        public const int NumberOfIteration = 5;
        public const int СountBranch = 3;
        public const double AddingA = 3 * WallsWidth + EntrywayLength;
        public const double AddingB = 2 * WallsWidth;

        //Constraints for the model of corridor type
        public const double MaxSquareSection = 500;
        //балкон
        public const double LengthBalcony = 2.4;
        public const double WidthBalcony = 1.2;
        public const double SquareBalcony = LengthBalcony * WidthBalcony;
        //коридор
        public const double MinWidthCorridor = 1.5;
        public const double MaxLengthCorridor = 30;
        public const double MaxSquareCorridor = MinWidthCorridor * MaxLengthCorridor;
        //Минимальные площади для квартир
        public const double MinSquareOneApartment = 35;
        public const double MinSquareTwoApartment = 44;
        public const double MinSquareThreeApartment = 52.00;
    }
}
