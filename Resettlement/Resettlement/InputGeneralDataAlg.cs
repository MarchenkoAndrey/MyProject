using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
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
            //Высчитать рекомендованное количество этажей самому
            
            var listSquaresOneFlat = ReadFromFileAndRecordingInputDataInList.ReadFile(FilesDefault.DefaultListOneFlat);
            var listSquaresTwoFlat = ReadFromFileAndRecordingInputDataInList.ReadFile(FilesDefault.DefaultListTwoFlat);

            var listSquaresGeneral = new List<double>(listSquaresOneFlat);
            listSquaresGeneral.AddRange(listSquaresTwoFlat);

            //Приведение к миниально допустимым площадям
            var listAllSquaresAfterCast = CastToMinimalSquare(listSquaresOneFlat, listSquaresTwoFlat);
            //Вычисление штрафа приведения
            var fine = listAllSquaresAfterCast.Sum() - listSquaresGeneral.Sum();
            //Суммарная площадь
            var sum = listAllSquaresAfterCast.Sum();
            //Количество квартир
            int countFlat = listAllSquaresAfterCast.Count;
            //Рекомендованное количество этажей
            int countFloor = (int)Math.Ceiling(sum / 400.0); //Todo improve 445
            //Количество квартир на этаже
            int countFlatOnFloor = countFlat / countFloor; // Количество квартир на этаже

            
            if(countFloor>5)
                throw new Exception("Превышен лимит");

            //Метод по разбивке на варианты по этажам
            var res = GroupFlatOnFlours(listAllSquaresAfterCast, countFlatOnFloor, countFloor);

            //Выравниваем площади за счет добавок
            //Todo 1.Поправить инициализацию лишних r, 2. Выровнять площадь на этажах

            var r1 = res[0].Sum();
            var r2 = res[1].Sum();
            var r3 = res[2].Sum();
            var r4 = res[3].Sum();
            var r5 = res[4].Sum();

            ListLenOneFlat = PreparationSquares.CalculateLengthOfFlat(listSquaresOneFlat, Constraints.WidthOfApartmentVariants[0]);
            ListLenTwoFlat = PreparationSquares.CalculateLengthOfFlat(listSquaresTwoFlat, Constraints.WidthOfApartmentVariants[0]);
            
            //Вычитаем балконы сразу из исходных площадей. У каждой квартиры предусмотрен балкон
            var listSquaresOneFlatExtended = DiffBalcony(listSquaresOneFlat);
            var listSquaresTwoFlatExtended = DiffBalcony(listSquaresTwoFlat);
           
            //listSquaresTwoFlatExtended = DiffAboveCorridor(listSquaresTwoFlatExtended);
            ListLenOneFlat = PreparationSquares.CalculateLengthOfFlat(listSquaresOneFlatExtended, Constraints.WidthOfApartmentVariants[0]);
            ListLenTwoFlat = PreparationSquares.CalculateLengthOfFlat(listSquaresTwoFlatExtended, Constraints.WidthOfApartmentVariants[0]);
        }

        //Метод вычитания балкона из площади. Балкон у каждой квартиры
        public static List<double> DiffBalcony(List<double> sourceList)
        {
            return sourceList.Select(a => Math.Round(a - Constraints.SquareBalcony, 3)).ToList();
        }
        // Метод приведения площади квартир к минимальному значению
        public static List<double> CastToMinimalSquare(List<double> oneFlat, List<double> twoFlat)
        {
            var generalList = oneFlat.Select(elem => elem < Constraints.MinSquareOneApartment ? Constraints.MinSquareOneApartment : elem).ToList();
            generalList.AddRange(twoFlat.Select(elem => elem < Constraints.MinSquareTwoApartment ? Constraints.MinSquareTwoApartment : elem).ToList());
            return generalList;
        }
        //Метод по разбивке на равные части (Задача разбиения Жадный алгоритм)
        //Todo Сортирнуть каждый и сопоставить и добавку
        public static List<List<double>> GroupFlatOnFlours(List<double> listFlat, int countFlatOnFloor, int countFloor)
        {
            var f1 = new List<double>();
            var f2 = new List<double>();
            var f3 = new List<double>();
            var f4 = new List<double>();
            var f5 = new List<double>();

            listFlat.Sort();

            switch (countFloor)
            {
                case 2:
                    for (var i = listFlat.Count - 1; i >= 0; i--)
                    {
                        if (f1.Sum() < f2.Sum())
                            f1.Add(listFlat[i]);
                        else
                        {
                            f2.Add(listFlat[i]);
                        }
                    }
                    return new List<List<double>> { f1, f2 };

                case 3:
                    for (var i = listFlat.Count - 1; i >= 0; i--)
                    {
                        if (f1.Sum() < f2.Sum())
                            f1.Add(listFlat[i]);
                        else if (f2.Sum() < f3.Sum())
                        {
                            f2.Add(listFlat[i]);
                        }
                        else
                        {
                            f3.Add(listFlat[i]);
                        }
                    }
                    return new List<List<double>> { f1, f2, f3 };

                case 4:
                    for (var i = listFlat.Count - 1; i >= 0; i--)
                    {
                        if (f1.Sum() < f2.Sum())
                            f1.Add(listFlat[i]);
                        else if (f2.Sum() < f3.Sum())
                        {
                            f2.Add(listFlat[i]);
                        }
                        else if (f3.Sum() < f4.Sum())
                        {
                            f3.Add(listFlat[i]);
                        }
                        else
                        {
                            f4.Add(listFlat[i]);
                        }
                    }
                    return new List<List<double>> { f1, f2, f3, f4 };
                case 5:
                    for (var i = listFlat.Count - 1; i >= 0; i--)
                    {
                        if (f1.Sum() < f2.Sum())
                            f1.Add(listFlat[i]);
                        else if (f2.Sum() < f3.Sum())
                        {
                            f2.Add(listFlat[i]);
                        }
                        else if (f3.Sum() < f4.Sum())
                        {
                            f3.Add(listFlat[i]);
                        }
                        else if (f4.Sum() < f5.Sum())
                        {
                            f4.Add(listFlat[i]);
                        }
                        else
                        {
                            f5.Add(listFlat[i]);
                        }
                    }
                    return new List<List<double>> { f1, f2, f3, f4, f5};

                default:
                    return new List<List<double>> {listFlat};
            }   
        }
    }
}
