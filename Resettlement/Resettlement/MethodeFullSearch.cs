using System;
using System.Collections.Generic;
using System.Linq;

namespace Resettlement
{
	static class MethodeFullSearch
	{
		public static List<object> FullSearch(List<double> listLengthOneFlat, List<double> listLengthTwoFlat,double step, double entryway, int countFloor)
		{
			var resultList = new List<object>();
            var optimalLocationFlatTotalNumber = Math.Min(listLengthOneFlat.Count / 2 * 2, listLengthTwoFlat.Count / 2 * 2);

			var optimalLocationOneFlat = new double[optimalLocationFlatTotalNumber];
			var optimalLocationTwoFlat = new double[optimalLocationFlatTotalNumber];

			var permListOneFlat = Resursion.Data(listLengthOneFlat.Count,optimalLocationFlatTotalNumber,true); //gereration permutations for Oneflat
			var permListTwoFlat = Resursion.Data(listLengthTwoFlat.Count,optimalLocationFlatTotalNumber, false); //gereration permutations for Twoflat
			 
			var listVariantsOneFlat = new List<double[]>();
			listVariantsOneFlat = VariantsFlats.VariantsFlat(listVariantsOneFlat, permListOneFlat, listLengthOneFlat);
			var listVariantsTwoFlat = new List<double[]>();
			listVariantsTwoFlat = VariantsFlats.VariantsFlat(listVariantsTwoFlat, permListTwoFlat, listLengthTwoFlat);

		    var totalArrangementSecondFloorResult = new List<object>();

			var minTotalExtraSquare = 10000.0;
		    const double restrictionOnDoor = 1.25;

		    foreach (var i in listVariantsOneFlat)
			{
				foreach (var j in listVariantsTwoFlat)
				{
                    //копировать массив j
                    double[] tempArrayTwoFlat;
                    Array.Copy(j, tempArrayTwoFlat = new double[j.Length], j.Length);

					var currentFineOneFloor = 0.0;
                    var sectionsTwoFlatsSquare = new List<double>();
                    var sectionsOneFlatsSquare = new List<double>();

                    //двигаем стены из-за 1.25
				    for (var k = 0; k < j.Length; k = k + 2)
					{
                        if (tempArrayTwoFlat[k] - i[k] < restrictionOnDoor)
					    {
                            var leftAddition = restrictionOnDoor - (tempArrayTwoFlat[k] - i[k]);
					        if (leftAddition < step)
					        {  
                                tempArrayTwoFlat[k] = Math.Round(tempArrayTwoFlat[k] + step, 1);
                                currentFineOneFloor = Math.Round(currentFineOneFloor + step, 1);
					        }
					        else
					        {
                                tempArrayTwoFlat[k] += Math.Round(Math.Ceiling(leftAddition / step) * step, 1);
                                currentFineOneFloor += Math.Round(Math.Ceiling(leftAddition / step) * step, 1);
					        }
					    }
                        if (tempArrayTwoFlat[k + 1] - i[k + 1] < restrictionOnDoor)
					    {
                            var rightAddition = restrictionOnDoor - (tempArrayTwoFlat[k + 1] - i[k + 1]);
					        if (rightAddition < step)
                            {
                                tempArrayTwoFlat[k + 1] = Math.Round(tempArrayTwoFlat[k+1] + step,1);
                                currentFineOneFloor = Math.Round(currentFineOneFloor + step,1);
                            }
                            else
                            {
                                tempArrayTwoFlat[k + 1] += Math.Round(Math.Ceiling(rightAddition / step) * step, 1);
                                currentFineOneFloor += Math.Round(Math.Ceiling(rightAddition / step) * step, 1);
                            }
					    }
					    sectionsOneFlatsSquare.Add(Math.Round(i[k] + i[k + 1] + entryway + 3 * step, 1));
                        sectionsTwoFlatsSquare.Add(Math.Round(tempArrayTwoFlat[k] + tempArrayTwoFlat[k + 1] + 2 * step, 1));       // delta1 + delta2
					}

				    for (var s = 0; s < sectionsOneFlatsSquare.Count; ++s)
					{
						var h = sectionsTwoFlatsSquare[s] - sectionsOneFlatsSquare[s];
							currentFineOneFloor = Math.Round(currentFineOneFloor + Math.Abs(h),1);
					}

				    if (countFloor == 2)
				    {
				        var currentArrangementSecondFloorResult = CreateSecondFloor.MethodeCreateSecondFloor(i, tempArrayTwoFlat, entryway, step);
				        var fineOfFloors = Math.Round((double) currentArrangementSecondFloorResult[4],1);  // равные квартиры друг под другом, равная длина этажей

                        //Todo вывести итог первого этажа отдельно, итог второго этажа отдельно
				        if (currentFineOneFloor + fineOfFloors < minTotalExtraSquare)
				        {
				            minTotalExtraSquare = Math.Round(currentFineOneFloor + fineOfFloors, 1);
				            totalArrangementSecondFloorResult = currentArrangementSecondFloorResult;
				        }
				    }
				    else
				    {
				        if (currentFineOneFloor < minTotalExtraSquare)
				        {
				            minTotalExtraSquare = Math.Round(currentFineOneFloor, 1);
				            optimalLocationOneFlat = i;
				            optimalLocationTwoFlat = tempArrayTwoFlat;
				        }
				    }
				}
			}
		    if (countFloor == 2)
		    {
                resultList.Add(minTotalExtraSquare);
                resultList.AddRange(totalArrangementSecondFloorResult);
		        return resultList;
		    }

		    resultList.Add(minTotalExtraSquare);
			resultList.Add(optimalLocationOneFlat.ToArray());
			resultList.Add(optimalLocationTwoFlat.ToArray());
			return resultList;
		}
	}
}