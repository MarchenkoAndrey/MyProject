using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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

            
            if (!flagIsNotFinish)
            {
                for (var numberFloor = 0; numberFloor < countFloor; ++numberFloor)
                {
                    resultGreedyLabel.Text += MessagesText.DividingLine;
                    PrintFloor(data.FinalPlaceOneFlat, resultGreedyLabel);
                    resultGreedyLabel.Text += MessagesText.DividingLine;
                    PrintFloor(data.FinalPlaceTwoFlat, resultGreedyLabel);
                    PrintStroke(data.FinalPlaceTwoFlat.Count, numberFloor, countFloor, resultGreedyLabel);
                }
            }
            if (flagIsNotFinish) return;
            PrintExceedFlat(data.ListLenExceedOneFlat, resultGreedyLabel, MessagesText.RectanglesAiNotList);
            PrintExceedFlat(data.ListLenExceedTwoFlat, resultGreedyLabel, MessagesText.RectanglesBiNotList);
        }

        public static void FullSearchPrintResult(ResultDataAfterGrouping data, int countFloor, Label resultFullSearchLabel)
        {
            const string resultFullSearch = MessagesText.ResultComprehensiveSearch;
            resultFullSearchLabel.Text += resultFullSearch + MessagesText.NextLine;
            var minFine = string.Format(MessagesText.Fine, data.Fine);
            resultFullSearchLabel.Text += minFine + MessagesText.NextLine;

            if (countFloor !=1)
            {
                for (var numberFloor = 0; numberFloor < countFloor; ++numberFloor)
                {
                    resultFullSearchLabel.Text += MessagesText.DividingLine;
                    PrintFloor(data.ListResultOneFlat, resultFullSearchLabel);
                    resultFullSearchLabel.Text += MessagesText.DividingLine;
                    PrintFloor(data.ListResultTwoFlat, resultFullSearchLabel);
                    PrintStroke(data.ListResultOneFlat.Count, numberFloor, countFloor, resultFullSearchLabel);
                }
            }   

            else
            {
                const string optArrangeOne = MessagesText.OptimalContainerPackage;
                resultFullSearchLabel.Text += optArrangeOne;
                resultFullSearchLabel.Text += MessagesText.NextLine;
                resultFullSearchLabel.Text += MessagesText.DividingLine;
                PrintFloor(data.ListResultOneFlat, resultFullSearchLabel);
                resultFullSearchLabel.Text += MessagesText.DividingLine;
                PrintFloor(data.ListResultTwoFlat, resultFullSearchLabel);
            }
            PrintExceedFlat(data.ListExcessOneFlat, resultFullSearchLabel, MessagesText.RectanglesAiNotList);
            PrintExceedFlat(data.ListExcessTwoFlat, resultFullSearchLabel, MessagesText.RectanglesBiNotList);
        }

        public static void DynamicProgrammingPrintResult(List<Container> listContainers, int countFloor, ResultDataAfterGrouping resDataAftGrouping, Label resultGreedyLabel)
        {

            resultGreedyLabel.Text +=
                string.Format(MessagesText.ValueFunctionalF,
                        listContainers.Last().FineChain*countFloor + resDataAftGrouping.Fine)
                    .ToString(CultureInfo.InvariantCulture);

            //Превращаем в список для удобного отображения
                var listOneFlat = new List<double>();
                var listTwoFlat = new List<double>();
                foreach (var container in listContainers)
                {
                    listOneFlat.Add(container.A1);
                    listOneFlat.Add(container.A2);
                    listTwoFlat.Add(container.B1);
                    listTwoFlat.Add(container.B2);
                }

            for (var numberFloor = 0; numberFloor < countFloor; ++numberFloor)
            {
                resultGreedyLabel.Text += MessagesText.DividingLine;
                    PrintFloor(listOneFlat, resultGreedyLabel);
                    resultGreedyLabel.Text += MessagesText.DividingLine;
                    PrintFloor(listTwoFlat, resultGreedyLabel);
                    PrintStroke(listContainers.Last().ExceedListOneFlat.Count, numberFloor, countFloor, resultGreedyLabel);
            }
            PrintExceedFlat(resDataAftGrouping.ListExcessOneFlat, resultGreedyLabel, MessagesText.RectanglesAiNotList);
            PrintExceedFlat(resDataAftGrouping.ListExcessTwoFlat, resultGreedyLabel, MessagesText.RectanglesBiNotList);
        }

        private static void PrintStroke(double totalListFlatCount, int numberFloor, int countFloor, Label resultLabel)
        {
            var strokeLength = MessagesText.StrokeLength;
            for (var i = 0; i < totalListFlatCount; ++i)
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
            if (listExceedFlat.Count==0) return;
            resultLabel.Text += rectanglesNotList;
            foreach (var i in listExceedFlat)
            {
                resultLabel.Text += (string.Format(" {0:0.0} ", i));
            }
            resultLabel.Text += MessagesText.NextLine;
        }
    }
}
