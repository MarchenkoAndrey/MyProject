﻿using System;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void greedy_btn_Click(object sender, EventArgs e)
        {
            var strOne = new string[1]
            {
                squareOne_input.Text.ToString(CultureInfo.InvariantCulture)
            };
            var strTwo = new string[1]
            {
                squareTwo_input.Text.ToString(CultureInfo.InvariantCulture)
            };

            const double entryway = 2.7;
            const double widthOfApartment = 5.7;
            const double step = 0.3;

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
            if (countFloor == 0)
            {
                MessageBox.Show("Необходимо выбрать значение 'Этаж'");
                return;
            }

            realizat_label.Text = "".ToString(CultureInfo.InvariantCulture);
            lossesOne_label.Text = "".ToString(CultureInfo.InvariantCulture);
            lossesTwo_label.Text = "".ToString(CultureInfo.InvariantCulture);
            resultGreedy_label.Text = "".ToString(CultureInfo.InvariantCulture);

            var realFlat = newLengthOneRoomFlat.Count + newLengthTwoRoomFlat.Count;
            realizat_label.Text += ("Реализация для " + realFlat + " квартир").ToString(CultureInfo.InvariantCulture);

            var lossesOne = "Потери при округлении длин однокомнатных квартир до числа, кратного 0.3: " + deltaOfOneRoomFlat.ToString(CultureInfo.InvariantCulture);
            var lossesTwo = "Потери при округлении длин двухкомнатных квартир до числа, кратного 0.3: " + deltaOfTwoRoomFlat.ToString(CultureInfo.InvariantCulture);
            lossesOne_label.Text += lossesOne.ToString(CultureInfo.InvariantCulture);
            lossesTwo_label.Text += lossesTwo.ToString(CultureInfo.InvariantCulture);

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

            var myStopWatchGreedy = new Stopwatch();
            myStopWatchGreedy.Start();
            var firstOneFlat = 0.0;
            var currentTotalFine = 10000.0;
            var minTotalFine = 100000.0;
            var a = 0;
            var a1 = 0;
            var totalOptimalResult = new List<object>();

            while (a<2)
            {
                if (a > 0)
                {
                    minTotalFine = currentTotalFine;
                }
                a++;

                // если минимальный штраф не уменьшается, заканчивать итерацию // альтернативная концовка

                var greedyAlgorithm = GreedyAlcorithmSection.GreedyMethode(newLengthOneRoomFlat, newLengthTwoRoomFlat,
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

                greedyAlgorithm[0] = Math.Round((double) greedyAlgorithm[0] + fineAfterGrouping, 1);
                currentTotalFine = Math.Round((double)greedyAlgorithm[0],1);

                //Todo Общий итог жадного алгоритма
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
                    newLengthOneRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength((List<double>)newListFlatAfterGrouping[0]);
                    newLengthTwoRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength((List<double>)newListFlatAfterGrouping[1]);
                }
                else
                {
                    newLengthOneRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength(lengthOneRoomFlat);
                    newLengthTwoRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength(lengthTwoRoomFlat);
                }
                //Вывод результата по итерациям
              PrintResult.GreedyIterationPrintResult(greedyAlgorithm,countFloor,entryway,step,a, true);
            }
            myStopWatchGreedy.Stop();
            PrintResult.GreedyIterationPrintResult(totalOptimalResult, countFloor, entryway, step, a1, false);

            resultGreedy_label.Text +=
                  ("Время работы жадного алгоритма: " +
                   (myStopWatchGreedy.ElapsedMilliseconds / 1000.0).ToString(CultureInfo.InvariantCulture) +
                   " секунд").ToString(CultureInfo.InvariantCulture);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void fullSearch_btn_Click(object sender, EventArgs e)
        {
            const double entryway = 2.7;
            const double widthOfApartment = 5.7;
            const double step = 0.3;
            var strOne = new string[1]
            {
                squareOne_input.Text.ToString(CultureInfo.InvariantCulture)
            };
            var strTwo = new string[1]
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
            if (countFloor == 0)
            {
                MessageBox.Show("Необходимо выбрать значение 'Этаж'");
                return;
            }
            
            realizat_label.Text = "".ToString(CultureInfo.InvariantCulture);
            lossesOne_label.Text = "".ToString(CultureInfo.InvariantCulture);
            lossesTwo_label.Text = "".ToString(CultureInfo.InvariantCulture);
            resultFullSearch_label.Text = "".ToString(CultureInfo.InvariantCulture);

            var realCountFlat = newLengthOneRoomFlat.Count + newLengthTwoRoomFlat.Count;
            realizat_label.Text += ("Реализация для " + realCountFlat + " квартир").ToString(CultureInfo.InvariantCulture);

            var lossesOne = "Потери при округлении длин однокомнатных квартир до числа, кратного 0.3: " + deltaOfOneRoomFlat.ToString(CultureInfo.InvariantCulture);
            var lossesTwo = "Потери при округлении длин двухкомнатных квартир до числа, кратного 0.3: " + deltaOfTwoRoomFlat.ToString(CultureInfo.InvariantCulture);
            lossesOne_label.Text += lossesOne.ToString(CultureInfo.InvariantCulture); 
            lossesTwo_label.Text += lossesTwo.ToString(CultureInfo.InvariantCulture);

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


            if (newLengthOneRoomFlat.Count >= 12 || newLengthTwoRoomFlat.Count >= 12)
            {
                MessageBox.Show("Для 12-ти и более вариантов используйте только жадный алгоритм"); 
                return;
            }

            if (Math.Abs(lengthOneRoomFlat.Count - lengthTwoRoomFlat.Count) >= 3 ||
                (Math.Abs(lengthOneRoomFlat.Count - lengthTwoRoomFlat.Count) == 2 && lengthOneRoomFlat.Count % 2 != 0))
            {
                MessageBox.Show("Слишком много вариантов для перебора");
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

            fullSearch[0] = Math.Round((double)fullSearch[0] + fineAfterGrouping,1);

            PrintResult.FullSearchPrintResult(fullSearch,countFloor);
            
            myStopWatch.Stop();
            resultFullSearch_label.Text += "\r\n";
            var timeFullSearch = "Время работы полного перебора " +
                                 (myStopWatch.ElapsedMilliseconds / 1000.0).ToString(CultureInfo.InvariantCulture) +
                                 " секунд";
            resultFullSearch_label.Text += timeFullSearch.ToString(CultureInfo.InvariantCulture);
        }

        private void labelOne_Click(object sender, EventArgs e)
        {
            
            
        }

        private void UserInterface_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
