﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using Resettlement.GeneralData;

namespace Resettlement
{
    partial class UserInterface
    {
        private void PerformHeuristicAlgorithm(List<object> preparationInputData)
        {
            var entryway = (double)preparationInputData[0];
            var widthOfApartment = (double)preparationInputData[1];
            var step = (double)preparationInputData[2];
            var sumDelta = (double)preparationInputData[3];
            var newLengthOneRoomFlat = (List<double>) preparationInputData[4];
            var newLengthTwoRoomFlat = (List<double>)preparationInputData[5];
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

            var realFlat = newLengthOneRoomFlat.Count + newLengthTwoRoomFlat.Count;
            realizat_label.Text += string.Format(MessagesText.RealizationForRectangles,realFlat).ToString(CultureInfo.InvariantCulture);

            lossesOne_label.Text += string.Format(MessagesText.SummarizeAdditionLengthForH, sumDelta.ToString(CultureInfo.InvariantCulture));

            var newListFlatAfterGrouping = new List<object>();
            var fineAfterGrouping = 0.0;
            if (countFloor == 2)
            {
                newListFlatAfterGrouping = GroupingOnTheFloors.GroupingTwoFloors(newLengthOneRoomFlat, newLengthTwoRoomFlat);
                newLengthOneRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength((List<double>)newListFlatAfterGrouping[0]);
                newLengthTwoRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength((List<double>)newListFlatAfterGrouping[1]);
                fineAfterGrouping = (double)newListFlatAfterGrouping[2];
            }
            if (countFloor == 3)
            {
                newListFlatAfterGrouping = GroupingOnTheFloors.GroupingThreeFloors(newLengthOneRoomFlat, newLengthTwoRoomFlat);
                newLengthOneRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength((List<double>)newListFlatAfterGrouping[0]);
                newLengthTwoRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength((List<double>)newListFlatAfterGrouping[1]);
                fineAfterGrouping = (double)newListFlatAfterGrouping[2];
            }

            if (countFloor == 4)
            {
                newListFlatAfterGrouping = GroupingOnTheFloors.GroupingFourthFloors(newLengthOneRoomFlat, newLengthTwoRoomFlat);
                newLengthOneRoomFlat = PreparationSquares.FlatsRestartList((List<double>)newListFlatAfterGrouping[0]);
                newLengthTwoRoomFlat = PreparationSquares.FlatsRestartList((List<double>)newListFlatAfterGrouping[1]);
                fineAfterGrouping = (double)newListFlatAfterGrouping[2];
            }

            var myStopWatchGreedy = new Stopwatch();
            myStopWatchGreedy.Start();
            var firstOneFlat = 0.0;
            var numberIteration = 0;
            var optimalNumberIteration = 0;
            var totalOptimalResult = new List<object>();

            while (numberIteration < 5)
            {
                numberIteration++;
                var greedyAlgorithm = GreedyAlgorithmSection.GreedyMethode(newLengthOneRoomFlat, newLengthTwoRoomFlat,
                    step, entryway, firstOneFlat);
                firstOneFlat = (double)greedyAlgorithm[5];
                if (countFloor == 2)
                {
                    greedyAlgorithm[0] = Math.Round((double)greedyAlgorithm[0] * 2.0, 1);
                }

                if (countFloor == 3)
                {
                    greedyAlgorithm[0] = Math.Round((double)greedyAlgorithm[0] * 3.0, 1);
                }

                if (countFloor == 4)
                {
                    greedyAlgorithm[0] = Math.Round((double)greedyAlgorithm[0] * 4.0, 1);
                }

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
                    newLengthOneRoomFlat = PreparationSquares.FlatsRestartList((List<double>)newListFlatAfterGrouping[0]);
                    newLengthTwoRoomFlat = PreparationSquares.FlatsRestartList((List<double>)newListFlatAfterGrouping[1]);
                    greedyAlgorithm[3] = newListFlatAfterGrouping[3];
                    greedyAlgorithm[4] = newListFlatAfterGrouping[4];
                }
                else
                {
                    newLengthOneRoomFlat = PreparationSquares.FlatsRestartList(lengthOneRoomFlat);
                    newLengthTwoRoomFlat = PreparationSquares.FlatsRestartList(lengthTwoRoomFlat);
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
