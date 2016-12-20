using System;
using System.Collections.Generic;
using System.Linq;

namespace Resettlement
{
    public static class VariantsFlats
	{
        public static DataPermutFullS VariantsFlat(IEnumerable<int[]> permutationListApartment, List<double> newLengthFlat)
        {
            var listApartments = new List<double[]>();
            var listExceedData = new List<double[]>();
            foreach (var i in permutationListApartment)
            {
                var currentListApartment = new List<double>();
                var temporalListApartment = new List<double>(newLengthFlat); // для нахождения лишних

                foreach (var t in i)
                {
                    currentListApartment.Add(temporalListApartment[t - 1]);
                    temporalListApartment[t - 1] = 0;  //зануляю взятые эл-ты
                }
                listExceedData.Add(temporalListApartment.Where(j => Math.Abs(j) > 1e-9).ToArray());   //оставшиеся варианты записать в exceedData
                listApartments.Add(currentListApartment.ToArray());
            }
            return new DataPermutFullS(listApartments, listExceedData);
        }
	}
}
