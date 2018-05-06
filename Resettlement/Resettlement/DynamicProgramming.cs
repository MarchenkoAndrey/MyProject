using System.Diagnostics;
using System.Globalization;
using ComputationMethods;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    partial class UserInterface
    {
        private void PerformDAlg(InputSectionDataAlg inSectionData)
        {
            ValidateConditions.Validate(inSectionData, true);

            realizat_label.Text = "".ToString(CultureInfo.InvariantCulture);
            lossesOne_label.Text = "".ToString(CultureInfo.InvariantCulture);
            resultDynam_label.Text = "".ToString(CultureInfo.InvariantCulture);
            resultDynam_label.Text = string.Format(MessagesText.ResultDynamicProgram);

            var flatCount = inSectionData.ListLenOneFlat.Count + inSectionData.ListLenTwoFlat.Count;
            realizat_label.Text += string.Format(MessagesText.RealizationForRectangles,flatCount).ToString(CultureInfo.InvariantCulture);
//            lossesOne_label.Text += string.Format(MessagesText.SummarizeAdditionLengthForH, inData.SumDelta.ToString(CultureInfo.InvariantCulture));

            var dataAlg = new DataPerformAlgorithm();

            var resultDataAfterGrouping = GroupingOnTheFloors.GroupingFlat(inSectionData);
            dataAlg.ListLenOneFlat =
                PreparationSquares.FlatsWithTheAdditiveLength(resultDataAfterGrouping.ListResultOneFlat);
            dataAlg.ListLenTwoFlat =
                PreparationSquares.FlatsWithTheAdditiveLength(resultDataAfterGrouping.ListResultTwoFlat);

            var myStopWatchDynamic = new Stopwatch();
            myStopWatchDynamic.Start();
            
            // Create solution-tree
            var resultListDynM =
                DynamicMethodeSect.DynamicMethode(new DataMethode(dataAlg.ListLenOneFlat, dataAlg.ListLenTwoFlat,
                    inSectionData.OptCountFlatOnFloor));

            // Backtracking for optimal solution
            var backTrackingResult = BackTrackForDynPr.BackTracking(resultListDynM);

            // Print Result ( штраф по этажам и от группировки считаем внутри печати, а также приведение площадей)
            PrintResult.DynamicProgrammingPrintResult(backTrackingResult, inSectionData.CountFloor, resultDataAfterGrouping, resultDynam_label);
            
            myStopWatchDynamic.Stop();
            resultDynam_label.Text +=
                  string.Format(MessagesText.WorkTimeDynamicProgram,
                   myStopWatchDynamic.ElapsedMilliseconds / 1000.0).ToString(CultureInfo.InvariantCulture);
        }
    }
}
