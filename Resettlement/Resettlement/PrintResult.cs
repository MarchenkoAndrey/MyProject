using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    public static class PrintResult
    {
        public static void GreedyIterationPrintResult(ResultGreedyMethode data, int countFloor, int numberIteration, bool flagIsNotFinish, Label resultGreedyLabel)
        {
            if (flagIsNotFinish)
            {
                resultGreedyLabel.Text +=
                    string.Format(MessagesText.ResultIterationHeuristicAlgorithm,numberIteration).ToString(CultureInfo.InvariantCulture);
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
                PrintExceedAppartment(data.ListLenOneFlat, resultGreedyLabel, MessagesText.RectanglesAiNotList);
                PrintExceedAppartment(data.ListLengthTBA, resultGreedyLabel, MessagesText.RectanglesBiNotList);
            }
                else
                {
                    resultGreedyLabel.Text += MessagesText.OptimalContainerPackage;
                    resultGreedyLabel.Text += MessagesText.NextLine;
                    resultGreedyLabel.Text += MessagesText.DividingLine;
                    PrintFloor(data.FinalPlaceTwoFlat, resultGreedyLabel);
                    resultGreedyLabel.Text += MessagesText.DividingLine;
                    PrintFloor(data.FinalPlaceTwoFlat, resultGreedyLabel);
                    PrintExceedAppartment(data.ListLenOneFlat, resultGreedyLabel, MessagesText.RectanglesAiNotList);
                    PrintExceedAppartment(data.ListLengthTBA, resultGreedyLabel, MessagesText.RectanglesBiNotList);
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
                    PrintFloor(data.ListResultOneFlat.ToArray(), resultFullSearchLabel);
                    resultFullSearchLabel.Text += MessagesText.DividingLine;
                    PrintFloor(data.ListResultTwoFlat.ToArray(), resultFullSearchLabel);
                    PrintStroke(data.ListResultOneFlat.ToArray(), numberFloor, countFloor, resultFullSearchLabel);
                }
                PrintExceedAppartment(data.ListExcessOneFlat, resultFullSearchLabel, MessagesText.RectanglesAiNotList);
                PrintExceedAppartment(data.listExcessTwoFlat, resultFullSearchLabel, MessagesText.RectanglesBiNotList);
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
                PrintFloor(data.ListResultOneFlat.ToArray(), resultFullSearchLabel);
                resultFullSearchLabel.Text += MessagesText.DividingLine;
                PrintFloor(data.ListResultTwoFlat.ToArray(), resultFullSearchLabel);
                PrintExceedAppartment(data.ListExcessOneFlat, resultFullSearchLabel, MessagesText.RectanglesAiNotList);
                PrintExceedAppartment(data.listExcessTwoFlat, resultFullSearchLabel, MessagesText.RectanglesBiNotList);
            }
        }

        private static void PrintStroke(double[] totalListOneBedroomApartment, int numberFloor, int countFloor, Label resultLabel)
        {
            var strokeLength = MessagesText.StrokeLength;
            for (var i = 0; i < totalListOneBedroomApartment.Length; ++i)
            {
                strokeLength += MessagesText.StrokeLength;
            }
            if (numberFloor != countFloor - 1)
            {
                resultLabel.Text += strokeLength;
            }
            resultLabel.Text += MessagesText.NextLine;
        }


        private static void PrintFloor(double[] listBedroomApartment, Label resultLabel)
        {
            var dividedLine = 0;
            foreach (var i in listBedroomApartment)
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

        private static void PrintExceedAppartment(List<double> listExceedBedroomApartment, Label resultLabel, string rectanglesNotList)
        {
            if (listExceedBedroomApartment.Count == 0) return;
            resultLabel.Text += rectanglesNotList;
            foreach (var i in listExceedBedroomApartment)
            {
                resultLabel.Text += (string.Format(" {0:0.0} ", i));
            }
            resultLabel.Text += MessagesText.NextLine;
        }
    }
}
