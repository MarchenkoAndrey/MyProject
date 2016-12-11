using System;
using System.Collections.Generic;

namespace Resettlement
{
    public class DataInnerGrouping
    {
        public double FineOneFlat { get; set; }
        public double FineTwoFlat { get; set; }
        public List<double> ListResultOneFlat { get; set; }
        public List<double> ListResultTwoFlat { get; set; }
        public List<double> ListExcessOneFlat { get; set; }
        public List<double> ListExcessTwoFlat { get; set; }
        public int OptimalCountFlat { get; private set; }
        public double TotalFineOneFlatExcess { get; set; }
        public double TotalFineTwoFlatExcess { get; set; }

        public DataInnerGrouping(DataAlgorithm data)
        {
            FineOneFlat = 0.0;
            FineTwoFlat = 0.0;
            TotalFineOneFlatExcess = double.MaxValue;
            TotalFineTwoFlatExcess = double.MaxValue;
            OptimalCountFlat = _calculateOptimalNumberFlat(data.ListLenOneFlat.Count, data.ListLenTwoFlat.Count,
                data.CountFloor);
            ListResultOneFlat = new List<double>();
            ListResultTwoFlat = new List<double>();
        }

        private readonly Func<int, int, int, int> _calculateOptimalNumberFlat =
                (countOneFlat, countTwoFlat, countFloor) =>
                        Math.Min(countOneFlat / countFloor * countFloor, countTwoFlat / countFloor * countFloor);


    }
}
