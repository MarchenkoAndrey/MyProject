using System;
using System.Collections.Generic;

namespace Resettlement
{
    static class GroupingOnTheFloors
    {
        public static List<object> GroupingTwoFloors(List<double> listLengthsOneRoomFlats, List<double> listLengthsTwoRoomFlats)
        {
            var resultList = new List<object>();
            var fineOneFlat = 0.0;
            var fineTwoFlat = 0.0;
            var sortedListOneFlat = InsertionSort.InsertSort(listLengthsOneRoomFlats);
            var sortedListTwoFlat = InsertionSort.InsertSort(listLengthsTwoRoomFlats);
            var resultListOneFlat = new List<double>();
            var resultListTwoFlat = new List<double>();

            //данные для нескольких списков - лишние квартиры
            var excessOneFlatFlag = false;
            var excessTwoFlatFlag = false;
            var optimalCountFlat = Math.Min(sortedListOneFlat.Count / 2 * 2, sortedListTwoFlat.Count / 2 * 2);   
            var excessDataOneFlat = new List<double>();
            var excessDataTwoFlat = new List<double>(); // квартиры, которые не попали в список 
            var totalFineOneFlatWithExcessData = 1000.0;
            var totalFineTwoFlatWithExcessData = 1000.0;
            var totalListsOneFlatForFloor = new List<double>();
            var totalListsTwoFlatForFloor = new List<double>();
           
            if (sortedListOneFlat.Count == optimalCountFlat)
            {
                for (var i = 0; i < sortedListOneFlat.Count; i = i + 2)
                {
                    fineOneFlat += Math.Round(sortedListOneFlat[i + 1] - sortedListOneFlat[i],1);
                    resultListOneFlat.Add(sortedListOneFlat[i + 1]);
                }
            }
            else
            {
                //as FS, all variants, to choice better
                excessOneFlatFlag = true;
                var excessValueCount = sortedListOneFlat.Count - optimalCountFlat;
                var newExcessValueCount = excessValueCount;
                var newListAfterDividedMoreTwoValues = new List<double>();
                if (excessValueCount > 2)
                {
                    var valuesMoreTwoCount = excessValueCount - 2;
                    newExcessValueCount -= valuesMoreTwoCount;
                    for (var index = 0; index < valuesMoreTwoCount; ++index)
                    {
                        excessDataOneFlat.Add(sortedListOneFlat[index]);
                    }
                    for(var index=valuesMoreTwoCount; index<sortedListOneFlat.Count;++index)
                    {
                        newListAfterDividedMoreTwoValues.Add(sortedListOneFlat[index]);
                    }
                }
                var newListForOneFlat = new List<double>(sortedListOneFlat);
                if (newListAfterDividedMoreTwoValues.Count != 0)
                {
                    newListForOneFlat = newListAfterDividedMoreTwoValues;
                }
                var totalResultListOneFlat = new List<double>();
               
                if (newExcessValueCount == 1)
                {
                    var excessListOneValue = new List<double>();
                    foreach (var index in newListForOneFlat)
                    {
                        var currentResultListOneFlat = new List<double>();
                        var currentListOneFlat = new List<double>(newListForOneFlat);
                        var currentFineOneFlat = 0.0;
                        currentListOneFlat.Remove(index);
                        for (var i = 0; i < currentListOneFlat.Count; i = i + 2)
                        {
                            currentFineOneFlat += Math.Round(currentListOneFlat[i + 1] - currentListOneFlat[i], 1);
                            currentResultListOneFlat.Add(currentListOneFlat[i + 1]);
                        }
                        if (currentFineOneFlat < totalFineOneFlatWithExcessData)
                        {
                            totalFineOneFlatWithExcessData = Math.Round(currentFineOneFlat,1);
                            totalResultListOneFlat=currentResultListOneFlat;
                            if (excessListOneValue.Count != 0)
                            {
                                excessListOneValue.RemoveAt(0);
                            }
                            excessListOneValue.Add(index);
                        }
                    }
                    totalListsOneFlatForFloor.AddRange(totalResultListOneFlat);
                    excessDataOneFlat.AddRange(excessListOneValue);
                }
                else // newExcessValueCount == 2
                {
                    var excessListOneValue = new List<double>();
                    for (var index = 0; index < newListForOneFlat.Count; ++index)
                    {
                        var currentListOneFlat = new List<double>(newListForOneFlat);
                        currentListOneFlat.Remove(newListForOneFlat[index]);
                       
                        for (var jndex = index + 1; jndex < newListForOneFlat.Count; ++jndex)
                        {
                            var currentResultListOneFlat = new List<double>();
                            var currentFineOneFlat = 0.0;
                            var currentListOneFlatEvenExcess = new List<double>(currentListOneFlat);
                            currentListOneFlatEvenExcess.Remove(newListForOneFlat[jndex]);
                            for (var i = 0; i < currentListOneFlatEvenExcess.Count; i = i + 2)
                            {
                                currentFineOneFlat += Math.Round(currentListOneFlatEvenExcess[i + 1] - currentListOneFlatEvenExcess[i], 1);
                                currentResultListOneFlat.Add(currentListOneFlatEvenExcess[i + 1]);
                            }
                            if (currentFineOneFlat < totalFineOneFlatWithExcessData)
                            {
                                totalFineOneFlatWithExcessData = Math.Round(currentFineOneFlat, 1);
                                totalResultListOneFlat = currentResultListOneFlat;
                                if (excessListOneValue.Count != 0)
                                {
                                    excessListOneValue.RemoveAt(0);
                                    excessListOneValue.RemoveAt(0);
                                }
                                excessListOneValue.Add(newListForOneFlat[index]);
                                excessListOneValue.Add(newListForOneFlat[jndex]);
                            }
                        }
                    }
                    
                    totalListsOneFlatForFloor.AddRange(totalResultListOneFlat);
                    excessDataOneFlat.AddRange(excessListOneValue);
                }
            }
            if (sortedListTwoFlat.Count == optimalCountFlat)
            {
                for (var i = 0; i < sortedListTwoFlat.Count; i = i + 2)
                {
                    fineTwoFlat += Math.Round(sortedListTwoFlat[i + 1] - sortedListTwoFlat[i],1);
                    resultListTwoFlat.Add(sortedListTwoFlat[i + 1]);
                }
            }
            else
            {
                //as FS, all variants, to choice better
                excessTwoFlatFlag = true;
                var excessValueCount = sortedListTwoFlat.Count - optimalCountFlat;
                var newExcessValueCount = excessValueCount;
                var newListAfterDividedMoreTwoValues = new List<double>();

                if (excessValueCount > 2)
                {
                    var valuesMoreTwoCount = excessValueCount - 2;
                    newExcessValueCount -= valuesMoreTwoCount;
                    for (var index = 0; index < sortedListTwoFlat.Count - valuesMoreTwoCount; ++index)
                    {
                        newListAfterDividedMoreTwoValues.Add(sortedListTwoFlat[index]);
                    }
                    for (var index = sortedListTwoFlat.Count - valuesMoreTwoCount; index < sortedListTwoFlat.Count; ++index)
                    {
                        excessDataTwoFlat.Add(sortedListTwoFlat[index]);
                    }
                }
                var newListForTwoFlat = new List<double>(sortedListTwoFlat);
                if (newListAfterDividedMoreTwoValues.Count != 0)
                {
                    newListForTwoFlat = newListAfterDividedMoreTwoValues;
                }
                var totalResultListTwoFlat = new List<double>();

                if (newExcessValueCount == 1)
                {
                    var excessListOneValue = new List<double>();
                    foreach (var index in newListForTwoFlat)
                    {
                        var currentResultListTwoFlat = new List<double>();
                        var currentListTwoFlat = new List<double>(newListForTwoFlat);
                        var currentFineTwoFlat = 0.0;
                        currentListTwoFlat.Remove(index);
                        for (var i = 0; i < currentListTwoFlat.Count; i = i + 2)
                        {
                            currentFineTwoFlat += Math.Round(currentListTwoFlat[i + 1] - currentListTwoFlat[i], 1);
                            currentResultListTwoFlat.Add(currentListTwoFlat[i + 1]);
                        }
                        if (currentFineTwoFlat < totalFineTwoFlatWithExcessData)
                        {
                            totalFineTwoFlatWithExcessData = Math.Round(currentFineTwoFlat, 1);
                            totalResultListTwoFlat = currentResultListTwoFlat;
                            if (excessListOneValue.Count != 0)
                            {
                                excessListOneValue.RemoveAt(0);
                            }
                            excessListOneValue.Add(index);
                        }
                    }
                    totalListsTwoFlatForFloor.AddRange(totalResultListTwoFlat);
                    excessDataTwoFlat.AddRange(excessListOneValue);
                }
                else // newExcessValueCount == 2
                {
                    var excessListOneValue = new List<double>();
                    for (var index = 0; index < newListForTwoFlat.Count; ++index)
                    {
                        var currentListTwoFlat = new List<double>(newListForTwoFlat);
                        currentListTwoFlat.Remove(newListForTwoFlat[index]);

                        for (var jndex = index + 1; jndex < newListForTwoFlat.Count; ++jndex)
                        {
                            var currentResultListTwoFlat = new List<double>();
                            var currentFineTwoFlat = 0.0;
                            var currentListTwoFlatEvenExcess = new List<double>(currentListTwoFlat);
                            currentListTwoFlatEvenExcess.Remove(newListForTwoFlat[jndex]);
                            for (var i = 0; i < currentListTwoFlatEvenExcess.Count; i = i + 2)
                            {
                                currentFineTwoFlat += Math.Round(currentListTwoFlatEvenExcess[i + 1] - currentListTwoFlatEvenExcess[i], 1);
                                currentResultListTwoFlat.Add(currentListTwoFlatEvenExcess[i + 1]);
                            }
                            if (currentFineTwoFlat < totalFineTwoFlatWithExcessData)
                            {
                                totalFineTwoFlatWithExcessData = Math.Round(currentFineTwoFlat, 1);
                                totalResultListTwoFlat = currentResultListTwoFlat;
                                if (excessListOneValue.Count != 0)
                                {
                                    excessListOneValue.RemoveAt(0);
                                    excessListOneValue.RemoveAt(0);
                                }
                                excessListOneValue.Add(newListForTwoFlat[index]);
                                excessListOneValue.Add(newListForTwoFlat[jndex]);
                            }
                        }
                    }
                    totalListsTwoFlatForFloor.AddRange(totalResultListTwoFlat);
                    excessDataTwoFlat.AddRange(excessListOneValue);
                }
            }
            resultList.Add(excessOneFlatFlag ? totalListsOneFlatForFloor : resultListOneFlat);
            resultList.Add(excessTwoFlatFlag ? totalListsTwoFlatForFloor : resultListTwoFlat);
            fineOneFlat = excessOneFlatFlag ? totalFineOneFlatWithExcessData : fineOneFlat;
            fineTwoFlat = excessTwoFlatFlag ? totalFineTwoFlatWithExcessData : fineTwoFlat;
            var totalFine = Math.Round(fineOneFlat + fineTwoFlat, 1);
            resultList.Add(totalFine);
            resultList.Add(excessDataOneFlat);
            resultList.Add(excessDataTwoFlat);
            return resultList;
        }

