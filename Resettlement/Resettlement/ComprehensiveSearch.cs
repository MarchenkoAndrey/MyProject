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
//        private void PerformComprehensiveSearch(DataAlgorithm dataAlg)
//        {
//            if (dataAlg.CountFloor == 0)
//            {
//                MessageBox.Show(ErrorsText.NotSelectedFloor);
//                return;
//            }
//
//            realizat_label.Text = "".ToString(CultureInfo.InvariantCulture);
//            lossesOne_label.Text = "".ToString(CultureInfo.InvariantCulture);
//            resultFullSearch_label.Text = "".ToString(CultureInfo.InvariantCulture);
//
//            var realCountFlat = dataAlg.ListLengthOneBedroomApartnent.Count + dataAlg.ListLengthTwoBedroomApartnent.Count;
//            realizat_label.Text += string.Format(MessagesText.RealizationForRectangles, realCountFlat).ToString(CultureInfo.InvariantCulture);
//            lossesOne_label.Text += string.Format(MessagesText.SummarizeAdditionLengthForH, dataAlg.SumDelta.ToString(CultureInfo.InvariantCulture));
//
//            var newListFlatAfterGrouping = new List<object>();
//            var fineAfterGrouping = 0.0;
//            if (dataAlg.CountFloor == 2 || dataAlg.CountFloor == 3 || dataAlg.CountFloor == 4)
//            {
//                newListFlatAfterGrouping = GroupingOnTheFloors.GroupingApartment(dataAlg.ListLengthOneBedroomApartnent, dataAlg.ListLengthTwoBedroomApartnent,dataAlg.CountFloor);
//                dataAlg.ListLengthOneBedroomApartnent = PreparationSquares.FlatsWithTheAdditiveLength((List<double>)newListFlatAfterGrouping[0]);
//                dataAlg.ListLengthTwoBedroomApartnent = PreparationSquares.FlatsWithTheAdditiveLength((List<double>)newListFlatAfterGrouping[1]);
//                fineAfterGrouping = (double)newListFlatAfterGrouping[2];
//            }
//
//            if ((dataAlg.ListLengthOneBedroomApartnent.Count >= 12 || dataAlg.ListLengthTwoBedroomApartnent.Count >= 12) && dataAlg.CountFloor == 1)
//            {
//                MessageBox.Show(ErrorsText.NotSixContaiters);
//                return;
//            }
//
//            if ((Math.Abs(dataAlg.ListLengthOneBedroomApartnent.Count - dataAlg.ListLengthTwoBedroomApartnent.Count) >= 3 ||
//                (Math.Abs(dataAlg.ListLengthOneBedroomApartnent.Count - dataAlg.ListLengthTwoBedroomApartnent.Count) == 2 && dataAlg.ListLengthOneBedroomApartnent.Count % 2 != 0)) && dataAlg.CountFloor == 1)
//            {
//                MessageBox.Show(ErrorsText.TooManyContainers);
//                return;
//            }
//
//            if (dataAlg.ListLengthOneBedroomApartnent.Count >= 12 || dataAlg.ListLengthTwoBedroomApartnent.Count >= 12 && dataAlg.CountFloor > 1)
//            {
//                MessageBox.Show(ErrorsText.NotSixContaiters);
//                return;
//            }
//
//            var myStopWatch = new Stopwatch();
//            myStopWatch.Start();
//
//            var fullSearch = MethodeFullSearch.FullSearch(dataAlg.ListLengthOneBedroomApartnent, dataAlg.ListLengthTwoBedroomApartnent, dataAlg.Step, dataAlg.Entryway);
//            if (dataAlg.CountFloor == 2)
//            {
//                fullSearch[0] = Math.Round((double)fullSearch[0] * 2.0, 1);
//            }
//
//            if (dataAlg.CountFloor == 3)
//            {
//                fullSearch[0] = Math.Round((double)fullSearch[0] * 3.0, 1);
//            }
//
//            if (dataAlg.CountFloor == 4)
//            {
//                fullSearch[0] = Math.Round((double)fullSearch[0] * 4.0, 1);
//            }
//
//            fullSearch[0] = Math.Round((double)fullSearch[0] + fineAfterGrouping, 1);
//            if (dataAlg.CountFloor != 1)
//            {
//                fullSearch[3] = newListFlatAfterGrouping[3];
//                fullSearch[4] = newListFlatAfterGrouping[4];
//            }
//            PrintResult.FullSearchPrintResult(fullSearch, dataAlg.CountFloor, resultFullSearch_label);
//
//            myStopWatch.Stop();
//            resultFullSearch_label.Text += MessagesText.NextLine;
//            var timeFullSearch = String.Format(MessagesText.WorkTimeComprehensiveSearch, 
//                myStopWatch.ElapsedMilliseconds/1000.0).ToString(CultureInfo.InvariantCulture);               
//            resultFullSearch_label.Text += timeFullSearch.ToString(CultureInfo.InvariantCulture);
//        }
    }
}
