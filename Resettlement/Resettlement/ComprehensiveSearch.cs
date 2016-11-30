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
        private void PerformComprehensiveSearch(DataAlgorithm data)
        {
            if (data.CountFloor == 0)
            {
                MessageBox.Show(ErrorsText.NotSelectedFloor);
                return;
            }

            realizat_label.Text = "".ToString(CultureInfo.InvariantCulture);
            lossesOne_label.Text = "".ToString(CultureInfo.InvariantCulture);
            resultFullSearch_label.Text = "".ToString(CultureInfo.InvariantCulture);

            var realCountFlat = data.ListLengthOneBedroomApartment.Count() + data.ListLengthTwoBedroomApartment.Count();
            realizat_label.Text += string.Format(MessagesText.RealizationForRectangles, realCountFlat).ToString(CultureInfo.InvariantCulture);
            lossesOne_label.Text += string.Format(MessagesText.SummarizeAdditionLengthForH, data.SumDelta.ToString(CultureInfo.InvariantCulture));

            var newListFlatAfterGrouping = new Tuple<List<double>, List<double>, double, List<double>, List<double>>(default(List<double>),
                    default(List<double>),
                    default(double), default(List<double>), default(List<double>));
            var fineAfterGrouping = 0.0;
            if (data.CountFloor == 2 || data.CountFloor == 3 || data.CountFloor == 4)
            {
                newListFlatAfterGrouping = GroupingOnTheFloors.GroupingApartment(data.ListLengthOneBedroomApartment, data.ListLengthTwoBedroomApartment,data.CountFloor);
                data.ListLengthOneBedroomApartment = PreparationSquares.FlatsWithTheAdditiveLength(newListFlatAfterGrouping.Item1);
                data.ListLengthTwoBedroomApartment = PreparationSquares.FlatsWithTheAdditiveLength(newListFlatAfterGrouping.Item2);
                fineAfterGrouping = newListFlatAfterGrouping.Item3;
            }

            if ((data.ListLengthOneBedroomApartment.Count() >= 12 || data.ListLengthTwoBedroomApartment.Count >= 12) && data.CountFloor == 1)
            {
                MessageBox.Show(ErrorsText.NotSixContaiters);
                return;
            }

            if ((Math.Abs(data.ListLengthOneBedroomApartment.Count() - data.ListLengthTwoBedroomApartment.Count) >= 3 ||
                (Math.Abs(data.ListLengthOneBedroomApartment.Count() - data.ListLengthTwoBedroomApartment.Count) == 2 && data.ListLengthOneBedroomApartment.Count % 2 != 0)) && data.CountFloor == 1)
            {
                MessageBox.Show(ErrorsText.TooManyContainers);
                return;
            }

            if (data.ListLengthOneBedroomApartment.Count() >= 12 || data.ListLengthTwoBedroomApartment.Count >= 12 && data.CountFloor > 1)
            {
                MessageBox.Show(ErrorsText.NotSixContaiters);
                return;
            }

            var myStopWatch = new Stopwatch();
            myStopWatch.Start();

            var fullSearch = MethodeFullSearch.FullSearch(data.ListLengthOneBedroomApartment, data.ListLengthTwoBedroomApartment, data.Step, data.Entryway);
            if (data.CountFloor == 2)
            {
                fullSearch[0] = Math.Round((double)fullSearch[0] * 2.0, 1);
            }

            if (data.CountFloor == 3)
            {
                fullSearch[0] = Math.Round((double)fullSearch[0] * 3.0, 1);
            }

            if (data.CountFloor == 4)
            {
                fullSearch[0] = Math.Round((double)fullSearch[0] * 4.0, 1);
            }

            fullSearch[0] = Math.Round((double)fullSearch[0] + fineAfterGrouping, 1);
            if (data.CountFloor != 1)
            {
                fullSearch[3] = newListFlatAfterGrouping.Item4;
                fullSearch[4] = newListFlatAfterGrouping.Item5;
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
