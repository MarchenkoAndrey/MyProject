using System;
using System.Collections.Generic;
using System.Linq;
using ComputationMethods;
using ComputationMethods.GeneralData;

namespace Resettlement
{
	public static class GreedyAlgorithmSection
	{
		public static List<object> GreedyMethode(DataAlgorithm data, double firstOneBedroomApartment)
		{
            //Todo избавиться от List<object>();
			var resultList = new List<object>();
		    var sortedAscListOneBedroomApartment = data.ListLengthOneBedroomApartment.OrderBy(z => z).ToList();
            var sortedAscListTwoBedroomApartment = data.ListLengthTwoBedroomApartment.OrderBy(z => z).ToList();
		    var optimalNumberApartments =
		        OptimalNumberApartments.CalculateOptimalNumberApartments(
		            sortedAscListOneBedroomApartment, sortedAscListTwoBedroomApartment, 2);
            var finalPlacementOneBedroomApartment = new double[optimalNumberApartments];
            var finalPlacementTwoBedroomApartment = new double[optimalNumberApartments];
			var totalFine = 0.0;
            var maxFine = 0.0;
		    var newFirstOneBedroomApartment = 0.0;
			var isFlagFirstEntry = true;
		    var index1 = 0;
		    var index2 = 0;
			for (var n = 0; n < optimalNumberApartments; n=n+2)             // цикл заполнения секций
			{
                double choiceMinOneBedroomApartment;
                if (Math.Abs(firstOneBedroomApartment)>1e-9 && isFlagFirstEntry)
                {
                     choiceMinOneBedroomApartment = firstOneBedroomApartment;
                }
                else 
                {                
                   choiceMinOneBedroomApartment = sortedAscListOneBedroomApartment[sortedAscListOneBedroomApartment.Count/2];
                }
			    isFlagFirstEntry = false;
				var newSortedListOneBedroomApartment = new List<double>();
                var isFlagMeetApartment = true;
				foreach (var elem in sortedAscListOneBedroomApartment) // divided from list given value oneApartment
				{
				    if (Math.Abs(elem - choiceMinOneBedroomApartment)< 1e-9 && isFlagMeetApartment)
				    {
				        isFlagMeetApartment = false;
				    }
				    else
				    {
				        newSortedListOneBedroomApartment.Add(elem);
				    }
				}
			    var fine = 10000.0;
              
				finalPlacementOneBedroomApartment[n] = choiceMinOneBedroomApartment;

			    var arraySortedTwoApartments = ChangeTypeVariable.ChangeListIntoArray(sortedAscListTwoBedroomApartment); 

				for (var i = 0; i < sortedAscListTwoBedroomApartment.Count(); ++i)
				{
					for (var j = i + 1; j < sortedAscListTwoBedroomApartment.Count(); ++j)
					{
						for (var h = 0; h < newSortedListOneBedroomApartment.Count; ++h)
						{
                            var currentExtraSquare = 0.0;
                            double[] currentMassiv;
                            Array.Copy(arraySortedTwoApartments, currentMassiv = new double[arraySortedTwoApartments.Length], arraySortedTwoApartments.Length);
                            //TODO когда остается 2 варианта добавить 2 разных варианта сочетания
						    if (optimalNumberApartments-n == 2)
						    {
						        Array.Reverse(currentMassiv);
						    }
						    if (currentMassiv[i] - choiceMinOneBedroomApartment < Constraints.ApartureLength) 
						    {
                                var tempFine1 = Math.Round(Constraints.ApartureLength - (currentMassiv[i] - choiceMinOneBedroomApartment),2);
                                if (tempFine1 <= data.Step)
                                {
                                    currentMassiv[i] += Math.Round(data.Step,1);
                                    currentExtraSquare += Math.Round(data.Step,1);
                                }
                                else
                                {
                                    currentMassiv[i] += Math.Round(Math.Ceiling(tempFine1 / data.Step) * data.Step, 1);
                                    currentExtraSquare += Math.Round(Math.Ceiling(tempFine1 / data.Step) * data.Step, 1);
                                }
						    }
                            if (currentMassiv[j] - newSortedListOneBedroomApartment[h] < Constraints.ApartureLength)
					        {
                                var tempFine2 = Math.Round(Constraints.ApartureLength - (currentMassiv[j] - newSortedListOneBedroomApartment[h]),2);
					            if (tempFine2 <= data.Step)
                                {
                                    currentMassiv[j] += Math.Round(data.Step,1);
                                    currentExtraSquare += Math.Round(data.Step,1);
                                }
                                else
                                {
                                    currentMassiv[j] += Math.Round(Math.Ceiling(tempFine2 / data.Step) * data.Step, 1);
                                    currentExtraSquare += Math.Round(Math.Ceiling(tempFine2 / data.Step) * data.Step, 1);
                                }
					        }
						    var currentFine =
								Math.Abs(Math.Round(
                                    currentMassiv[i] + currentMassiv[j] + 2 * data.Step - choiceMinOneBedroomApartment - data.Entryway - 3 * data.Step -
                                    newSortedListOneBedroomApartment[h] + currentExtraSquare, 1));
							if (currentFine < fine)
							{
								fine = currentFine;
                                finalPlacementTwoBedroomApartment[n] = (currentMassiv[i]);
							    index1 = i;
                                finalPlacementTwoBedroomApartment[n + 1] = (currentMassiv[j]);
							    index2 = j;
								finalPlacementOneBedroomApartment[n+1] = (newSortedListOneBedroomApartment[h]);
							}
						}
					}
				}
				//удаление занятых вариантов из списка и суммирование штрафа
				totalFine= Math.Round(totalFine + fine,1);
                if(maxFine<fine)
                {
                    maxFine = fine;
                    newFirstOneBedroomApartment = finalPlacementOneBedroomApartment[n];
                }
			
				sortedAscListOneBedroomApartment.Remove(finalPlacementOneBedroomApartment[n]);
				sortedAscListOneBedroomApartment.Remove(finalPlacementOneBedroomApartment[n+1]);
			    if (index1 > index2)
			    {
			        sortedAscListTwoBedroomApartment.RemoveAt(index1);
			        sortedAscListTwoBedroomApartment.RemoveAt(index2);
			    }
			    else
			    {
                    sortedAscListTwoBedroomApartment.RemoveAt(index2);
                    sortedAscListTwoBedroomApartment.RemoveAt(index1);
			    }

			}
		    
			resultList.Add(totalFine);
			resultList.Add(finalPlacementOneBedroomApartment);
			resultList.Add(finalPlacementTwoBedroomApartment);
            resultList.Add(data.ListLengthOneBedroomApartment);
            resultList.Add(data.ListLengthTwoBedroomApartment);
            resultList.Add(newFirstOneBedroomApartment);
			return resultList;
		}
	}
}