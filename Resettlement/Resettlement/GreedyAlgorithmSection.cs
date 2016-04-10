using System;
using System.Collections.Generic;
using Resettlement.GeneralData;

namespace Resettlement
{
	static class GreedyAlgorithmSection
	{
		public static List<object> GreedyMethode(List<double> newLengthOneFlat, List<double> newLengthTwoFlat, double step,
			double entryway, double newFirstOneF)
		{
			var list = new List<object>();
			var sortedListOneFlat = InsertionSort.InsertSort(newLengthOneFlat);
			var sortedListTwoFlat = InsertionSort.InsertSort(newLengthTwoFlat);
            var numberOfApartments = Math.Min(newLengthOneFlat.Count / 2 * 2, newLengthTwoFlat.Count / 2 * 2);
            var finalPlacementOneFlat = new double[numberOfApartments];
            var finalPlacementTwoFlat = new double[numberOfApartments];
			var itogFine = 0.0;
            var maxFine = 0.0;
            var newFirstOneFlat=0.0;
			var b = 0;
		    var index1 = 0;
		    var index2 = 0;
			for (var n = 0; n < numberOfApartments; n=n+2)             // цикл заполнения секций
			{
                double choiceMinOneFlat;
                if (newFirstOneF!=0 && b==0)
                {
                     choiceMinOneFlat = newFirstOneF;
                }
                else 
                {                
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

                //запись в массив
                var sortedTwo = new double[sortedListTwoFlat.Count];
                for (var p = 0; p < sortedListTwoFlat.Count; ++p)
                {
                    sortedTwo[p] = sortedListTwoFlat[p];
                }

				for (var i = 0; i < sortedListTwoFlat.Count; ++i)
				{
					for (var j = i + 1; j < sortedListTwoFlat.Count; ++j)
					{
						for (var h = 0; h < newSortedListOneFlat.Count; ++h)
						{
                            
                            var currentExtraSquare = 0.0;
                            double[] currentMassiv;
                            Array.Copy(sortedTwo, currentMassiv = new double[sortedTwo.Length], sortedTwo.Length);
						    if (numberOfApartments-n == 2)
						    {
                                Array.Reverse(currentMassiv);
						    }
						    if (currentMassiv[i] - choiceMinOneFlat < Constraints.ApartureLength) 
						    {
                                var a1 = Math.Round(Constraints.ApartureLength - (currentMassiv[i] - choiceMinOneFlat),2);
                                if (a1 <= step)
                                {
                                    currentMassiv[i] += step;
                                    currentExtraSquare += step;
                                }
                                else
                                {
                                    currentMassiv[i] += Math.Round(Math.Ceiling(a1 / step) * step, 1);
                                    currentExtraSquare += Math.Round(Math.Ceiling(a1 / step) * step, 1);
                                }
						    }
                            if (currentMassiv[j] - newSortedListOneFlat[h] < Constraints.ApartureLength)
					        {
                                var a2 = Math.Round(Constraints.ApartureLength - (currentMassiv[j] - newSortedListOneFlat[h]),2);
					            if (a2 <= step)
                                {
                                    currentMassiv[j] += step;
                                    currentExtraSquare += step;
                                }
                                else
                                {
                                    currentMassiv[j] += Math.Round(Math.Ceiling(a2 / step) * step, 1);
                                    currentExtraSquare += Math.Round(Math.Ceiling(a2 / step) * step, 1);
                                }
					        }
						    var currentFine =
								Math.Abs(Math.Round(
                                    currentMassiv[i] + currentMassiv[j] + 2 * step - choiceMinOneFlat - entryway - 3 * step -
                                    newSortedListOneFlat[h] + currentExtraSquare, 1));
							if (currentFine < fine)
							{
								fine = currentFine;
                                finalPlacementTwoFlat[n] = (currentMassiv[i]);
							    index1 = i;
                                finalPlacementTwoFlat[n + 1] = (currentMassiv[j]);
							    index2 = j;
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
			    if (index1 > index2)
			    {
			        sortedListTwoFlat.RemoveAt(index1);
			        sortedListTwoFlat.RemoveAt(index2);
			    }
			    else
			    {
                    sortedListTwoFlat.RemoveAt(index2);
                    sortedListTwoFlat.RemoveAt(index1);
			    }

			}
		    
			list.Add(itogFine);
			list.Add(finalPlacementOneFlat);
			list.Add(finalPlacementTwoFlat);
            list.Add(newLengthOneFlat);
            list.Add(newLengthTwoFlat);
            list.Add(newFirstOneFlat);
			return list;
		}
	}
}
