using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ComputationMethods;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    public class PrepareDataCorridorModel
    {
        //        var widthOfApartment = InputConstraints.C(valueC.Text.ToString(CultureInfo.InvariantCulture));
        //        var step = InputConstraints.Q(valueQ.Text.ToString(CultureInfo.InvariantCulture));
        //        public double SumDelta { get; set; }

        /*
        public List<double> ListSquares { get; set; }
        public List<double> ListExcessSquares { get; set; }
        public List<double> ListLengthFlat { get; set; }
        */

        public PrepareDataCorridorModel()
        {
            var building = new Building();

            var listSquaresOneFlat = ReadFromFileAndRecordingInputDataInList.ReadFile(FilesDefault.DefaultListOneFlat);
            var listSquaresTwoFlat = ReadFromFileAndRecordingInputDataInList.ReadFile(FilesDefault.DefaultListTwoFlat);

            var listOne = Flat.Initialize(listSquaresOneFlat, FlatType.OneFlat);
            var listTwo = Flat.Initialize(listSquaresTwoFlat, FlatType.TwoFlat);

            building.Flats.AddRange(listOne);
            building.Flats.AddRange(listTwo);

            //Исходное количество квартир
            building.InputCountFlat = building.Flats.Count;
            //todo ввод с экрана
            building.CountFloor = 3;
            
            //Приведение к минимально допустимым площадям
            Flat.CastToMinimalSquare(building.Flats);

            //Отсечение лишних квартир (самые мелкие однокомнатные)
            building = SeverExcessFlats.ToSeverExcessFlats(building);

            //Вычисление штрафа приведения
            building.Fine.CastToMin = Math.Round(
                Flat.CalculateSumCastSquares(building.Flats) -
                Flat.CalculateSumInputSquares(building.Flats), 2);
            //Площадь после приведения
            building.SumSquareAfterCastToMin =
                Math.Round(Flat.CalculateSumCastSquares(building.Flats), 2);

            building.CountFlat = building.Flats.Count;
            if (building.CountFlat < 12)
                MessageBox.Show(MessagesText.TooLittleData);

            //Метод по разбивке квартир по этажам на примерно равные группы

            var res = GroupFlatOnFlours(building.Flats, building.CountFloor);
            
            //Самый крупную группу оставляем на последний этаж, чтобы там за счет коридора в углу построить секцию


            //Выравниваем площади за счет добавок
            //Todo 1.Поправить инициализацию лишних r, 2. Выровнять площадь на этажах

            var r1 = res[0].Sum();
            var r2 = res[1].Sum();
            var r3 = res[2].Sum();
            var r4 = res[3].Sum();
            //var r5 = res[4].Sum();

            //ListLenOneFlat = PreparationSquares.CalculateLengthOfFlat(listSquaresOneFlat, Constraints.WidthFlat[0]);
            //ListLenTwoFlat = PreparationSquares.CalculateLengthOfFlat(listSquaresTwoFlat, Constraints.WidthFlat[0]);
            
            //Вычитаем балконы сразу из исходных площадей. У каждой квартиры предусмотрен балкон
            var listSquaresOneFlatExtended = DiffBalcony(listSquaresOneFlat);
            var listSquaresTwoFlatExtended = DiffBalcony(listSquaresTwoFlat);
           
            //listSquaresTwoFlatExtended = DiffAboveCorridor(listSquaresTwoFlatExtended);
            //ListLenOneFlat = PreparationSquares.CalculateLengthOfFlat(listSquaresOneFlatExtended, Constraints.WidthFlat[0]);
            //ListLenTwoFlat = PreparationSquares.CalculateLengthOfFlat(listSquaresTwoFlatExtended, Constraints.WidthFlat[0]);
        }

        //Метод вычитания балкона из площади. Балкон у каждой квартиры
        public static List<double> DiffBalcony(List<double> sourceList)
        {
            return sourceList.Select(a => Math.Round(a - Constraints.SquareBalcony, 3)).ToList();
        }

        //Метод по разбивке квартир по этажам на равные части с учетом аномалий
        public static List<List<double>> GroupFlatOnFlours(List<Flat> listFlat, int countFloor)
        {
            var listSquares = Flat.ReceiveListSquares(listFlat);
            listSquares.Sort();

            //Поиск аномалий. Исключение аномалий из сортировки. Ручное управление ими
            var listAnomaly = AnomalySearch.FindAnomaly(listSquares, countFloor);

            var passSortList =
                new List<double>(listSquares.GetRange(listSquares.Count - countFloor, countFloor).ToList());
            listSquares.RemoveRange(listSquares.Count - countFloor, countFloor);

            var f1 = new List<double>();
            var f2 = new List<double>();
            var f3 = new List<double>();
            var f4 = new List<double>();
            var f5 = new List<double>();

            var fineBring = 0.0;

            for (var l = 0; l < listSquares.Count; l+=countFloor)
            {
                var cur = listSquares.GetRange(l, countFloor);
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
