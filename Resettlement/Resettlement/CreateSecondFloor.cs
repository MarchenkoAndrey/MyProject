using System;
using System.Collections.Generic;
using ComputationMethods;

namespace Resettlement
{
    static class CreateSecondFloor
    {
        public static List<object> MethodeCreateSecondFloor(object optArrangeOne, object optArrangeTwo, double entryway, double step)
        {
            var optArrangeOneArray = (double[]) optArrangeOne;          //переделывание в массив
            var optArrangeTwoArray = (double[]) optArrangeTwo;
            var itogOptArrangeOneArray = new double[optArrangeOneArray.Length];
            var itogOptArrangeTwoArray = new double[optArrangeTwoArray.Length];
            var resultList = new List<object>();
			var listSquareOneFlat = new List<double>();
            var listSquareTwoFlat = new List<double>();

            const bool flagTwoFloor = true;
            var permutationVariants = Resursion.Data(optArrangeOneArray.Length/2, optArrangeTwoArray.Length/2, true);
            // для индекса вычитаем 1 из каждого элемента перестановки
            foreach (var t in permutationVariants)
            {
                for (var j = 0; j < permutationVariants[0].Length; ++j)
                {
                    t[j]--;
                }
            }

            var totalFineSecondFloor = 1000.0;
            var optimalVariant = 0;

            for (var i = 0; i < permutationVariants.Count; ++i)
            {
                var currentInnerFineSect = 0.0;
                double[] tempArrayArrangeOne;
                Array.Copy(optArrangeOneArray, tempArrayArrangeOne = new double[optArrangeOneArray.Length],
                    optArrangeOneArray.Length);

                double[] tempArrayArrangeTwo;
                Array.Copy(optArrangeTwoArray, tempArrayArrangeTwo = new double[optArrangeTwoArray.Length],
                    optArrangeTwoArray.Length);

                for (var h = 0; h < permutationVariants[i].Length; h = h + 2)
                {
                    double fine;
//                    var a = optArrangeOneArray[2*permutationVariants[i][h]]; //МАЯКИ ДЛЯ ПРОВЕРКИ
//                    var a1 = optArrangeOneArray[2*permutationVariants[i][h + 1]]; //МАЯКИ ДЛЯ ПРОВЕРКИ

                    //1-ые однокомнатные
                    if (optArrangeOneArray[2*permutationVariants[i][h]] >
                        optArrangeOneArray[2*permutationVariants[i][h + 1]])
                    {
                        fine =
                            Math.Round(optArrangeOneArray[2*permutationVariants[i][h]] -
                                       optArrangeOneArray[2*permutationVariants[i][h + 1]], 1);
                        tempArrayArrangeOne[2*permutationVariants[i][h + 1]] = tempArrayArrangeOne[2*permutationVariants[i][h]];
                    }
                    else
                    {
                        fine =
                            Math.Round(optArrangeOneArray[2*permutationVariants[i][h + 1]] -
                                       optArrangeOneArray[2*permutationVariants[i][h]], 1);
                        tempArrayArrangeOne[2*permutationVariants[i][h]] = tempArrayArrangeOne[2*permutationVariants[i][h + 1]];
                    }
                    currentInnerFineSect += fine;

                    //2-ые однокомнатные
                    if (optArrangeOneArray[2*permutationVariants[i][h] + 1] >
                        optArrangeOneArray[2*permutationVariants[i][h + 1] + 1])
                    {
                        fine =
                            Math.Round(optArrangeOneArray[2*permutationVariants[i][h] + 1] -
                                       optArrangeOneArray[2*permutationVariants[i][h + 1] + 1], 1);
                        tempArrayArrangeOne[2*permutationVariants[i][h + 1] + 1] =
                            tempArrayArrangeOne[2*permutationVariants[i][h] + 1];
                    }
                    else
                    {
                        fine =
                            Math.Round(optArrangeOneArray[2*permutationVariants[i][h + 1] + 1] -
                                       optArrangeOneArray[2*permutationVariants[i][h] + 1], 1);
                        tempArrayArrangeOne[2*permutationVariants[i][h] + 1] =
                            tempArrayArrangeOne[2*permutationVariants[i][h + 1] + 1];
                    }
                    currentInnerFineSect += fine;

                    //1-ые двухкомнатные
                    if (optArrangeTwoArray[2*permutationVariants[i][h]] >
                        optArrangeTwoArray[2*permutationVariants[i][h + 1]])
                    {
                        fine =
                            Math.Round(optArrangeTwoArray[2*permutationVariants[i][h]] -
                                       optArrangeTwoArray[2*permutationVariants[i][h + 1]], 1);
                        tempArrayArrangeTwo[2*permutationVariants[i][h + 1]] = tempArrayArrangeTwo[2*permutationVariants[i][h]];
                    }
                    else
                    {
                        fine =
                            Math.Round(optArrangeTwoArray[2*permutationVariants[i][h + 1]] -
                                       optArrangeTwoArray[2*permutationVariants[i][h]], 1);
                        tempArrayArrangeTwo[2*permutationVariants[i][h]] = tempArrayArrangeTwo[2*permutationVariants[i][h + 1]];
                    }
                    currentInnerFineSect += fine;

                    //2-ые двухкомнатные
                    if (optArrangeTwoArray[2*permutationVariants[i][h] + 1] >
                        optArrangeTwoArray[2*permutationVariants[i][h + 1] + 1])
                    {
                        fine =
                            Math.Round(optArrangeTwoArray[2*permutationVariants[i][h] + 1] -
                                       optArrangeTwoArray[2*permutationVariants[i][h + 1] + 1], 1);
                        tempArrayArrangeTwo[2*permutationVariants[i][h + 1] + 1] =
                            tempArrayArrangeTwo[2*permutationVariants[i][h] + 1];
                    }
                    else
                    {
                        fine =
                            Math.Round(optArrangeTwoArray[2*permutationVariants[i][h + 1] + 1] -
                                       optArrangeTwoArray[2*permutationVariants[i][h] + 1], 1);
                        tempArrayArrangeTwo[2*permutationVariants[i][h] + 1] =
                            tempArrayArrangeTwo[2*permutationVariants[i][h + 1] + 1];
                    }
                    currentInnerFineSect += fine;

                }

                for (var t = 0; t < tempArrayArrangeOne.Length; t = t + 2)
                {
                    listSquareOneFlat.Add(Math.Round(tempArrayArrangeOne[t] + tempArrayArrangeOne[t + 1] + entryway + 3 * step, 1));
                }
                for (var t = 0; t < tempArrayArrangeTwo.Length; t = t + 2)
                {
                    listSquareTwoFlat.Add(Math.Round(tempArrayArrangeTwo[t] + tempArrayArrangeTwo[t + 1] + 2 * step, 1));
                }

                for (var numberRowVariant = 0; numberRowVariant < permutationVariants.Count; ++numberRowVariant)
                {
                    var currentOutFineSection = 0.0;
                    for (var index = 0; index < permutationVariants[numberRowVariant].Length; index = index + 2)
                    {
                        double fine;
                        if (Math.Max(listSquareOneFlat[index], listSquareTwoFlat[index]) >
                            Math.Max(listSquareOneFlat[index + 1], listSquareTwoFlat[index + 1]))
                        {
                            fine =
                                Math.Round(
                                    Math.Max(listSquareOneFlat[index], listSquareTwoFlat[index]) -
                                    Math.Max(listSquareOneFlat[index + 1], listSquareTwoFlat[index + 1]), 1);
                        }
                        else
                        {
                            fine =
                                Math.Round(
                                    Math.Max(listSquareOneFlat[index + 1], listSquareTwoFlat[index + 1]) -
                                    Math.Max(listSquareOneFlat[index], listSquareTwoFlat[index]), 1);
                        }
                        currentOutFineSection += fine;

                    }
                    if (currentOutFineSection + currentInnerFineSect < totalFineSecondFloor)
                    {
                        optimalVariant = numberRowVariant;
                        totalFineSecondFloor = currentOutFineSection+currentInnerFineSect;
                        itogOptArrangeOneArray = tempArrayArrangeOne;
                        itogOptArrangeTwoArray = tempArrayArrangeTwo;
                    }
                }
            }
            
            var optimalPermutation = permutationVariants[optimalVariant];
            var optVarOneflatOneFloor = new double[optimalPermutation.Length];
            var optVarTwoflatOneFloor = new double[optimalPermutation.Length];
            var optVarOneflatTwoFloor = new double[optimalPermutation.Length];
            var optVarTwoflatTwoFloor = new double[optimalPermutation.Length];

            //первый этаж
            for (var i = 0; i < optimalPermutation.Length; i=i+2)
            {
                optVarOneflatOneFloor[i] = (itogOptArrangeOneArray[optimalPermutation[i]*2]);
                optVarOneflatOneFloor[i + 1] = (itogOptArrangeOneArray[optimalPermutation[i]*2 + 1]);
            }
            for (var j = 0; j < optimalPermutation.Length; j=j+2)
            {
                optVarTwoflatOneFloor[j] = (itogOptArrangeTwoArray[optimalPermutation[j]*2]);
                optVarTwoflatOneFloor[j + 1] = (itogOptArrangeTwoArray[optimalPermutation[j] * 2 + 1]);
            }
            resultList.Add(optVarOneflatOneFloor);
            resultList.Add(optVarTwoflatOneFloor);

            //второй этаж
            for (var i = 1; i < optimalPermutation.Length; i = i + 2)
            {
                optVarOneflatTwoFloor[i - 1] = (itogOptArrangeOneArray[optimalPermutation[i] * 2]);
                optVarOneflatTwoFloor[i] = (itogOptArrangeOneArray[optimalPermutation[i] * 2 + 1]);
            }
            for (var j = 1; j < optimalPermutation.Length; j = j + 2)
            {
                optVarTwoflatTwoFloor[j - 1] = (itogOptArrangeTwoArray[optimalPermutation[j] * 2]);
                optVarTwoflatTwoFloor[j] = (itogOptArrangeTwoArray[optimalPermutation[j] * 2 + 1]);
            }
            resultList.Add(optVarOneflatTwoFloor);
            resultList.Add(optVarTwoflatTwoFloor);
            resultList.Add(totalFineSecondFloor);
            return resultList;
        }
    }
}