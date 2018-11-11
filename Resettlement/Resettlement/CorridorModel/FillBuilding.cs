using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputationMethods.GeneralData;
using Resettlement.CorridorModel.Models;

namespace Resettlement.CorridorModel
{
    public static class FillBuilding
    {
        public static void ToFillBuilding(Building building, bool[] position)
        {
            foreach (var floor in building.Floors)
            {
                ToFillFloor(floor,position);
            }
        }

        private static void ToFillFloor(Floor floor, bool[] position)
        {
            var listW1 = new List<Flat>();
            var listW2 = new List<Flat>();

            for (var i = 0; i < position.Length; ++i)
            {
                if (position[i])
                    listW1.Add(floor.Flats[i]);
                else listW2.Add(floor.Flats[i]);
            }
            //поменять местами, если entryway в w2
            if (listW2.Contains(floor.Flats[floor.Flats.Count-1]))
            {
                var tmp = listW1;
                listW1 = listW2;
                listW2 = tmp;
            }
            //todo выбрать ширину и трогать entryway
            // сравнить sum W1 и W2
            var sumSquaresW1 = SumSquares(listW1);
            var sumSquaresW2 = SumSquares(listW2);

            var opt = double.MaxValue;
            var resW1 = 0.0;
            var resW2 = 0.0;
            foreach (var w1 in Constraints.WidthFlat)
            {
                foreach (var w2 in Constraints.WidthFlat)
                {
                    if (opt > Math.Abs(sumSquaresW2 / w2 - sumSquaresW1 / w1))
                    {
                        opt = Math.Abs(sumSquaresW2 / w2 - sumSquaresW1 / w1);
                        resW1 = w1;
                        resW2 = w2;
                    }
                }
            }

            //final
            floor.FlatsW1 = listW1;
            floor.FlatsW2 = listW2;
        }

        private static double SumSquares(List<Flat> flats)
        {
            return flats.Select(a=>a.CastSquare).Sum();
        }
    }
}
