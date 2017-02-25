using System;
using System.Diagnostics;
using System.Globalization;
using ComputationMethods;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    partial class UserInterface
    {
        private void PerformComprehensiveSearch(InputDataAlg inData)
        {
            ValidateConditions.Validate(inData, false);

            realizat_label.Text = "".ToString(CultureInfo.InvariantCulture);
            lossesOne_label.Text = "".ToString(CultureInfo.InvariantCulture);
            resultFullSearch_label.Text = "".ToString(CultureInfo.InvariantCulture);

            var flatCount = inData.ListLenOneFlat.Count + inData.ListLenTwoFlat.Count;
            realizat_label.Text += string.Format(MessagesText.RealizationForRectangles, flatCount).ToString(CultureInfo.InvariantCulture);
//            lossesOne_label.Text += string.Format(MessagesText.SummarizeAdditionLengthForH, inData.SumDelta.ToString(CultureInfo.InvariantCulture));

            var dataAlg = new DataPerformAlgorithm(inData.ListLenOneFlat, inData.ListLenTwoFlat);

            var resultDataAfterGrouping = GroupingOnTheFloors.GroupingFlat(inData);
            dataAlg.ListLenOneFlat = PreparationSquares.FlatsWithTheAdditiveLength(resultDataAfterGrouping.ListResultOneFlat);
            dataAlg.ListLenTwoFlat = PreparationSquares.FlatsWithTheAdditiveLength(resultDataAfterGrouping.ListResultTwoFlat);
            dataAlg.FineAfterGrouping = resultDataAfterGrouping.Fine;

            var myStopWatch = new Stopwatch();
            myStopWatch.Start();

            var fullSearch = MethodeFullSearch.FullSearch(dataAlg, inData.OptCountFlatOnFloor);

            fullSearch.Fine = Math.Round(fullSearch.Fine * inData.CountFloor, 1);
            fullSearch.Fine = Math.Round(fullSearch.Fine + dataAlg.FineAfterGrouping, 1);
            fullSearch.ListExcessOneFlat = resultDataAfterGrouping.ListExcessOneFlat;
            fullSearch.ListExcessTwoFlat = resultDataAfterGrouping.ListExcessTwoFlat;

            PrintResult.FullSearchPrintResult(fullSearch, inData.CountFloor, resultFullSearch_label);

            myStopWatch.Stop();
            resultFullSearch_label.Text += MessagesText.NextLine;
            var timeFullSearch = string.Format(MessagesText.WorkTimeComprehensiveSearch, 
                myStopWatch.ElapsedMilliseconds/1000.0).ToString(CultureInfo.InvariantCulture);               
            resultFullSearch_label.Text += timeFullSearch.ToString(CultureInfo.InvariantCulture);
        }
    }
}
