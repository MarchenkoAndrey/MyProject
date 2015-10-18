using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace Resettlement
{
	static class Recursion3
	{
		public static List<int[]> Data(int[] current)
		{
			var result = new List<int[]>();
			var n = current.Length;
			Do(current,0,n,result);

			return result;
		}

//		private static void Do(int[] current, int a, int n, List<int[]> result)
//		{
//			if (a == n)
//			{
//				result.Add(current.ToArray());
//				return;
//			}
//			for (int i = a; i < n; ++i)
//			{
//				exchange(current,a,i);
//				Do(current,a+1,n,result);
//				exchange(current,a,i);
//			}
//		}
//
//		public static void exchange(int[] m, int n, int k)
//		{
//			int c= m[n];
//			m[n] = m[k];
//			m[k] = c;
//		}
		private static void Do(int[] current, int a, int n, List<int[]> result)
		{
			if (a == n)
			{
				result.Add(current.ToArray());
				return;
			}
			for (int i = a; i < n; i = i + 1)
			{
				Exchange(current, a, i);
				Do(current, a + 1, n, result);
				Exchange(current, a, i);
			}
		}

		private static void Exchange(int[] m, int n, int k)
		{
			int c = m[n];
			m[n] = m[k];
			m[k] = c;
		}
	}
}
