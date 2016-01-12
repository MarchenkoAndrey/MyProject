using System.Collections.Generic;
using System;

namespace Resettlement
{
	static class VariantsFlats
	{
		public static List<object> VariantsFlat(List<int[]> permListFlat, List<double> newLengthFlat)
		{
            var resultList = new List<object>();
            var listFlat = new List<double[]>();
            var excessData = new List<double[]>();
			foreach (var i in permListFlat)
			{
				var currentList = new List<double>();
                var currentExcessData = new List<double>();
                var tempList = new List<double>(newLengthFlat); // для нахождения лишних

				for (var s = 0; s < i.Length; ++s)
				{
                    currentList.Add(tempList[i[s] - 1]);
                    tempList[i[s] - 1] = 0;  //зануляю взятые эл-ты
				}
                foreach (var j in tempList)
                {
                    if (j != 0)
                    {
                        currentExcessData.Add(j);
                    }
                }
                excessData.Add(currentExcessData.ToArray());   //оставшиеся варианты записать в excessData
				listFlat.Add(currentList.ToArray());

			}
            resultList.AddRange(listFlat);
            resultList.AddRange(excessData);
			return resultList;
		}
	}
}
