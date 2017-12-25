using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using ComputationMethods;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    partial class UserInterface
    {
        private void PerformHAlg(InputDataAlg inData)
        {
            ValidateConditions.Validate(inData, true);

            realizat_label.Text = "".ToString(CultureInfo.InvariantCulture);
            lossesOne_label.Text = "".ToString(CultureInfo.InvariantCulture);
            resultGreedy_label.Text = "".ToString(CultureInfo.InvariantCulture);

            var flatCount = inData.ListLenOneFlat.Count + inData.ListLenTwoFlat.Count;
            realizat_label.Text +=
                string.Format(MessagesText.RealizationForRectangles, flatCount).ToString(CultureInfo.InvariantCulture);
//            lossesOne_label.Text += string.Format(MessagesText.SummarizeAdditionLengthForH, inData.SumDelta.ToString(CultureInfo.InvariantCulture));

            var dataAlg = new DataPerformAlgorithm();

            var resultDataAfterGrouping = GroupingOnTheFloors.GroupingFlat(inData);
            dataAlg.ListLenOneFlat =
                PreparationSquares.FlatsWithTheAdditiveLength(resultDataAfterGrouping.ListResultOneFlat);
            dataAlg.ListLenTwoFlat =
                PreparationSquares.FlatsWithTheAdditiveLength(resultDataAfterGrouping.ListResultTwoFlat);
            dataAlg.FineAfterGrouping = resultDataAfterGrouping.Fine;
            
            //for print in txt-file
            /*
            var str1 = new StringBuilder();
            var str2 = new StringBuilder();
            foreach (var elem in dataAlg.ListLenOneFlat)
            {
                str1.Append(elem + " ");
            }

            foreach (var elem in dataAlg.ListLenTwoFlat)
            {
                str2.Append(elem + " ");
            }

           File.WriteAllText(@"C:\Users\marchenko.a\Downloads\Модифицированная Статья\ExampleTwoFirstList.txt", str1.ToString());
           File.WriteAllText(@"C:\Users\marchenko.a\Downloads\Модифицированная Статья\ExampleTwoSecondList.txt", str2.ToString());
           */

            //Todo уже приведено, осталось собрать секцию

            var myStopWatchGreedy = new Stopwatch();
            myStopWatchGreedy.Start();
           
            var resultList = new ResultListGreedyMethode();
            
            foreach (var flag in resultList.PositionStart)
            {
                var allIterationsResult = new ResultGreedyMethode[Constraints.NumberOfIteration];
                var totalOptimalResult = new ResultGreedyMethode(double.MaxValue);
                var firstOneFlat = 0.0; // в RGreedyMethode
                var numberIteration = 1;
                while (numberIteration <= Constraints.NumberOfIteration)
                {
                    var resultGreedyIter =
                        GreedyMethodeSect.GreedyMethode(
                            new DataMethode(dataAlg.ListLenOneFlat, dataAlg.ListLenTwoFlat, inData.OptCountFlatOnFloor),
                            firstOneFlat,flag, Constraints.VersionExtended);
                    firstOneFlat = resultGreedyIter.NewFirstOneFlat;
                    resultGreedyIter.NumIter = numberIteration;
                    resultGreedyIter.Fine = Math.Round(resultGreedyIter.Fine*inData.CountFloor, 1);
                    resultGreedyIter.Fine = Math.Round(resultGreedyIter.Fine + dataAlg.FineAfterGrouping, 1);
                    resultGreedyIter.ListLenExceedOneFlat = resultDataAfterGrouping.ListExcessOneFlat;
                    resultGreedyIter.ListLenExceedTwoFlat = resultDataAfterGrouping.ListExcessTwoFlat;

                    allIterationsResult[numberIteration-1] = resultGreedyIter;

                    if (resultGreedyIter.Fine < totalOptimalResult.Fine)
                    {
                        totalOptimalResult = resultGreedyIter;
                    }
                    //Вывод результата по итерациям
                   //PrintResult.GreedyIterationPrintResult(resultGreedyIter, inData.CountFloor, true, resultGreedy_label);
                    numberIteration++;
                    if(numberIteration>Constraints.NumberOfIteration)
                        resultList.Results.Add(totalOptimalResult);
                }
        }

        myStopWatchGreedy.Stop();
            PrintResult.GreedyIterationPrintResult(resultList.Results.OrderBy(a => a.Fine).First(), inData.CountFloor,
                false, resultGreedy_label);

            resultGreedy_label.Text +=
                  string.Format(MessagesText.WorkTimeHeuristicAlgoruthm,
                   myStopWatchGreedy.ElapsedMilliseconds / 1000.0).ToString(CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture);
        }
    }

    class ResultListGreedyMethode
    {
        public List<ResultGreedyMethode> Results { get; private set; }
        public readonly List<string> PositionStart;

        public ResultListGreedyMethode()
        {
            Results = new List<ResultGreedyMethode>();
            PositionStart = new List<string> { "First", "Middle", "Penultimate" };
        }
    }
}
