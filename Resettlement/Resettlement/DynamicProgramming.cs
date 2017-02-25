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
//            lossesOne_label.Text += string.Format(MessagesText.SummarizeAdditionLengthForH, inData.SumDelta.ToString(CultureInfo.InvariantCulture));

            var dataAlg = new DataPerformAlgorithm(inData.ListLenOneFlat,inData.ListLenTwoFlat);

            var resultDataAfterGrouping = GroupingOnTheFloors.GroupingFlat(inData);
            dataAlg.ListLenOneFlat =
                PreparationSquares.FlatsWithTheAdditiveLength(resultDataAfterGrouping.ListResultOneFlat);
            dataAlg.ListLenTwoFlat =
                PreparationSquares.FlatsWithTheAdditiveLength(resultDataAfterGrouping.ListResultTwoFlat);

            var myStopWatchDynamic = new Stopwatch();
            myStopWatchDynamic.Start();
            
            // Create solution-tree
            var resultListDynM =
                DynamicMethodeSect.DynamicMethode(new DataMethode(dataAlg.ListLenOneFlat, dataAlg.ListLenTwoFlat,
                    inData.OptCountFlatOnFloor));

            // Backtracking for optimal solution
            var backTrackingResult = BackTrackForDynPr.BackTracking(resultListDynM);

            // Print Result ( штраф по этажам и от группировки считаем внутри печати )
            PrintResult.DynamicProgrammingPrintResult(backTrackingResult, inData.CountFloor, resultDataAfterGrouping, resultGreedy_label);
            
            myStopWatchDynamic.Stop();
            resultGreedy_label.Text +=
                  string.Format(MessagesText.WorkTimeHeuristicAlgoruthm,
                   myStopWatchDynamic.ElapsedMilliseconds / 1000.0).ToString(CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture);
        }
    }
}
