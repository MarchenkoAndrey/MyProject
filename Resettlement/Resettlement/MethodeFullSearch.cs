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
                    var resultApartLen = CreatePlacementForCompSearch.CreatePlacement(i, j, Constraints.StepH);

				    if (!(resultApartLen.FineAfterGrouping < totalOptimalExceedSquare)) continue;
				    totalOptimalExceedSquare = Math.Round(resultApartLen.FineAfterGrouping, 1);
                    result.Fine = resultApartLen.FineAfterGrouping;
                    result.ListResultOneFlat = resultApartLen.ListLenOneFlat;
                    result.ListResultTwoFlat = resultApartLen.ListLenTwoFlat;
                    result.ListExcessOneFlat = permutDataOneFlat.ListExceedFlat[countI].ToList();
                    result.ListExcessTwoFlat = permutDataTwoFlat.ListExceedFlat[countJ].ToList();
				}
			}
            return result;
		}
	}
}