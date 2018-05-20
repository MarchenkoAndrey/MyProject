namespace ComputationMethods.GeneralData
{
    public static class MessagesText
    {
        //General messages for all modeles
        public const string RealizationForRectangles = "Realization for {0} rectangles";
        public const string SummarizeAdditionLengthForH = "The addition of the lengths of a rounding up\r\n to the number of times the wall thickness: {0}";
        public const string ValueFunctionalF = "Value of the functional F: {0} \r\n";
        public const string RectanglesAiNotList = "Rectangles a(i) not included in the total result:";
        public const string RectanglesBiNotList = "Rectangles b(i) not included in the total result:";
        public const string OptimalContainerPackage = "Optimal containers packaging: ";
        public const string Fine = "Fine {0}";
        public const string DividingLine = "|";
        public const string NextLine = "\r\n";
        public const string StrokeLength = "-------";

        public const string NotSelectedFloor = "It is need to choose count of floors";
        public const string NotSixContaiters = "For 6 or more containers, use only heuristic algorithm";

        //Messages for the model of container type
        public const string WorkTimeHeuristicAlgoruthm = "Work time of the heuristic algorithm: {0} seconds";
        public const string WorkTimeComprehensiveSearch = "Work time of the comprehensive search: {0} seconds";
        public const string WorkTimeDynamicProgram = "Work time of the MDP: {0} seconds";
        public const string ResultIterationHeuristicAlgorithm = "Result {0} iteration of heuristic algorithm:\r\n";
        public const string ResultTotalHeuristicAlgorithm = "Total result of heuristic algorithm:\r\n";
        public const string ResultComprehensiveSearch = "Result of comprehensive search:";
        public const string ResultDynamicProgram = "Result of MDP:\r\n";

        //Messages for the model of corridor type
        public const string TooLittleData = "Слишком мало данных. Невозможно построить дом";
        public const string TooMuchData = "Слишком много данных для построения одного дома. Удалите варианты суммарной площадью {0} м2";
        public const string AnomalyBiggerFlat = "Слишком большая площадь квартиры";
    }
}
