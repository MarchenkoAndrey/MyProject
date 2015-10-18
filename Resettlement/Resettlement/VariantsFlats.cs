using System.Collections.Generic;

namespace Resettlement
{
	static class VariantsFlats
	{
		public static List<double[]> VariantsFlat(List<double[]> listFlat, List<int[]> permListFlat, List<double> newLengthFlat)
		{
			foreach (var i in permListFlat)
			{
				var currentList = new List<double>();
				for (var s = 0; s < i.Length; ++s)
				{
					currentList.Add(newLengthFlat[i[s]-1]);
				}
				listFlat.Add(currentList.ToArray());
			}
			return listFlat;
		}
	}
}
