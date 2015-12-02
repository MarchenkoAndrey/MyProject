using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

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
            StartAndFinishProgram.Program(strOne,strTwo, false); 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void countFloor_input_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(countFloor_input.Text) != 1)
            {
                MessageBox.Show("Реализован расчет пока только для 1-го этажа");
            }
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
            var myStopWatch = new Stopwatch();
            myStopWatch.Start();

            var fullSearch = MethodeFullSearch.FullSearch(newLengthOneRoomFlat, newLengthTwoRoomFlat, step, entryway);
            myStopWatch.Stop();
            var timeFullSearch = "Время работы полного перебора " +
                                 (myStopWatch.ElapsedMilliseconds/1000.0).ToString(CultureInfo.InvariantCulture) +
                                 " секунд";
            timeFullSearch_label.Text += timeFullSearch.ToString(CultureInfo.InvariantCulture);

            const string resultFullSearch = "Итог полного перебора:";
            resultFullSearch_label.Text += resultFullSearch.ToString(CultureInfo.InvariantCulture);
            var minFine = string.Format("Минимальный штраф {0}", fullSearch[0]);
            minFine_label.Text += minFine.ToString(CultureInfo.InvariantCulture);

            const string optArrangeOne = "Оптимальная расстановка однокомнатных квартир";
            optArrangeOne_label.Text += optArrangeOne.ToString(CultureInfo.InvariantCulture);
            foreach (var i in (IEnumerable)fullSearch[1])
            {
                optArrangeOne_label.Text+=(string.Format(" {0} ", i));
            }
            const string optArrangeTwo = "Оптимальная расстановка однокомнатных квартир";
            optArrangeTwo_label.Text += optArrangeTwo.ToString(CultureInfo.InvariantCulture);
            foreach (var i in (IEnumerable)fullSearch[2])
            {
                optArrangeTwo_label.Text += (string.Format(" {0} ", i));
            }
        }

        private void labelOne_Click(object sender, EventArgs e)
        {
            
            
        }

        private void UserInterface_Load(object sender, EventArgs e)
        {

        }
    }
}
