using System;
using System.Windows.Forms;
using ComputationMethods;
using ComputationMethods.GeneralData;
using Resettlement.CorridorModel.Models;

namespace Resettlement.CorridorModel
{
    public static class PrepareCorridorModel
    {
        //        var widthOfApartment = InputConstraints.C(valueC.Text.ToString(CultureInfo.InvariantCulture));
        //        var step = InputConstraints.Q(valueQ.Text.ToString(CultureInfo.InvariantCulture));
        //        public double SumDelta { get; set; }

        public static Building ToPrepareCorridorModel()
        {
            var building = new Building();

            var listSquaresOneFlat = ReadFromFileAndRecordingInputDataInList.ReadFile(FilesDefault.DefaultListOneFlat);
            var listSquaresTwoFlat = ReadFromFileAndRecordingInputDataInList.ReadFile(FilesDefault.DefaultListTwoFlat);

            building.Flats.AddRange(Flat.Initialize(listSquaresOneFlat, FlatType.OneFlat, listSquaresTwoFlat, FlatType.TwoFlat));

            //Исходное количество квартир
            building.InputCountFlat = building.Flats.Count;
            //todo ввод с экрана
            building.CountFloor = 4;
            building.Floors = Floor.CreateFloors(building.CountFloor);
            
            //Приведение к минимально допустимым площадям
            Flat.CastToMinimalSquare(building.Flats);

            //Отсечение лишних квартир
            building = SeverExcessFlats.ToSeverExcessFlats(building);

            //Вычисление штрафа приведения
            building.Fine.CastToMin = Math.Round(
                Flat.CalculateSumCastSquares(building.Flats) -
                Flat.CalculateSumInputSquares(building.Flats), 2);
            //Площадь после приведения
            building.SumSquare =
                Math.Round(Flat.CalculateSumCastSquares(building.Flats), 2);
            
            building.CountFlat = building.Flats.Count;
            if (building.CountFlat < 4 * building.CountFloor)
                MessageBox.Show(MessagesText.TooLittleData);

            building.Flats = Flat.DiffBalcony(building.Flats);

            return building;
        }
    }
}
