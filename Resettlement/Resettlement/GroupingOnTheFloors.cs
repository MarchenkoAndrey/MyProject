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
            var newListOneFlat = new List<double>();
            var newListTwoFlat = new List<double>();

            //данные для нескольких списков - лишние квартиры
            var oneFlag = true;
            var twoFlag = true;
            var optimalCountFlat = Math.Min(sortedListOneFlat.Count / 2 * 2, sortedListTwoFlat.Count / 2 * 2);
            var fineListsOneFlat = new List<double>();
            var fineListsTwoFlat = new List<double>();
            var excessDataOneFlat = new List<List<double>>();
            var excessDataTwoFlat = new List<List<double>>(); // квартиры, которые не попали в список 
            var totalListsOneFlatForFloor = new List<List<double>>();
            var totalListsTwoFlatForFloor = new List<List<double>>();
            var totalFineLists = new List<List<double>>();
           
            if (sortedListOneFlat.Count == optimalCountFlat)
            {
                for (var i = 0; i < sortedListOneFlat.Count; i = i + 2)
                {
                    fineOneFlat += Math.Round(sortedListOneFlat[i + 1] - sortedListOneFlat[i],1);
                    newListOneFlat.Add(sortedListOneFlat[i + 1]);
                }
            }
            else
            {
                oneFlag = false;
                var listCount = sortedListOneFlat.Count - optimalCountFlat + 1;
                for (var k = 0; k < listCount;++k)
                {
                    var currentList = new List<double>(sortedListOneFlat);

                    //временный cписок, удаляя все значения взятые в список, оставшийся и есть лишний
                    for (var i = k; sortedListOneFlat.Count - i > 1; i = i + 2)
                    {
                        fineOneFlat += Math.Round(sortedListOneFlat[i + 1] - sortedListOneFlat[i],1);
                        newListOneFlat.Add(sortedListOneFlat[i + 1]);
                        currentList.Remove(sortedListOneFlat[i+1]);
                        currentList.Remove(sortedListOneFlat[i]);
                    }
                    totalListsOneFlatForFloor.Add(newListOneFlat);
                    fineListsOneFlat.Add(fineOneFlat);
                    excessDataOneFlat.Add(currentList);
                    newListOneFlat = new List<double>();
                    fineOneFlat = 0.0;
                }
            }
            totalFineLists.Add(fineListsOneFlat);
            if (sortedListTwoFlat.Count == optimalCountFlat)
            {
                for (var i = 0; i < sortedListTwoFlat.Count; i = i + 2)
                {
                    fineTwoFlat += Math.Round(sortedListTwoFlat[i + 1] - sortedListTwoFlat[i],1);
                    newListTwoFlat.Add(sortedListTwoFlat[i + 1]);
                }
            }
            else
            {
                twoFlag = false;
                var listCount = sortedListTwoFlat.Count - optimalCountFlat+1;
                for (var k = 0; k < listCount; ++k)
                {
                    var currentList = new List<double>(sortedListTwoFlat);

                    for (var i = k; sortedListTwoFlat.Count- i > 1; i = i + 2)
                    {
                        fineTwoFlat += Math.Round(sortedListTwoFlat[i + 1] - sortedListTwoFlat[i],1);
                        newListTwoFlat.Add(sortedListTwoFlat[i + 1]);
                        currentList.Remove(sortedListTwoFlat[i + 1]);
                        currentList.Remove(sortedListTwoFlat[i]);
                    }
                    totalListsTwoFlatForFloor.Add(newListTwoFlat);
                    fineListsTwoFlat.Add(fineTwoFlat);
                    excessDataTwoFlat.Add(currentList);
                    newListTwoFlat = new List<double>();
                    fineTwoFlat = 0.0;
                }
            }

            totalFineLists.Add(fineListsTwoFlat);
            if (oneFlag)
            {    
                resultList.Add(newListOneFlat);
            }
            else
            {
                resultList.Add(totalListsOneFlatForFloor);
            }
            if (twoFlag)
            {
                resultList.Add(newListTwoFlat);
            }
            else
            {
                resultList.Add(totalListsTwoFlatForFloor);
            }
            if (oneFlag && twoFlag)
            {
                var totalFine = Math.Round(fineOneFlat + fineTwoFlat, 1);
                resultList.Add(totalFine);
            }
            else
            {
                resultList.Add(totalFineLists);
            }
            resultList.Add(excessDataOneFlat);
            resultList.Add(excessDataTwoFlat);
            return resultList;
        }

        public static List<object> GroupingThreeFloors(List<double> listlengthsOneRoomFlats, List<double> listlengthsTwoRoomFlats)
        {
            var resultList = new List<object>();
            var fineOneFlat = 0.0;
            var fineTwoFlat = 0.0;
            var totalFine = 0.0;
            var excessData = new List<double>();    // квартиры, которые не попали в список
            var sortedListOneFlat = InsertionSort.InsertSort(listlengthsOneRoomFlats);
            var sortedListTwoFlat = InsertionSort.InsertSort(listlengthsTwoRoomFlats);
            var newListOneFlat = new List<double>();
            var newListTwoFlat = new List<double>();

            if (sortedListOneFlat.Count % 3 == 0)
            {
                for (var i = 0; i < sortedListOneFlat.Count; i = i + 3)
                {
                    fineOneFlat = Math.Round(fineOneFlat + (sortedListOneFlat[i + 2] - sortedListOneFlat[i]) + (sortedListOneFlat[i + 2] - sortedListOneFlat[i+1]),1);
                    newListOneFlat.Add(sortedListOneFlat[i + 2]);
                }
            }
            if (sortedListTwoFlat.Count % 3 == 0)
            {
                for (var i = 0; i < sortedListTwoFlat.Count; i = i + 3)
                {
                    fineTwoFlat = Math.Round(fineTwoFlat + (sortedListTwoFlat[i + 2] - sortedListTwoFlat[i]) + (sortedListTwoFlat[i + 2] - sortedListTwoFlat[i+1]),1);
                    newListTwoFlat.Add(sortedListTwoFlat[i + 2]);
                }
            }
            totalFine = Math.Round(fineOneFlat + fineTwoFlat, 1);
            resultList.Add(newListOneFlat);
            resultList.Add(newListTwoFlat);
            resultList.Add(totalFine);
            return resultList;
        }
    }
}
