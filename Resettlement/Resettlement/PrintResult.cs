using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    public static class PrintResult
    {
        public static void GreedyIterationPrintResult(ResultGreedyMethode data, int countFloor, bool flagIsNotFinish, Label resultGreedyLabel)
        {
            if (flagIsNotFinish)
            {
                resultGreedyLabel.Text +=
                    string.Format(MessagesText.ResultIterationHeuristicAlgorithm,data.NumIter).ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                resultGreedyLabel.Text += MessagesText.NextLine;
                resultGreedyLabel.Text +=
                    MessagesText.TotalResultHeuristicAlgorithm.ToString(CultureInfo.InvariantCulture);
            }

            resultGreedyLabel.Text +=
                 string.Format(MessagesText.ValueFunctionalF, data.Fine).ToString(CultureInfo.InvariantCulture);

            if (countFloor !=1)
            {
                if (!flagIsNotFinish)
                {
                    for (var numberFloor = 0; numberFloor < countFloor; ++numberFloor)
                    {
                        resultGreedyLabel.Text += MessagesText.DividingLine;
                        PrintFloor(data.FinalPlaceOneFlat, resultGreedyLabel);
                        resultGreedyLabel.Text += MessagesText.DividingLine;
                        PrintFloor(data.FinalPlaceTwoFlat, resultGreedyLabel);
                        PrintStroke(data.FinalPlaceTwoFlat, numberFloor, countFloor, resultGreedyLabel);
                    }
                }
                if (flagIsNotFinish) return;
                PrintExceedFlat(data.ListLenExceedOneFlat, resultGreedyLabel, MessagesText.RectanglesAiNotList);
                PrintExceedFlat(data.ListLenExceedTwoFlat, resultGreedyLabel, MessagesText.RectanglesBiNotList);
            }
                else
                {
                    resultGreedyLabel.Text += MessagesText.OptimalContainerPackage;
                    resultGreedyLabel.Text += MessagesText.NextLine;
                    resultGreedyLabel.Text += MessagesText.DividingLine;
                    PrintFloor(data.FinalPlaceTwoFlat, resultGreedyLabel);
                    resultGreedyLabel.Text += MessagesText.DividingLine;
                    PrintFloor(data.FinalPlaceTwoFlat, resultGreedyLabel);
                    PrintExceedFlat(data.ListLenExceedOneFlat, resultGreedyLabel, MessagesText.RectanglesAiNotList);
                    PrintExceedFlat(data.ListLenExceedTwoFlat, resultGreedyLabel, MessagesText.RectanglesBiNotList);
                }
        }

        public static void FullSearchPrintResult(ResultDataAfterGrouping data, int countFloor, Label resultFullSearchLabel)
        {
            if (countFloor !=1)
            {
                const string resultFullSearch = MessagesText.ResultComprehensiveSearch;
                resultFullSearchLabel.Text += resultFullSearch + MessagesText.NextLine;
                var minFine = string.Format(MessagesText.ValueFunctionalF, data.Fine);
                resultFullSearchLabel.Text += minFine + MessagesText.NextLine + MessagesText.NextLine;
                for (var numberFloor = 0; numberFloor < countFloor; ++numberFloor)
                {
                    resultFullSearchLabel.Text += MessagesText.DividingLine;
                    PrintFloor(data.ListResultOneFlat, resultFullSearchLabel);
                    resultFullSearchLabel.Text += MessagesText.DividingLine;
                    PrintFloor(data.ListResultTwoFlat, resultFullSearchLabel);
                    PrintStroke(data.ListResultOneFlat, numberFloor, countFloor, resultFullSearchLabel);
                }
                PrintExceedFlat(data.ListExcessOneFlat, resultFullSearchLabel, MessagesText.RectanglesAiNotList);
                PrintExceedFlat(data.ListExcessTwoFlat, resultFullSearchLabel, MessagesText.RectanglesBiNotList);
            }   

            else
            {
                const string resultFullSearch = MessagesText.ResultComprehensiveSearch;
                resultFullSearchLabel.Text += resultFullSearch + MessagesText.NextLine;
                var minFine = string.Format(MessagesText.Fine, data.Fine);
                resultFullSearchLabel.Text += minFine + MessagesText.NextLine;
                const string optArrangeOne = MessagesText.OptimalContainerPackage;
                resultFullSearchLabel.Text += optArrangeOne;
                resultFullSearchLabel.Text += MessagesText.NextLine;
                resultFullSearchLabel.Text += MessagesText.DividingLine;
                PrintFloor(data.ListResultOneFlat, resultFullSearchLabel);
                resultFullSearchLabel.Text += MessagesText.DividingLine;
                PrintFloor(data.ListResultTwoFlat, resultFullSearchLabel);
                PrintExceedFlat(data.ListExcessOneFlat, resultFullSearchLabel, MessagesText.RectanglesAiNotList);
                PrintExceedFlat(data.ListExcessTwoFlat, resultFullSearchLabel, MessagesText.RectanglesBiNotList);
            }
        }

        private static void PrintStroke(List<double> totalListOneBedroomApartment, int numberFloor, int countFloor, Label resultLabel)
        {
            var strokeLength = MessagesText.StrokeLength;
            for (var i = 0; i < totalListOneBedroomApartment.Count; ++i)
            {
                strokeLength += MessagesText.StrokeLength;
            }
            if (numberFloor != countFloor - 1)
            {
                resultLabel.Text += strokeLength;
            }
            resultLabel.Text += MessagesText.NextLine;
        }


        private static void PrintFloor(List<double> listFlat, Label resultLabel)
        {
            var dividedLine = 0;
            foreach (var i in listFlat)
            {
                resultLabel.Text += (string.Format(" {0:0.0} ", i));
                ++dividedLine;
                if (dividedLine % 2 == 0)
                {
                    resultLabel.Text += MessagesText.DividingLine;
                }
            }
            resultLabel.Text += MessagesText.NextLine;
        }

        private static void PrintExceedFlat(List<double> listExceedFlat, Label resultLabel, string rectanglesNotList)
        {
            if (listExceedFlat == null) return;
            resultLabel.Text += rectanglesNotList;
            foreach (var i in listExceedFlat)
            {
                resultLabel.Text += (string.Format(" {0:0.0} ", i));
            }
            resultLabel.Text += MessagesText.NextLine;
        }
    }
}
