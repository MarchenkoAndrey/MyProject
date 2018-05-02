using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ComputationMethods;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    public class InputGeneralDataAlg
    {
        //        var widthOfApartment = InputConstraints.C(valueC.Text.ToString(CultureInfo.InvariantCulture));
        //        var step = InputConstraints.Q(valueQ.Text.ToString(CultureInfo.InvariantCulture));
        //        public double SumDelta { get; set; }

        public readonly List<double> ListLenOneFlat;
        public readonly List<double> ListLenTwoFlat;

        public InputGeneralDataAlg()
        {
            var listSquaresOneFlat = ReadFromFileAndRecordingInputDataInList.ReadFile(FilesDefault.DefaultListOneFlat);
            var listSquaresTwoFlat = ReadFromFileAndRecordingInputDataInList.ReadFile(FilesDefault.DefaultListTwoFlat);

            var listSquaresGeneral = new List<double>(listSquaresOneFlat);
            listSquaresGeneral.AddRange(listSquaresTwoFlat);

            //Todo работа с лишними квартирами, где отсекаем? Как обрабатываем?
            //Todo Выкидываем самые мелкие однокомнатные, с соответствующим выводом квартир, которые не попали в итоговую модель

            //Приведение к миниально допустимым площадям
            var listAllSquaresAfterCast = CastToMinimalSquare(listSquaresOneFlat, listSquaresTwoFlat);
            //Вычисление штрафа приведения
            var fine = Math.Round(listAllSquaresAfterCast.Sum() - listSquaresGeneral.Sum(),2);
            //Суммарная площадь
            var sum = listAllSquaresAfterCast.Sum();
            //Количество квартир
            int countFlat = listAllSquaresAfterCast.Count;
            //Рекомендованное количество этажей
            int countFloor = (int)Math.Ceiling(sum / 400.0); //Todo improve 445
            //Количество квартир на этаже
            int countFlatOnFloor = countFlat / countFloor; // Количество квартир на этаже

            if (countFlat < 12)
                MessageBox.Show("Мало данных. Невозможно построить 3-этажный дом");

            if (countFloor < 3)
                countFloor = 3;
            if(countFloor>5)
                MessageBox.Show("Мы не строим небоскребы. Уменьшите количество исходных данных");

            //Метод по разбивке квартир по этажам на примерно равные группы
            var res = GroupFlatOnFlours(listAllSquaresAfterCast, countFloor);
            
            //Самый крупную группу оставляем на последний этаж, чтобы там за счет коридора в углу построить секцию


            //Выравниваем площади за счет добавок
            //Todo 1.Поправить инициализацию лишних r, 2. Выровнять площадь на этажах

            var r1 = res[0].Sum();
            var r2 = res[1].Sum();
            var r3 = res[2].Sum();
            var r4 = res[3].Sum();
            //var r5 = res[4].Sum();

            ListLenOneFlat = PreparationSquares.CalculateLengthOfFlat(listSquaresOneFlat, Constraints.WidthFlat[0]);
            ListLenTwoFlat = PreparationSquares.CalculateLengthOfFlat(listSquaresTwoFlat, Constraints.WidthFlat[0]);
            
            //Вычитаем балконы сразу из исходных площадей. У каждой квартиры предусмотрен балкон
            var listSquaresOneFlatExtended = DiffBalcony(listSquaresOneFlat);
            var listSquaresTwoFlatExtended = DiffBalcony(listSquaresTwoFlat);
           
            //listSquaresTwoFlatExtended = DiffAboveCorridor(listSquaresTwoFlatExtended);
            ListLenOneFlat = PreparationSquares.CalculateLengthOfFlat(listSquaresOneFlatExtended, Constraints.WidthFlat[0]);
            ListLenTwoFlat = PreparationSquares.CalculateLengthOfFlat(listSquaresTwoFlatExtended, Constraints.WidthFlat[0]);
        }

        //Метод вычитания балкона из площади. Балкон у каждой квартиры
        public static List<double> DiffBalcony(List<double> sourceList)
        {
            return sourceList.Select(a => Math.Round(a - Constraints.SquareBalcony, 3)).ToList();
        }
        // Метод приведения площади квартир к минимальному значению
        public static List<double> CastToMinimalSquare(List<double> oneFlat, List<double> twoFlat)
        {
            var generalList = oneFlat.Select(elem => elem < Constraints.MinSquareOneApartment ? Constraints.MinSquareOneApartment : Math.Round(elem,2)).ToList();
            generalList.AddRange(twoFlat.Select(elem => elem < Constraints.MinSquareTwoApartment ? Constraints.MinSquareTwoApartment : Math.Round(elem, 2)).ToList());
            return generalList;
        }
        //Метод по разбивке квартир по этажам на равные части с учетом аномалий
        public static List<List<double>> GroupFlatOnFlours(List<double> listFlat, int countFloor)
        {
            listFlat.Sort();

            //Поиск аномалий. Исключение аномалий из сортировки. Ручное управление ими
            var listAnomaly = AnomalySearch.FindAnomaly(listFlat, countFloor);

            var passSortList =
                new List<double>(listFlat.GetRange(listFlat.Count - countFloor, countFloor).ToList());
            listFlat.RemoveRange(listFlat.Count - countFloor, countFloor);

            var f1 = new List<double>();
            var f2 = new List<double>();
            var f3 = new List<double>();
            var f4 = new List<double>();
            var f5 = new List<double>();

            var fineBring = 0.0;

            for (var l = 0; l < listFlat.Count; l+=countFloor)
            {
                var cur = listFlat.GetRange(l, countFloor);
                var max = cur.Max();
                for (var i = 0; i<cur.Count; ++i)
                {
                    fineBring += Math.Round(fineBring + (max - cur[i]), 2);
                    cur[i] = max;
                }

                f1.Add(max);
                f2.Add(max);
                f3.Add(max);
                if (countFloor <= 3) continue;
                f4.Add(max);
                if (countFloor > 4)
                {
                    f5.Add(max);
                }
            }

            //Здесь у меня уже есть нужные списки без учета аномалий.

            int u = 1;


            return new List<List<double>>();
        }
    }
}
