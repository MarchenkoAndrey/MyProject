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
            var excessDataOneFlat = new List<double>();
            var excessDataTwoFlat = new List<double>(); // квартиры, которые не попали в список 
            var totalListsOneFlatForFloor = new List<double>();
            var totalListsTwoFlatForFloor = new List<double>();
            var totalFineLists = new List<double>();
           
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
                for (var k = listCount-1; k < listCount;++k)
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
                    totalListsOneFlatForFloor.AddRange(newListOneFlat);
                    fineListsOneFlat.Add(fineOneFlat);
                    excessDataOneFlat.AddRange(currentList);
                    newListOneFlat = new List<double>();
                    fineOneFlat = 0.0;
                    //break;                      // берем только 1 список
                }
            }
            totalFineLists.AddRange(fineListsOneFlat);
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
                    totalListsTwoFlatForFloor.AddRange(newListTwoFlat);
                    fineListsTwoFlat.Add(fineTwoFlat);
                    excessDataTwoFlat.AddRange(currentList);
                    newListTwoFlat = new List<double>();
                    fineTwoFlat = 0.0;
                    break;          //Берем только 1 список
                }
            }

            totalFineLists.AddRange(fineListsTwoFlat);
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
            
            var totalFine = Math.Round(fineOneFlat + fineTwoFlat, 1);
            resultList.Add(totalFine);
            resultList.Add(excessDataOneFlat);
            resultList.Add(excessDataTwoFlat);
            return resultList;
        }

        //Todo 3 floor

        public static List<object> GroupingThreeFloors(List<double> listLengthsOneRoomFlats, List<double> listLengthsTwoRoomFlats)
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
            var optimalCountFlat = Math.Min(sortedListOneFlat.Count / 3 * 3, sortedListTwoFlat.Count / 3 * 3);
            var fineListsOneFlat = new List<double>();
            var fineListsTwoFlat = new List<double>();
            var excessDataOneFlat = new List<double>();
            var excessDataTwoFlat = new List<double>(); // квартиры, которые не попали в список 
            var totalListsOneFlatForFloor = new List<double>();
            var totalListsTwoFlatForFloor = new List<double>();
            var totalFineLists = new List<double>();

            if (sortedListOneFlat.Count == optimalCountFlat)
            {
                for (var i = 0; i < sortedListOneFlat.Count; i = i + 3)
                {
                    fineOneFlat = Math.Round(fineOneFlat + (sortedListOneFlat[i + 2] - sortedListOneFlat[i]) + (sortedListOneFlat[i + 2] - sortedListOneFlat[i + 1]), 1);
                    newListOneFlat.Add(sortedListOneFlat[i + 2]);
                }

            }
            else
            {
                oneFlag = false;
                var listCount = sortedListOneFlat.Count - optimalCountFlat + 1;
                for (var k = listCount - 1; k < listCount; ++k)
                {
                    var currentList = new List<double>(sortedListOneFlat);

                    //временный cписок, удаляя все значения взятые в список, оставшийся и есть лишний
                    for (var i = k; sortedListOneFlat.Count - i > 1; i = i + 3)
                    {
                        fineOneFlat += Math.Round(fineOneFlat + (sortedListOneFlat[i + 2] - sortedListOneFlat[i]) + (sortedListOneFlat[i + 2] - sortedListOneFlat[i + 1]), 1);
                        newListOneFlat.Add(sortedListOneFlat[i + 2]);
                        currentList.Remove(sortedListOneFlat[i + 2]);
                        currentList.Remove(sortedListOneFlat[i + 1]);
                        currentList.Remove(sortedListOneFlat[i]);
                    }
                    totalListsOneFlatForFloor.AddRange(newListOneFlat);
                    fineListsOneFlat.Add(fineOneFlat);
                    excessDataOneFlat.AddRange(currentList);
                    newListOneFlat = new List<double>();
                    fineOneFlat = 0.0;
                    //break;                      // берем только 1 список
                }
            }
            totalFineLists.AddRange(fineListsOneFlat);
            if (sortedListTwoFlat.Count == optimalCountFlat)
            {
                for (var i = 0; i < sortedListTwoFlat.Count; i = i + 3)
                {
                    fineTwoFlat = Math.Round(fineTwoFlat + (sortedListTwoFlat[i + 2] - sortedListTwoFlat[i]) + (sortedListTwoFlat[i + 2] - sortedListTwoFlat[i + 1]), 1);
                    newListTwoFlat.Add(sortedListTwoFlat[i + 2]);
                }
            }
            else
            {
                twoFlag = false;
                var listCount = sortedListTwoFlat.Count - optimalCountFlat + 1;
                for (var k = 0; k < listCount; ++k)
                {
                    var currentList = new List<double>(sortedListTwoFlat);

                    for (var i = k; sortedListTwoFlat.Count - i > 1; i = i + 3)
                    {
                        fineTwoFlat += Math.Round(fineTwoFlat + (sortedListTwoFlat[i + 2] - sortedListTwoFlat[i]) + (sortedListTwoFlat[i + 2] - sortedListTwoFlat[i + 1]), 1); ;
                        newListTwoFlat.Add(sortedListTwoFlat[i + 2]);
                        currentList.Remove(sortedListTwoFlat[i + 2]);
                        currentList.Remove(sortedListTwoFlat[i + 1]);
                        currentList.Remove(sortedListTwoFlat[i]);
                    }
                    totalListsTwoFlatForFloor.AddRange(newListTwoFlat);
                    fineListsTwoFlat.Add(fineTwoFlat);
                    excessDataTwoFlat.AddRange(currentList);
                    newListTwoFlat = new List<double>();
                    fineTwoFlat = 0.0;
                    break;          //Берем только 1 список
                }
            }

            totalFineLists.AddRange(fineListsTwoFlat);
            resultList.Add(oneFlag ? newListOneFlat : totalListsOneFlatForFloor);
            resultList.Add(twoFlag ? newListTwoFlat : totalListsTwoFlatForFloor);

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
            var newListOneFlat = new List<double>();
            var newListTwoFlat = new List<double>();

            //данные для нескольких списков - лишние квартиры
            var oneFlag = true;
            var twoFlag = true;
            var optimalCountFlat = Math.Min(sortedListOneFlat.Count / 4 * 4, sortedListTwoFlat.Count / 4 * 4);
            var fineListsOneFlat = new List<double>();
            var fineListsTwoFlat = new List<double>();
            var excessDataOneFlat = new List<double>();
            var excessDataTwoFlat = new List<double>(); // квартиры, которые не попали в список 
            var totalListsOneFlatForFloor = new List<double>();
            var totalListsTwoFlatForFloor = new List<double>();
            var totalFineLists = new List<double>();

            if (sortedListOneFlat.Count == optimalCountFlat)
            {
                for (var i = 0; i < sortedListOneFlat.Count; i = i + 4)
                {
                    fineOneFlat = Math.Round(fineOneFlat + (sortedListOneFlat[i + 3] - sortedListOneFlat[i]) + 
                        (sortedListOneFlat[i + 3] - sortedListOneFlat[i + 1]) + (sortedListOneFlat[i + 3] - sortedListOneFlat[i + 2]), 1);
                    newListOneFlat.Add(sortedListOneFlat[i + 3]);
                }

            }
            else
            {
                oneFlag = false;
                var listCount = sortedListOneFlat.Count - optimalCountFlat + 1;
                for (var k = listCount - 1; k < listCount; ++k)
                {
                    var currentList = new List<double>(sortedListOneFlat);

                    //временный cписок, удаляя все значения взятые в список, оставшийся и есть лишний
                    for (var i = k; sortedListOneFlat.Count - i > 1; i = i + 4)
                    {
                        fineOneFlat += Math.Round(fineOneFlat + (sortedListOneFlat[i + 3] - sortedListOneFlat[i]) +
                        (sortedListOneFlat[i + 3] - sortedListOneFlat[i + 1]) + (sortedListOneFlat[i + 3] - sortedListOneFlat[i + 2]), 1);
                        newListOneFlat.Add(sortedListOneFlat[i + 3]);
                        currentList.Remove(sortedListOneFlat[i + 3]);
                        currentList.Remove(sortedListOneFlat[i + 2]);
                        currentList.Remove(sortedListOneFlat[i + 1]);
                        currentList.Remove(sortedListOneFlat[i]);
                    }
                    totalListsOneFlatForFloor.AddRange(newListOneFlat);
                    fineListsOneFlat.Add(fineOneFlat);
                    excessDataOneFlat.AddRange(currentList);
                    newListOneFlat = new List<double>();
                    fineOneFlat = 0.0;
                    //break;                      // берем только 1 список
                }
            }
            totalFineLists.AddRange(fineListsOneFlat);
            if (sortedListTwoFlat.Count == optimalCountFlat)
            {
                for (var i = 0; i < sortedListTwoFlat.Count; i = i + 4)
                {
                    fineTwoFlat = Math.Round(fineTwoFlat + (sortedListTwoFlat[i + 3] - sortedListTwoFlat[i])
                        + (sortedListTwoFlat[i + 3] - sortedListTwoFlat[i + 1]) + (sortedListTwoFlat[i + 3] - sortedListTwoFlat[i + 2]), 1);
                    newListTwoFlat.Add(sortedListTwoFlat[i + 3]);
                }
            }
            else
            {
                twoFlag = false;
                var listCount = sortedListTwoFlat.Count - optimalCountFlat + 1;
                for (var k = 0; k < listCount; ++k)
                {
                    var currentList = new List<double>(sortedListTwoFlat);

                    for (var i = k; sortedListTwoFlat.Count - i > 1; i = i + 4)
                    {
                        fineTwoFlat += Math.Round(fineTwoFlat + (sortedListTwoFlat[i + 3] - sortedListTwoFlat[i])
                            + (sortedListTwoFlat[i + 3] - sortedListTwoFlat[i + 1]) + (sortedListTwoFlat[i + 3] - sortedListTwoFlat[i + 2]), 1);
                        newListTwoFlat.Add(sortedListTwoFlat[i + 3]);
                        currentList.Remove(sortedListTwoFlat[i + 3]);
                        currentList.Remove(sortedListTwoFlat[i + 2]);
                        currentList.Remove(sortedListTwoFlat[i + 1]);
                        currentList.Remove(sortedListTwoFlat[i]);
                    }
                    totalListsTwoFlatForFloor.AddRange(newListTwoFlat);
                    fineListsTwoFlat.Add(fineTwoFlat);
                    excessDataTwoFlat.AddRange(currentList);
                    newListTwoFlat = new List<double>();
                    fineTwoFlat = 0.0;
                    break;          //Берем только 1 список
                }
            }

            totalFineLists.AddRange(fineListsTwoFlat);
            resultList.Add(oneFlag ? newListOneFlat : totalListsOneFlatForFloor);
            resultList.Add(twoFlag ? newListTwoFlat : totalListsTwoFlatForFloor);

            var totalFine = Math.Round(fineOneFlat + fineTwoFlat, 1);
            resultList.Add(totalFine);
            resultList.Add(excessDataOneFlat);
            resultList.Add(excessDataTwoFlat);
            return resultList;
        }



        /*

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
         * */
    }
}
