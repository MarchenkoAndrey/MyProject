using System;
using System.Diagnostics;
using System.Globalization;
using ComputationMethods;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    partial class UserInterface
    {
        private void PerformDAlg(InputDataAlg inData)
        {
            ValidateConditions.Validate(inData, true);

            realizat_label.Text = "".ToString(CultureInfo.InvariantCulture);
            lossesOne_label.Text = "".ToString(CultureInfo.InvariantCulture);
            resultGreedy_label.Text = "".ToString(CultureInfo.InvariantCulture);

            var flatCount = inData.ListLenOneFlat.Count + inData.ListLenTwoFlat.Count;
            realizat_label.Text += string.Format(MessagesText.RealizationForRectangles,flatCount).ToString(CultureInfo.InvariantCulture);
            lossesOne_label.Text += string.Format(MessagesText.SummarizeAdditionLengthForH, inData.SumDelta.ToString(CultureInfo.InvariantCulture));

            var dataAlg = new DataPerformAlgorithm(inData.ListLenOneFlat,inData.ListLenTwoFlat);

            var resultDataAfterGrouping = GroupingOnTheFloors.GroupingFlat(inData);
            dataAlg.ListLenOneFlat =
                PreparationSquares.FlatsWithTheAdditiveLength(resultDataAfterGrouping.ListResultOneFlat);
            dataAlg.ListLenTwoFlat =
                PreparationSquares.FlatsWithTheAdditiveLength(resultDataAfterGrouping.ListResultTwoFlat);
            dataAlg.FineAfterGrouping = resultDataAfterGrouping.Fine;

            var myStopWatchDynamic = new Stopwatch();
            myStopWatchDynamic.Start();


            
            // var resultDynamicIter = Methode, renurn tree (array containers)
            // backtracking for optimal solution
            // Print Result

//            var resultDynamicMethode = DynamicMethodeSect.DynamicMethode(dataAlg.ListLenOneFlat, dataAlg.ListLenTwoFlat, inData.OptCountFlatOnFloor);
            var resultDynamicMethode =
                DynamicMethodeSect.DynamicMethode(new DataGreedyMethode(dataAlg.ListLenOneFlat, dataAlg.ListLenTwoFlat,
                    inData.OptCountFlatOnFloor));

                

            myStopWatchDynamic.Stop();
            //PrintResult.GreedyIterationPrintResult(totalOptimalResult, inData.CountFloor, false, resultGreedy_label);

            resultGreedy_label.Text +=
                  string.Format(MessagesText.WorkTimeHeuristicAlgoruthm,
                   myStopWatchDynamic.ElapsedMilliseconds / 1000.0).ToString(CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture);
        }
    }
}
