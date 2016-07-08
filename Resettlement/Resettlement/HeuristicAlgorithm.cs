using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using ComputationMethods;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    partial class UserInterface
    {
//        private void PerformHeuristicAlgorithm(DataAlgorithm dataAlg)
//        {
//            if (dataAlg.CountFloor == 0)
//            {
//                MessageBox.Show(ErrorsText.NotSelectedFloor);
//                return;
//            }
//
//            realizat_label.Text = "".ToString(CultureInfo.InvariantCulture);
//            lossesOne_label.Text = "".ToString(CultureInfo.InvariantCulture);
//            resultGreedy_label.Text = "".ToString(CultureInfo.InvariantCulture);
//
//            var realFlat = dataAlg.ListLengthOneBedroomApartnent.Count + dataAlg.ListLengthTwoBedroomApartnent.Count;
//            realizat_label.Text += string.Format(MessagesText.RealizationForRectangles,realFlat).ToString(CultureInfo.InvariantCulture);
//
//            lossesOne_label.Text += string.Format(MessagesText.SummarizeAdditionLengthForH, dataAlg.SumDelta.ToString(CultureInfo.InvariantCulture));
//
//            var newListApartmentsAfterGrouping = new List<object>();
//            var fineAfterGrouping = 0.0;
//            if (dataAlg.CountFloor == 2 || dataAlg.CountFloor == 3 || dataAlg.CountFloor == 4)
//            {
//                newListApartmentsAfterGrouping = GroupingOnTheFloors.GroupingApartment(dataAlg.ListLengthOneBedroomApartnent, dataAlg.ListLengthTwoBedroomApartnent,dataAlg.CountFloor);
//                dataAlg.ListLengthOneBedroomApartnent = PreparationSquares.FlatsWithTheAdditiveLength((List<double>)newListApartmentsAfterGrouping[0]);
//                dataAlg.ListLengthTwoBedroomApartnent = PreparationSquares.FlatsWithTheAdditiveLength((List<double>)newListApartmentsAfterGrouping[1]);
//                fineAfterGrouping = (double)newListApartmentsAfterGrouping[2];
//            }       
//
//            var myStopWatchGreedy = new Stopwatch();
//            myStopWatchGreedy.Start();
//            var firstOneFlat = 0.0;
//            var numberIteration = 0;
//            var optimalNumberIteration = 0;
//            var totalOptimalResult = new List<object>();
//
//            while (numberIteration < Constraints.NumberOfIteration)
//            {
//                numberIteration++;
//                var greedyAlgorithm = GreedyAlgorithmSection.GreedyMethode(dataAlg.ListLengthOneBedroomApartnent, dataAlg.ListLengthTwoBedroomApartnent,
//                    dataAlg.Step, dataAlg.Entryway, firstOneFlat);
//                firstOneFlat = (double)greedyAlgorithm[5];
//                greedyAlgorithm[0] = Math.Round((double)greedyAlgorithm[0] * dataAlg.CountFloor, 1);
//                greedyAlgorithm[0] = Math.Round((double)greedyAlgorithm[0] + fineAfterGrouping, 1);
//
//                if (totalOptimalResult.Count == greedyAlgorithm.Count)
//                {
//                    if ((double)totalOptimalResult[0] > (double)greedyAlgorithm[0])
//                    {
//                        totalOptimalResult = greedyAlgorithm;
//                        optimalNumberIteration = numberIteration;
//                    }
//                }
//                else
//                {
//                    totalOptimalResult = greedyAlgorithm;
//                }
//
//                if (dataAlg.CountFloor != 1)
//                {
//                    dataAlg.ListLengthOneBedroomApartnent = PreparationSquares.FlatsRestartList((List<double>)newListApartmentsAfterGrouping[0]);
//                    dataAlg.ListLengthTwoBedroomApartnent = PreparationSquares.FlatsRestartList((List<double>)newListApartmentsAfterGrouping[1]);
//                    greedyAlgorithm[3] = newListApartmentsAfterGrouping[3];
//                    greedyAlgorithm[4] = newListApartmentsAfterGrouping[4];
//                }
//                else
//                {
//                    dataAlg.ListLengthOneBedroomApartnent = PreparationSquares.FlatsWithTheAdditiveLength(dataAlg.ListLengthOneBedroomApartnentWithoutFormats);
//                    dataAlg.ListLengthTwoBedroomApartnent = PreparationSquares.FlatsWithTheAdditiveLength(dataAlg.ListLengthTwoBedroomApartnentWithoutFormats);
//                }
//                //Вывод результата по итерациям
//                PrintResult.GreedyIterationPrintResult(greedyAlgorithm, dataAlg.CountFloor, numberIteration, true, resultGreedy_label);
//            }
//            myStopWatchGreedy.Stop();
//            PrintResult.GreedyIterationPrintResult(totalOptimalResult, dataAlg.CountFloor, optimalNumberIteration, false, resultGreedy_label);
//
//            resultGreedy_label.Text +=
//                  string.Format(MessagesText.WorkTimeHeuristicAlgoruthm,
//                   myStopWatchGreedy.ElapsedMilliseconds / 1000.0).ToString(CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture);
//        }
    }
}
