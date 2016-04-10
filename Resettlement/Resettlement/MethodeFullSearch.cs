﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Resettlement
{
	public static class MethodeFullSearch
	{
		public static List<object> FullSearch(List<double> listLengthOneFlat, List<double> listLengthTwoFlat,double step, double entryway, int countFloor)
		{
			var resultList = new List<object>();
            var excessDataOneFlatTotal = new List<double>();
            var excessDataTwoFlatTotal = new List<double>();
            var optimalLocationFlatTotalNumber = Math.Min(listLengthOneFlat.Count / 2 * 2, listLengthTwoFlat.Count / 2 * 2);

			var optimalLocationOneFlat = new double[optimalLocationFlatTotalNumber];
			var optimalLocationTwoFlat = new double[optimalLocationFlatTotalNumber];

		    const bool flagOneFloor = false;
            var permListOneFlat = Resursion.Data(listLengthOneFlat.Count, optimalLocationFlatTotalNumber, true, flagOneFloor); //gereration permutations for Oneflat
            var permListTwoFlat = Resursion.Data(listLengthTwoFlat.Count, optimalLocationFlatTotalNumber, false, flagOneFloor); //gereration permutations for Twoflat

            var listVariantsOneFlat = new List<double[]>();
            var listExcessDataOneFlat = new List<double[]>();
            var listVariantsTwoFlat = new List<double[]>();
            var listExcessDataTwoFlat = new List<double[]>();
            VariantsFlats.VariantsFlat(out listVariantsOneFlat, out listExcessDataOneFlat, permListOneFlat, listLengthOneFlat);
            VariantsFlats.VariantsFlat(out listVariantsTwoFlat, out listExcessDataTwoFlat, permListTwoFlat, listLengthTwoFlat);
			var minTotalExtraSquare = 10000.0;
		    //const double restrictionOnDoor = 1.25;

            var countI = -1;
		    foreach (var i in listVariantsOneFlat)
			{
                var countJ = -1;
                countI++;
				foreach (var j in listVariantsTwoFlat)
				{
                    countJ++;
                    //копировать массив j
                    double[] tempArrayTwoFlat;
                    Array.Copy(j, tempArrayTwoFlat = new double[j.Length], j.Length);

					var currentFineOneFloor = 0.0;
                    var sectionsTwoFlatsSquare = new List<double>();
                    var sectionsOneFlatsSquare = new List<double>();

                    //двигаем стены из-за 1.25
				    for (var k = 0; k < j.Length; k = k + 2)
					{
                        if (tempArrayTwoFlat[k] - i[k] < Constraints.ApartureLength)
					    {
                            var leftAddition = Constraints.ApartureLength - (tempArrayTwoFlat[k] - i[k]);
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
                        if (tempArrayTwoFlat[k + 1] - i[k + 1] < Constraints.ApartureLength)
					    {
                            var rightAddition = Constraints.ApartureLength - (tempArrayTwoFlat[k + 1] - i[k + 1]);
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
				   
				    if (currentFineOneFloor < minTotalExtraSquare)
				    {
				        minTotalExtraSquare = Math.Round(currentFineOneFloor, 1);
				        optimalLocationOneFlat = i;
				        optimalLocationTwoFlat = tempArrayTwoFlat;
                        if (listExcessDataOneFlat.Count > 0)
                        {
                            excessDataOneFlatTotal = listExcessDataOneFlat[countI].ToList();
                        }
                        if (listExcessDataTwoFlat.Count > 0)
                        {
                            excessDataTwoFlatTotal = listExcessDataTwoFlat[countJ].ToList();
                        }
				    }
				}
			}

		    resultList.Add(minTotalExtraSquare);
			resultList.Add(optimalLocationOneFlat.ToArray());
			resultList.Add(optimalLocationTwoFlat.ToArray());
            resultList.Add(excessDataOneFlatTotal);
            resultList.Add(excessDataTwoFlatTotal);

			return resultList;
		}
	}
}