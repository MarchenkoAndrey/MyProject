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

            /*Todo V2 Anomaly = исключаем из выравнивателя группу самых крупных квартир для дальнейшего анализа. Размер группы - количество этажей
            //var listExcessFlats = HandlerBiggerFlats.ToDefineBiggerFlats(listFlats, building.CountFloor);
            //listFlats = HandlerBiggerFlats.ToDeleteBiggerFlats(listFlats, listExcessFlats);*/

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

            /*Todo V2 Anomaly 
            //группировка аномальных
            //listExcessFlats = HandlerBiggerFlats.ToGroupBiggerFlats(listExcessFlats);
            //добавление аномальных квартир (большие наверх)
            //Самые крупные квартиры оставляем на последние этажи, чтобы там за счет коридора в углу построить секцию

            var numberFloor = 1;
            foreach (var elem in listExcessFlats)
            {
                listFlatsOnFloor[numberFloor].Add(elem);
                numberFloor++;
            }*/

            return building;
        }

        private static List<Floor> CreateFinalBuilding(Building building)
        {

            return new List<Floor>();
        }
    }
}
