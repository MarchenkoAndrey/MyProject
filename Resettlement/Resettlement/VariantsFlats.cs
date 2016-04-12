using System.Collections.Generic;
using System.Linq;

namespace Resettlement
{
    public static class VariantsFlats
	{
        public static void VariantsFlat(out List<double[]> totalListApartments, out List<double[]> totalListExceedData, List<int[]> permutationListApartment, List<double> newLengthFlat)
		{
            var listApartments = new List<double[]>();
            var listExceedData = new List<double[]>();
			foreach (var i in permutationListApartment)
			{
				var currentListApartment = new List<double>();
			    var temporalListApartment = new List<double>(newLengthFlat); // для нахождения лишних
                
				for (var s = 0; s < i.Length; ++s)
				{
                    currentListApartment.Add(temporalListApartment[s - 1]);
                    temporalListApartment[s - 1] = 0;  //зануляю взятые эл-ты
				}
			    listExceedData.Add(temporalListApartment.Where(j => j != 0).ToArray());   //оставшиеся варианты записать в exceedData
				listApartments.Add(currentListApartment.ToArray());
			}
            totalListApartments = listApartments;
            totalListExceedData = listExceedData;
			
		}
	}
}
