
using System.Collections.Generic;
using System.Linq;

namespace Resettlement
{
	static class Resursion
	{
		public static List<int[]> Data(int n,bool flag)
		{
			var result = new List<int[]>();
		    var used = false;
		    if (n%2 != 0)   //Если нечетное количество входных параметров
		    {
		        --n;
		        used = true;
		    }
		    Do(n, n, new bool[n], new int[n], result, flag);
		    if (used) //перестановка для нечетного числа
		    {
                result.AddRange(CreatePermWithOddParam.MethodeCreatePermWithOddParam(result, n));
		    }
		    return result;
		}

		private static void Do(int n, int k, bool[] used, int[] current, List<int[]> result,bool flag)
		{
			if (k == 0)
			{
				if (!flag)
				{
					var res = PermutationWithoutRepetition.Data(current.Length/2);
					foreach (int[] i in res)
					{
						result.Add(BuildingPermutationPairs.PairPerm(i, current).ToArray()); //perestanovka for TwoFlat
					}
				}
				else
				{
					result.Add(current.ToArray());
				}
				return;
			}
			int s;
			for (s = n; s > 0; --s)
				if (!used[s - 1])
					break;
			current[k - 1] = s;
			used[s - 1] = true;
			for (int t = s - 1; t > 0; --t)
			{
				if (used[t - 1])
					continue;
				current[k - 2] = t;
				used[t - 1] = true;
			    Do(n, k - 2, used, current, result,flag);
				used[t - 1] = false;
			}
			used[s - 1] = false;
		}
	}
}

