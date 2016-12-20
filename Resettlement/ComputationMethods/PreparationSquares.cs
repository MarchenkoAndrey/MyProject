using System;
using System.Collections.Generic;
using System.Linq;
using ComputationMethods.GeneralData;

namespace ComputationMethods
{
    public static class PreparationSquares
	{
		public static List<double> CalculateLengthOfFlat(IEnumerable<double> squareOfApartments, double widthOfApartment)
		{
		    return squareOfApartments.Select(i => Math.Round(i/widthOfApartment, 3)).ToList();
		}

        public static List<double> FlatsWithTheAdditiveLength(IEnumerable<double> squareOfAppartments)
		{
            return squareOfAppartments.Select(i => Math.Round(Math.Ceiling(i / Constraints.DefaultH) * Constraints.DefaultH, 1)).ToList();
		}

		public static double DeltaSquaresOfFlats(List<double> lengthOfApartments, List<double> lengthApartmentsWithAdditive)
		{
			var additive = 0.0;
			for (var i = 0; i < lengthOfApartments.Count; ++i)
			{
				additive = additive + Math.Round(lengthApartmentsWithAdditive[i] - lengthOfApartments[i],3);
			}
			return additive;
		}
	}
}