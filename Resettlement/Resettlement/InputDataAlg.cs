using System;
using System.Collections.Generic;
using System.Linq;
using ComputationMethods;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    public class InputDataAlg
    {
//        var widthOfApartment = InputConstraints.C(valueC.Text.ToString(CultureInfo.InvariantCulture));
//        var step = InputConstraints.Q(valueQ.Text.ToString(CultureInfo.InvariantCulture));
//        public double SumDelta { get; set; }

        public int CountFloor { get; private set; } // Остается для подачи тестов
        public readonly List<double> ListLenOneFlat;
        public readonly List<double> ListLenTwoFlat;
        public int OptCountFlat { get; private set; }
        public int OptCountFlatOnFloor { get; private set; }

        // Исключительно для тестов
        public InputDataAlg(List<double> list1, List<double> list2, int countFloor)
        {
            CountFloor = countFloor;
            ListLenOneFlat = list1;
            ListLenTwoFlat = list2;
            OptCountFlat = _calculateOptimalNumberFlat(ListLenOneFlat.Count, ListLenTwoFlat.Count,
                CountFloor);
            OptCountFlatOnFloor = OptCountFlat / CountFloor;
        }

        // Прием входных данных из формы или из .txt
        public InputDataAlg()
        {
            CountFloor = Constraints.CountFloor;
            var listSquaresOneFlat = ReadFromFileAndRecordingInputDataInList.ReadFile(FilesDefault.DefaultListOneFlat);
            var listSquaresTwoFlat = ReadFromFileAndRecordingInputDataInList.ReadFile(FilesDefault.DefaultListTwoFlat);
           
            ListLenOneFlat = PreparationSquares.CalculateLengthOfFlat(listSquaresOneFlat, Constraints.WidthOfApartmentVariants[0]);
            ListLenTwoFlat = PreparationSquares.CalculateLengthOfFlat(listSquaresTwoFlat, Constraints.WidthOfApartmentVariants[0]);
            
            //Todo create enum versions
            if (Constraints.VersionExtended) // если это расширенная схема с балконами и коридором
            {
                //Вычитаем балконы сразу из исходных площадей. У каждой квартиры предусмотрен балкон
                var listSquaresOneFlatExtended = DiffBalcony(listSquaresOneFlat);
                var listSquaresTwoFlatExtended = DiffBalcony(listSquaresTwoFlat);
                listSquaresTwoFlatExtended = DiffAboveCorridor(listSquaresTwoFlatExtended);
                ListLenOneFlat = PreparationSquares.CalculateLengthOfFlat(listSquaresOneFlatExtended, Constraints.WidthOfApartmentVariants[0]);
                ListLenTwoFlat = PreparationSquares.CalculateLengthOfFlat(listSquaresTwoFlatExtended, Constraints.WidthOfApartmentVariants[0]);
            }
            
            OptCountFlat = _calculateOptimalNumberFlat(ListLenOneFlat.Count, ListLenTwoFlat.Count,
                CountFloor);
            OptCountFlatOnFloor = OptCountFlat/CountFloor;
        }
        //Оптимальное количество квартир в конечной модели одного типа
        private readonly Func<int, int, int, int> _calculateOptimalNumberFlat =
                (countOneFlat, countTwoFlat, countFloor) =>
                        Math.Min(countOneFlat / countFloor / 2 * 2 * countFloor, countTwoFlat / countFloor / 2 * 2 * countFloor);
        
        //Метод вычитания балкона из площади. Балкон у каждой квартиры, кроме первого этажа????
        public static List<double> DiffBalcony(List<double> sourceList)
        {
            return sourceList.Select(a => Math.Round(a - Constraints.SquareBalcony, 3)).ToList();
        }
        // Метод вычитания площади 2к квартиры над коридором (коридор жестко закреплен)
        public static List<double> DiffAboveCorridor(List<double> twoFlatList)
        {
            return twoFlatList.Select(a => Math.Round(a - Constraints.SquareAboveCorridorFor2K, 3)).ToList();
        }

    }
}
