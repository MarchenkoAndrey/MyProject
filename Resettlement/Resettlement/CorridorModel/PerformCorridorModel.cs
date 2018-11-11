using System;
using System.Collections.Generic;
using System.Linq;
using Resettlement.CorridorModel.Models;

namespace Resettlement.CorridorModel
{
    public static class PerformCorridorModel
    {
        public static Building ToPerformCorridorModel(Building building)
        {
            //1. Группировка квартир по этажам
            var listFloors = SplitFlatsOnFlours(building);

            //2. Расстановка квартир в секции
            var finalBuilding = CreateFinalBuilding(listFloors);

            return new Building();
        }

        private static Building SplitFlatsOnFlours(Building building)
        {
            var listFlats = building.Flats.OrderBy(a => a.CastSquare).ToList();

            for (var j = 0; j < listFlats.Count; j += building.CountFloor)
            {
                var group = listFlats.GetRange(j, building.CountFloor);
                var max = group.Select(b => b.CastSquare).Max();

                var number = 1;
                foreach (var flat in group)
                {
                    flat.Fine += Math.Round(max - flat.CastSquare, 2);
                    flat.CastSquare = max;
                    Floor.AddFlat(building, flat, number);
                    number++;
                }
            }

            //добавление лестничной клетки на каждый этаж 
            Floor.AddEntryway(building, Flat.CreateEntryway(building));

            return building;
        }

        private static List<Floor> CreateFinalBuilding(Building building)
        {
            //поиск оптимального разбиения на W1 и W2
            var flats = building.Floors[0].Flats;
            var optimalSubset = SearchOptimalSubsets.ToSearchOptimalSubset(flats);

            //наполнение всех секций дома
            

            return new List<Floor>();
        }

        
    
        
    }
}