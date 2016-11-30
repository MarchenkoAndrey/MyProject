using System;
using System.Collections.Generic;
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

            var realFlat = data.ListLengthOneBedroomApartment.Count + data.ListLengthTwoBedroomApartment.Count;
            realizat_label.Text += string.Format(MessagesText.RealizationForRectangles,realFlat).ToString(CultureInfo.InvariantCulture);
            lossesOne_label.Text += string.Format(MessagesText.SummarizeAdditionLengthForH, data.SumDelta.ToString(CultureInfo.InvariantCulture));

            var newListApartmentsAfterGrouping =
                new Tuple<List<double>, List<double>, double, List<double>, List<double>>(default(List<double>),
                    default(List<double>),
                    default(double), default(List<double>), default(List<double>));
            //newListApartmentsAfterGrouping = new Tuple<>();
            var fineAfterGrouping = 0.0;
            if (data.CountFloor == 2 || data.CountFloor == 3 || data.CountFloor == 4)
            {
                newListApartmentsAfterGrouping = GroupingOnTheFloors.GroupingApartment(data.ListLengthOneBedroomApartment, data.ListLengthTwoBedroomApartment,data.CountFloor);
                data.ListLengthOneBedroomApartment = PreparationSquares.FlatsWithTheAdditiveLength(newListApartmentsAfterGrouping.Item1);
                data.ListLengthTwoBedroomApartment = PreparationSquares.FlatsWithTheAdditiveLength(newListApartmentsAfterGrouping.Item2);
                fineAfterGrouping = newListApartmentsAfterGrouping.Item3;
            }       

            var myStopWatchGreedy = new Stopwatch();
            myStopWatchGreedy.Start();
            var firstOneFlat = 0.0;
            var numberIteration = 0;
            var optimalNumberIteration = 0;
            var totalOptimalResult = new List<object>();

            while (numberIteration < Constraints.NumberOfIteration)
            {
                numberIteration++;
//                var greedyAlgorithm = GreedyAlgorithmSection.GreedyMethode(dataAlg.ListLengthOneBedroomApartnent, dataAlg.ListLengthTwoBedroomApartnent,
//                    dataAlg.Step, dataAlg.Entryway, firstOneFlat);
                var greedyAlgorithm = GreedyAlgorithmSection.GreedyMethode(data, firstOneFlat);
                firstOneFlat = (double)greedyAlgorithm[5];
                greedyAlgorithm[0] = Math.Round((double)greedyAlgorithm[0] * data.CountFloor, 1);
                greedyAlgorithm[0] = Math.Round((double)greedyAlgorithm[0] + fineAfterGrouping, 1);

                if (totalOptimalResult.Count == greedyAlgorithm.Count)
                {
                    if ((double)totalOptimalResult[0] > (double)greedyAlgorithm[0])
                    {
                        totalOptimalResult = greedyAlgorithm;
                        optimalNumberIteration = numberIteration;
                    }
                }
                else
                {
                    totalOptimalResult = greedyAlgorithm;
                }

                if (data.CountFloor != 1)
                {
                    data.ListLengthOneBedroomApartment = PreparationSquares.FlatsRestartList(newListApartmentsAfterGrouping.Item1);
                    data.ListLengthTwoBedroomApartment = PreparationSquares.FlatsRestartList(newListApartmentsAfterGrouping.Item2);
                    greedyAlgorithm[3] = newListApartmentsAfterGrouping.Item4;
                    greedyAlgorithm[4] = newListApartmentsAfterGrouping.Item5;
                }
                else
                {
                    data.ListLengthOneBedroomApartment = PreparationSquares.FlatsWithTheAdditiveLength(data.ListLengthOneBedroomApartnentWithoutFormats);
                    data.ListLengthTwoBedroomApartment = PreparationSquares.FlatsWithTheAdditiveLength(data.ListLengthTwoBedroomApartnentWithoutFormats);
                }
                //Вывод результата по итерациям
                PrintResult.GreedyIterationPrintResult(greedyAlgorithm, data.CountFloor, numberIteration, true, resultGreedy_label);
            }
            myStopWatchGreedy.Stop();
            PrintResult.GreedyIterationPrintResult(totalOptimalResult, data.CountFloor, optimalNumberIteration, false, resultGreedy_label);

            resultGreedy_label.Text +=
                  string.Format(MessagesText.WorkTimeHeuristicAlgoruthm,
                   myStopWatchGreedy.ElapsedMilliseconds / 1000.0).ToString(CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture);
        }
    }
}
