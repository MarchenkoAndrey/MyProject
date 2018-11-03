using System;
using System.Linq;
using ComputationMethods.GeneralData;
using Resettlement.CorridorModel.Models;

namespace Resettlement.CorridorModel
{
    public static class SeverExcessFlats
    {
        /// <summary>
        ///     Отсечение лишних квартир. Два правила:
        ///         а) Количество квартир на этажах одинаковое
        ///         б) Площадь секции не превышает 500м2
        ///     Стараемся отбрасывать самые маленькие однокомнатные, так как их проще встроить в новую модель.
        ///     Алгоритм в лоб:
        ///         Сначала работаем с правилом б. Отсекаем лишние
        ///         Проверяем на выполнение правила а
        /// </summary>
        public static Building ToSeverExcessFlats(Building building)
        {
            // Общая нежилая площадь = Лестничная клетка + коридор
            var generalSquare = Math.Round(Constraints.EntrywayLength * Constraints.WidthFlat[4] + Constraints.MaxSquareCorridor, 2);

            building.Flats = building.Flats.OrderBy(a => a.InputSquare).ToList();

            var listSquares = Flat.ReceiveListCastSquares(building.Flats);

            // Суммарная допустимая жилая площадь
            var livingSquare = (Constraints.MaxSquareSection - generalSquare) * building.CountFloor;
            var k = listSquares.Sum();

            //б)
            while (listSquares.Sum() > livingSquare)
            {
                building.FlatsExcess.Add(building.Flats.First());
                building.Flats.Remove(building.Flats.First());
                listSquares.Remove(listSquares.First());
            }
            //а)
            while (building.Flats.Count % building.CountFloor != 0)
            {
                building.FlatsExcess.Add(building.Flats.First());
                building.Flats.Remove(building.Flats.First());
            }
            return building;
        }
    }
}
