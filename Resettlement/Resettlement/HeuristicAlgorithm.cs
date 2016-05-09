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
        private void PerformHeuristicAlgorithm(List<object> preparationInputData)
        {
            var oneListApartment = new AddEssence();
            var twoListApartment = new AddEssence();



            var entryway = (double)preparationInputData[0];
//            var widthOfApartment = (double)preparationInputData[1];
            var step = (double)preparationInputData[2];
            var sumDelta = (double)preparationInputData[3];

            var newLengthOneBedroomApartment = (List<double>) preparationInputData[4];
            var newLengthTwoBedroomApartment = (List<double>)preparationInputData[5];
            var countFloor = (int) preparationInputData[6];
            var lengthOneRoomFlat = (List<double>)preparationInputData[7];
            var lengthTwoRoomFlat = (List<double>)preparationInputData[8];

            if (countFloor == 0)
            {
                MessageBox.Show(ErrorsText.NotSelectedFloor);
                return;
            }

            realizat_label.Text = "".ToString(CultureInfo.InvariantCulture);
            lossesOne_label.Text = "".ToString(CultureInfo.InvariantCulture);
            resultGreedy_label.Text = "".ToString(CultureInfo.InvariantCulture);

            var realFlat = newLengthOneBedroomApartment.Count + newLengthTwoBedroomApartment.Count;
            realizat_label.Text += string.Format(MessagesText.RealizationForRectangles,realFlat).ToString(CultureInfo.InvariantCulture);

            lossesOne_label.Text += string.Format(MessagesText.SummarizeAdditionLengthForH, sumDelta.ToString(CultureInfo.InvariantCulture));

            var newListApartmentsAfterGrouping = new List<object>();
            var fineAfterGrouping = 0.0;
            if (countFloor == 2 || countFloor == 3 || countFloor == 4)
            {
                newListApartmentsAfterGrouping = GroupingOnTheFloors.GroupingApartment(newLengthOneBedroomApartment, newLengthTwoBedroomApartment,countFloor);
                newLengthOneBedroomApartment = PreparationSquares.FlatsWithTheAdditiveLength((List<double>)newListApartmentsAfterGrouping[0]);
                newLengthTwoBedroomApartment = PreparationSquares.FlatsWithTheAdditiveLength((List<double>)newListApartmentsAfterGrouping[1]);
                fineAfterGrouping = (double)newListApartmentsAfterGrouping[2];
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
                var greedyAlgorithm = GreedyAlgorithmSection.GreedyMethode(newLengthOneBedroomApartment, newLengthTwoBedroomApartment,
                    step, entryway, firstOneFlat);
                firstOneFlat = (double)greedyAlgorithm[5];
                greedyAlgorithm[0] = Math.Round((double)greedyAlgorithm[0] * countFloor, 1);
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

                if (countFloor != 1)
                {
                    newLengthOneBedroomApartment = PreparationSquares.FlatsRestartList((List<double>)newListApartmentsAfterGrouping[0]);
                    newLengthTwoBedroomApartment = PreparationSquares.FlatsRestartList((List<double>)newListApartmentsAfterGrouping[1]);
                    greedyAlgorithm[3] = newListApartmentsAfterGrouping[3];
                    greedyAlgorithm[4] = newListApartmentsAfterGrouping[4];
                }
                else
                {
                    newLengthOneBedroomApartment = PreparationSquares.FlatsRestartList(lengthOneRoomFlat);
                    newLengthTwoBedroomApartment = PreparationSquares.FlatsRestartList(lengthTwoRoomFlat);
                }
                //Вывод результата по итерациям


                PrintResult.GreedyIterationPrintResult(greedyAlgorithm, countFloor, numberIteration, true, resultGreedy_label);
            }
            myStopWatchGreedy.Stop();
            PrintResult.GreedyIterationPrintResult(totalOptimalResult, countFloor, optimalNumberIteration, false, resultGreedy_label);

            resultGreedy_label.Text +=
                  string.Format(MessagesText.WorkTimeHeuristicAlgoruthm,
                   myStopWatchGreedy.ElapsedMilliseconds / 1000.0).ToString(CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture);
        }
    }
}
