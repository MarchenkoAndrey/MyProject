using System;
using System.Collections.Generic;
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
        private void PerformComprehensiveSearch(DataAlgorithm dataAlg)
        {
            if (dataAlg.CountFloor == 0)
            {
                MessageBox.Show(ErrorsText.NotSelectedFloor);
                return;
            }

            realizat_label.Text = "".ToString(CultureInfo.InvariantCulture);
            lossesOne_label.Text = "".ToString(CultureInfo.InvariantCulture);
            resultFullSearch_label.Text = "".ToString(CultureInfo.InvariantCulture);

            var realCountFlat = dataAlg.ListLengthOneBedroomApartment.Count() + dataAlg.ListLengthTwoBedroomApartment.Count();
            realizat_label.Text += string.Format(MessagesText.RealizationForRectangles, realCountFlat).ToString(CultureInfo.InvariantCulture);
            lossesOne_label.Text += string.Format(MessagesText.SummarizeAdditionLengthForH, dataAlg.SumDelta.ToString(CultureInfo.InvariantCulture));

            var newListFlatAfterGrouping = new List<object>();
            var fineAfterGrouping = 0.0;
            if (dataAlg.CountFloor == 2 || dataAlg.CountFloor == 3 || dataAlg.CountFloor == 4)
            {
                newListFlatAfterGrouping = GroupingOnTheFloors.GroupingApartment(dataAlg.ListLengthOneBedroomApartment, dataAlg.ListLengthTwoBedroomApartment,dataAlg.CountFloor);
                dataAlg.ListLengthOneBedroomApartment = PreparationSquares.FlatsWithTheAdditiveLength((List<double>)newListFlatAfterGrouping[0]);
                dataAlg.ListLengthTwoBedroomApartment = PreparationSquares.FlatsWithTheAdditiveLength((List<double>)newListFlatAfterGrouping[1]);
                fineAfterGrouping = (double)newListFlatAfterGrouping[2];
            }

            if ((dataAlg.ListLengthOneBedroomApartment.Count() >= 12 || dataAlg.ListLengthTwoBedroomApartment.Count >= 12) && dataAlg.CountFloor == 1)
            {
                MessageBox.Show(ErrorsText.NotSixContaiters);
                return;
            }

            if ((Math.Abs(dataAlg.ListLengthOneBedroomApartment.Count() - dataAlg.ListLengthTwoBedroomApartment.Count) >= 3 ||
                (Math.Abs(dataAlg.ListLengthOneBedroomApartment.Count() - dataAlg.ListLengthTwoBedroomApartment.Count) == 2 && dataAlg.ListLengthOneBedroomApartment.Count % 2 != 0)) && dataAlg.CountFloor == 1)
            {
                MessageBox.Show(ErrorsText.TooManyContainers);
                return;
            }

            if (dataAlg.ListLengthOneBedroomApartment.Count() >= 12 || dataAlg.ListLengthTwoBedroomApartment.Count >= 12 && dataAlg.CountFloor > 1)
            {
                MessageBox.Show(ErrorsText.NotSixContaiters);
                return;
            }

            var myStopWatch = new Stopwatch();
            myStopWatch.Start();

            var fullSearch = MethodeFullSearch.FullSearch(dataAlg.ListLengthOneBedroomApartment, dataAlg.ListLengthTwoBedroomApartment, dataAlg.Step, dataAlg.Entryway);
            if (dataAlg.CountFloor == 2)
            {
                fullSearch[0] = Math.Round((double)fullSearch[0] * 2.0, 1);
            }

            if (dataAlg.CountFloor == 3)
            {
                fullSearch[0] = Math.Round((double)fullSearch[0] * 3.0, 1);
            }

            if (dataAlg.CountFloor == 4)
            {
                fullSearch[0] = Math.Round((double)fullSearch[0] * 4.0, 1);
            }

            fullSearch[0] = Math.Round((double)fullSearch[0] + fineAfterGrouping, 1);
            if (dataAlg.CountFloor != 1)
            {
                fullSearch[3] = newListFlatAfterGrouping[3];
                fullSearch[4] = newListFlatAfterGrouping[4];
            }
            PrintResult.FullSearchPrintResult(fullSearch, dataAlg.CountFloor, resultFullSearch_label);

            myStopWatch.Stop();
            resultFullSearch_label.Text += MessagesText.NextLine;
            var timeFullSearch = String.Format(MessagesText.WorkTimeComprehensiveSearch, 
                myStopWatch.ElapsedMilliseconds/1000.0).ToString(CultureInfo.InvariantCulture);               
            resultFullSearch_label.Text += timeFullSearch.ToString(CultureInfo.InvariantCulture);
        }
    }
}
