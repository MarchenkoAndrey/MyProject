using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.VisualStyles;
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
            var flats = building.Floors[0].Flats;
            //flats.RemoveRange(1,5);
            var average = flats.Select(a=>a.CastSquare).Sum() * 0.525; //пополам + 5% 
            var total = new bool[flats.Count];
            var optimal= 0.0;
            var result = new List<Tuple<double, bool[]>>();
            MakeSubsets(flats, new bool[flats.Count], 0, average, total, optimal, ref result);

            optimal += optimal;

            return new List<Floor>();
        }

        static Tuple<double,bool[]> Evaluate(List<Flat> flats, bool[] subset, double average,  bool[] total, double optimal)
        {
            var sum = 0.0;
            for (int i = 0; i < subset.Length; i++)
            {
                if (subset[i]) sum += flats[i].CastSquare;
                //else sum -= flats[i].CastSquare;
            }

            if (Math.Abs(average - sum) < 5.0)
            {
                optimal = sum;
                total = subset;

                return new Tuple<double,bool[]>(optimal,total);
            }

            return new Tuple<double, bool[]>(0, new[] {true});
        }
    
        static void MakeSubsets(List<Flat> flats, bool[] subset, int position, double average, bool[] total, double optimal, ref List<Tuple<double, bool[]>> result)
        {
            if (position == subset.Length)
            {
                total = new bool[flats.Count];
                var res = Evaluate(flats, subset, average, total, optimal);
                //if (res.Item2.Length>1)
                
                result.Add(res);
                return;
            }
            subset[position] = false;
            MakeSubsets(flats, subset, position + 1,average, total, optimal, ref result);
            subset[position] = true;
            MakeSubsets(flats, subset, position + 1, average, total, optimal, ref result);
        }
    }
}