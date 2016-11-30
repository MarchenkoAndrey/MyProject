using System;
using System.Diagnostics;
using System.Globalization;
using ComputationMethods;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    partial class UserInterface
    {
        private void PerformHeuristicAlgorithm(DataAlgorithm data)
        {
            ValidateConditions.Validate(data);

            realizat_label.Text = "".ToString(CultureInfo.InvariantCulture);
            lossesOne_label.Text = "".ToString(CultureInfo.InvariantCulture);
            resultGreedy_label.Text = "".ToString(CultureInfo.InvariantCulture);

            var flatCount = data.ListLenOneFlat.Count + data.ListLenTwoFlat.Count;
            realizat_label.Text += string.Format(MessagesText.RealizationForRectangles,flatCount).ToString(CultureInfo.InvariantCulture);
            lossesOne_label.Text += string.Format(MessagesText.SummarizeAdditionLengthForH, data.SumDelta.ToString(CultureInfo.InvariantCulture));

            var resultDataAfterGrouping = new ResultDataAfterGrouping();
                
            var fineAfterGrouping = 0.0;
            if (data.CountFloor == 2 || data.CountFloor == 3 || data.CountFloor == 4)
            {
                resultDataAfterGrouping = GroupingOnTheFloors.GroupingApartment(data.ListLenOneFlat, data.ListLenTwoFlat,data.CountFloor);
                data.ListLenOneFlat = PreparationSquares.FlatsWithTheAdditiveLength(resultDataAfterGrouping.ListResultOneFlat);
                data.ListLenTwoFlat = PreparationSquares.FlatsWithTheAdditiveLength(resultDataAfterGrouping.ListResultTwoFlat);
                fineAfterGrouping = resultDataAfterGrouping.Fine;
            }       

            var myStopWatchGreedy = new Stopwatch();
            myStopWatchGreedy.Start();
            var firstOneFlat = 0.0;
            var numberIteration = 0;
            var optimalNumberIteration = 0;
            var totalOptimalResult = new ResultGreedyMethode();

            while (numberIteration < Constraints.NumberOfIteration)
            {
                numberIteration++;
                var resultGreedy = GreedyAlgorithmSection.GreedyMethode(data, firstOneFlat);
                firstOneFlat = resultGreedy.NewFirstOneFlat;
                resultGreedy.Fine = Math.Round(resultGreedy.Fine * data.CountFloor, 1);
                resultGreedy.Fine = Math.Round(resultGreedy.Fine + fineAfterGrouping, 1); // каждый раз суммируется??

                if (numberIteration != 0)
                {
                    if (totalOptimalResult.Fine > resultGreedy.Fine)
                    {
                        totalOptimalResult.Fine = resultGreedy.Fine;
                        optimalNumberIteration = numberIteration;
                    }
                }
                else
                {
                    totalOptimalResult = resultGreedy;
                }

                if (data.CountFloor != 1)
                {
                    data.ListLenOneFlat = PreparationSquares.FlatsRestartList(resultDataAfterGrouping.ListResultOneFlat);
                    data.ListLenTwoFlat = PreparationSquares.FlatsRestartList(resultDataAfterGrouping.ListResultTwoFlat);
                    resultGreedy.ListLenOneFlat = resultDataAfterGrouping.ListExcessOneFlat;
                    resultGreedy.ListLengthTBA = resultDataAfterGrouping.listExcessTwoFlat;
                }
                else
                {
                    data.ListLenOneFlat = PreparationSquares.FlatsWithTheAdditiveLength(data.ListLenOneFlatWithoutFormats);
                    data.ListLenTwoFlat = PreparationSquares.FlatsWithTheAdditiveLength(data.ListLenTwoFlatWithoutFormats);
                }
                //Вывод результата по итерациям
                PrintResult.GreedyIterationPrintResult(resultGreedy, data.CountFloor, numberIteration, true, resultGreedy_label);
            }
            myStopWatchGreedy.Stop();
            PrintResult.GreedyIterationPrintResult(totalOptimalResult, data.CountFloor, optimalNumberIteration, false, resultGreedy_label);

            resultGreedy_label.Text +=
                  string.Format(MessagesText.WorkTimeHeuristicAlgoruthm,
                   myStopWatchGreedy.ElapsedMilliseconds / 1000.0).ToString(CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture);
        }
    }
}
