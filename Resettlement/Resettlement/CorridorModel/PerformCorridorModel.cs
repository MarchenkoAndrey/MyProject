using System;
using System.Collections.Generic;
using System.Linq;

namespace Resettlement.CorridorModel
{
    public static class PerformCorridorModel
    {
        public static Building ToPerformCorridorModel(Building building)
        {
            //1. Группировка квартир по этажам
            var res = SplitFlatsOnFlours(building);

            //2. Расстановка секции


            return new Building();
        }

        private static Dictionary<int, List<Flat>> SplitFlatsOnFlours(Building building)
        {
            var listFlats = building.Flats.OrderBy(a => a.CastSquare).ToList();

            //Todo V2 Anomaly = исключаем из выравнивателя группу самых крупных квартир для дальнейшего анализа. Размер группы - количество этажей
            //var listExcessFlats = HandlerBiggerFlats.ToDefineBiggerFlats(listFlats, building.CountFloor);
            //listFlats = HandlerBiggerFlats.ToDeleteBiggerFlats(listFlats, listExcessFlats);

            // словарь [этаж - список квартир] для разделения на равные группы площадей
            var listFlatsOnFloor = new Dictionary<int, List<Flat>>();
            // инициализация словаря
            for (var i = 1; i <= building.CountFloor; ++i)
            {
                listFlatsOnFloor[i] = new List<Flat>();
            }
            for (var j = 0; j < listFlats.Count; j += building.CountFloor)
            {
                var cur = listFlats.GetRange(j, building.CountFloor);
                var max = cur.Select(b => b.CastSquare).Max();

                var number = 1;
                foreach (var elem in cur)
                {
                    elem.Fine += Math.Round(max - elem.CastSquare, 2);
                    elem.CastSquare = max;

                    //добавление на этажи
                    listFlatsOnFloor[number].Add(elem);
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
            }
            */

            return listFlatsOnFloor;
        }
    }
}
