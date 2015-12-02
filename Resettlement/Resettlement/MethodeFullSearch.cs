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
            var totalNumberOptimalLocationFlat = Math.Min(newLengthOneFlat.Count / 4 * 4, newLengthOneFlat.Count / 4 * 4);
			var optimalLocationOneFlat = new double[totalNumberOptimalLocationFlat];
			var optimalLocationTwoFlat = new double[totalNumberOptimalLocationFlat];

			var permListOneFlat = Resursion.Data(newLengthOneFlat.Count,true); //gereration permutations for Oneflat
			var permListTwoFlat = Resursion.Data(newLengthTwoFlat.Count, false); //gereration permutations for Twoflat
			 

			var listOneFlats = new List<double[]>();
			listOneFlats = VariantsFlats.VariantsFlat(listOneFlats, permListOneFlat, newLengthOneFlat);
			var listTwoFlats = new List<double[]>();
			listTwoFlats = VariantsFlats.VariantsFlat(listTwoFlats, permListTwoFlat, newLengthTwoFlat);
			var minExtraSquare = 10000.0;

			foreach (var i in listOneFlats)
			{
				var squareSectionsOneFlats = new List<double>();
				for (var k = 0; k < i.Length; k=k+2)
				{
					squareSectionsOneFlats.Add(Math.Round(i[k] + i[k + 1] + entryway + 3*step,1));
				}
				foreach (var j in listTwoFlats)
				{
					var currentExtraSquare = 0.0;
					var squareSectionsTwoFlats = new List<double>();
					for (var k = 0; k < j.Length; k = k + 2)
					{
						squareSectionsTwoFlats.Add(Math.Round(j[k] + j[k + 1] + 2 * step, 1));       // delta1 + delta2
					}
					for (var s = 0; s < squareSectionsOneFlats.Count; ++s)
					{
						var h = squareSectionsTwoFlats[s] - squareSectionsOneFlats[s];
							currentExtraSquare += Math.Abs(h);
					}
					if (currentExtraSquare < minExtraSquare)
					{
						minExtraSquare = Math.Round(currentExtraSquare,1);
						optimalLocationOneFlat=i;
						optimalLocationTwoFlat=j;
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
