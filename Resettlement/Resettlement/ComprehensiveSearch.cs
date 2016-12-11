using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ComputationMethods;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    partial class UserInterface
    {
        private void PerformComprehensiveSearch(InputDataAlg data)
        {
            if (data.CountFloor == 0)
            {
                MessageBox.Show(ErrorsText.NotSelectedFloor);
                return;
            }

            realizat_label.Text = "".ToString(CultureInfo.InvariantCulture);
            lossesOne_label.Text = "".ToString(CultureInfo.InvariantCulture);
            resultFullSearch_label.Text = "".ToString(CultureInfo.InvariantCulture);

            var realCountFlat = data.ListLenOneFlat.Count + data.ListLenTwoFlat.Count;
            realizat_label.Text += string.Format(MessagesText.RealizationForRectangles, realCountFlat).ToString(CultureInfo.InvariantCulture);
            lossesOne_label.Text += string.Format(MessagesText.SummarizeAdditionLengthForH, data.SumDelta.ToString(CultureInfo.InvariantCulture));

            var resultDataAfterGrouping = new ResultDataAfterGrouping();
            var fineAfterGrouping = 0.0;
            if (data.CountFloor == 2 || data.CountFloor == 3 || data.CountFloor == 4)
            {
                resultDataAfterGrouping = GroupingOnTheFloors.GroupingFlat(data);
                data.ListLenOneFlat = PreparationSquares.FlatsWithTheAdditiveLength(resultDataAfterGrouping.ListResultOneFlat);
                data.ListLenTwoFlat = PreparationSquares.FlatsWithTheAdditiveLength(resultDataAfterGrouping.ListResultTwoFlat);
                fineAfterGrouping = resultDataAfterGrouping.Fine;
            }

            if ((data.ListLenOneFlat.Count >= 12 || data.ListLenTwoFlat.Count >= 12) && data.CountFloor == 1)
            {
                MessageBox.Show(ErrorsText.NotSixContaiters);
                return;
            }

            if ((Math.Abs(data.ListLenOneFlat.Count - data.ListLenTwoFlat.Count) >= 3 ||
                (Math.Abs(data.ListLenOneFlat.Count - data.ListLenTwoFlat.Count) == 2 && data.ListLenOneFlat.Count % 2 != 0)) && data.CountFloor == 1)
            {
                MessageBox.Show(ErrorsText.TooManyContainers);
                return;
            }

            if (data.ListLenOneFlat.Count >= 12 || data.ListLenTwoFlat.Count >= 12 && data.CountFloor > 1)
            {
                MessageBox.Show(ErrorsText.NotSixContaiters);
                return;
            }

            var myStopWatch = new Stopwatch();
            myStopWatch.Start();

            var fullSearch = MethodeFullSearch.FullSearch(data);
            if (data.CountFloor == 2)
            {
                fullSearch.Fine = Math.Round(fullSearch.Fine * 2.0, 1);
            }

            if (data.CountFloor == 3)
            {
                fullSearch.Fine = Math.Round(fullSearch.Fine * 3.0, 1);
            }

            if (data.CountFloor == 4)
            {
                fullSearch.Fine = Math.Round(fullSearch.Fine * 4.0, 1);
            }

            fullSearch.Fine = Math.Round(fullSearch.Fine + fineAfterGrouping, 1);
            if (data.CountFloor != 1)
            {
                fullSearch.ListExcessOneFlat = resultDataAfterGrouping.ListExcessOneFlat;
                fullSearch.listExcessTwoFlat = resultDataAfterGrouping.listExcessTwoFlat;
            }
            PrintResult.FullSearchPrintResult(fullSearch, data.CountFloor, resultFullSearch_label);

            myStopWatch.Stop();
            resultFullSearch_label.Text += MessagesText.NextLine;
            var timeFullSearch = String.Format(MessagesText.WorkTimeComprehensiveSearch, 
                myStopWatch.ElapsedMilliseconds/1000.0).ToString(CultureInfo.InvariantCulture);               
            resultFullSearch_label.Text += timeFullSearch.ToString(CultureInfo.InvariantCulture);
        }
    }
}