        public static List<object> GroupingThreeFloors(List<double> listLengthsOneRoomFlats, List<double> listLengthsTwoRoomFlats)
        {
            var resultList = new List<object>();
            var fineOneFlat = 0.0;
            var fineTwoFlat = 0.0;
            var sortedListOneFlat = InsertionSort.InsertSort(listLengthsOneRoomFlats);
            var sortedListTwoFlat = InsertionSort.InsertSort(listLengthsTwoRoomFlats);
            var resultListOneFlat = new List<double>();
            var resultListTwoFlat = new List<double>();

            //данные для нескольких списков - лишние квартиры
            var excessOneFlatFlag = false;
            var excessTwoFlatFlag = false;
            var optimalCountFlat = Math.Min(sortedListOneFlat.Count / 3 * 3, sortedListTwoFlat.Count / 3 * 3);
            var excessDataOneFlat = new List<double>();
            var excessDataTwoFlat = new List<double>(); // квартиры, которые не попали в список 
            var totalFineOneFlatWithExcessData = 1000.0;
            var totalFineTwoFlatWithExcessData = 1000.0;
            var totalListsOneFlatForFloor = new List<double>();
            var totalListsTwoFlatForFloor = new List<double>();

            if (sortedListOneFlat.Count == optimalCountFlat)
            {
                for (var i = 0; i < sortedListOneFlat.Count; i = i + 3)
                {
                    fineOneFlat += Math.Round(sortedListOneFlat[i + 2] - sortedListOneFlat[i] + (sortedListOneFlat[i + 2] - sortedListOneFlat[i + 1]), 1);
                    resultListOneFlat.Add(sortedListOneFlat[i + 2]);
                }
            }
            else
            {
                //as FS, all variants, to choice better
                excessOneFlatFlag = true;
                var excessValueCount = sortedListOneFlat.Count - optimalCountFlat;
                var newExcessValueCount = excessValueCount;
                var newListAfterDividedMoreTwoValues = new List<double>();
                if (excessValueCount > 2)
                {
                    var valuesMoreTwoCount = excessValueCount - 2;
                    newExcessValueCount -= valuesMoreTwoCount;
                    for (var index = 0; index < valuesMoreTwoCount; ++index)
                    {
                        excessDataOneFlat.Add(sortedListOneFlat[index]);
                    }
                    for (var index = valuesMoreTwoCount; index < sortedListOneFlat.Count; ++index)
                    {
                        newListAfterDividedMoreTwoValues.Add(sortedListOneFlat[index]);
                    }
                }
                var newListForOneFlat = new List<double>(sortedListOneFlat);
                if (newListAfterDividedMoreTwoValues.Count != 0)
                {
                    newListForOneFlat = newListAfterDividedMoreTwoValues;
                }
                var totalResultListOneFlat = new List<double>();

                if (newExcessValueCount == 1)
                {
                    var excessListOneValue = new List<double>();
                    foreach (var index in newListForOneFlat)
                    {
                        var currentResultListOneFlat = new List<double>();
                        var currentListOneFlat = new List<double>(newListForOneFlat);
                        var currentFineOneFlat = 0.0;
                        currentListOneFlat.Remove(index);
                        for (var i = 0; i < currentListOneFlat.Count; i = i + 3)
                        {
                            currentFineOneFlat +=
                                Math.Round(
                                    currentListOneFlat[i + 2] - currentListOneFlat[i] +
                                    (currentListOneFlat[i + 2] - currentListOneFlat[i + 1]), 1);
                            currentResultListOneFlat.Add(currentListOneFlat[i + 2]);
                        }
                        if (currentFineOneFlat < totalFineOneFlatWithExcessData)
                        {
                            totalFineOneFlatWithExcessData = Math.Round(currentFineOneFlat, 1);
                            totalResultListOneFlat = currentResultListOneFlat;
                            if (excessListOneValue.Count != 0)
                            {
                                excessListOneValue.RemoveAt(0);
                            }
                            excessListOneValue.Add(index);
                        }
                    }
                    totalListsOneFlatForFloor.AddRange(totalResultListOneFlat);
                    excessDataOneFlat.AddRange(excessListOneValue);
                }
                else // newExcessValueCount == 2
                {
                    var excessListOneValue = new List<double>();
                    for (var index = 0; index < newListForOneFlat.Count; ++index)
                    {
                        var currentListOneFlat = new List<double>(newListForOneFlat);
                        currentListOneFlat.Remove(newListForOneFlat[index]);

                        for (var jndex = index + 1; jndex < newListForOneFlat.Count; ++jndex)
                        {
                            var currentResultListOneFlat = new List<double>();
                            var currentFineOneFlat = 0.0;
                            var currentListOneFlatEvenExcess = new List<double>(currentListOneFlat);
                            currentListOneFlatEvenExcess.Remove(newListForOneFlat[jndex]);
                            for (var i = 0; i < currentListOneFlatEvenExcess.Count; i = i + 3)
                            {
                                currentFineOneFlat += Math.Round(currentListOneFlatEvenExcess[i + 2] - currentListOneFlatEvenExcess[i] + (currentListOneFlatEvenExcess[i + 2] - currentListOneFlatEvenExcess[i+1]), 1);
                                currentResultListOneFlat.Add(currentListOneFlatEvenExcess[i + 2]);
                            }
                            if (currentFineOneFlat < totalFineOneFlatWithExcessData)
                            {
                                totalFineOneFlatWithExcessData = Math.Round(currentFineOneFlat, 1);
                                totalResultListOneFlat = currentResultListOneFlat;
                                if (excessListOneValue.Count != 0)
                                {
                                    excessListOneValue.RemoveAt(0);
                                    excessListOneValue.RemoveAt(0);
                                }
                                excessListOneValue.Add(newListForOneFlat[index]);
                                excessListOneValue.Add(newListForOneFlat[jndex]);
                            }
                        }
                    }

                    totalListsOneFlatForFloor.AddRange(totalResultListOneFlat);
                    excessDataOneFlat.AddRange(excessListOneValue);
                }
            }
            if (sortedListTwoFlat.Count == optimalCountFlat)
            {
                for (var i = 0; i < sortedListTwoFlat.Count; i = i + 3)
                {
                    fineTwoFlat +=
                        Math.Round(
                            sortedListTwoFlat[i + 2] - sortedListTwoFlat[i] +
                            (sortedListTwoFlat[i + 2] - sortedListTwoFlat[i + 1]), 1);
                    resultListTwoFlat.Add(sortedListTwoFlat[i + 2]);
                }
            }
            else
            {
                //as FS, all variants, to choice better
                excessTwoFlatFlag = true;
                var excessValueCount = sortedListTwoFlat.Count - optimalCountFlat;
                var newExcessValueCount = excessValueCount;
                var newListAfterDividedMoreTwoValues = new List<double>();
                if (excessValueCount > 2)
                {
                    var valuesMoreTwoCount = excessValueCount - 2;
                    newExcessValueCount -= valuesMoreTwoCount;
                    for (var index = 0; index < sortedListTwoFlat.Count - valuesMoreTwoCount; ++index)
                    {
                        newListAfterDividedMoreTwoValues.Add(sortedListTwoFlat[index]);
                    }
                    for (var index = sortedListTwoFlat.Count - valuesMoreTwoCount; index < sortedListTwoFlat.Count; ++index)
                    {
                        excessDataTwoFlat.Add(sortedListTwoFlat[index]);
                    }
                }
                var newListForTwoFlat = new List<double>(sortedListTwoFlat);
                if (newListAfterDividedMoreTwoValues.Count != 0)
                {
                    newListForTwoFlat = newListAfterDividedMoreTwoValues;
                }
                var totalResultListTwoFlat = new List<double>();

                if (newExcessValueCount == 1)
                {
                    var excessListOneValue = new List<double>();
                    foreach (var index in newListForTwoFlat)
                    {
                        var currentResultListTwoFlat = new List<double>();
                        var currentListTwoFlat = new List<double>(newListForTwoFlat);
                        var currentFineTwoFlat = 0.0;
                        currentListTwoFlat.Remove(index);
                        for (var i = 0; i < currentListTwoFlat.Count; i = i + 3)
                        {
                            currentFineTwoFlat +=
                                Math.Round(
                                    currentListTwoFlat[i + 2] - currentListTwoFlat[i] +
                                    (currentListTwoFlat[i + 2] - currentListTwoFlat[i + 1]), 1);
                            currentResultListTwoFlat.Add(currentListTwoFlat[i + 2]);
                        }
                        if (currentFineTwoFlat < totalFineTwoFlatWithExcessData)
                        {
                            totalFineTwoFlatWithExcessData = Math.Round(currentFineTwoFlat, 1);
                            totalResultListTwoFlat = currentResultListTwoFlat;
                            if (excessListOneValue.Count != 0)
                            {
                                excessListOneValue.RemoveAt(0);
                            }
                            excessListOneValue.Add(index);
                        }
                    }
                    totalListsTwoFlatForFloor.AddRange(totalResultListTwoFlat);
                    excessDataTwoFlat.AddRange(excessListOneValue);
                }
                else // newExcessValueCount == 2
                {
                    var excessListOneValue = new List<double>();
                    for (var index = 0; index < newListForTwoFlat.Count; ++index)
                    {
                        var currentListTwoFlat = new List<double>(newListForTwoFlat);
                        currentListTwoFlat.Remove(newListForTwoFlat[index]);

                        for (var jndex = index + 1; jndex < newListForTwoFlat.Count; ++jndex)
                        {
                            var currentResultListTwoFlat = new List<double>();
                            var currentFineTwoFlat = 0.0;
                            var currentListTwoFlatEvenExcess = new List<double>(currentListTwoFlat);
                            currentListTwoFlatEvenExcess.Remove(newListForTwoFlat[jndex]);
                            for (var i = 0; i < currentListTwoFlatEvenExcess.Count; i = i + 3)
                            {
                                currentFineTwoFlat +=
                                    Math.Round(
                                        currentListTwoFlatEvenExcess[i + 2] - currentListTwoFlatEvenExcess[i] +
                                        (currentListTwoFlatEvenExcess[i + 2] - currentListTwoFlatEvenExcess[i + 1]), 1);
                                currentResultListTwoFlat.Add(currentListTwoFlatEvenExcess[i + 2]);
                            }
                            if (currentFineTwoFlat < totalFineTwoFlatWithExcessData)
                            {
                                totalFineTwoFlatWithExcessData = Math.Round(currentFineTwoFlat, 1);
                                totalResultListTwoFlat = currentResultListTwoFlat;
                                if (excessListOneValue.Count != 0)
                                {
                                    excessListOneValue.RemoveAt(0);
                                    excessListOneValue.RemoveAt(0);
                                }
                                excessListOneValue.Add(newListForTwoFlat[index]);
                                excessListOneValue.Add(newListForTwoFlat[jndex]);
                            }
                        }
                    }
                    totalListsTwoFlatForFloor.AddRange(totalResultListTwoFlat);
                    excessDataTwoFlat.AddRange(excessListOneValue);
                }
            }
            resultList.Add(excessOneFlatFlag ? totalListsOneFlatForFloor : resultListOneFlat);
            resultList.Add(excessTwoFlatFlag ? totalListsTwoFlatForFloor : resultListTwoFlat);
            fineOneFlat = excessOneFlatFlag ? totalFineOneFlatWithExcessData : fineOneFlat;
            fineTwoFlat = excessTwoFlatFlag ? totalFineTwoFlatWithExcessData : fineTwoFlat;
            var totalFine = Math.Round(fineOneFlat + fineTwoFlat, 1);
            resultList.Add(totalFine);
            resultList.Add(excessDataOneFlat);
            resultList.Add(excessDataTwoFlat);
            return resultList;
        }

