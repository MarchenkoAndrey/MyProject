using System.Collections.Generic;

namespace Resettlement
{
    public class DataPerformAlgorithm
    {
        public List<double> ListLenOneFlat { get; set; }
        public List<double> ListLenTwoFlat { get; set; }
        public double FineAfterGrouping { get; set; }

        public DataPerformAlgorithm(List<double> listLenOneFlat, List<double> listLenTwoFlat)
        {
            ListLenOneFlat = listLenOneFlat;
            ListLenTwoFlat = listLenTwoFlat;
            FineAfterGrouping = 0.0;
        }
    }
}
