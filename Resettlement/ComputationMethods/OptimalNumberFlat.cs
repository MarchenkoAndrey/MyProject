using System;
using System.Collections.Generic;

namespace ComputationMethods
{
    //Todo Удалить, оставив Func
    public static class OptimalNumberFlat
    {
        public static int CalculateOptimalNumberFlat(List<double> listOneFlat,
            List<double> listTwoFlat, int countFloor)
        {
            return Math.Min(listOneFlat.Count / countFloor * countFloor,
                listTwoFlat.Count / countFloor * countFloor);
        }
    }
}