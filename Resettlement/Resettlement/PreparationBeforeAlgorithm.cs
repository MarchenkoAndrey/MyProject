using System.Globalization;
using ComputationMethods;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    partial class UserInterface
    {
        private DataAlgorithm PreparationBeforeAlgorithm()
        {
            var entryway = InputConstraints.G(valueG.Text.ToString(CultureInfo.InvariantCulture));
            var widthOfApartment = InputConstraints.C(valueC.Text.ToString(CultureInfo.InvariantCulture));
            var step = InputConstraints.Q(valueQ.Text.ToString(CultureInfo.InvariantCulture));

            var inputDataOneApartment = new[]
            {
                squareOne_input.Text.ToString(CultureInfo.InvariantCulture)
            };
            var inputDataTwoApartment = new[]
            {
                squareTwo_input.Text.ToString(CultureInfo.InvariantCulture)
            };

            var enterDataListOneBedroomApartment = inputDataOneApartment[0] == "" ?
                ReadFromFileAndRecordingInputDataInList.ReadFile(FilesDefault.DefaultListOneBedroomApartment) :
                ReadFromFileAndRecordingInputDataInList.RecordingInputDataInList(inputDataOneApartment);
            var enterDataListTwoBedroomApartment = inputDataTwoApartment[0] == "" ?
                ReadFromFileAndRecordingInputDataInList.ReadFile(FilesDefault.DefaultListTwoBedroomApartment) :
                ReadFromFileAndRecordingInputDataInList.RecordingInputDataInList(inputDataTwoApartment);

            var listSquareOneBedroomApartment = ChangeTypeVariable.ChangeListIntoArray(enterDataListOneBedroomApartment);
            var listSquareTwoBedroomApartment = ChangeTypeVariable.ChangeListIntoArray(enterDataListTwoBedroomApartment);

            var lengthOneRoomFlat = PreparationSquares.CalculateLengthOfFlat(listSquareOneBedroomApartment, widthOfApartment);
            var lengthTwoRoomFlat = PreparationSquares.CalculateLengthOfFlat(listSquareTwoBedroomApartment, widthOfApartment);
            var newLengthOneRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength(lengthOneRoomFlat);
            var newLengthTwoRoomFlat = PreparationSquares.FlatsWithTheAdditiveLength(lengthTwoRoomFlat);
            var deltaOfOneRoomFlat = PreparationSquares.DeltaSquaresOfFlats(lengthOneRoomFlat, newLengthOneRoomFlat);
            var deltaOfTwoRoomFlat = PreparationSquares.DeltaSquaresOfFlats(lengthTwoRoomFlat, newLengthTwoRoomFlat);
            var sumDelta = deltaOfOneRoomFlat + deltaOfTwoRoomFlat;

            var countFloor = 0;
            if (radioButton1.Checked)
            {
                countFloor = 1;
            }
            if (radioButton2.Checked)
            {
                countFloor = 2;
            }
            if (radioButton3.Checked)
            {
                countFloor = 3;
            }
            if (radioButton4.Checked)
            {
                countFloor = 4;
            }


            return new DataAlgorithm
            {
                Entryway = entryway,
                WidthOfApartment = widthOfApartment,
                Step = step,
                SumDelta = sumDelta,
                ListLengthOneBedroomApartnent = newLengthOneRoomFlat,
                ListLengthTwoBedroomApartnent = newLengthTwoRoomFlat,
                CountFloor = countFloor,
                ListLengthOneBedroomApartnentWithoutFormats = lengthOneRoomFlat,
                ListLengthTwoBedroomApartnentWithoutFormats = lengthTwoRoomFlat
            };
        }
    }
}