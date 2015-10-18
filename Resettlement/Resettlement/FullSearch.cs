using System;
using System.Collections.Generic;
using System.Linq;

namespace Resettlement
{
	static class FullSearch
	{
		public static List<object> MethodeFullSearch(List<double> newLengthOneFlat, List<double> newLengthTwoFlat,double step, double entryway)
		{
			var resultList = new List<object>();
			var optimalLocationOneFlat = new double[newLengthOneFlat.Count];
			var optimalLocationTwoFlat = new double[newLengthTwoFlat.Count];

//			var optimalLocationOneFlat = new List<double>();
//			var optimalLocationTwoFlat = new List<double>();

			var permListOneFlat = Resursion2.Data(newLengthOneFlat.Count); //gereration permutations for 1flat
			var p2 = Resursion.Data(newLengthTwoFlat.Count);              // generation perm for 2flat
			//Todo перестановок для двухкомнатных больше, можно пары менять местами 
			var permListTwoFlat = permListOneFlat;

			if (newLengthOneFlat.Count != newLengthTwoFlat.Count)
			{
				permListTwoFlat = Resursion.Data(newLengthTwoFlat.Count);
			}  

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
