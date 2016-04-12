using System;
using System.Collections.Generic;

namespace Resettlement
{
    static class GroupingOnTheFloors
    {
        public static List<object> GroupingTwoFloors(List<double> listLengthsOneBedroomApartment,
            List<double> listLengthsTwoBedroomAppartment, int countFloor)
        {
            var listResult = new List<object>();
            var fineOneBedroomApartment = 0.0;
            var fineTwoBedroomApartment = 0.0;
            var listSortAscOneBedroomApartment = InsertionSort.InsertSort(listLengthsOneBedroomApartment);
            var listSortAscTwoBedroomApartment = InsertionSort.InsertSort(listLengthsTwoBedroomAppartment);
            var listResultOneBedroomApartment = new List<double>();
            var listResultTwoBedroomApartment = new List<double>();
            var listExcessDataOneBedroomApartment = new List<double>();
            var listExcessDataTwoBedroomApartment = new List<double>(); 
            var optimalCountApartment = CalculateOptimalNumberApartments(listSortAscOneBedroomApartment,
                listSortAscTwoBedroomApartment, countFloor);  
            var totalFineOneBedroomApartmentBecauseExcessData = 1000.0;
            var totalFineTwoBedroomApartmentBecauseExcessData = 1000.0;
            //var totalListOneBedroomApartmentForFloor = new List<double>();
            //var totalListTwoBedroomApartmentForFloor = new List<double>();
           
            if (listSortAscOneBedroomApartment.Count == optimalCountApartment)
            {
                for (var i = 0; i < listSortAscOneBedroomApartment.Count; i = i + 2)
                {
                    fineOneBedroomApartment +=Math.Round(listSortAscOneBedroomApartment[i + 1] - listSortAscOneBedroomApartment[i], 1);
                    listResultOneBedroomApartment.Add(listSortAscOneBedroomApartment[i + 1]);
                }
            }
            else
            {
                //as FS, all variants, to choice better
                var exceedValuesCount = listSortAscOneBedroomApartment.Count - optimalCountApartment;
                var countExceedValuesMoreTwo = exceedValuesCount;
                var listAfterConversionTwoValues = new List<double>();
                if (exceedValuesCount > 2)
                {
                    countExceedValuesMoreTwo = countExceedValuesMoreTwo - (exceedValuesCount - 2);
                    for (var index = 0; index < countExceedValuesMoreTwo; ++index)
                    {
                        listExcessDataOneBedroomApartment.Add(listSortAscOneBedroomApartment[index]);
                    }
                    for (var index = countExceedValuesMoreTwo; index < listSortAscOneBedroomApartment.Count; ++index)
                    {
                        listAfterConversionTwoValues.Add(listSortAscOneBedroomApartment[index]);
                    }
                }

                var listOneBedroomApartmentForCalculate = listAfterConversionTwoValues.Count != 0 ? listAfterConversionTwoValues: listSortAscOneBedroomApartment;
                //var totalResultListOneFlat = new List<double>();
               
                if (countExceedValuesMoreTwo == 1)
                {
                    var listExceedOneValue = new List<double>();
                    foreach (var index in listOneBedroomApartmentForCalculate)
                    {
                        var currentResultListOneBedroomApartment = new List<double>();
                        var currentListOneBedroomApartment = new List<double>(listOneBedroomApartmentForCalculate);
                        var currentFineOneBedroomApartment = 0.0;
                        currentListOneBedroomApartment.Remove(index);
                        for (var i = 0; i < currentListOneBedroomApartment.Count; i = i + 2)
                        {
                            currentFineOneBedroomApartment += Math.Round(currentListOneBedroomApartment[i + 1] - currentListOneBedroomApartment[i], 1);
                            currentResultListOneBedroomApartment.Add(currentListOneBedroomApartment[i + 1]);
                        }
                        if (currentFineOneBedroomApartment < totalFineOneBedroomApartmentBecauseExcessData)
                        {
                            totalFineOneBedroomApartmentBecauseExcessData = Math.Round(currentFineOneBedroomApartment,1);
                            listResultOneBedroomApartment=currentResultListOneBedroomApartment;
                            if (listExceedOneValue.Count != 0)
                            {
                                listExceedOneValue.RemoveAt(0);
                            }
                            listExceedOneValue.Add(index);
                        }
                    }
                    //totalListOneBedroomApartmentForFloor.AddRange(listResultOneBedroomApartment);
                    listExcessDataOneBedroomApartment.AddRange(listExceedOneValue);
                }
                else // newExcessValueCount == 2
                {
                    var listExceedOneValue = new List<double>();
                    for (var index = 0; index < listOneBedroomApartmentForCalculate.Count; ++index)
                    {
                        var currentListOneFlat = new List<double>(listOneBedroomApartmentForCalculate);
                        currentListOneFlat.Remove(listOneBedroomApartmentForCalculate[index]);
                       
                        for (var jndex = index + 1; jndex < listOneBedroomApartmentForCalculate.Count; ++jndex)
                        {
                            var currentResultListOneBedroomApartment = new List<double>();
                            var currentFineOneBedroomApartment = 0.0;
                            var currentListOneBedroomApartment = new List<double>(currentListOneFlat);
                            currentListOneBedroomApartment.Remove(listOneBedroomApartmentForCalculate[jndex]);
                            for (var i = 0; i < currentListOneBedroomApartment.Count; i = i + 2)
                            {
                                currentFineOneBedroomApartment += Math.Round(currentListOneBedroomApartment[i + 1] - currentListOneBedroomApartment[i], 1);
                                currentResultListOneBedroomApartment.Add(currentListOneBedroomApartment[i + 1]);
                            }
                            if (currentFineOneBedroomApartment < totalFineOneBedroomApartmentBecauseExcessData)
                            {
                                totalFineOneBedroomApartmentBecauseExcessData = Math.Round(currentFineOneBedroomApartment, 1);
                                listResultOneBedroomApartment = currentResultListOneBedroomApartment;
                                if (listExceedOneValue.Count != 0)
                                {
                                    listExceedOneValue.RemoveAt(0);
                                    listExceedOneValue.RemoveAt(0);
                                }
                                listExceedOneValue.Add(listOneBedroomApartmentForCalculate[index]);
                                listExceedOneValue.Add(listOneBedroomApartmentForCalculate[jndex]);
                            }
                        }
                    }
                    
                    //totalListOneBedroomApartmentForFloor.AddRange(totalResultListOneFlat);
                    listExcessDataOneBedroomApartment.AddRange(listExceedOneValue);
                }
            }
            if (listSortAscTwoBedroomApartment.Count == optimalCountApartment)
            {
                for (var i = 0; i < listSortAscTwoBedroomApartment.Count; i = i + 2)
                {
                    fineTwoBedroomApartment += Math.Round(listSortAscTwoBedroomApartment[i + 1] - listSortAscTwoBedroomApartment[i],1);
                    listResultTwoBedroomApartment.Add(listSortAscTwoBedroomApartment[i + 1]);
                }
            }
            else
            {
                //as FS, all variants, to choice better
                var exceedValuesCount = listSortAscTwoBedroomApartment.Count - optimalCountApartment;
                var countExceedValuesMoreTwo = exceedValuesCount;
                var listAfterConversionTwoValues = new List<double>();
                if (exceedValuesCount > 2)
                {
                    countExceedValuesMoreTwo = countExceedValuesMoreTwo - (exceedValuesCount - 2);
                    for (var index = 0; index < listSortAscTwoBedroomApartment.Count - countExceedValuesMoreTwo; ++index)
                    {
                        listAfterConversionTwoValues.Add(listSortAscTwoBedroomApartment[index]);
                    }
                    for (var index = listSortAscTwoBedroomApartment.Count - countExceedValuesMoreTwo; index < listSortAscTwoBedroomApartment.Count; ++index)
                    {
                        listExcessDataTwoBedroomApartment.Add(listSortAscTwoBedroomApartment[index]);
                    }
                }
                var listTwoBedroomApartmentForCalculate = listAfterConversionTwoValues.Count != 0 ? listAfterConversionTwoValues : listSortAscTwoBedroomApartment;

                if (countExceedValuesMoreTwo == 1)
                {
                    var excessListOneValue = new List<double>();
                    foreach (var index in listTwoBedroomApartmentForCalculate)
                    {
                        var currentResultListTwoBedroomApartment = new List<double>();
                        var currentListTwoBedroomApartment = new List<double>(listTwoBedroomApartmentForCalculate);
                        var currentFineTwoBedroomApartment = 0.0;
                        currentListTwoBedroomApartment.Remove(index);
                        for (var i = 0; i < currentListTwoBedroomApartment.Count; i = i + 2)
                        {
                            currentFineTwoBedroomApartment += Math.Round(currentListTwoBedroomApartment[i + 1] - currentListTwoBedroomApartment[i], 1);
                            currentResultListTwoBedroomApartment.Add(currentListTwoBedroomApartment[i + 1]);
                        }
                        if (currentFineTwoBedroomApartment < totalFineTwoBedroomApartmentBecauseExcessData)
                        {
                            totalFineTwoBedroomApartmentBecauseExcessData = Math.Round(currentFineTwoBedroomApartment, 1);
                            listResultTwoBedroomApartment = currentResultListTwoBedroomApartment;
                            if (excessListOneValue.Count != 0)
                            {
                                excessListOneValue.RemoveAt(0);
                            }
                            excessListOneValue.Add(index);
                        }
                    }
                    //totalListTwoBedroomApartmentForFloor.AddRange(listResultTwoBedroomApartment);
                    listExcessDataTwoBedroomApartment.AddRange(excessListOneValue);
                }
                else // newExcessValueCount == 2
                {
                    var excessListOneValue = new List<double>();
                    for (var index = 0; index < listTwoBedroomApartmentForCalculate.Count; ++index)
                    {
                        var currentListTwoFlat = new List<double>(listTwoBedroomApartmentForCalculate);
                        currentListTwoFlat.Remove(listTwoBedroomApartmentForCalculate[index]);

                        for (var jndex = index + 1; jndex < listTwoBedroomApartmentForCalculate.Count; ++jndex)
                        {
                            var currentResultListTwoFlat = new List<double>();
                            var currentFineTwoFlat = 0.0;
                            var currentListTwoFlatEvenExcess = new List<double>(currentListTwoFlat);
                            currentListTwoFlatEvenExcess.Remove(listTwoBedroomApartmentForCalculate[jndex]);
                            for (var i = 0; i < currentListTwoFlatEvenExcess.Count; i = i + 2)
                            {
                                currentFineTwoFlat += Math.Round(currentListTwoFlatEvenExcess[i + 1] - currentListTwoFlatEvenExcess[i], 1);
                                currentResultListTwoFlat.Add(currentListTwoFlatEvenExcess[i + 1]);
                            }
                            if (currentFineTwoFlat < totalFineTwoBedroomApartmentBecauseExcessData)
                            {
                                totalFineTwoBedroomApartmentBecauseExcessData = Math.Round(currentFineTwoFlat, 1);
                                listResultTwoBedroomApartment = currentResultListTwoFlat;
                                if (excessListOneValue.Count != 0)
                                {
                                    excessListOneValue.RemoveAt(0);
                                    excessListOneValue.RemoveAt(0);
                                }
                                excessListOneValue.Add(listTwoBedroomApartmentForCalculate[index]);
                                excessListOneValue.Add(listTwoBedroomApartmentForCalculate[jndex]);
                            }
                        }
                    }
                    //totalListTwoBedroomApartmentForFloor.AddRange(totalResultListTwoFlat);
                    listExcessDataTwoBedroomApartment.AddRange(excessListOneValue);
                }
            }
            listResult.Add(listResultOneBedroomApartment);
            listResult.Add(listResultTwoBedroomApartment);
            fineOneBedroomApartment = Math.Abs(fineOneBedroomApartment) < 0.1 ? totalFineOneBedroomApartmentBecauseExcessData : fineOneBedroomApartment;
            fineTwoBedroomApartment = Math.Abs(fineOneBedroomApartment) < 0.1 ? totalFineTwoBedroomApartmentBecauseExcessData : fineTwoBedroomApartment;
            var totalFine = Math.Round(fineOneBedroomApartment + fineTwoBedroomApartment, 1);
            listResult.Add(totalFine);
            listResult.Add(listExcessDataOneBedroomApartment);
            listResult.Add(listExcessDataTwoBedroomApartment);
            return listResult;
        }

