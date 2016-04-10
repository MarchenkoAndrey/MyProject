using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;

namespace Resettlement
{
    public partial class UserInterface : Form
    {
        public UserInterface()
        {
            InitializeComponent();
        }
        private void greedy_btn_Click(object sender, EventArgs e)
        {
            var strOne = new[]
            {
                squareOne_input.Text.ToString(CultureInfo.InvariantCulture)
            };
            var strTwo = new[]
            {
                squareTwo_input.Text.ToString(CultureInfo.InvariantCulture)
            };

            var inputValueG = valueG.Text.ToString(CultureInfo.InvariantCulture);
            var entryway = inputValueG == "" ? 2.7 : double.Parse(inputValueG);
            var inputValueC = valueC.Text.ToString(CultureInfo.InvariantCulture);
            var widthOfApartment  = inputValueC == "" ? 5.7 : double.Parse(inputValueC);
            var inputValueQ = valueQ.Text.ToString(CultureInfo.InvariantCulture);
            var step = inputValueQ =="" ? 0.3 : double.Parse(inputValueQ);

            var enterDataOneRoomFlat = ReadFromFile.ReadFileOneRoom(strOne);
            var enterDataTwoRoomFlat = ReadFromFile.ReadFileTwoRoom(strTwo);
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
            resultGreedy_label.Text = "".ToString(CultureInfo.InvariantCulture);

            var realFlat = newLengthOneRoomFlat.Count + newLengthTwoRoomFlat.Count;
            realizat_label.Text += ("Realization for " + realFlat + " rectangles").ToString(CultureInfo.InvariantCulture);

            lossesOne_label.Text += string.Format("The addition of the lengths of a rounding up\r\n to the number of times the wall thickness: {0}",
                sumDelta.ToString(CultureInfo.InvariantCulture));

            var newListFlatAfterGrouping = new List<object>();
            var fineAfterGrouping = 0.0;
            if (countFloor == 2)
            {
                newListFlatAfterGrouping = GroupingOnTheFloors.GroupingTwoFloors(newLengthOneRoomFlat, newLengthTwoRoomFlat);
                newLengthOneRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength((List<double>) newListFlatAfterGrouping[0]); 
                newLengthTwoRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength((List<double>) newListFlatAfterGrouping[1]);
                fineAfterGrouping = (double) newListFlatAfterGrouping[2];
            }
            if (countFloor == 3)
            {
                newListFlatAfterGrouping = GroupingOnTheFloors.GroupingThreeFloors(newLengthOneRoomFlat, newLengthTwoRoomFlat);
                newLengthOneRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength((List<double>)newListFlatAfterGrouping[0]);
                newLengthTwoRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength((List<double>)newListFlatAfterGrouping[1]);
                fineAfterGrouping = (double) newListFlatAfterGrouping[2];
            }

            if (countFloor == 4)
            {
                newListFlatAfterGrouping = GroupingOnTheFloors.GroupingFourthFloors(newLengthOneRoomFlat, newLengthTwoRoomFlat);
                newLengthOneRoomFlat = PreparationSquares.FlatsRestartList((List<double>)newListFlatAfterGrouping[0]);
                newLengthTwoRoomFlat = PreparationSquares.FlatsRestartList((List<double>)newListFlatAfterGrouping[1]);
                fineAfterGrouping = (double)newListFlatAfterGrouping[2];
            }

            var myStopWatchGreedy = new Stopwatch();
            myStopWatchGreedy.Start();
            var firstOneFlat = 0.0;
            var a = 0;
            var a1 = 0;
            var totalOptimalResult = new List<object>();

            while (a<5)
            {
                a++;
                var greedyAlgorithm = GreedyAlgorithmSection.GreedyMethode(newLengthOneRoomFlat, newLengthTwoRoomFlat,
                    step, entryway, firstOneFlat);
                firstOneFlat = (double)greedyAlgorithm[3];
                if (countFloor == 2)
                {
                    greedyAlgorithm[0] = Math.Round((double) greedyAlgorithm[0] * 2.0,1);
                }

                if (countFloor == 3)
                {
                    greedyAlgorithm[0] = Math.Round((double) greedyAlgorithm[0] * 3.0,1);
                }

                if (countFloor == 4)
                {
                    greedyAlgorithm[0] = Math.Round((double)greedyAlgorithm[0] * 4.0, 1);
                }

                greedyAlgorithm[0] = Math.Round((double) greedyAlgorithm[0] + fineAfterGrouping, 1);

                if (totalOptimalResult.Count == greedyAlgorithm.Count)
                {
                    if ((double)totalOptimalResult[0]>(double)greedyAlgorithm[0])
                    {
                        totalOptimalResult = greedyAlgorithm;
                        a1 = a;
                    }
                }
                else
                {
                    totalOptimalResult = greedyAlgorithm;
                }

                if (countFloor != 1)
                {
                    newLengthOneRoomFlat = PreparationSquares.FlatsRestartList((List<double>)newListFlatAfterGrouping[0]);
                    newLengthTwoRoomFlat = PreparationSquares.FlatsRestartList((List<double>)newListFlatAfterGrouping[1]);
                    greedyAlgorithm[4] = newListFlatAfterGrouping[3];
                    greedyAlgorithm[5] = newListFlatAfterGrouping[4];
                }
                else
                {
                    newLengthOneRoomFlat = PreparationSquares.FlatsRestartList(lengthOneRoomFlat);
                    newLengthTwoRoomFlat = PreparationSquares.FlatsRestartList(lengthTwoRoomFlat);
                }
                //Вывод результата по итерациям


              PrintResult.GreedyIterationPrintResult(greedyAlgorithm,countFloor,a, true, resultGreedy_label);
            }
            myStopWatchGreedy.Stop();
            PrintResult.GreedyIterationPrintResult(totalOptimalResult, countFloor, a1, false, resultGreedy_label);

            resultGreedy_label.Text +=
                  ("Work time of the heuristic algorithm: " +
                   (myStopWatchGreedy.ElapsedMilliseconds / 1000.0).ToString(CultureInfo.InvariantCulture) +
                   " seconds").ToString(CultureInfo.InvariantCulture);
        }

