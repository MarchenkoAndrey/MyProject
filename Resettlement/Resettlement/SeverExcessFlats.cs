using System;
using System.Linq;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    public class SeverExcessFlats
    {
        public static Building ToSeverExcessFlats(Building building)
        {
            building.Flats = building.Flats.OrderBy(a => a.InputSquare).ToList();
            var listSquares = Flat.ReceiveListCastSquares(building.Flats);
            // Общая нежилая площадь = Лестничная клетка + корридор
            var generalSquare = Math.Round(Constraints.EntrywayLength * Constraints.WidthFlat[4] + Constraints.MaxSquareCorridor,2); 

            while (listSquares.Sum() > (Constraints.MaxSquareSection - generalSquare) * building.CountFloor)
            {
                building.FlatsExcess.Add(building.Flats.First());
                building.Flats.Remove(building.Flats.First());
                listSquares.Remove(listSquares.First());
            }
            return building;
        }
    }
}