        private static int CalculateOptimalNumberApartments(List<double> listSortAscOneBedroomApartment,
            List<double> listSortAscTwoBedroomApartment, int countFloor)
        {
            return Math.Min(listSortAscOneBedroomApartment.Count/countFloor*countFloor,
                listSortAscTwoBedroomApartment.Count/countFloor*countFloor);
        }

        public static List<object> GroupingOneBedroomApartment(List<double> listSortAscOneBedroomApartment, int optimalCountApartment,
            double fineOneBedroomApartment, List<double> listResultOneBedroomApartment,
            List<double> listExcessDataOneBedroomApartment, double totalFineOneBedroomApartmentBecauseExcessData, int countFloor)
        {
            var listResult = new List<object>();
            if (listSortAscOneBedroomApartment.Count == optimalCountApartment)
            {
                for (var i = 0; i < listSortAscOneBedroomApartment.Count; i = i + 2)
                {
                    fineOneBedroomApartment += Math.Round(listSortAscOneBedroomApartment[i + 1] - listSortAscOneBedroomApartment[i], 1);
                    listResultOneBedroomApartment.Add(listSortAscOneBedroomApartment[i + 1]);
                }
            }
            else
            {
                //as FS, all variants, to choice better
                //flagIsExcessOneBedroomApartment = true;
                var exceedValuesCount = listSortAscOneBedroomApartment.Count - optimalCountApartment;
                var countExceedValuesMoreTwo = exceedValuesCount;
                var listAfterConversionTwoValues = new List<double>();
                if (exceedValuesCount > 2)
                {
                    countExceedValuesMoreTwo = countExceedValuesMoreTwo - (exceedValuesCount - 2);
                    for (var index = 0; index < countExceedValuesMoreTwo; ++index)
                    {
                        listExcessDataOneBedroomApartment.Add(listSortAscOneBedroomApartment[index]);
                    }
                    for (var index = countExceedValuesMoreTwo; index < listSortAscOneBedroomApartment.Count; ++index)
                    {
                        listAfterConversionTwoValues.Add(listSortAscOneBedroomApartment[index]);
                    }
                }

                var listOneBedroomApartmentForCalculate = listAfterConversionTwoValues.Count != 0 ? listAfterConversionTwoValues : listSortAscOneBedroomApartment;
                //var totalResultListOneFlat = new List<double>();

                if (countExceedValuesMoreTwo == 1)
                {
                    var listExceedOneValue = new List<double>();
                    foreach (var index in listOneBedroomApartmentForCalculate)
                    {
                        var currentResultListOneBedroomApartment = new List<double>();
                        var currentListOneBedroomApartment = new List<double>(listOneBedroomApartmentForCalculate);
                        var currentFineOneBedroomApartment = 0.0;
                        currentListOneBedroomApartment.Remove(index);
                        for (var i = 0; i < currentListOneBedroomApartment.Count; i = i + 2)
                        {
                            currentFineOneBedroomApartment += Math.Round(currentListOneBedroomApartment[i + 1] - currentListOneBedroomApartment[i], 1);
                            currentResultListOneBedroomApartment.Add(currentListOneBedroomApartment[i + 1]);
                        }
                        if (currentFineOneBedroomApartment < totalFineOneBedroomApartmentBecauseExcessData)
                        {
                            totalFineOneBedroomApartmentBecauseExcessData = Math.Round(currentFineOneBedroomApartment, 1);
                            listResultOneBedroomApartment = currentResultListOneBedroomApartment;
                            if (listExceedOneValue.Count != 0)
                            {
                                listExceedOneValue.RemoveAt(0);
                            }
                            listExceedOneValue.Add(index);
                        }
                    }
                    listExcessDataOneBedroomApartment.AddRange(listExceedOneValue);
                }
                else // newExcessValueCount == 2
                {
                    var listExceedOneValue = new List<double>();
                    for (var index = 0; index < listOneBedroomApartmentForCalculate.Count; ++index)
                    {
                        var currentListOneFlat = new List<double>(listOneBedroomApartmentForCalculate);
                        currentListOneFlat.Remove(listOneBedroomApartmentForCalculate[index]);

                        for (var jndex = index + 1; jndex < listOneBedroomApartmentForCalculate.Count; ++jndex)
                        {
                            var currentResultListOneBedroomApartment = new List<double>();
                            var currentFineOneBedroomApartment = 0.0;
                            var currentListOneBedroomApartment = new List<double>(currentListOneFlat);
                            currentListOneBedroomApartment.Remove(listOneBedroomApartmentForCalculate[jndex]);
                            for (var i = 0; i < currentListOneBedroomApartment.Count; i = i + 2)
                            {
                                currentFineOneBedroomApartment += Math.Round(currentListOneBedroomApartment[i + 1] - currentListOneBedroomApartment[i], 1);
                                currentResultListOneBedroomApartment.Add(currentListOneBedroomApartment[i + 1]);
                            }
                            if (currentFineOneBedroomApartment < totalFineOneBedroomApartmentBecauseExcessData)
                            {
                                totalFineOneBedroomApartmentBecauseExcessData = Math.Round(currentFineOneBedroomApartment, 1);
                                listResultOneBedroomApartment = currentResultListOneBedroomApartment;
                                if (listExceedOneValue.Count != 0)
                                {
                                    listExceedOneValue.RemoveAt(0);
                                    listExceedOneValue.RemoveAt(0);
                                }
                                listExceedOneValue.Add(listOneBedroomApartmentForCalculate[index]);
                                listExceedOneValue.Add(listOneBedroomApartmentForCalculate[jndex]);
                            }
                        }
                    }
                    listExcessDataOneBedroomApartment.AddRange(listExceedOneValue);
                }
            }



            return listResult;
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