        private void fullSearch_btn_Click(object sender, EventArgs e)
        {
            var inputValueG = valueG.Text.ToString(CultureInfo.InvariantCulture);
            var entryway = inputValueG == "" ? 2.7 : double.Parse(inputValueG);
            var inputValueC = valueC.Text.ToString(CultureInfo.InvariantCulture);
            var widthOfApartment = inputValueC == "" ? 5.7 : double.Parse(inputValueC);
            var inputValueQ = valueQ.Text.ToString(CultureInfo.InvariantCulture);
            var step = inputValueQ == "" ? 0.3 : double.Parse(inputValueQ);

            var strOne = new []
            {
                squareOne_input.Text.ToString(CultureInfo.InvariantCulture)
            };
            var strTwo = new []
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
            lossesOne_label.Text += string.Format("The addition of the lengths of a rounding up\r\n to the number of times the wall thickness: {0}",  sumDelta.ToString(CultureInfo.InvariantCulture));

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

            if ((newLengthOneRoomFlat.Count >= 12 || newLengthTwoRoomFlat.Count >= 12) && countFloor==1)
            {
                MessageBox.Show("For 6 or more containers, use only heuristic algorithm"); 
                return;
            }

            if ((Math.Abs(lengthOneRoomFlat.Count - lengthTwoRoomFlat.Count) >= 3 ||
                (Math.Abs(lengthOneRoomFlat.Count - lengthTwoRoomFlat.Count) == 2 && lengthOneRoomFlat.Count % 2 != 0)) && countFloor==1)
            {
                MessageBox.Show("Too many containers for sorting");
                return;
            }

            if(newLengthOneRoomFlat.Count>=12 || newLengthTwoRoomFlat.Count>=12 && countFloor>1)
            {
                MessageBox.Show("For 6 or more containers, use only heuristic algorithm");
                return;
            }

            var myStopWatch = new Stopwatch();
            myStopWatch.Start();

            var fullSearch = MethodeFullSearch.FullSearch(newLengthOneRoomFlat, newLengthTwoRoomFlat, step, entryway, countFloor);
            if (countFloor == 2)
            {
                fullSearch[0] = Math.Round((double) fullSearch[0] * 2.0,1);
            }

            if (countFloor == 3)
            {
                fullSearch[0] = Math.Round((double)fullSearch[0] * 3.0,1);
            }

            if (countFloor == 4)
            {
                fullSearch[0] = Math.Round((double)fullSearch[0] * 4.0, 1);
            }

            fullSearch[0] = Math.Round((double)fullSearch[0] + fineAfterGrouping,1);
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
