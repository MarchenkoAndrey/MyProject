using System;
using System.Collections.Generic;

namespace Resettlement
{
    static class CreatePermWithOddParam
    {
        public static List<int[]> MethodeCreatePermWithOddParam(List<int[]> result, int n)
        {
            var newResultList = new List<int[]>();
            var totCountRow = result.Count;
            var addNewNumberInPerm = n + 1;
            for (var countElemInRow = 1; countElemInRow <= n; ++countElemInRow)
            {
                for (var numberRow = 0; numberRow < totCountRow; ++numberRow)
                {
                    int[] currentMassiv; 
                    Array.Copy(result[0], currentMassiv = new int[result[0].Length], result[0].Length);
                    currentMassiv[Array.IndexOf(currentMassiv, countElemInRow)] = addNewNumberInPerm;
                    newResultList.Add(currentMassiv);   
                }
            }
            return newResultList;
        }
    }
}
