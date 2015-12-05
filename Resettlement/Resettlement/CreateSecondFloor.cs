using System;
using System.Collections.Generic;

namespace Resettlement
{
    static class CreateSecondFloor
    {
        public static List<double[]> MethodeCreateSecondFloor(object optArrangeOne, object optArrangeTwo, double entryway, double step)
        {
            var optArrangeOneArray = (double[]) optArrangeOne;
            var optArrangeTwoArray = (double[]) optArrangeTwo;
            var result = new List<double[]>();
			var listSquareOneFlat = new List<double>();
            var listSquareTwoFlat = new List<double>();
			for (var i = 0; i < optArrangeOneArray.Length; i=i+2)
			{
				listSquareOneFlat.Add(Math.Round(optArrangeOneArray[i] + optArrangeOneArray[i + 1] + entryway + 3*step,1));
			}
            for (var j = 0; j < optArrangeTwoArray.Length; j=j+2)
            {
                listSquareTwoFlat.Add(Math.Round(optArrangeTwoArray[j] + optArrangeTwoArray[j + 1] + 2*step, 1));
            }

            var listFineSection = new List<double>();
            for (var s = 0; s < listSquareOneFlat.Count; ++s)
            {
              listFineSection.Add(Math.Abs(listSquareTwoFlat[s] - listSquareOneFlat[s])); 
            }
            var permutationVariants = Resursion.Data(listFineSection.Count, listFineSection.Count, true);

            for (var i = 0; i < permutationVariants.Count; ++i)
            {
                for (var j = 0; j < permutationVariants[0].Length; ++j)
                {
                    permutationVariants[i][j]--;
                }
            }

            var totalFineSection = 1000.0;
            var optimalVariant = 0;
            for (var numberRowVariant = 0; numberRowVariant < permutationVariants.Count; ++numberRowVariant)
            {
                int[] currentMassiv;
                var currentFineSection = 0.0;
                Array.Copy(permutationVariants[numberRowVariant], currentMassiv = new int[permutationVariants[numberRowVariant].Length], permutationVariants[numberRowVariant].Length);

                for (var i = 0; i < currentMassiv.Length; i = i + 2)
                {
                    double f;
                    if (listFineSection[currentMassiv[i]] > listFineSection[currentMassiv[i + 1]])
                    {
                        f = Math.Round(listFineSection[currentMassiv[i]] - listFineSection[currentMassiv[i + 1]],1);
                    }
                    else
                    {
                        f = Math.Round(listFineSection[currentMassiv[i + 1]] - listFineSection[currentMassiv[i]],1);
                    }
                    currentFineSection += f;

                }
                if (currentFineSection < totalFineSection)
                {
                    optimalVariant = numberRowVariant;
                    totalFineSection = currentFineSection;
                }
            }

            //Todo Прописать итоговый вариант расстановки
            var optimalPermutation = permutationVariants[optimalVariant];
            var optVarOneflatOneFloor = new double[optimalPermutation.Length];
            var optVarTwoflatOneFloor = new double[optimalPermutation.Length];
            var optVarOneflatTwoFloor = new double[optimalPermutation.Length];
            var optVarTwoflatTwoFloor = new double[optimalPermutation.Length];

            //первый этаж
            for (var i = 0; i < optimalPermutation.Length; i=i+2)
            {
                optVarOneflatOneFloor[i] = (optArrangeOneArray[optimalPermutation[i]*2]);
                optVarOneflatOneFloor[i + 1] = (optArrangeOneArray[optimalPermutation[i]*2 + 1]);
            }
            for (var j = 0; j < optimalPermutation.Length; j=j+2)
            {
                optVarTwoflatOneFloor[j] = (optArrangeTwoArray[optimalPermutation[j]*2]);
                optVarTwoflatOneFloor[j + 1] = (optArrangeTwoArray[optimalPermutation[j]*2 + 1]);
            }
            result.Add(optVarOneflatOneFloor);
            result.Add(optVarTwoflatOneFloor);

            //второй этаж
            for (var i = 1; i < optimalPermutation.Length; i = i + 2)
            {
                optVarOneflatTwoFloor[i-1] = (optArrangeOneArray[optimalPermutation[i] * 2]);
                optVarOneflatTwoFloor[i] = (optArrangeOneArray[optimalPermutation[i] * 2 + 1]);
            }
            for (var j = 1; j < optimalPermutation.Length; j = j + 2)
            {
                optVarTwoflatTwoFloor[j-1] = (optArrangeTwoArray[optimalPermutation[j] * 2]);
                optVarTwoflatTwoFloor[j] = (optArrangeTwoArray[optimalPermutation[j] * 2 + 1]);
            }
            result.Add(optVarOneflatTwoFloor);
            result.Add(optVarTwoflatTwoFloor);

            return result;
        }
    }
}