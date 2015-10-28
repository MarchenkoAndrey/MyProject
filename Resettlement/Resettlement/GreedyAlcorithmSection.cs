using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
			var size = sortedListOneFlat.Count;
			var itogTwoFlat = new double[size];
			var itogOneFlat = new double[size];
			var itogFine = 0.0;
			for (int n = 0; n < size; n=n+2)             // цикл заполнения секций
			{
				var choiseMinOneFlat = sortedListOneFlat[0];
				var newSortListOneFlat = new List<double>();
				for (var i = 1; i < sortedListOneFlat.Count; ++i)
				{
					newSortListOneFlat.Add(sortedListOneFlat[i]);
				}
				var fine = 10000.0;
				
				itogOneFlat[n] = choiseMinOneFlat;

				for (var i = 0; i < sortedListTwoFlat.Count; ++i)
				{
					for (var j = i + 1; j < sortedListTwoFlat.Count; ++j)
					{
						for (var h = 0; h < newSortListOneFlat.Count; ++h)
						{
							var f =
								Math.Round(
									sortedListTwoFlat[i] + sortedListTwoFlat[j] + 2*step - choiseMinOneFlat - entryway - 3*step -
									newSortListOneFlat[h], 1);
							if (f > -1 && f < fine)
							{
								fine = f;
								itogTwoFlat[n] = (sortedListTwoFlat[i]);
								itogTwoFlat[n+1] = (sortedListTwoFlat[j]);
								itogOneFlat[n+1] = (newSortListOneFlat[h]);
							}
						}
					}
				}
				//удаление занятых вариантов из списка и суммирование штрафа
				itogFine+=Math.Abs(fine);
				sortedListOneFlat.Remove(itogOneFlat[n]);
				sortedListOneFlat.Remove(itogOneFlat[n+1]);
				sortedListTwoFlat.Remove(itogTwoFlat[n]);
				sortedListTwoFlat.Remove(itogTwoFlat[n+1]);
			}
			list.Add(itogFine);
			list.Add(itogOneFlat);
			list.Add(itogTwoFlat);
			return list;
		}
	}
}
