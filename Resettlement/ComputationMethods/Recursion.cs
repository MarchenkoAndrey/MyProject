using System.Collections.Generic;
using System.Linq;

namespace ComputationMethods
{
	public static class Resursion
	{
        public static IEnumerable<int[]> Data(int n, int optN, bool isPermutationForOneBedroom)
		{
			var result = new List<int[]>();
		    var countExcessNumber=0;
		    if (n > optN)
		    {
		        countExcessNumber = n - optN;
		        n = optN;
		    }

		    if (n%2 != 0)
		    {
		        countExcessNumber = 1;
		        n--;
                isPermutationForOneBedroom = true;
		    }


            Do(n, n, new bool[n], new int[n], result, isPermutationForOneBedroom);
		    if (countExcessNumber==1)
		    {
                result.AddRange(CreatePermWithExcessParam.MethodeCreatePermWithOddParam(result, n));
		    }
		    if (countExcessNumber == 2)
		    {
                result.AddRange(CreatePermWithExcessParam.MethodeCreatePermWithTwoExcessParam(result,n));
		    }
		    return result;
		}

        private static void Do(int n, int k, bool[] used, int[] current, List<int[]> result, bool isPermutationForOneBedroom)
		{
			if (k == 0)
			{
                if (!isPermutationForOneBedroom)
				{
					var res = PermutationWithoutRepetition.Data(current.Length/2);
					foreach (int[] i in res)
					{
						result.Add(BuildingPermutationPairs.PairPerm(i, current).ToArray()); //permutation for TwoBedroom Apartments
					}
				}
				else
				{
					result.Add(current.ToArray());
				}
				return;
			}
			int s;
			for (s = n; s > 0; --s) //ищем неиспользованное число 
				if (!used[s - 1])
					break;
			current[k - 1] = s; // Заполняем с конца [индекс в массиве - 1]
			used[s - 1] = true; // обозначили, что записали (повторно не возьмем)
			for (int t = s - 1; t > 0; --t) // второй цикл для составления пары к числу s, начиная с s-1
			{
				if (used[t - 1]) // если занята, то ищем дальше свободную
					continue;
				current[k - 2] = t; // записываем на предпоследнее возможное место t
				used[t - 1] = true; // показали что заняли (повторно не возьмем)
                Do(n, k - 2, used, current, result, isPermutationForOneBedroom); //вызвали рекурсию, уменьшив на 2 элемента массив
				used[t - 1] = false; // освободили парное число
			}
			used[s - 1] = false; // освободили первичное число
		}
	}
}

