using System.Collections.Generic;

namespace Resettlement
{
    public class DataInnerGrouping
    {
        public double FineFlat { get; set; }
        public List<double> ListResultFlat { get; set; }
        public List<double> ListExcessFlat { get; private set; }
        public double TotalFineFlatExcess { get; set; }

        public DataInnerGrouping()
        {
            FineFlat = 0.0;
            TotalFineFlatExcess = double.MaxValue;
            ListResultFlat = new List<double>();
            ListExcessFlat = new List<double>();
        }
    }
}
