using System.Collections.Generic;
using ComputationMethods;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    public class DataAlgorithm
    {
        //            var widthOfApartment = InputConstraints.C(valueC.Text.ToString(CultureInfo.InvariantCulture));
        //            var step = InputConstraints.Q(valueQ.Text.ToString(CultureInfo.InvariantCulture));
        public List<double> ListSquaresOneBedroomApartment;
        public List<double> ListSquaresTwoBedroomApartment;
        public List<double> ListSquaresThreeBedroomApartment;

        public int CountFloor { get; set; }
        public double SumDelta { get; set; }
        public double Step { get; set; }
        public double Entryway { get; set; }

        public List<double> ListLengthOneBedroomApartment;
        public List<double> ListLengthTwoBedroomApartment;

        public List<double> ListLengthOneBedroomApartnentWithoutFormats;
        public List<double> ListLengthTwoBedroomApartnentWithoutFormats;

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
            ListSquaresOneBedroomApartment =
                ReadFromFileAndRecordingInputDataInList.ReadFile(FilesDefault.DefaultListOneBedroomApartment);
            ListSquaresTwoBedroomApartment =
                ReadFromFileAndRecordingInputDataInList.ReadFile(FilesDefault.DefaultListTwoBedroomApartment);
            ListSquaresThreeBedroomApartment =
                ReadFromFileAndRecordingInputDataInList.ReadFile(FilesDefault.DefaultListThreeBedroomApartment);
            #region specific

//            TotalCountApartments = ListSquaresOneBedroomApartment.Count + ListSquaresTwoBedroomApartment.Count +
//                                       ListSquaresThreeBedroomApartment.Count;
//            SumSquaresOriginal = Calculate.CalculateSumList(ListSquaresOneBedroomApartment) +
//                Calculate.CalculateSumList(ListSquaresTwoBedroomApartment) +
//                Calculate.CalculateSumList(ListSquaresThreeBedroomApartment);
            #endregion
        }
    }
}
