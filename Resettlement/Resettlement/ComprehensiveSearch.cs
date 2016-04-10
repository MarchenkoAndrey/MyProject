using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;

namespace Resettlement
{
    partial class UserInterface
    {
        private void PerformComprehensiveSearch()
        {
            var entryway = InputConstraints.G(valueG.Text.ToString(CultureInfo.InvariantCulture));
            var widthOfApartment = InputConstraints.C(valueC.Text.ToString(CultureInfo.InvariantCulture));
            var step = InputConstraints.Q(valueQ.Text.ToString(CultureInfo.InvariantCulture));

            var strOne = new[]
            {
                squareOne_input.Text.ToString(CultureInfo.InvariantCulture)
            };
            var strTwo = new[]
            {
                squareTwo_input.Text.ToString(CultureInfo.InvariantCulture)
            };

            var enterDataOneRoomFlat = ReadFromFile.ReadFileOneRoom(strOne); // если пуст, то по умолчанию берем данные из указанного файла
            var enterDataTwoRoomFlat = ReadFromFile.ReadFileTwoRoom(strTwo); // если пуст, то по умолчанию берем данные из указанного файла
            var squareOneRoomFlat = new double[enterDataOneRoomFlat.Count];
            var squareTwoRoomFlat = new double[enterDataTwoRoomFlat.Count];
            //запись в массив
            for (var i = 0; i < enterDataOneRoomFlat.Count; ++i)
            {
                squareOneRoomFlat[i] = enterDataOneRoomFlat[i];
            }
            for (var i = 0; i < enterDataTwoRoomFlat.Count; ++i)
            {
                squareTwoRoomFlat[i] = enterDataTwoRoomFlat[i];
            }

            var lengthOneRoomFlat = PreparationSquares.CalculateLengthOfFlat(squareOneRoomFlat, widthOfApartment);
            var lengthTwoRoomFlat = PreparationSquares.CalculateLengthOfFlat(squareTwoRoomFlat, widthOfApartment);
            var newLengthOneRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength(lengthOneRoomFlat);
            var newLengthTwoRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength(lengthTwoRoomFlat);
            var deltaOfOneRoomFlat = PreparationSquares.DeltaSquaresOfFlats(lengthOneRoomFlat, newLengthOneRoomFlat);
            var deltaOfTwoRoomFlat = PreparationSquares.DeltaSquaresOfFlats(lengthTwoRoomFlat, newLengthTwoRoomFlat);
            var sumDelta = deltaOfOneRoomFlat + deltaOfTwoRoomFlat;

            var countFloor = 0;
            if (radioButton1.Checked)
            {
                countFloor = 1;
            }
            if (radioButton2.Checked)
            {
                countFloor = 2;
            }
            if (radioButton3.Checked)
            {
                countFloor = 3;
            }
            if (radioButton4.Checked)
            {
                countFloor = 4;
            }
            if (countFloor == 0)
            {
                MessageBox.Show("It is need to choose count of floors");
                return;
            }

            realizat_label.Text = "".ToString(CultureInfo.InvariantCulture);
            lossesOne_label.Text = "".ToString(CultureInfo.InvariantCulture);
            resultFullSearch_label.Text = "".ToString(CultureInfo.InvariantCulture);

            var realCountFlat = newLengthOneRoomFlat.Count + newLengthTwoRoomFlat.Count;
            realizat_label.Text += ("Realization for " + realCountFlat + " rectangles").ToString(CultureInfo.InvariantCulture);
            lossesOne_label.Text += string.Format("The addition of the lengths of a rounding up\r\n to the number of times the wall thickness: {0}", sumDelta.ToString(CultureInfo.InvariantCulture));

            var newListFlatAfterGrouping = new List<object>();
            var fineAfterGrouping = 0.0;
            if (countFloor == 2)
            {
                newListFlatAfterGrouping = GroupingOnTheFloors.GroupingTwoFloors(newLengthOneRoomFlat, newLengthTwoRoomFlat);
                newLengthOneRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength((List<double>)newListFlatAfterGrouping[0]);
                newLengthTwoRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength((List<double>)newListFlatAfterGrouping[1]);
                fineAfterGrouping = (double)newListFlatAfterGrouping[2];
            }
            if (countFloor == 3)
            {
                newListFlatAfterGrouping = GroupingOnTheFloors.GroupingThreeFloors(newLengthOneRoomFlat, newLengthTwoRoomFlat);
                newLengthOneRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength((List<double>)newListFlatAfterGrouping[0]);
                newLengthTwoRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength((List<double>)newListFlatAfterGrouping[1]);
                fineAfterGrouping = (double)newListFlatAfterGrouping[2];
            }

            if (countFloor == 4)
            {
                newListFlatAfterGrouping = GroupingOnTheFloors.GroupingFourthFloors(newLengthOneRoomFlat, newLengthTwoRoomFlat);
                newLengthOneRoomFlat = PreparationSquares.FlatsRestartList((List<double>)newListFlatAfterGrouping[0]);
                newLengthTwoRoomFlat = PreparationSquares.FlatsRestartList((List<double>)newListFlatAfterGrouping[1]);
                fineAfterGrouping = (double)newListFlatAfterGrouping[2];
            }

            if ((newLengthOneRoomFlat.Count >= 12 || newLengthTwoRoomFlat.Count >= 12) && countFloor == 1)
            {
                MessageBox.Show("For 6 or more containers, use only heuristic algorithm");
                return;
            }

            if ((Math.Abs(lengthOneRoomFlat.Count - lengthTwoRoomFlat.Count) >= 3 ||
                (Math.Abs(lengthOneRoomFlat.Count - lengthTwoRoomFlat.Count) == 2 && lengthOneRoomFlat.Count % 2 != 0)) && countFloor == 1)
            {
                MessageBox.Show("Too many containers for sorting");
                return;
            }

            if (newLengthOneRoomFlat.Count >= 12 || newLengthTwoRoomFlat.Count >= 12 && countFloor > 1)
            {
                MessageBox.Show("For 6 or more containers, use only heuristic algorithm");
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
            resultFullSearch_label.Text += "\r\n";
            var timeFullSearch = "Work time of the comprehensive search " +
                                 (myStopWatch.ElapsedMilliseconds / 1000.0).ToString(CultureInfo.InvariantCulture) +
                                 " seconds";
            resultFullSearch_label.Text += timeFullSearch.ToString(CultureInfo.InvariantCulture);
        }
    }
}
