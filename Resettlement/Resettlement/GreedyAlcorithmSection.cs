using System;
using System.Collections.Generic;

namespace Resettlement
{
	static class GreedyAlcorithmSection
	{
		public static List<object> GreedyMethode(List<double> newLengthOneFlat, List<double> newLengthTwoFlat, double step,
			double entryway, double newFirstOneF)
		{
			var list = new List<object>();
			var sortedListOneFlat = InsertionSort.InsertSort(newLengthOneFlat);
			var sortedListTwoFlat = InsertionSort.InsertSort(newLengthTwoFlat);
            var numberOfApartments = Math.Min(newLengthOneFlat.Count / 2 * 2, newLengthTwoFlat.Count / 2 * 2);
//			var finalPlacementOneFlat = new double[numberOfApartments];
//			var finalPlacementTwoFlat = new double[numberOfApartments];
            var finalPlacementOneFlat = new double[numberOfApartments];
            var finalPlacementTwoFlat = new double[numberOfApartments];
			var itogFine = 0.0;
            var maxFine = 0.0;
            var newFirstOneFlat=0.0;
			var b = 0;
			for (var n = 0; n < numberOfApartments; n=n+2)             // цикл заполнения секций
			{
                double choiceMinOneFlat;
                if (newFirstOneF!=0 && b==0)
                {
                     choiceMinOneFlat = newFirstOneF;
                }
                else 
                {
//                 choiceMinOneFlat = sortedListOneFlat[0];
                   choiceMinOneFlat = sortedListOneFlat[sortedListOneFlat.Count/2];
                }
				b++;
				var newSortedListOneFlat = new List<double>();
                var a = 0;
				for (var i = 0; i < sortedListOneFlat.Count; ++i)
				{
                    if (sortedListOneFlat[i] == choiceMinOneFlat && a == 0)
                    {
                        a++;
                    }
                    else
                    {
                        newSortedListOneFlat.Add(sortedListOneFlat[i]);
                    }
				}
				var fine = 10000.0;
				
				finalPlacementOneFlat[n] = choiceMinOneFlat;

				for (var i = 0; i < sortedListTwoFlat.Count; ++i)
				{
					for (var j = i + 1; j < sortedListTwoFlat.Count; ++j)
					{
						for (var h = 0; h < newSortedListOneFlat.Count; ++h)
						{
						    if (sortedListTwoFlat[i] - choiceMinOneFlat < 1.25 || sortedListTwoFlat[j] - newSortedListOneFlat[h] < 1.25)
						    {
						        continue;
						    }
						    var currentFine =
								Math.Abs(Math.Round(
									sortedListTwoFlat[i] + sortedListTwoFlat[j] + 2*step - choiceMinOneFlat - entryway - 3*step -
									newSortedListOneFlat[h], 1));
							if (currentFine < fine)
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

				itogFine+=fine;
                if(maxFine<fine)
                {
                    maxFine = fine;
                    newFirstOneFlat = finalPlacementOneFlat[n];
                }
               
				sortedListOneFlat.Remove(finalPlacementOneFlat[n]);
				sortedListOneFlat.Remove(finalPlacementOneFlat[n+1]);
				sortedListTwoFlat.Remove(finalPlacementTwoFlat[n]);
				sortedListTwoFlat.Remove(finalPlacementTwoFlat[n+1]);
			}
			list.Add(itogFine);
			list.Add(finalPlacementOneFlat);
			list.Add(finalPlacementTwoFlat);
            list.Add(newFirstOneFlat);
			return list;
		}
	}
}
