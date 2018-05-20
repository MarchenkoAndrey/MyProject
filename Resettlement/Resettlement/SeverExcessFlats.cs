using System.Linq;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    public class SeverExcessFlats
    {
        //Todo учет лестничной клетки
        public static Building ToSeverExcessFlats(Building building)
        {
            var listSquares = Flat.ReceiveListSquares(building.Flats);
            while (listSquares.Sum() > Constraints.MaxSquareSection * building.CountFloor)
            {
                building.FlatsExcess.Add(building.Flats.OrderBy(a => a.InputSquare).First());
                building.Flats.Remove(building.Flats.OrderBy(a => a.InputSquare).First());
                listSquares.Remove(listSquares.Min());
            }
            return building;
        }
    }
}
