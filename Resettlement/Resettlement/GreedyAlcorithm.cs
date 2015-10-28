using System;
using System.Collections.Generic;
using System.Linq;

namespace Resettlement
{
	static class GreedyAlcorithm
	{
		public static List<object> GreedyMethode(List<double> newLengthOneFlat, List<double> newLengthTwoFlat, double step,
			double entryway)
		{
			var list = new List<object>();
			var sortedListOneFlat = InsertionSort.InsertSort(newLengthOneFlat);
			var sortedListTwoFlat = InsertionSort.InsertSort(newLengthTwoFlat);
			var groupingAverageTwoFlat = new List<double>();

			for (var i = 0; i < sortedListOneFlat.Count/2.0;++i)
			{
				groupingAverageTwoFlat.Add(sortedListTwoFlat[i]);
				groupingAverageTwoFlat.Add(sortedListTwoFlat[sortedListTwoFlat.Count-1-i]);
			}

			var averageSectionTwoFlat = new List<double>();

			for (var k=0; k<groupingAverageTwoFlat.Count;k=k+2)
			{
				averageSectionTwoFlat.Add(groupingAverageTwoFlat[k] + groupingAverageTwoFlat[k + 1] + 2*step);
			}
			var arrangementOneFlat = new double[sortedListOneFlat.Count];
			var maxOneFlatToAverageSectionTwoFlat = new List<double>();
			for (var j=0; j<averageSectionTwoFlat.Count;++j)
			{
				maxOneFlatToAverageSectionTwoFlat.Add(Math.Round(averageSectionTwoFlat[j] - entryway - 3*step - sortedListOneFlat[j],1));
				arrangementOneFlat[2 * j] = sortedListOneFlat[j];
			}

			maxOneFlatToAverageSectionTwoFlat = InsertionSort.InsertSort(maxOneFlatToAverageSectionTwoFlat);
			var remainingVariantsOneFlat = new List<double>();
			for (var i = sortedListOneFlat.Count/2; i < sortedListOneFlat.Count; ++i)
			{
				remainingVariantsOneFlat.Add(sortedListOneFlat[i]);
			}
			var fineWithSection = new double[maxOneFlatToAverageSectionTwoFlat.Count];

			for (var c = 0; c < maxOneFlatToAverageSectionTwoFlat.Count; ++c)
			{
				fineWithSection[c] = Math.Round(maxOneFlatToAverageSectionTwoFlat[c] - remainingVariantsOneFlat[c],1);
				arrangementOneFlat[2*(c+1) - 1] = remainingVariantsOneFlat[c];
			}

			var finishFine =0.0;
			
			for (var i = 0; i < fineWithSection.Length; ++i)
			{
				finishFine += Math.Abs(fineWithSection[i]);
			}
			list.Add(finishFine);
			list.Add(arrangementOneFlat);
			list.Add(sortedListTwoFlat);
		
			return list;
		}
	}
}
