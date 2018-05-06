using System;
using System.Collections.Generic;
using System.Linq;
using ComputationMethods;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    public class InputSectionDataAlg
    {
//        var widthOfApartment = InputConstraints.C(valueC.Text.ToString(CultureInfo.InvariantCulture));
//        var step = InputConstraints.Q(valueQ.Text.ToString(CultureInfo.InvariantCulture));
//        public double SumDelta { get; set; }

        public int CountFloor { get; } // Остается для подачи тестов
        public readonly List<double> ListLenOneFlat;
        public readonly List<double> ListLenTwoFlat;
        public int OptCountFlat { get; }
        public int OptCountFlatOnFloor { get; }

        // Исключительно для тестов
        public InputSectionDataAlg(List<double> list1, List<double> list2, int countFloor)
        {
            CountFloor = countFloor;
            ListLenOneFlat = list1;
            ListLenTwoFlat = list2;
            OptCountFlat = _calculateOptimalNumberFlat(ListLenOneFlat.Count, ListLenTwoFlat.Count,
                CountFloor);
            OptCountFlatOnFloor = OptCountFlat / CountFloor;
        }

        // Прием входных данных из формы или из .txt
        public InputSectionDataAlg()
        {
            CountFloor = Constraints.CountFloor;
            var listSquaresOneFlat = ReadFromFileAndRecordingInputDataInList.ReadFile(FilesDefault.DefaultListOneFlat);
            var listSquaresTwoFlat = ReadFromFileAndRecordingInputDataInList.ReadFile(FilesDefault.DefaultListTwoFlat);
           
            ListLenOneFlat = PreparationSquares.CalculateLengthOfFlat(listSquaresOneFlat, Constraints.WidthFlat[0]);
            ListLenTwoFlat = PreparationSquares.CalculateLengthOfFlat(listSquaresTwoFlat, Constraints.WidthFlat[0]);
          
            OptCountFlat = _calculateOptimalNumberFlat(ListLenOneFlat.Count, ListLenTwoFlat.Count,
                CountFloor);
            OptCountFlatOnFloor = OptCountFlat/CountFloor;
        }
        //Оптимальное количество квартир в конечной модели одного типа
        private readonly Func<int, int, int, int> _calculateOptimalNumberFlat =
                (countOneFlat, countTwoFlat, countFloor) =>
                        Math.Min(countOneFlat / countFloor / 2 * 2 * countFloor, countTwoFlat / countFloor / 2 * 2 * countFloor);
    }
}
