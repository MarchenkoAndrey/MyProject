using System;
using System.Collections.Generic;

namespace Resettlement
{
    public class DataInnerGrouping
    {
        public double FineFlat { get; set; }
        public List<double> ListResultFlat { get; set; }
        public List<double> ListExcessFlat { get; set; }
        public double TotalFineFlatExcess { get; set; }
        private bool IsOneFlat { get; set; }

        public DataInnerGrouping(bool flag)
        {
            IsOneFlat = flag;
            FineFlat = 0.0;
            TotalFineFlatExcess = double.MaxValue;
            ListResultFlat = new List<double>();
            ListExcessFlat = new List<double>();
        }

        


    }
}
