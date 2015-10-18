using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Resettlement
{
	static class FullSearch
	{
		public static double MethodeFullSearch(List<double> newLengthOneFlat, List<double> newLengthTwoFlat,double step,double widthOfAppartment, double entryway)
		{
			double minCost = 10000;
			var permListOneFlat = new List<int[]>();
			var permListTwoFlat = new List<int[]>();
			permListOneFlat = Resursion.Data(newLengthOneFlat.Count); //gereration permutations
		
			//Todo перестановок для двухкомнатных больше, можно пары менять местами 
			permListTwoFlat = permListOneFlat;

			if (newLengthOneFlat.Count != newLengthTwoFlat.Count)
			{
				permListTwoFlat = Resursion.Data(newLengthTwoFlat.Count);
			}  

			var listOneFlats = new List<double[]>();
			listOneFlats = VariantsFlats.VariantsFlat(listOneFlats, permListOneFlat, newLengthOneFlat);
			var listTwoFlats = new List<double[]>();
			listTwoFlats = VariantsFlats.VariantsFlat(listTwoFlats, permListTwoFlat, newLengthTwoFlat);

			foreach (var i in permListOneFlat)
			{
				var variantPermOneFlat = i;
				for (var l = 0; l < variantPermOneFlat.Length; ++ l)
				{

				}
				var squareSectionsOneFlat = new List<double>();
				for (var k = 0; k < variantPermOneFlat.Length; k=k+2)
				{
					squareSectionsOneFlat.Add(variantPermOneFlat[k] + variantPermOneFlat[k + 1] + entryway + 2*step);
				}

				foreach (var j in permListTwoFlat)
				{
					var variantPermTwoFlat = permListOneFlat[0];

				}
			}

			return minCost;
		}
	}
}
