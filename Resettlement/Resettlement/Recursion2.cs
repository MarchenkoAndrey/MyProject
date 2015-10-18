using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Resettlement
{
	static class Resursion2
	{
		public static List<int[]> Data(int n)
		{
			var result = new List<int[]>();
			Do(n, n, new bool[n], new int[n], result);
//			foreach (var list in result)
//			{
//				foreach (var x in list)
//					Console.Write(string.Format("{0} ", x));
//				Console.WriteLine();
//			}
			var l = result.Count;
			Console.WriteLine(l);
			return result;
		}

		private static void Do(int n, int k, bool[] used, int[] current, List<int[]> result)
		{
			if (k == 0)
			{
				var r = Recursion3.Data(current);
				result.Add(current.ToArray());
				return;
			}
			int s;
			for (s = n; s > 0; --s)
			{
				if (!used[s - 1])
					break;
			}
			current[k - 1] = s;
			used[s - 1] = true;
			for (int t = s - 1; t > 0; --t)
			{
				if (used[t - 1])
					continue;
				current[k - 2] = t;
				used[t - 1] = true;
				Do(n, k - 2, used, current, result);
				used[t - 1] = false;
			}
			used[s - 1] = false;
		}
	}
}
