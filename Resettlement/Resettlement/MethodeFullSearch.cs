using System;
using System.Collections.Generic;
using System.Linq;
using Resettlement.GeneralData;

namespace Resettlement
{
	public static class MethodeFullSearch
	{
		public static List<object> FullSearch(List<double> listLengthsOneBedroomApartment, List<double> listLengthsTwoBedroomApartment,double step, double entryway, int countFloor)
		{
			var resultList = new List<object>();
            var totalListExceedDataOneBedroomApartment = new List<double>();
            var totalListExceedDataTwoBedroomApartment = new List<double>();
		    var numberOptimalLocationApartments = OptimalNumberApartments.CalculateOptimalNumberApartments(listLengthsOneBedroomApartment,
		        listLengthsTwoBedroomApartment, 2);

			var optimalLocationOneBedroomApartments = new double[numberOptimalLocationApartments];
			var optimalLocationTwoBedroomApartments = new double[numberOptimalLocationApartments];

		    const bool flagFirstFloor = false;
            var permListOneFlat = Resursion.Data(listLengthsOneBedroomApartment.Count, numberOptimalLocationApartments, true, flagFirstFloor); //gereration permutations
            var permListTwoFlat = Resursion.Data(listLengthsTwoBedroomApartment.Count, numberOptimalLocationApartments, false, flagFirstFloor); //gereration permutations

            List<double[]> listVariantsOneBedroomApartment;
            List<double[]> listExceedDataOneBedroomApartment;
            List<double[]> listVariantsTwoBedroomApartment;
            List<double[]> listExcessDataTwoBedroomApartment;
            VariantsFlats.VariantsFlat(out listVariantsOneBedroomApartment, out listExceedDataOneBedroomApartment, permListOneFlat, listLengthsOneBedroomApartment);
            VariantsFlats.VariantsFlat(out listVariantsTwoBedroomApartment, out listExcessDataTwoBedroomApartment, permListTwoFlat, listLengthsTwoBedroomApartment);
			var totalOptimalExceedSquare = 10000.0;

            var countI = -1;
		    foreach (var i in listVariantsOneBedroomApartment)
			{
                var countJ = -1;
                countI++;
				foreach (var j in listVariantsTwoBedroomApartment)
				{
                    countJ++;
                    //копировать массив j
                    double[] temporalArrayTwoBedroomApartment;
                    Array.Copy(j, temporalArrayTwoBedroomApartment = new double[j.Length], j.Length);

					var currentFineFirstFloor = 0.0;
                    var listSquareSectionsTwoBedroomApartment = new List<double>();
                    var listSquareSectionsOneBedroomApartment = new List<double>();

                    //двигаем стены из-за ApartureLength
				    for (var k = 0; k < j.Length; k = k + 2)
					{
                        if (temporalArrayTwoBedroomApartment[k] - i[k] < Constraints.ApartureLength)
					    {
                            var leftAddition = Constraints.ApartureLength - (temporalArrayTwoBedroomApartment[k] - i[k]);
					        if (leftAddition < step)
					        {  
                                temporalArrayTwoBedroomApartment[k] = Math.Round(temporalArrayTwoBedroomApartment[k] + step, 1);
                                currentFineFirstFloor = Math.Round(currentFineFirstFloor + step, 1);
					        }
					        else
					        {
                                temporalArrayTwoBedroomApartment[k] += Math.Round(Math.Ceiling(leftAddition / step) * step, 1);
                                currentFineFirstFloor += Math.Round(Math.Ceiling(leftAddition / step) * step, 1);
					        }
					    }
                        if (temporalArrayTwoBedroomApartment[k + 1] - i[k + 1] < Constraints.ApartureLength)
					    {
                            var rightAddition = Constraints.ApartureLength - (temporalArrayTwoBedroomApartment[k + 1] - i[k + 1]);
					        if (rightAddition < step)
                            {
                                temporalArrayTwoBedroomApartment[k + 1] = Math.Round(temporalArrayTwoBedroomApartment[k+1] + step,1);
                                currentFineFirstFloor = Math.Round(currentFineFirstFloor + step,1);
                            }
                            else
                            {
                                temporalArrayTwoBedroomApartment[k + 1] += Math.Round(Math.Ceiling(rightAddition / step) * step, 1);
                                currentFineFirstFloor += Math.Round(Math.Ceiling(rightAddition / step) * step, 1);
                            }
					    }
					    listSquareSectionsOneBedroomApartment.Add(Math.Round(i[k] + i[k + 1] + entryway + 3 * step, 1));
                        listSquareSectionsTwoBedroomApartment.Add(Math.Round(temporalArrayTwoBedroomApartment[k] + temporalArrayTwoBedroomApartment[k + 1] + 2 * step, 1));       // delta1 + delta2
					}

				    for (var s = 0; s < listSquareSectionsOneBedroomApartment.Count; ++s)
					{
						var h = listSquareSectionsTwoBedroomApartment[s] - listSquareSectionsOneBedroomApartment[s];
							currentFineFirstFloor = Math.Round(currentFineFirstFloor + Math.Abs(h),1);
					}
				   
				    if (currentFineFirstFloor < totalOptimalExceedSquare)
				    {
				        totalOptimalExceedSquare = Math.Round(currentFineFirstFloor, 1);
				        optimalLocationOneBedroomApartments = i;
				        optimalLocationTwoBedroomApartments = temporalArrayTwoBedroomApartment;
                        if (listExceedDataOneBedroomApartment.Count > 0)
                        {
                            totalListExceedDataOneBedroomApartment = listExceedDataOneBedroomApartment[countI].ToList();
                        }
                        if (listExcessDataTwoBedroomApartment.Count > 0)
                        {
                            totalListExceedDataTwoBedroomApartment = listExcessDataTwoBedroomApartment[countJ].ToList();
                        }
				    }
				}
			}

		    resultList.Add(totalOptimalExceedSquare);
			resultList.Add(optimalLocationOneBedroomApartments.ToArray());
			resultList.Add(optimalLocationTwoBedroomApartments.ToArray());
            resultList.Add(totalListExceedDataOneBedroomApartment);
            resultList.Add(totalListExceedDataTwoBedroomApartment);

			return resultList;
		}
	}
}