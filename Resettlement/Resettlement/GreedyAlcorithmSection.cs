using System;
using System.Collections.Generic;

namespace Resettlement
{
	static class GreedyAlcorithmSection
	{
		public static List<object> GreedyMethode(List<double> newLengthOneFlat, List<double> newLengthTwoFlat, double step,
			double entryway)
		{
			var list = new List<object>();
			var sortedListOneFlat = InsertionSort.InsertSort(newLengthOneFlat);
			var sortedListTwoFlat = InsertionSort.InsertSort(newLengthTwoFlat);
			var numberOfApartments = sortedListOneFlat.Count;
			var finalPlacementOneFlat = new double[numberOfApartments];
			var finalPlacementTwoFlat = new double[numberOfApartments];
			
			var itogFine = 0.0;
			for (int n = 0; n < numberOfApartments; n=n+2)             // цикл заполнения секций
			{
				var choiceMinOneFlat = sortedListOneFlat[0];
				var newSortedListOneFlat = new List<double>();
				for (var i = 1; i < sortedListOneFlat.Count; ++i)
				{
					newSortedListOneFlat.Add(sortedListOneFlat[i]);
				}
				var fine = 10000.0;
				
				finalPlacementOneFlat[n] = choiceMinOneFlat;

				for (var i = 0; i < sortedListTwoFlat.Count; ++i)
				{
					for (var j = i + 1; j < sortedListTwoFlat.Count; ++j)
					{
						for (var h = 0; h < newSortedListOneFlat.Count; ++h)
						{
							var currentFine =
								Math.Round(
									sortedListTwoFlat[i] + sortedListTwoFlat[j] + 2*step - choiceMinOneFlat - entryway - 3*step -
									newSortedListOneFlat[h], 1);
							if (currentFine > -1 && currentFine < fine)
							{
								fine = currentFine;
								finalPlacementTwoFlat[n] = (sortedListTwoFlat[i]);
								finalPlacementTwoFlat[n+1] = (sortedListTwoFlat[j]);
								finalPlacementOneFlat[n+1] = (newSortedListOneFlat[h]);
							}
						}
					}
				}
				//удаление занятых вариантов из списка и суммирование штрафа
				itogFine+=Math.Abs(fine);
				sortedListOneFlat.Remove(finalPlacementOneFlat[n]);
				sortedListOneFlat.Remove(finalPlacementOneFlat[n+1]);
				sortedListTwoFlat.Remove(finalPlacementTwoFlat[n]);
				sortedListTwoFlat.Remove(finalPlacementTwoFlat[n+1]);
			}
			list.Add(itogFine);
			list.Add(finalPlacementOneFlat);
			list.Add(finalPlacementTwoFlat);
			return list;
		}
	}
}
