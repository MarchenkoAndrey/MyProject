using System;
using System.Collections.Generic;
using System.Linq;
using ComputationMethods;

namespace Resettlement
{
	public static class MethodeFullSearch
	{
        public static ResultDataAfterGrouping FullSearch(InputDataAlg data)
		{
            var result = new ResultDataAfterGrouping();
		    const bool isPermutationForOneBedroom = true;
            const bool isPermutationForTwoBedroom = true;
            var permListOneBedroomApartment = Resursion.Data(data.ListLenOneFlat.Count, data.OptCountFlat, isPermutationForOneBedroom); //gereration permutations
            var permListTwoBedroomApartment = Resursion.Data(data.ListLenTwoFlat.Count, data.OptCountFlat, isPermutationForTwoBedroom); //gereration permutations

            List<double[]> listVariantsOneBedroomApartment;
            List<double[]> listExceedDataOneBedroomApartment;
            List<double[]> listVariantsTwoBedroomApartment;
            List<double[]> listExcessDataTwoBedroomApartment;
            VariantsFlats.VariantsFlat(out listVariantsOneBedroomApartment, out listExceedDataOneBedroomApartment, permListOneBedroomApartment, data.ListLenOneFlat);
            VariantsFlats.VariantsFlat(out listVariantsTwoBedroomApartment, out listExcessDataTwoBedroomApartment, permListTwoBedroomApartment, data.ListLenTwoFlat);
			var totalOptimalExceedSquare = 10000.0;

            var countI = -1;
		    foreach (var i in listVariantsOneBedroomApartment)
			{
                var countJ = -1;
                countI++;
				foreach (var j in listVariantsTwoBedroomApartment)
				{
                    countJ++;
                    var constraintAparture = ConstraintLengthApartureForCS.LengthAparture(i, j, data.Step, data.Entryway);

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
				    result.ListResultOneFlat = i.ToList();
                    result.ListResultTwoFlat = temporalArrayTwoBedroomApartment.ToList();
				    if (listExceedDataOneBedroomApartment.Count > 0)
				    {
				        result.ListExcessOneFlat = listExceedDataOneBedroomApartment[countI].ToList();
				    }
				    if (listExcessDataTwoBedroomApartment.Count > 0)
				    {
                        result.listExcessTwoFlat = listExcessDataTwoBedroomApartment[countJ].ToList();
				    }
				}
			}
            return result;
		}
	}
}