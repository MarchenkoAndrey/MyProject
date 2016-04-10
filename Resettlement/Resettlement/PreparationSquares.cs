using System;
using System.Collections.Generic;
using System.Linq;
using Resettlement.GeneralData;

namespace Resettlement
{
	static class PreparationSquares
	{
		public static List<double> CalculateLengthOfFlat(IEnumerable<double> squareOfApartments, double widthOfApartment)
		{
			var lengthOfApartments = new List<double>();
			foreach (var i in squareOfApartments)
			{
				lengthOfApartments.Add(Math.Round(i/widthOfApartment, 3));
			}
			return lengthOfApartments;
		}
		public static List<double> FlatsWithTheAdditiveLength(IEnumerable<double> squareOfAppartments)
		{
            return squareOfAppartments.Select(i => Math.Round(Math.Ceiling(i / Constraints.DefaultH) * Constraints.DefaultH, 1)).ToList();
		}
        public static List<double> FlatsRestartList(IEnumerable<double> squareOfAppartments)
        {
            return squareOfAppartments.ToList();
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
