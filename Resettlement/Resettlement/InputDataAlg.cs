using System;
using System.Collections.Generic;
using ComputationMethods;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    public class InputDataAlg
    {
        //            var widthOfApartment = InputConstraints.C(valueC.Text.ToString(CultureInfo.InvariantCulture));
        //            var step = InputConstraints.Q(valueQ.Text.ToString(CultureInfo.InvariantCulture));
        public List<double> ListSquaresOneFlat;
        public List<double> ListSquaresTwoFlat;

        public int CountFloor { get; set; }
        public double SumDelta { get; set; }
        public double Step { get; set; }
        public double Entryway { get; set; }
        public double AddingA { get; private set; }
        public double AddingB { get; private set; }

        public List<double> ListLenOneFlat;
        public List<double> ListLenTwoFlat;

        public int OptCountFlat { get; private set; }
        public int OptCountFlatOnFloor { get; private set; }

        #region specific

        //        public int TotalCountApartments;
        //        public List<double> ListSquaresThreeFlat;

        //        public List<double> ListSquaresOneBedroomApartmentBringingToMin;
        //        public List<double> ListSquaresTwoBedroomApartmentBringingToMin;
        //        public List<double> ListSquaresThreeBedroomApartmentBringingToMin;
        //
        //        public double SumSquaresOriginal;
        //        public double SumSquaresAfterBrindingToMin;
        //        public int TotalCountSections;

        #endregion


        public InputDataAlg(List<double> list1, List<double> list2, int numFloor)
        {
            CountFloor = numFloor;
            ListLenOneFlat = list1;
            ListLenTwoFlat = list2;
            Step = Constraints.ThickWallsWidth;
            Entryway = Constraints.EntrywayLength;
            AddingA = 3*Step + Entryway;
            AddingB = 2*Step;
            OptCountFlat = _calculateOptimalNumberFlat(ListLenOneFlat.Count, ListLenTwoFlat.Count,
                CountFloor);
            OptCountFlatOnFloor = OptCountFlat/CountFloor;
        }

        public InputDataAlg()
        {
            ListSquaresOneFlat =
                ReadFromFileAndRecordingInputDataInList.ReadFile(FilesDefault.DefaultListOneFlat);
            ListSquaresTwoFlat =
                ReadFromFileAndRecordingInputDataInList.ReadFile(FilesDefault.DefaultListTwoFlat);
            CountFloor = Constraints.CountFloor;

            ListLenOneFlat = PreparationSquares.CalculateLengthOfFlat(ListSquaresOneFlat, Constraints.WidthOfApartmentVariants[0]);
            ListLenTwoFlat = PreparationSquares.CalculateLengthOfFlat(ListSquaresTwoFlat, Constraints.WidthOfApartmentVariants[0]);
            Step = Constraints.ThickWallsWidth;
            Entryway = Constraints.EntrywayLength;
            AddingA = 3 * Step + Entryway;
            AddingB = 2 * Step;
            OptCountFlat = _calculateOptimalNumberFlat(ListLenOneFlat.Count, ListLenTwoFlat.Count,
                CountFloor);
            OptCountFlatOnFloor = OptCountFlat/CountFloor;


            #region specific

            //            ListSquaresThreeFlat =
            //                ReadFromFileAndRecordingInputDataInList.ReadFile(FilesDefault.DefaultListThreeFlat);

//            TotalCountApartments = ListSquaresOneBedroomApartment.Count + ListSquaresTwoBedroomApartment.Count +
//                                       ListSquaresThreeFlat.Count;
//            SumSquaresOriginal = Calculate.CalculateSumList(ListSquaresOneBedroomApartment) +
//                Calculate.CalculateSumList(ListSquaresTwoBedroomApartment) +
//                Calculate.CalculateSumList(ListSquaresThreeFlat);

            #endregion
        }
        //Оптимальное количество квартир в конечной модели 1-го типа
        private readonly Func<int, int, int, int> _calculateOptimalNumberFlat =
                (countOneFlat, countTwoFlat, countFloor) =>
                        Math.Min(countOneFlat / countFloor / 2 * 2 * countFloor, countTwoFlat / countFloor / 2 * 2 * countFloor);
    }
}
