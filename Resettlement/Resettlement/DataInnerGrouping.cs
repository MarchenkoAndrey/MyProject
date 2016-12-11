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
        public double TotalFineOneFlatExcess { get; set; }
        public double TotalFineTwoFlatExcess { get; set; }

        public DataInnerGrouping()
        {
            FineOneFlat = 0.0;
            FineTwoFlat = 0.0;
            TotalFineOneFlatExcess = double.MaxValue;
            TotalFineTwoFlatExcess = double.MaxValue;
            ListResultOneFlat = new List<double>();
            ListResultTwoFlat = new List<double>();
            ListExcessOneFlat = new List<double>();
            ListExcessTwoFlat = new List<double>();
        }

        


    }
}
