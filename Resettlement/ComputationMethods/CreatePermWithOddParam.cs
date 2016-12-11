using System;
using System.Collections.Generic;

namespace ComputationMethods
{
    static class CreatePermWithExcessParam
    {
        public static IEnumerable<int[]> MethodeCreatePermWithOddParam(List<int[]> result, int n)
        {
            var newResultList = new List<int[]>();
            var totCountRow = result.Count;
            var addNewNumberInPerm = n + 1;
            for (var countElemInRow = 1; countElemInRow <= n; ++countElemInRow)
            {
                for (var numberRow = 0; numberRow < totCountRow; ++numberRow)
                {
                    int[] currentMassiv;
                    Array.Copy(result[numberRow], currentMassiv = new int[result[numberRow].Length], result[numberRow].Length);
                    currentMassiv[Array.IndexOf(currentMassiv, countElemInRow)] = addNewNumberInPerm;
                    newResultList.Add(currentMassiv);   
                }
            }
            return newResultList;
        }

        public static IEnumerable<int[]> MethodeCreatePermWithTwoExcessParam(List<int[]> result, int n)
        {
            var a1 = n + 1;
            var a2 = n + 2;
            var newResultList = new List<int[]>();
            var totCountRow = result.Count;

            //Перестановки с заменой одной цифры на новые
            for (var elemInRow = 1; elemInRow <= n; ++elemInRow)
            {
                for (var numberRow = 0; numberRow < totCountRow; ++numberRow)
                {
                    int[] currentMassiv;
                    Array.Copy(result[numberRow], currentMassiv = new int[result[numberRow].Length], result[numberRow].Length);
                    currentMassiv[Array.IndexOf(currentMassiv, elemInRow)] = a1;
                    newResultList.Add(currentMassiv);

                    Array.Copy(result[numberRow], currentMassiv = new int[result[numberRow].Length], result[numberRow].Length);
                    currentMassiv[Array.IndexOf(currentMassiv, elemInRow)] = a2;
                    newResultList.Add(currentMassiv);
                }
            }
            // Перестановки комбинаций двух новых цифр
            for (var elemInRow = 1; elemInRow < n; ++elemInRow)
            {
                for (var elemInRowNext = elemInRow + 1; elemInRowNext <= n; ++elemInRowNext)
                {
                    for (var numberRow = 0; numberRow < totCountRow; ++numberRow)
                    {
                        int[] currentMassiv;
                        Array.Copy(result[numberRow], currentMassiv = new int[result[numberRow].Length], result[numberRow].Length);
                        currentMassiv[Array.IndexOf(currentMassiv, elemInRow)] = a1;
                        currentMassiv[Array.IndexOf(currentMassiv, elemInRowNext)] = a2;
                        newResultList.Add(currentMassiv);
                    }
                }
            }
            return newResultList;
        }
    }
}