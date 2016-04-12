using System;
using System.Collections.Generic;

namespace Resettlement
{
    public static class OptimalNumberApartments
    {
        public static int CalculateOptimalNumberApartments(List<double> listSortAscOneBedroomApartment,
            List<double> listSortAscTwoBedroomApartment, int countFloor)
        {
            return Math.Min(listSortAscOneBedroomApartment.Count / countFloor * countFloor,
                listSortAscTwoBedroomApartment.Count / countFloor * countFloor);
        }
    }
}
