using System;
using System.Collections.Generic;
using System.Linq;

namespace Resettlement.CorridorModel
{
    public static class SearchOptimalSubsets
    {
        public static Tuple<double,bool[]> ToSearchOptimalSubsets(List<Flat> flats)
        {
            var average = flats.Select(a => a.CastSquare).Sum() / 2.0;
            var optimalVariants = new List<Tuple<double, bool[]>>();
            MakeSubsets(flats, new bool[flats.Count], 0, average, ref optimalVariants);

            //Сортировка оптимальных вариантов по сумме
            optimalVariants.Sort((x, y) => x.Item1.CompareTo(y.Item1));
            
            //Возвращаем оптимальный
            return optimalVariants.First(a => a.Item1 >= average);
        }

        //рекурсивная генерация подмножеств
        static void MakeSubsets(List<Flat> flats, bool[] subset, int position, double average, ref List<Tuple<double, bool[]>> optimalVariants)
        {
            if (position == subset.Length)
            {
                var res = Evaluate(flats, subset, average);
                //если результат непустой -> сохраним
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
        static Tuple<double, bool[]> Evaluate(List<Flat> flats, bool[] subset, double average)
        {
            var sum = 0.0;
            for (int i = 0; i < subset.Length; i++)
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

    }
}
