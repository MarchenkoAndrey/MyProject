﻿using System.Collections.Generic;

namespace Resettlement
{
	static class BuildingPermutationPairs
	{
		public static List<int> PairPerm(int[] r, int[] current)
		{
			var result = new List<int>();
			for (int i=0;i<r.Length; i++)
			{
				result.Add(current[(r[i] - 1) * 2]);
				result.Add(current[(r[i] - 1) * 2+1]);
			}

			return result;
		}
	}
}
