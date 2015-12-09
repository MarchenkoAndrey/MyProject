using System;
using System.Collections;
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
            //StartAndFinishProgram.Program(strOne,strTwo, false); 

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

            //var countFloor = 0;
            var countFloor = 0;
            if (countFloor_input.Text.ToString(CultureInfo.InvariantCulture) != "".ToString())
            {
              countFloor = int.Parse(countFloor_input.Text);
            }

            realizat_label.Text = "".ToString(CultureInfo.InvariantCulture);
            lossesOne_label.Text = "".ToString(CultureInfo.InvariantCulture);
            lossesTwo_label.Text = "".ToString(CultureInfo.InvariantCulture);
            resultGreedy_label.Text = "".ToString(CultureInfo.InvariantCulture);

            var realizateLabel = "Реализация для " + newLengthOneRoomFlat.Count * 2 + " квартир";
            realizat_label.Text += (realizateLabel).ToString(CultureInfo.InvariantCulture);

            var lossesOne = "Потери при округлении длин однокомнатных квартир до числа, кратного 0.3: " + deltaOfOneRoomFlat.ToString(CultureInfo.InvariantCulture);
            var lossesTwo = "Потери при округлении длин двухкомнатных квартир до числа, кратного 0.3: " + deltaOfTwoRoomFlat.ToString(CultureInfo.InvariantCulture);
            lossesOne_label.Text += lossesOne.ToString(CultureInfo.InvariantCulture);
            //lossesOne_label.Font = new Font("Calibri", 14);
            lossesTwo_label.Text += lossesTwo.ToString(CultureInfo.InvariantCulture);

            var myStopWatchGreedy = new Stopwatch();
            myStopWatchGreedy.Start();
            var firstOneFlat = 0.0;
            var currentTotalFine = 10000.0;
            var minTotalFine = 100000.0;
            var a = 0;
            while (minTotalFine > currentTotalFine)
            {
                if (a > 0)
                {
                    minTotalFine = currentTotalFine;
                }
                a++;

                var greedyAlhorithm = GreedyAlcorithmSection.GreedyMethode(newLengthOneRoomFlat, newLengthTwoRoomFlat,
                    step, entryway, firstOneFlat);
                firstOneFlat = (double)greedyAlhorithm[3];
                currentTotalFine = (double)greedyAlhorithm[0];

                newLengthOneRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength(lengthOneRoomFlat);
                newLengthTwoRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength(lengthTwoRoomFlat);


                //Todo второй этаж для жадного алгоритма
                if (countFloor == 2)
                {

                    resultGreedy_label.Text += ("Итог " + a + "-й итерации жадного алгоритма:" + "\r\n").ToString(CultureInfo.InvariantCulture);
                    resultGreedy_label.Text += (string.Format("Штраф {0}", greedyAlhorithm[0]) + "\r\n").ToString(CultureInfo.InvariantCulture);
                    resultGreedy_label.Text += "\r\n";
                    var optArrangeSecondFloorResult = CreateSecondFloor.MethodeCreateSecondFloor(greedyAlhorithm[1], greedyAlhorithm[2], entryway, step);
                    foreach (var i in (IEnumerable)optArrangeSecondFloorResult[0])
                    {
                        resultGreedy_label.Text += (string.Format(" {0} ", i));
                    }
                    resultGreedy_label.Text += "\r\n";

                    foreach (var i in (IEnumerable)optArrangeSecondFloorResult[1])
                    {
                        resultGreedy_label.Text += (string.Format(" {0} ", i));
                    }
                    resultGreedy_label.Text += "\r\n";

                    resultGreedy_label.Text += "_____________________\r\n";

                    foreach (var i in (IEnumerable)optArrangeSecondFloorResult[2])
                    {
                        resultGreedy_label.Text += (string.Format(" {0} ", i));
                    }
                    resultGreedy_label.Text += "\r\n";

                    foreach (var i in (IEnumerable)optArrangeSecondFloorResult[3])
                    {
                        resultGreedy_label.Text += (string.Format(" {0} ", i));
                    }
                    resultGreedy_label.Text += "\r\n";
                    resultGreedy_label.Text += (string.Format("Штраф от этажей {0} \r\n",optArrangeSecondFloorResult[4]));
                    resultGreedy_label.Text += "\r\n";
                    resultGreedy_label.Text += "\r\n";

                }
                else if (countFloor == 1 || countFloor.ToString(CultureInfo.InvariantCulture) == "")
                {
                    resultGreedy_label.Text += ("Итог " + a + "-й итерации жадного алгоритма:" + "\r\n").ToString(CultureInfo.InvariantCulture);
                    resultGreedy_label.Text += (string.Format("Штраф {0}", greedyAlhorithm[0]) + "\r\n").ToString(CultureInfo.InvariantCulture);

                    resultGreedy_label.Text +=
                        ("Оптимальная расстановка однокомнатных квартир: ").ToString(CultureInfo.InvariantCulture);
                    foreach (var i in (IEnumerable)greedyAlhorithm[1])
                    {
                        resultGreedy_label.Text += (string.Format(" {0} ", i));
                    }
                    resultGreedy_label.Text += ("\r\n").ToString(CultureInfo.InvariantCulture);
                    resultGreedy_label.Text +=
                        ("Оптимальная расстановка двухкомнатных квартир: ").ToString(CultureInfo.InvariantCulture);
                    foreach (var i in (IEnumerable)greedyAlhorithm[2])
                    {
                        resultGreedy_label.Text += (string.Format(" {0} ", i));
                    }
                    resultGreedy_label.Text += ("\r\n").ToString(CultureInfo.InvariantCulture);
                    resultGreedy_label.Text += ("\r\n").ToString(CultureInfo.InvariantCulture);
                    //var f = Math.Round(s1 + 0.3*newLengthOneRoomFlat.Count - s - 1.8*newLengthOneRoomFlat.Count,2);
                }
                else 
                {
                    MessageBox.Show("Некорректное значение в поле 'Этаж'");
                    return;
                }
                myStopWatchGreedy.Stop();
            }
            resultGreedy_label.Text +=
                  ("Время работы жадного алгоритма: " +
                   (myStopWatchGreedy.ElapsedMilliseconds / 1000.0).ToString(CultureInfo.InvariantCulture) +
                   " секунд").ToString(CultureInfo.InvariantCulture);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void countFloor_input_TextChanged(object sender, EventArgs e)
        {
            //if (int.Parse(countFloor_input.Text) != 1 && int.Parse(countFloor_input.Text) != 2)
            //{
            //    MessageBox.Show("Реализован расчет только для одного- и двухэтажного дома");
            //}
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

            //StartAndFinishProgram.Program(strOne, strTwo, true);

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
            if (countFloor_input.Text.ToString(CultureInfo.InvariantCulture) != "")
            {
               countFloor = int.Parse(countFloor_input.Text);
            }

            realizat_label.Text = "".ToString(CultureInfo.InvariantCulture);
            lossesOne_label.Text = "".ToString(CultureInfo.InvariantCulture);
            lossesTwo_label.Text = "".ToString(CultureInfo.InvariantCulture);
            resultFullSearch_label.Text = "".ToString(CultureInfo.InvariantCulture);

            var realizateLabel = "Реализация для " + newLengthOneRoomFlat.Count * 2 + " квартир";
            realizat_label.Text += (realizateLabel).ToString(CultureInfo.InvariantCulture);

            var lossesOne = "Потери при округлении длин однокомнатных квартир до числа, кратного 0.3: " + deltaOfOneRoomFlat.ToString(CultureInfo.InvariantCulture);
            var lossesTwo = "Потери при округлении длин двухкомнатных квартир до числа, кратного 0.3: " + deltaOfTwoRoomFlat.ToString(CultureInfo.InvariantCulture);
            lossesOne_label.Text += lossesOne.ToString(CultureInfo.InvariantCulture);
            //lossesOne_label.Font = new Font("Calibri", 14);
            lossesTwo_label.Text += lossesTwo.ToString(CultureInfo.InvariantCulture);
            if (lengthOneRoomFlat.Count >= 12 || lengthTwoRoomFlat.Count >= 12)
            {
                MessageBox.Show("Для 12-ти и более вариантов используйте только жадный алгоритм");
                //StartAndFinishProgram.Program(strOne, strTwo, false);
                return;
            }
            /*
            if (lengthOneRoomFlat.Count >= 8 && lengthTwoRoomFlat.Count >= 8)
            {
                const string pleaseWaiting = "Пожалуйста подождите, идет расчет";
                pleaseWaiting_label.Text += pleaseWaiting.ToString(CultureInfo.InvariantCulture);
                pleaseWaiting_label.Font = new Font("Calibri",14);
                pleaseWaiting_label.ForeColor = Color.FromArgb(39, 0, 255);
                if (optArrangeOne_label.Text != "")
                {
                    pleaseWaiting_label.Text = "";
                }
            }
            */
            var myStopWatch = new Stopwatch();
            myStopWatch.Start();

            var fullSearch = MethodeFullSearch.FullSearch(newLengthOneRoomFlat, newLengthTwoRoomFlat, step, entryway);
            //myStopWatch.Stop();

            if (countFloor == 2)
            {
               var optArrangeSecondFloorResult = CreateSecondFloor.MethodeCreateSecondFloor(fullSearch[1],fullSearch[2],entryway,step);
               foreach (var i in (IEnumerable)optArrangeSecondFloorResult[0])
               {
                   resultFullSearch_label.Text += (string.Format(" {0} ", i));
               }
               resultFullSearch_label.Text += "\r\n";

               foreach (var i in (IEnumerable)optArrangeSecondFloorResult[1])
               {
                   resultFullSearch_label.Text += (string.Format(" {0} ", i));
               }
               resultFullSearch_label.Text += "\r\n";

               resultFullSearch_label.Text +=  "_____________________\r\n";

               foreach (var i in (IEnumerable)optArrangeSecondFloorResult[2])
               {
                   resultFullSearch_label.Text += (string.Format(" {0} ", i));
               }
               resultFullSearch_label.Text += "\r\n";

               foreach (var i in (IEnumerable)optArrangeSecondFloorResult[3])
               {
                   resultFullSearch_label.Text += (string.Format(" {0} ", i));
               }
               resultFullSearch_label.Text += "\r\n";
               resultFullSearch_label.Text += (string.Format("Штраф от этажей {0} \r\n", optArrangeSecondFloorResult[4]));
//               resultFullSearch_label.Text += "\r\n";
            }
            else if (countFloor == 1 || countFloor.ToString(CultureInfo.InvariantCulture) == "")
            {
                
                const string resultFullSearch = "Итог полного перебора:";
                resultFullSearch_label.Text += resultFullSearch.ToString(CultureInfo.InvariantCulture)+"\r\n";
                var minFine = string.Format("Штраф {0}", fullSearch[0]);
                resultFullSearch_label.Text += minFine.ToString(CultureInfo.InvariantCulture)+"\r\n";

                const string optArrangeOne = "Оптимальная расстановка однокомнатных квартир";
                resultFullSearch_label.Text += optArrangeOne.ToString(CultureInfo.InvariantCulture);
                foreach (var i in (IEnumerable) fullSearch[1])
                {
                    resultFullSearch_label.Text += (string.Format(" {0} ", i));
                }
                resultFullSearch_label.Text += "\r\n";
                const string optArrangeTwo = "Оптимальная расстановка однокомнатных квартир";
                resultFullSearch_label.Text += optArrangeTwo.ToString(CultureInfo.InvariantCulture);
                foreach (var i in (IEnumerable) fullSearch[2])
                {
                    resultFullSearch_label.Text += (string.Format(" {0} ", i));
                }
                resultFullSearch_label.Text += "\r\n";
            }
            else
            {
                MessageBox.Show("Некорректное значение в поле 'Этаж'");
                return;
            }
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
    }
}
