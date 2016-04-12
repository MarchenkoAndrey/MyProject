using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Resettlement.GeneralData;

namespace Resettlement
{
    public static class PrintResult
    {
        public static void GreedyIterationPrintResult(List<object> heuristicAlgorithmData, int countFloor, int numberIteration, bool flagIsNotFinish, Label resultGreedyLabel)
        {
            var fine = (double)heuristicAlgorithmData[0];
            var totalListOneBedroomApartment = (double[])heuristicAlgorithmData[1];
            var totalListTwoBedroomApartment = (double[])heuristicAlgorithmData[2];
            var exceedListOneBedroomApartment = (List<double>)heuristicAlgorithmData[3];
            var exceedListTwoBedroomApartment = (List<double>)heuristicAlgorithmData[4];

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
                 string.Format(MessagesText.ValueFunctionalF, fine).ToString(CultureInfo.InvariantCulture);

            if (countFloor !=1)
            {
                if (!flagIsNotFinish)
                {
                    for (var numberFloor = 0; numberFloor < countFloor; ++numberFloor)
                    {
                        resultGreedyLabel.Text += MessagesText.DividingLine;
                        PrintFloor(totalListOneBedroomApartment, resultGreedyLabel);
                        resultGreedyLabel.Text += MessagesText.DividingLine;
                        PrintFloor(totalListTwoBedroomApartment, resultGreedyLabel);
                        PrintStroke(totalListOneBedroomApartment, numberFloor, countFloor, resultGreedyLabel);
                    }
                }
                if (flagIsNotFinish) return;
                PrintExceedAppartment(exceedListOneBedroomApartment, resultGreedyLabel, MessagesText.RectanglesAiNotList);
                PrintExceedAppartment(exceedListTwoBedroomApartment, resultGreedyLabel, MessagesText.RectanglesBiNotList);
            }
                else
                {
                    resultGreedyLabel.Text += MessagesText.OptimalContainerPackage;
                    resultGreedyLabel.Text += MessagesText.NextLine;
                    resultGreedyLabel.Text += MessagesText.DividingLine;
                    PrintFloor(totalListOneBedroomApartment, resultGreedyLabel);
                    resultGreedyLabel.Text += MessagesText.DividingLine;
                    PrintFloor(totalListTwoBedroomApartment, resultGreedyLabel);
                    PrintExceedAppartment(exceedListOneBedroomApartment, resultGreedyLabel, MessagesText.RectanglesAiNotList);
                    PrintExceedAppartment(exceedListTwoBedroomApartment, resultGreedyLabel, MessagesText.RectanglesBiNotList);
                }
        }

        public static void FullSearchPrintResult(List<object> comprehensiveSearchData, int countFloor, Label resultFullSearchLabel)
        {
            var fine = (double)comprehensiveSearchData[0];
            var totalListOneBedroomApartment = (double[])comprehensiveSearchData[1];
            var totalListTwoBedroomApartment = (double[])comprehensiveSearchData[2];
            var exceedListOneBedroomApartment = (List<double>)comprehensiveSearchData[3];
            var exceedListTwoBedroomApartment = (List<double>)comprehensiveSearchData[4];

            if (countFloor !=1)
            {
                const string resultFullSearch = MessagesText.ResultComprehensiveSearch;
                resultFullSearchLabel.Text += resultFullSearch + MessagesText.NextLine;
                var minFine = string.Format(MessagesText.ValueFunctionalF, fine);
                resultFullSearchLabel.Text += minFine + MessagesText.NextLine + MessagesText.NextLine;
                for (var numberFloor = 0; numberFloor < countFloor; ++numberFloor)
                {
                    resultFullSearchLabel.Text += MessagesText.DividingLine;
                    PrintFloor(totalListOneBedroomApartment, resultFullSearchLabel);
                    resultFullSearchLabel.Text += MessagesText.DividingLine;
                    PrintFloor(totalListTwoBedroomApartment, resultFullSearchLabel);
                    PrintStroke(totalListOneBedroomApartment, numberFloor, countFloor, resultFullSearchLabel);
                }
                PrintExceedAppartment(exceedListOneBedroomApartment, resultFullSearchLabel, MessagesText.RectanglesAiNotList);
                PrintExceedAppartment(exceedListTwoBedroomApartment, resultFullSearchLabel, MessagesText.RectanglesBiNotList);
            }   

            else
            {
                const string resultFullSearch = MessagesText.ResultComprehensiveSearch;
                resultFullSearchLabel.Text += resultFullSearch + MessagesText.NextLine;
                var minFine = string.Format(MessagesText.Fine, fine);
                resultFullSearchLabel.Text += minFine + MessagesText.NextLine;
                const string optArrangeOne = MessagesText.OptimalContainerPackage;
                resultFullSearchLabel.Text += optArrangeOne;
                resultFullSearchLabel.Text += MessagesText.NextLine;
                resultFullSearchLabel.Text += MessagesText.DividingLine;
                PrintFloor(totalListOneBedroomApartment, resultFullSearchLabel);
                resultFullSearchLabel.Text += MessagesText.DividingLine;
                PrintFloor(totalListTwoBedroomApartment, resultFullSearchLabel);
                PrintExceedAppartment(exceedListOneBedroomApartment, resultFullSearchLabel, MessagesText.RectanglesAiNotList);
                PrintExceedAppartment(exceedListTwoBedroomApartment, resultFullSearchLabel, MessagesText.RectanglesBiNotList);
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
