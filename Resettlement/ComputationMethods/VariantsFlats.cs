using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputationMethods
{
    public static class VariantsFlats
	{
        public static void VariantsFlat(out List<double[]> totalListApartments, out List<double[]> totalListExceedData, IEnumerable<int[]> permutationListApartment, IEnumerable<double> newLengthFlat)
		{
            var listApartments = new List<double[]>();
            var listExceedData = new List<double[]>();
			foreach (var i in permutationListApartment)
			{
				var currentListApartment = new List<double>();
			    var temporalListApartment = new List<double>(newLengthFlat); // для нахождения лишних
                
				foreach (int t in i)
				{
				    currentListApartment.Add(temporalListApartment[t - 1]);
				    temporalListApartment[t - 1] = 0;  //зануляю взятые эл-ты
				}
			    listExceedData.Add(temporalListApartment.Where(j => Math.Abs(j) > 1e-9).ToArray());   //оставшиеся варианты записать в exceedData
				listApartments.Add(currentListApartment.ToArray());
			}
            totalListApartments = listApartments;
            totalListExceedData = listExceedData;
			
		}
	}
}
