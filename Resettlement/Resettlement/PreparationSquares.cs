using System;
using System.Collections.Generic;

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
			const double delta = 0.3;
			var lengthApartmentsWithAdditive = new List<double>();
			foreach (var i in squareOfAppartments)
			{		
				lengthApartmentsWithAdditive.Add(Math.Round(Math.Ceiling(i/delta)*delta,1));
//				lengthApartmentsWithAdditive.Add(Math.Ceiling(i/delta)*delta);
			}
			return lengthApartmentsWithAdditive;
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
