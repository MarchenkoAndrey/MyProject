﻿using System;
using System.Diagnostics;
using System.Globalization;
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
            realizat_label.Text += string.Format(MessagesText.RealizationForRectangles,flatCount).ToString(CultureInfo.InvariantCulture);
//            lossesOne_label.Text += string.Format(MessagesText.SummarizeAdditionLengthForH, inData.SumDelta.ToString(CultureInfo.InvariantCulture));

            var dataAlg = new DataPerformAlgorithm(inData.ListLenOneFlat,inData.ListLenTwoFlat);

            var resultDataAfterGrouping = GroupingOnTheFloors.GroupingFlat(inData);
            dataAlg.ListLenOneFlat =
                PreparationSquares.FlatsWithTheAdditiveLength(resultDataAfterGrouping.ListResultOneFlat);
            dataAlg.ListLenTwoFlat =
                PreparationSquares.FlatsWithTheAdditiveLength(resultDataAfterGrouping.ListResultTwoFlat);
            dataAlg.FineAfterGrouping = resultDataAfterGrouping.Fine;

            var myStopWatchGreedy = new Stopwatch();
            myStopWatchGreedy.Start();
            var firstOneFlat = 0.0; // в RGreedyMethode
            var numberIteration = 0;
            var allIterationsResult = new ResultGreedyMethode[Constraints.NumberOfIteration];
            var totalOptimalResult = new ResultGreedyMethode(double.MaxValue);

            while (numberIteration < Constraints.NumberOfIteration)
            {
                var resultGreedyIter =
                    GreedyMethodeSect.GreedyMethode(
                        new DataMethode(dataAlg.ListLenOneFlat, dataAlg.ListLenTwoFlat, inData.OptCountFlatOnFloor),
                        firstOneFlat);
                firstOneFlat = resultGreedyIter.NewFirstOneFlat;
                resultGreedyIter.NumIter = numberIteration;
                resultGreedyIter.Fine = Math.Round(resultGreedyIter.Fine * inData.CountFloor, 1);
                resultGreedyIter.Fine = Math.Round(resultGreedyIter.Fine + dataAlg.FineAfterGrouping, 1); //Todo каждый раз суммируется??
                resultGreedyIter.ListLenExceedOneFlat = resultDataAfterGrouping.ListExcessOneFlat;
                resultGreedyIter.ListLenExceedTwoFlat = resultDataAfterGrouping.ListExcessTwoFlat;

                allIterationsResult[numberIteration] = resultGreedyIter;

                if (resultGreedyIter.Fine < totalOptimalResult.Fine)
                {
                    totalOptimalResult = resultGreedyIter;
                }
                //Вывод результата по итерациям
                PrintResult.GreedyIterationPrintResult(resultGreedyIter, inData.CountFloor, true, resultGreedy_label);
                numberIteration++;
            }
            myStopWatchGreedy.Stop();
            PrintResult.GreedyIterationPrintResult(totalOptimalResult, inData.CountFloor, false, resultGreedy_label);

            resultGreedy_label.Text +=
                  string.Format(MessagesText.WorkTimeHeuristicAlgoruthm,
                   myStopWatchGreedy.ElapsedMilliseconds / 1000.0).ToString(CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture);
        }
    }
}
