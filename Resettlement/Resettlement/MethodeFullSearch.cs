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
				    var constraintAparture = ConstraintLengthApartureForComprehensiveSearch.LengthAparture(i,j, step,entryway);

				    var listSquareSectionsOneBedroomApartment = (List<double>)constraintAparture[0];
                    var listSquareSectionsTwoBedroomApartment = (List<double>)constraintAparture[1];
				    var currentFineFirstFloor = (double) constraintAparture[2];
				    var temporalArrayTwoBedroomApartment = (double[]) constraintAparture[3];

//                    for (var s = 0; s < listSquareSectionsOneBedroomApartment.Count; ++s)
//                    {
//                        var h = listSquareSectionsTwoBedroomApartment[s] - listSquareSectionsOneBedroomApartment[s];
//                        currentFineFirstFloor = Math.Round(currentFineFirstFloor + Math.Abs(h), 1);
//                    }
				    currentFineFirstFloor = listSquareSectionsOneBedroomApartment.Select((t, s) => listSquareSectionsTwoBedroomApartment[s] - t).Aggregate(currentFineFirstFloor, (current, h) => Math.Round(current + Math.Abs(h), 1));

				    if (!(currentFineFirstFloor < totalOptimalExceedSquare)) continue;
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

		    resultList.Add(totalOptimalExceedSquare);
			resultList.Add(optimalLocationOneBedroomApartments.ToArray());
			resultList.Add(optimalLocationTwoBedroomApartments.ToArray());
            resultList.Add(totalListExceedDataOneBedroomApartment);
            resultList.Add(totalListExceedDataTwoBedroomApartment);

			return resultList;
		}
	}
}