        public static List<object> GroupingFourthFloors(List<double> listLengthsOneRoomFlats, List<double> listLengthsTwoRoomFlats)
        {
            var resultList = new List<object>();
            var fineOneFlat = 0.0;
            var fineTwoFlat = 0.0;
            var sortedListOneFlat = InsertionSort.InsertSort(listLengthsOneRoomFlats);
            var sortedListTwoFlat = InsertionSort.InsertSort(listLengthsTwoRoomFlats);
            var resultListOneFlat = new List<double>();
            var resultListTwoFlat = new List<double>();

            //данные для нескольких списков - лишние квартиры
            var excessOneFlatFlag = false;
            var excessTwoFlatFlag = false;
            var optimalCountFlat = Math.Min(sortedListOneFlat.Count / 4 * 4, sortedListTwoFlat.Count / 4 * 4);
            var excessDataOneFlat = new List<double>();
            var excessDataTwoFlat = new List<double>(); // квартиры, которые не попали в список 
            var totalFineOneFlatWithExcessData = 1000.0;
            var totalFineTwoFlatWithExcessData = 1000.0;
            var totalListsOneFlatForFloor = new List<double>();
            var totalListsTwoFlatForFloor = new List<double>();

            if (sortedListOneFlat.Count == optimalCountFlat)
            {
                for (var i = 0; i < sortedListOneFlat.Count; i = i + 4)
                {
                    fineOneFlat += Math.Round(sortedListOneFlat[i + 3] - sortedListOneFlat[i] +
                        (sortedListOneFlat[i + 3] - sortedListOneFlat[i + 1]) + (sortedListOneFlat[i + 3] - sortedListOneFlat[i + 2]), 1);
                    resultListOneFlat.Add(sortedListOneFlat[i + 3]);
                }
            }
            else
            {
                //as FS, all variants, to choice better
                excessOneFlatFlag = true;
                var excessValueCount = sortedListOneFlat.Count - optimalCountFlat;
                var newExcessValueCount = excessValueCount;
                var newListAfterDividedMoreTwoValues = new List<double>();
                if (excessValueCount > 2)
                {
                    var valuesMoreTwoCount = excessValueCount - 2;
                    newExcessValueCount -= valuesMoreTwoCount;
                    for (var index = 0; index < valuesMoreTwoCount; ++index)
                    {
                        excessDataOneFlat.Add(sortedListOneFlat[index]);
                    }
                    for (var index = valuesMoreTwoCount; index < sortedListOneFlat.Count; ++index)
                    {
                        newListAfterDividedMoreTwoValues.Add(sortedListOneFlat[index]);
                    }
                }
                var newListForOneFlat = new List<double>(sortedListOneFlat);
                if (newListAfterDividedMoreTwoValues.Count != 0)
                {
                    newListForOneFlat = newListAfterDividedMoreTwoValues;
                }
                var totalResultListOneFlat = new List<double>();

                if (newExcessValueCount == 1)
                {
                    var excessListOneValue = new List<double>();
                    foreach (var index in newListForOneFlat)
                    {
                        var currentResultListOneFlat = new List<double>();
                        var currentListOneFlat = new List<double>(newListForOneFlat);
                        var currentFineOneFlat = 0.0;
                        currentListOneFlat.Remove(index);
                        for (var i = 0; i < currentListOneFlat.Count; i = i + 4)
                        {
                            currentFineOneFlat +=
                                Math.Round(
                                    currentListOneFlat[i + 3] - currentListOneFlat[i] +
                                    (currentListOneFlat[i + 3] - currentListOneFlat[i + 1]) +
                                    (currentListOneFlat[i + 3] - currentListOneFlat[i + 2]), 1);
                            currentResultListOneFlat.Add(currentListOneFlat[i + 3]);
                        }
                        if (currentFineOneFlat < totalFineOneFlatWithExcessData)
                        {
                            totalFineOneFlatWithExcessData = Math.Round(currentFineOneFlat, 1);
                            totalResultListOneFlat = currentResultListOneFlat;
                            if (excessListOneValue.Count != 0)
                            {
                                excessListOneValue.RemoveAt(0);
                            }
                            excessListOneValue.Add(index);
                        }
                    }
                    totalListsOneFlatForFloor.AddRange(totalResultListOneFlat);
                    excessDataOneFlat.AddRange(excessListOneValue);
                }
                else // newExcessValueCount == 2
                {
                    var excessListOneValue = new List<double>();
                    for (var index = 0; index < newListForOneFlat.Count; ++index)
                    {
                        var currentListOneFlat = new List<double>(newListForOneFlat);
                        currentListOneFlat.Remove(newListForOneFlat[index]);

                        for (var jndex = index + 1; jndex < newListForOneFlat.Count; ++jndex)
                        {
                            var currentResultListOneFlat = new List<double>();
                            var currentFineOneFlat = 0.0;
                            var currentListOneFlatEvenExcess = new List<double>(currentListOneFlat);
                            currentListOneFlatEvenExcess.Remove(newListForOneFlat[jndex]);
                            for (var i = 0; i < currentListOneFlatEvenExcess.Count; i = i + 4)
                            {
                                currentFineOneFlat +=
                                    Math.Round(
                                        currentListOneFlatEvenExcess[i + 3] - currentListOneFlatEvenExcess[i] +
                                        (currentListOneFlatEvenExcess[i + 3] - currentListOneFlatEvenExcess[i + 1]) +
                                        (currentListOneFlatEvenExcess[i + 3] - currentListOneFlatEvenExcess[i + 2]), 1);
                                currentResultListOneFlat.Add(currentListOneFlatEvenExcess[i + 3]);
                            }
                            if (currentFineOneFlat < totalFineOneFlatWithExcessData)
                            {
                                totalFineOneFlatWithExcessData = Math.Round(currentFineOneFlat, 1);
                                totalResultListOneFlat = currentResultListOneFlat;
                                if (excessListOneValue.Count != 0)
                                {
                                    excessListOneValue.RemoveAt(0);
                                    excessListOneValue.RemoveAt(0);
                                }
                                excessListOneValue.Add(newListForOneFlat[index]);
                                excessListOneValue.Add(newListForOneFlat[jndex]);
                            }
                        }
                    }

                    totalListsOneFlatForFloor.AddRange(totalResultListOneFlat);
                    excessDataOneFlat.AddRange(excessListOneValue);
                }
            }
            if (sortedListTwoFlat.Count == optimalCountFlat)
            {
                for (var i = 0; i < sortedListTwoFlat.Count; i = i + 4)
                {
                    fineTwoFlat +=
                        Math.Round(
                            sortedListTwoFlat[i + 3] - sortedListTwoFlat[i] +
                            (sortedListTwoFlat[i + 3] - sortedListTwoFlat[i + 1]) +
                            (sortedListTwoFlat[i + 3] - sortedListTwoFlat[i + 2]), 1);
                    resultListTwoFlat.Add(sortedListTwoFlat[i + 3]);
                }
            }
            else
            {
                //as FS, all variants, to choice better
                excessTwoFlatFlag = true;
                var excessValueCount = sortedListTwoFlat.Count - optimalCountFlat;
                var newExcessValueCount = excessValueCount;
                var newListAfterDividedMoreTwoValues = new List<double>();
                if (excessValueCount > 2)
                {
                    var valuesMoreTwoCount = excessValueCount - 2;
                    newExcessValueCount -= valuesMoreTwoCount;
                    for (var index = 0; index < sortedListTwoFlat.Count - valuesMoreTwoCount; ++index)
                    {
                        newListAfterDividedMoreTwoValues.Add(sortedListTwoFlat[index]);
                    }
                    for (var index = sortedListTwoFlat.Count - valuesMoreTwoCount; index < sortedListTwoFlat.Count; ++index)
                    {
                        excessDataTwoFlat.Add(sortedListTwoFlat[index]);
                    }
                }
                var newListForTwoFlat = new List<double>(sortedListTwoFlat);
                if (newListAfterDividedMoreTwoValues.Count != 0)
                {
                    newListForTwoFlat = newListAfterDividedMoreTwoValues;
                }
                var totalResultListTwoFlat = new List<double>();

                if (newExcessValueCount == 1)
                {
                    var excessListOneValue = new List<double>();
                    foreach (var index in newListForTwoFlat)
                    {
                        var currentResultListTwoFlat = new List<double>();
                        var currentListTwoFlat = new List<double>(newListForTwoFlat);
                        var currentFineTwoFlat = 0.0;
                        currentListTwoFlat.Remove(index);
                        for (var i = 0; i < currentListTwoFlat.Count; i = i + 4)
                        {
                            currentFineTwoFlat +=
                                Math.Round(
                                    currentListTwoFlat[i + 3] - currentListTwoFlat[i] +
                                    (currentListTwoFlat[i + 3] - currentListTwoFlat[i + 1]) +
                                    (currentListTwoFlat[i + 3] - currentListTwoFlat[i + 2]), 1);
                            currentResultListTwoFlat.Add(currentListTwoFlat[i + 3]);
                        }
                        if (currentFineTwoFlat < totalFineTwoFlatWithExcessData)
                        {
                            totalFineTwoFlatWithExcessData = Math.Round(currentFineTwoFlat, 1);
                            totalResultListTwoFlat = currentResultListTwoFlat;
                            if (excessListOneValue.Count != 0)
                            {
                                excessListOneValue.RemoveAt(0);
                            }
                            excessListOneValue.Add(index);
                        }
                    }
                    totalListsTwoFlatForFloor.AddRange(totalResultListTwoFlat);
                    excessDataTwoFlat.AddRange(excessListOneValue);
                }
                else // newExcessValueCount == 2
                {
                    var excessListOneValue = new List<double>();
                    for (var index = 0; index < newListForTwoFlat.Count; ++index)
                    {
                        var currentListTwoFlat = new List<double>(newListForTwoFlat);
                        currentListTwoFlat.Remove(newListForTwoFlat[index]);

                        for (var jndex = index + 1; jndex < newListForTwoFlat.Count; ++jndex)
                        {
                            var currentResultListTwoFlat = new List<double>();
                            var currentFineTwoFlat = 0.0;
                            var currentListTwoFlatEvenExcess = new List<double>(currentListTwoFlat);
                            currentListTwoFlatEvenExcess.Remove(newListForTwoFlat[jndex]);
                            for (var i = 0; i < currentListTwoFlatEvenExcess.Count; i = i + 4)
                            {
                                currentFineTwoFlat +=
                                    Math.Round(
                                        currentListTwoFlatEvenExcess[i + 3] - currentListTwoFlatEvenExcess[i] +
                                        (currentListTwoFlatEvenExcess[i + 3] - currentListTwoFlatEvenExcess[i + 1]) +
                                        (currentListTwoFlatEvenExcess[i + 3] - currentListTwoFlatEvenExcess[i + 2]), 1);
                                currentResultListTwoFlat.Add(currentListTwoFlatEvenExcess[i + 3]);
                            }
                            if (currentFineTwoFlat < totalFineTwoFlatWithExcessData)
                            {
                                totalFineTwoFlatWithExcessData = Math.Round(currentFineTwoFlat, 1);
                                totalResultListTwoFlat = currentResultListTwoFlat;
                                if (excessListOneValue.Count != 0)
                                {
                                    excessListOneValue.RemoveAt(0);
                                    excessListOneValue.RemoveAt(0);
                                }
                                excessListOneValue.Add(newListForTwoFlat[index]);
                                excessListOneValue.Add(newListForTwoFlat[jndex]);
                            }
                        }
                    }
                    totalListsTwoFlatForFloor.AddRange(totalResultListTwoFlat);
                    excessDataTwoFlat.AddRange(excessListOneValue);
                }
            }
            resultList.Add(excessOneFlatFlag ? totalListsOneFlatForFloor : resultListOneFlat);
            resultList.Add(excessTwoFlatFlag ? totalListsTwoFlatForFloor : resultListTwoFlat);
            fineOneFlat = excessOneFlatFlag ? totalFineOneFlatWithExcessData : fineOneFlat;
            fineTwoFlat = excessTwoFlatFlag ? totalFineTwoFlatWithExcessData : fineTwoFlat;
            var totalFine = Math.Round(fineOneFlat + fineTwoFlat, 1);
            resultList.Add(totalFine);
            resultList.Add(excessDataOneFlat);
            resultList.Add(excessDataTwoFlat);
            return resultList;
        }
    }
}
