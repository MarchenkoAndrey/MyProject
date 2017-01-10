using System;
using System.Collections.Generic;
using System.Linq;
using ComputationMethods;
using ComputationMethods.GeneralData;

namespace Resettlement
{
	public static class MethodeFullSearch
	{
        public static ResultDataAfterGrouping FullSearch(DataPerformAlgorithm data, int optCountFlat)
		{
            var result = new ResultDataAfterGrouping();
		    const bool isPermutationForOneFlat = true;
            const bool isPermutationForTwoFlat = true;
            var permListOneFlat = Resursion.Data(data.ListLenOneFlat.Count, optCountFlat, isPermutationForOneFlat); //gereration permutations
            var permListTwoFlat = Resursion.Data(data.ListLenTwoFlat.Count, optCountFlat, isPermutationForTwoFlat); //gereration permutations
            var permutDataOneFlat = VariantsFlats.VariantsFlat(permListOneFlat, data.ListLenOneFlat);
            var permutDataTwoFlat = VariantsFlats.VariantsFlat(permListTwoFlat, data.ListLenTwoFlat);
			var totalOptimalExceedSquare = double.MaxValue;

            var countI = -1;
		    foreach (var i in permutDataOneFlat.ListVariantsFlat)
			{
                var countJ = -1;
                countI++;
				foreach (var j in permutDataTwoFlat.ListVariantsFlat)
				{
                    countJ++;
                    var constraintAparture = ConstraintLengthApartureForCs.LengthAparture(i, j, Constraints.DefaultH, Constraints.EntrywayLength);

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
				    result.Fine = totalOptimalExceedSquare;
				    result.ListResultOneFlat = i.ToList();
                    result.ListResultTwoFlat = temporalArrayTwoBedroomApartment.ToList();
                    result.ListExcessOneFlat = permutDataOneFlat.ListExceedFlat[countI].ToList();
                    result.ListExcessTwoFlat = permutDataTwoFlat.ListExceedFlat[countJ].ToList();
				}
			}
            return result;
		}
	}
}