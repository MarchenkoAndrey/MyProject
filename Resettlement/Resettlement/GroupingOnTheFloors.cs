using System.Collections.Generic;

namespace Resettlement
{
    static class GroupingOnTheFloors
    {
        public static List<object> GroupingTwoFloors(List<double> listlengthsOneRoomFlats, List<double> listlengthsTwoRoomFlats)
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

            if (sortedListOneFlat.Count%2 == 0)
            {
                for (var i = 0; i < sortedListOneFlat.Count; i = i + 2)
                {
                    fineOneFlat+=sortedListOneFlat[i + 1] - sortedListOneFlat[i];
                    newListOneFlat.Add(sortedListOneFlat[i+1]);
                }
            }
            if (sortedListTwoFlat.Count % 2 == 0)
            {
                for (var i = 0; i < sortedListTwoFlat.Count; i = i + 2)
                {
                    fineTwoFlat += sortedListTwoFlat[i + 1] - sortedListTwoFlat[i];
                    newListTwoFlat.Add(sortedListTwoFlat[i + 1]);
                }
            }
            totalFine = fineOneFlat + fineTwoFlat;
            resultList.Add(newListOneFlat);
            resultList.Add(newListTwoFlat);
            resultList.Add(totalFine);
            return resultList;
        }

        public static List<double> GroupingThreeFloors(List<double> listlengthsOneRoomFlats, List<double> listlengthsTwoRoomFlats)
        {
            var resultList = new List<double>();
            return resultList;
        }
    }
}
