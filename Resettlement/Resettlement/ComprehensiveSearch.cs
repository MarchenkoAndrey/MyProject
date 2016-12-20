using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using ComputationMethods;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    partial class UserInterface
    {
        private void PerformComprehensiveSearch(InputDataAlg inData)
        {
            ValidateConditions.Validate(inData);

            realizat_label.Text = "".ToString(CultureInfo.InvariantCulture);
            lossesOne_label.Text = "".ToString(CultureInfo.InvariantCulture);
            resultFullSearch_label.Text = "".ToString(CultureInfo.InvariantCulture);

            var flatCount = inData.ListLenOneFlat.Count + inData.ListLenTwoFlat.Count;
            realizat_label.Text += string.Format(MessagesText.RealizationForRectangles, flatCount).ToString(CultureInfo.InvariantCulture);
            lossesOne_label.Text += string.Format(MessagesText.SummarizeAdditionLengthForH, inData.SumDelta.ToString(CultureInfo.InvariantCulture));

            var resultDataAfterGrouping = new ResultDataAfterGrouping();
            var dataAlg = new DataHeuristicAlgorithm(inData.ListLenOneFlat, inData.ListLenTwoFlat);
            if (inData.CountFloor > 1)
            {
                resultDataAfterGrouping = GroupingOnTheFloors.GroupingFlat(inData);
                dataAlg.ListLenOneFlat = PreparationSquares.FlatsWithTheAdditiveLength(resultDataAfterGrouping.ListResultOneFlat);
                dataAlg.ListLenTwoFlat = PreparationSquares.FlatsWithTheAdditiveLength(resultDataAfterGrouping.ListResultTwoFlat);
                dataAlg.FineAfterGrouping = resultDataAfterGrouping.Fine;
            }
            //Todo убрать в validate
            if ((inData.ListLenOneFlat.Count >= 12 || inData.ListLenTwoFlat.Count >= 12) && inData.CountFloor == 1)
            {
                MessageBox.Show(ErrorsText.NotSixContaiters);
                return;
            }

            if ((Math.Abs(inData.ListLenOneFlat.Count - inData.ListLenTwoFlat.Count) >= 3 ||
                (Math.Abs(inData.ListLenOneFlat.Count - inData.ListLenTwoFlat.Count) == 2 && inData.ListLenOneFlat.Count % 2 != 0)) && inData.CountFloor == 1)
            {
                MessageBox.Show(ErrorsText.TooManyContainers);
                return;
            }

            if (inData.ListLenOneFlat.Count >= 12 || inData.ListLenTwoFlat.Count >= 12 && inData.CountFloor > 1)
            {
                MessageBox.Show(ErrorsText.NotSixContaiters);
                return;
            }

            var myStopWatch = new Stopwatch();
            myStopWatch.Start();

//            var fullSearch = MethodeFullSearch.FullSearch(inData);
            var fullSearch = MethodeFullSearch.FullSearch(dataAlg, inData.OptCountFlatOnFloor);

            fullSearch.Fine = Math.Round(fullSearch.Fine * inData.CountFloor, 1);
            fullSearch.Fine = Math.Round(fullSearch.Fine + dataAlg.FineAfterGrouping, 1);
            fullSearch.ListExcessOneFlat = resultDataAfterGrouping.ListExcessOneFlat;
            fullSearch.ListExcessTwoFlat = resultDataAfterGrouping.ListExcessTwoFlat;

            PrintResult.FullSearchPrintResult(fullSearch, inData.CountFloor, resultFullSearch_label);

            myStopWatch.Stop();
            resultFullSearch_label.Text += MessagesText.NextLine;
            var timeFullSearch = String.Format(MessagesText.WorkTimeComprehensiveSearch, 
                myStopWatch.ElapsedMilliseconds/1000.0).ToString(CultureInfo.InvariantCulture);               
            resultFullSearch_label.Text += timeFullSearch.ToString(CultureInfo.InvariantCulture);
        }
    }
}
