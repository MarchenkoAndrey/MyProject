using System.Collections.Generic;
using System.Linq;

namespace Resettlement
{
	static class PermutationWithoutRepetition
	{
		public static List<int[]> Data(int n)
		{

			var result = new List<int[]>();
			var mas = new int[n];
			for (int i = n; i > 0; --i)
			{
				mas[i - 1] = i;
			}
			Do(mas,0,n,result);

			return result;
		}

		private static void Do(int[] current, int a, int n, List<int[]> result)
		{
			if (a == n)
			{
				result.Add(current.ToArray());
				return;
			}
			for (int i = a; i < n; ++i)
			{
				Exchange(current,a,i);
				Do(current,a+1,n,result);
				Exchange(current,a,i);
			}
		}

		private static void Exchange(int[] current, int n, int k)
		{
			int c= current[n];
			current[n] = current[k];
			current[k] = c;
		}
		
	}
}
