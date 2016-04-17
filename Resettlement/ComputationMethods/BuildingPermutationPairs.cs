using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputationMethods
{
    static class BuildingPermutationPairs
    {
        public static List<int> PairPerm(int[] r, int[] current)
        {
            var result = new List<int>();
            foreach (var index in r)
            {
                result.Add(current[(index - 1) * 2]);
                result.Add(current[(index - 1) * 2 + 1]);
            }
            return result;
        }
    }
}
