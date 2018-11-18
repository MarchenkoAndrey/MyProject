using System;
using System.Collections.Generic;
using System.Linq;
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
                ToFillFloor(building, floor, position);
                floor.Fine = floor.FlatsW1.Select(a => a.Fine).Sum() + floor.FlatsW2.Select(a => a.Fine).Sum();
            }

            building.Fine = building.Floors.Select(a => a.Fine).Sum();
        }

        private static void ToFillFloor(Building building,Floor floor, bool[] position)
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

            var sumSquaresW1 = SumSquares(listW1);
            var sumSquaresW2 = SumSquares(listW2);

            var optimalDiffLength = double.MaxValue;
            var optimalW1 = building.W1;
            var optimalW2 = building.W2;

            // если это не первый этаж, то w1 и w2 уже известны
            // перебор w1 и w2 и расчет разницы их длин
            if (optimalW1 < 1)
            {
                foreach (var w1 in Constraints.WidthFlat)
                {
                    foreach (var w2 in Constraints.WidthFlat)
                    {
                        if (optimalDiffLength > Math.Abs(sumSquaresW2 / w2 - sumSquaresW1 / w1))
                        {
                            optimalDiffLength = Math.Abs(sumSquaresW2 / w2 - sumSquaresW1 / w1);
                            optimalW1 = w1;
                            optimalW2 = w2;
                        }
                    }
                }
                //записываем оптимальные w1 и w2
                building.W1 = optimalW1;
                building.W2 = optimalW2;
            }
            // в переборе подмножеств, мы брали случайное значение Entryway, теперь же нужно его пересчитать
            // 1. Меняем предыдущее значение площади Entryway на правильное
            // 2. Пересчитываем суммы, пересчитываем разницу площадей
            // 3. Смотрим, куда же нужно добавить разницу между длинами w1 и w2
            // 4. Добавляем любой квартире в списке эту разницу

            //1
            listW1[listW1.Count - 1].CastSquare = Math.Round(Constraints.EntrywayLength * optimalW1, 2);
            //2
            sumSquaresW1 = SumSquares(listW1);
            optimalDiffLength = Math.Abs(sumSquaresW2 / optimalW2 - sumSquaresW1 / optimalW1);
            //3
            var isRequiredAddInW1 = sumSquaresW1 / optimalW1 > sumSquaresW2 / optimalW2;
            //4
            if (isRequiredAddInW1)
                listW1[listW1.Count - 2].CastSquare += Math.Round(optimalDiffLength * optimalW1, 2);
            else
                listW2[listW2.Count - 1].CastSquare += Math.Round(optimalDiffLength * optimalW2, 2);

            // Посчитать Fine для каждой квартиры
            foreach (var flat in listW1)
            {
                flat.Fine = Math.Round(flat.CastSquare + flat.BalconySquare - flat.InputSquare, 2);
            }

            foreach (var flat in listW2)
            {
                flat.Fine = Math.Round(flat.CastSquare + flat.BalconySquare - flat.InputSquare, 2);
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
