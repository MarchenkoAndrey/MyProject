using System.Collections.Generic;

namespace Resettlement
{
    public class DataHeuristicAlgorithm
    {
        public List<double> ListLenOneFlat { get; set; }
        public List<double> ListLenTwoFlat { get; set; }
        public double FineAfterGrouping { get; set; }

        public DataHeuristicAlgorithm(List<double> listLenOneFlat, List<double> listLenTwoFlat)
        {
            ListLenOneFlat = listLenOneFlat;
            ListLenTwoFlat = listLenTwoFlat;
            FineAfterGrouping = 0.0;
        }
    }
}
