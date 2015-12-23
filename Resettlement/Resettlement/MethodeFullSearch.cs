using System;
using System.Collections.Generic;
using System.Linq;

namespace Resettlement
{
	static class MethodeFullSearch
	{
		public static List<object> FullSearch(List<double> newLengthOneFlat, List<double> newLengthTwoFlat,double step, double entryway, int countFloor)
		{
			var resultList = new List<object>();
            var totalNumberOptimalLocationFlat = Math.Min(newLengthOneFlat.Count / 2 * 2, newLengthTwoFlat.Count / 2 * 2);

			var optimalLocationOneFlat = new double[totalNumberOptimalLocationFlat];
			var optimalLocationTwoFlat = new double[totalNumberOptimalLocationFlat];

			var permListOneFlat = Resursion.Data(newLengthOneFlat.Count,totalNumberOptimalLocationFlat,true); //gereration permutations for Oneflat
			var permListTwoFlat = Resursion.Data(newLengthTwoFlat.Count,totalNumberOptimalLocationFlat, false); //gereration permutations for Twoflat
			 
			var listOneFlats = new List<double[]>();
			listOneFlats = VariantsFlats.VariantsFlat(listOneFlats, permListOneFlat, newLengthOneFlat);
			var listTwoFlats = new List<double[]>();
			listTwoFlats = VariantsFlats.VariantsFlat(listTwoFlats, permListTwoFlat, newLengthTwoFlat);

		    var totalArrangeSecondFloorResult = new List<object>();

			var minExtraSquare = 10000.0;
		    double totFineOfFloor = 0; 
		    const double restrictionOnDoor = 1.25;

		    foreach (var i in listOneFlats)
			{
				foreach (var j in listTwoFlats)
				{
                    //копировать массив j
                    double[] currentMassiv;
                    Array.Copy(j, currentMassiv = new double[j.Length], j.Length);

					var currentExtraSquare = 0.0;
               
					var squareSectionsTwoFlats = new List<double>();
                    var squareSectionsOneFlats = new List<double>();

                    //двигаем стены из-за 1.25
				    for (var k = 0; k < j.Length; k = k + 2)
					{
                        if (currentMassiv[k] - i[k] < restrictionOnDoor)
					    {
                            var a1 = restrictionOnDoor - (currentMassiv[k] - i[k]);
					        if (a1 < step)
					        {  
                                currentMassiv[k] = Math.Round(currentMassiv[k] + step, 1);
                                currentExtraSquare = Math.Round(currentExtraSquare + step, 1);
					        }
					        else
					        {
                                currentMassiv[k] += Math.Round(Math.Ceiling(a1 / step) * step, 1);
                                currentExtraSquare += Math.Round(Math.Ceiling(a1 / step) * step, 1);
					        }
					    }
                        if (currentMassiv[k + 1] - i[k + 1] < restrictionOnDoor)
					    {
                            var a2 = restrictionOnDoor - (currentMassiv[k + 1] - i[k + 1]);
					        if (a2 < step)
                            {
                                currentMassiv[k + 1] = Math.Round(currentMassiv[k+1] + step,1);
                                currentExtraSquare = Math.Round(currentExtraSquare + step,1);
                            }
                            else
                            {
                                currentMassiv[k + 1] += Math.Round(Math.Ceiling(a2 / step) * step, 1);
                                currentExtraSquare += Math.Round(Math.Ceiling(a2 / step) * step, 1);
                            }
					    }
					    squareSectionsOneFlats.Add(Math.Round(i[k] + i[k + 1] + entryway + 3 * step, 1));
                        squareSectionsTwoFlats.Add(Math.Round(currentMassiv[k] + currentMassiv[k + 1] + 2 * step, 1));       // delta1 + delta2
					}

				    for (var s = 0; s < squareSectionsOneFlats.Count; ++s)
					{
						var h = squareSectionsTwoFlats[s] - squareSectionsOneFlats[s];
							currentExtraSquare = Math.Round(currentExtraSquare + Math.Abs(h),1);
					}


                    //todo сразу делать второй этаж и считать общий штраф
				    
				    if (countFloor == 2)
				    {
				        var currentArrangeSecondFloorResult = CreateSecondFloor.MethodeCreateSecondFloor(i, currentMassiv, entryway, step);
				        var fineOfFloor = (double) currentArrangeSecondFloorResult[4];

				        if (currentExtraSquare + fineOfFloor < minExtraSquare)
				        {
				            minExtraSquare = Math.Round(currentExtraSquare, 1);
				            totalArrangeSecondFloorResult = currentArrangeSecondFloorResult;
				        }
				    }
				    else
				    {
				        //TODO При подсчете второго этажа двигать стены

				        if (currentExtraSquare < minExtraSquare)
				        {
				            minExtraSquare = Math.Round(currentExtraSquare, 1);
				            optimalLocationOneFlat = i;
				            optimalLocationTwoFlat = currentMassiv;
				        }
				    }
				}
			}
		    if (countFloor == 2)
		    {
                resultList.Add(minExtraSquare);
                resultList.AddRange(totalArrangeSecondFloorResult);
		        return resultList;
		    }

		    resultList.Add(minExtraSquare);
			resultList.Add(optimalLocationOneFlat.ToArray());
			resultList.Add(optimalLocationTwoFlat.ToArray());
			return resultList;
		}
	}
}
