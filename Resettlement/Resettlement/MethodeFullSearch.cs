using System;
using System.Collections.Generic;
using System.Linq;

namespace Resettlement
{
	static class MethodeFullSearch
	{
		public static List<object> FullSearch(List<double> newLengthOneFlat, List<double> newLengthTwoFlat,double step, double entryway)
		{
			var resultList = new List<object>();
            var totalNumberOptimalLocationFlat = Math.Min(newLengthOneFlat.Count / 2 * 2, newLengthTwoFlat.Count / 2 * 2);

		    var optimalLocationOneFlat = new List<double>();
		    var optimalLocationTwoFlat = new List<double>();
//			var optimalLocationOneFlat = new double[totalNumberOptimalLocationFlat];
//			var optimalLocationTwoFlat = new double[totalNumberOptimalLocationFlat];

			var permListOneFlat = Resursion.Data(newLengthOneFlat.Count,totalNumberOptimalLocationFlat,true); //gereration permutations for Oneflat
			var permListTwoFlat = Resursion.Data(newLengthTwoFlat.Count,totalNumberOptimalLocationFlat, false); //gereration permutations for Twoflat
			 
			var listOneFlats = new List<double[]>();
			listOneFlats = VariantsFlats.VariantsFlat(listOneFlats, permListOneFlat, newLengthOneFlat);
			var listTwoFlats = new List<double[]>();
			listTwoFlats = VariantsFlats.VariantsFlat(listTwoFlats, permListTwoFlat, newLengthTwoFlat);
			var minExtraSquare = 10000.0;

		    var maxCountOptimalFlat = 0;
			foreach (var i in listOneFlats)
			{
				//var squareSectionsOneFlats = new List<double>();
//				for (var k = 0; k < i.Length; k=k+2)
//				{
//					squareSectionsOneFlats.Add(Math.Round(i[k] + i[k + 1] + entryway + 3 * step, 1));
//				}
				foreach (var j in listTwoFlats)
				{
					var currentExtraSquare = 0.0;
					var squareSectionsTwoFlats = new List<double>();
                    var squareSectionsOneFlats = new List<double>();
				    var newOptimalOneFlat = new List<double>();
                    var newOptimalTwoFlat = new List<double>();
					for (var k = 0; k < j.Length; k = k + 2)
					{
					    if (j[k] - i[k] < 1.25 || j[k + 1] - i[k + 1] < 1.25)
					    {
					        continue;
					    }
					    newOptimalOneFlat.Add(i[k]);
                        newOptimalOneFlat.Add(i[k+1]);
                        newOptimalTwoFlat.Add(j[k]);
                        newOptimalTwoFlat.Add(j[k + 1]);
                        squareSectionsOneFlats.Add(Math.Round(i[k] + i[k + 1] + entryway + 3 * step, 1));
                        squareSectionsTwoFlats.Add(Math.Round(j[k] + j[k + 1] + 2 * step, 1));       // delta1 + delta2
					}

				    if (squareSectionsOneFlats.Count == 0)
				    {
                        continue;
				    }      

				    for (var s = 0; s < squareSectionsOneFlats.Count; ++s)
					{
						var h = squareSectionsTwoFlats[s] - squareSectionsOneFlats[s];
							currentExtraSquare += Math.Abs(h);
					}
                    // максимальная комбинация по размеру
					if (maxCountOptimalFlat<newOptimalOneFlat.Count || 
                        (currentExtraSquare < minExtraSquare && maxCountOptimalFlat == newOptimalOneFlat.Count)) 
					{
						minExtraSquare = Math.Round(currentExtraSquare,1);
						optimalLocationOneFlat = newOptimalOneFlat;
						optimalLocationTwoFlat = newOptimalTwoFlat;
                        maxCountOptimalFlat = newOptimalOneFlat.Count;
					}
				}
			}
			resultList.Add(minExtraSquare);
			resultList.Add(optimalLocationOneFlat.ToArray());
			resultList.Add(optimalLocationTwoFlat.ToArray());
			return resultList;
		}
	}
}
