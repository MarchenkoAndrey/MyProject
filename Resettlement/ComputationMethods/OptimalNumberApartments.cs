using System;
using System.Collections.Generic;

namespace ComputationMethods
{
    public static class OptimalNumberApartments
    {
        public static int CalculateOptimalNumberApartments(List<double> listSortAscOneFlat,
            List<double> listSortAscTwoFlat, int countFloor)
        {
            return Math.Min(listSortAscOneFlat.Count / countFloor * countFloor,
                listSortAscTwoFlat.Count / countFloor * countFloor);
        }
    }
}