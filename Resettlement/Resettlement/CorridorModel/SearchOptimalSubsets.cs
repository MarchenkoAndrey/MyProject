using System;
using System.Collections.Generic;
using System.Linq;

namespace Resettlement.CorridorModel
{
    public static class SearchOptimalSubsets
    {
        public static Tuple<double,bool[]> ToSearchOptimalSubset(List<Flat> flats)
        {
            var average = flats.Select(a => a.CastSquare).Sum() / 2.0;
            var subsets = new List<Tuple<double, bool[]>>();

            //Todo 3. добавить в статью обоснование полного перебора, сказать что случаи с 15 квартирами в секции быть не может из-за 500м2
            MakeSubsets(flats, new bool[flats.Count], 0, average, ref subsets);
            if (subsets == null) throw new Exception();
            
            return ValidateSubsetFinder(subsets, average);
        }
        
        //рекурсивная генерация подмножеств
        private static void MakeSubsets(List<Flat> flats, bool[] subset, int position, double average, ref List<Tuple<double, bool[]>> optimalVariants)
        {
            if (position == subset.Length)
            {
                var res = Evaluate(flats, subset, average);
                //пустой результат не сохраняем
                if (res.Item2.Length > 1)
                {
                    optimalVariants.Add(res);
                }
                return;
            }
            subset[position] = false;
            MakeSubsets(flats, subset, position + 1, average, ref optimalVariants);
            subset[position] = true;
            MakeSubsets(flats, subset, position + 1, average, ref optimalVariants);
        }
        
        //оценка текущего подмножества на оптимальность
        private static Tuple<double, bool[]> Evaluate(List<Flat> flats, bool[] subset, double average)
        {
            var sum = 0.0;
            for (var i = 0; i < subset.Length; i++)
            {
                if (subset[i]) sum += flats[i].CastSquare;
            }
            //5% допустимый интервал от среднего значения
            if (Math.Abs(average - sum) < average * 0.05)
            {
                var optimal = sum;
                bool[] total;
                Array.Copy(subset,
                    total = new bool[subset.Length],
                    subset.Length);

                return new Tuple<double, bool[]>(optimal, total);
            }

            return new Tuple<double, bool[]>(0, new[] { true });
        }

        //Поиск и валидация найденного решения
        //Валидация на >1 True и >1 False (из-за ограничения на минимум 2 квартиры в ряду), там где Entryway, должны быть 3 квартиры
        private static Tuple<double, bool[]> ValidateSubsetFinder(List<Tuple<double, bool[]>> subsets, double average)
        {
            subsets.Sort((x, y) => x.Item1.CompareTo(y.Item1));
            var optimalSubset = subsets.First(a => a.Item1 >= average);
            var state = false;
            while (!state)
            {
                optimalSubset = subsets.First(a => a.Item1 >= average);
                //entryway - последняя в списке
                var entryway = optimalSubset.Item2[optimalSubset.Item2.Length - 1];
                var w1 = entryway ? -1 : 0;
                var w2 = entryway ? 0 : -1;

                var dict = new Dictionary<bool, int>
                {
                    {true, w1},
                    {false, w2}
                };
                foreach (var i in optimalSubset.Item2)
                    dict[i] += 1;

                if (dict.Values.Contains(0) || dict.Values.Contains(1))
                {
                    subsets.Remove(optimalSubset);
                }
                else
                    state = true;
            }

            return optimalSubset;
        }
    }
}
