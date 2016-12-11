using System.Collections.Generic;
using ComputationMethods;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    public class DataAlgorithm
    {
        //            var widthOfApartment = InputConstraints.C(valueC.Text.ToString(CultureInfo.InvariantCulture));
        //            var step = InputConstraints.Q(valueQ.Text.ToString(CultureInfo.InvariantCulture));
        public List<double> ListSquaresOneFlat;
        public List<double> ListSquaresTwoFlat;
//        public List<double> ListSquaresThreeFlat;

        public int CountFloor { get; set; }
        public double SumDelta { get; set; }
        public double Step { get; set; }
        public double Entryway { get; set; }

        public List<double> ListLenOneFlat;
        public List<double> ListLenTwoFlat;

        public List<double> ListLenOneFlatWithoutFormats;
        public List<double> ListLenTwoFlatWithoutFormats;

        #region specific

        //        public int TotalCountApartments;


        //        public List<double> ListSquaresOneBedroomApartmentBringingToMin;
        //        public List<double> ListSquaresTwoBedroomApartmentBringingToMin;
        //        public List<double> ListSquaresThreeBedroomApartmentBringingToMin;
        //
        //        public double SumSquaresOriginal;
        //        public double SumSquaresAfterBrindingToMin;
        //        public int TotalCountSections;

        #endregion

        public DataAlgorithm()
        {
            ListSquaresOneFlat =
                ReadFromFileAndRecordingInputDataInList.ReadFile(FilesDefault.DefaultListOneFlat);
            ListSquaresTwoFlat =
                ReadFromFileAndRecordingInputDataInList.ReadFile(FilesDefault.DefaultListTwoFlat);
            CountFloor = Constraints.CountFloor;

            ListLenOneFlat = PreparationSquares.CalculateLengthOfFlat(ListSquaresOneFlat,Constraints.WidthOfApartmentVariants[0]);
            ListLenTwoFlat = PreparationSquares.CalculateLengthOfFlat(ListSquaresTwoFlat, Constraints.WidthOfApartmentVariants[0]);
            
//            ListSquaresThreeFlat =
//                ReadFromFileAndRecordingInputDataInList.ReadFile(FilesDefault.DefaultListThreeFlat);

            #region specific

//            TotalCountApartments = ListSquaresOneBedroomApartment.Count + ListSquaresTwoBedroomApartment.Count +
//                                       ListSquaresThreeFlat.Count;
//            SumSquaresOriginal = Calculate.CalculateSumList(ListSquaresOneBedroomApartment) +
//                Calculate.CalculateSumList(ListSquaresTwoBedroomApartment) +
//                Calculate.CalculateSumList(ListSquaresThreeFlat);

            #endregion
        }
    }
}
