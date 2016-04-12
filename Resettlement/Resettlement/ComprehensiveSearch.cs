using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using Resettlement.GeneralData;

namespace Resettlement
{
    partial class UserInterface
    {
        private void PerformComprehensiveSearch(List<object> preparationInputData)
        {
            var entryway = (double)preparationInputData[0];
            var widthOfApartment = (double)preparationInputData[1];
            var step = (double)preparationInputData[2];
            var sumDelta = (double)preparationInputData[3];
            var newLengthOneRoomFlat = (List<double>)preparationInputData[4];
            var newLengthTwoRoomFlat = (List<double>)preparationInputData[5];
            var countFloor = (int)preparationInputData[6];
            var lengthOneRoomFlat = (List<double>)preparationInputData[7];
            var lengthTwoRoomFlat = (List<double>)preparationInputData[8];

            if (countFloor == 0)
            {
                MessageBox.Show(ErrorsText.NotSelectedFloor);
                return;
            }

            realizat_label.Text = "".ToString(CultureInfo.InvariantCulture);
            lossesOne_label.Text = "".ToString(CultureInfo.InvariantCulture);
            resultFullSearch_label.Text = "".ToString(CultureInfo.InvariantCulture);

            var realCountFlat = newLengthOneRoomFlat.Count + newLengthTwoRoomFlat.Count;
            realizat_label.Text += string.Format(MessagesText.RealizationForRectangles, realCountFlat).ToString(CultureInfo.InvariantCulture);
            lossesOne_label.Text += string.Format(MessagesText.SummarizeAdditionLengthForH, sumDelta.ToString(CultureInfo.InvariantCulture));

            var newListFlatAfterGrouping = new List<object>();
            var fineAfterGrouping = 0.0;
            if (countFloor == 2 || countFloor == 3 || countFloor == 4)
            {
                newListFlatAfterGrouping = GroupingOnTheFloors.GroupingApartment(newLengthOneRoomFlat, newLengthTwoRoomFlat,countFloor);
                newLengthOneRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength((List<double>)newListFlatAfterGrouping[0]);
                newLengthTwoRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength((List<double>)newListFlatAfterGrouping[1]);
                fineAfterGrouping = (double)newListFlatAfterGrouping[2];
            }

            if ((newLengthOneRoomFlat.Count >= 12 || newLengthTwoRoomFlat.Count >= 12) && countFloor == 1)
            {
                MessageBox.Show(ErrorsText.NotSixContaiters);
                return;
            }

            if ((Math.Abs(lengthOneRoomFlat.Count - lengthTwoRoomFlat.Count) >= 3 ||
                (Math.Abs(lengthOneRoomFlat.Count - lengthTwoRoomFlat.Count) == 2 && lengthOneRoomFlat.Count % 2 != 0)) && countFloor == 1)
            {
                MessageBox.Show(ErrorsText.TooManyContainers);
                return;
            }

            if (newLengthOneRoomFlat.Count >= 12 || newLengthTwoRoomFlat.Count >= 12 && countFloor > 1)
            {
                MessageBox.Show(ErrorsText.NotSixContaiters);
                return;
            }

            var myStopWatch = new Stopwatch();
            myStopWatch.Start();

            var fullSearch = MethodeFullSearch.FullSearch(newLengthOneRoomFlat, newLengthTwoRoomFlat, step, entryway, countFloor);
            if (countFloor == 2)
            {
                fullSearch[0] = Math.Round((double)fullSearch[0] * 2.0, 1);
            }

            if (countFloor == 3)
            {
                fullSearch[0] = Math.Round((double)fullSearch[0] * 3.0, 1);
            }

            if (countFloor == 4)
            {
                fullSearch[0] = Math.Round((double)fullSearch[0] * 4.0, 1);
            }

            fullSearch[0] = Math.Round((double)fullSearch[0] + fineAfterGrouping, 1);
            if (countFloor != 1)
            {
                fullSearch[3] = newListFlatAfterGrouping[3];
                fullSearch[4] = newListFlatAfterGrouping[4];
            }
            PrintResult.FullSearchPrintResult(fullSearch, countFloor, resultFullSearch_label);

            myStopWatch.Stop();
            resultFullSearch_label.Text += MessagesText.NextLine;
            var timeFullSearch = String.Format(MessagesText.WorkTimeComprehensiveSearch, 
                myStopWatch.ElapsedMilliseconds/1000.0).ToString(CultureInfo.InvariantCulture);               
            resultFullSearch_label.Text += timeFullSearch.ToString(CultureInfo.InvariantCulture);
        }
    }
}
