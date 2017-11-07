using System.Collections.Generic;

namespace Resettlement
{
    public class DataPerformAlgorithm
    {
        public List<double> ListLenOneFlat { get; set; }
        public List<double> ListLenTwoFlat { get; set; }
        public double FineAfterGrouping { get; set; }
        
        public DataPerformAlgorithm(List<double> listLenOneFlat, List<double> listLenTwoFlat, double fine)
        {
            ListLenOneFlat = listLenOneFlat;
            ListLenTwoFlat = listLenTwoFlat;
            FineAfterGrouping = fine;
        }

        public DataPerformAlgorithm()
        {
            ListLenOneFlat = new List<double>();
            ListLenTwoFlat = new List<double>();
            FineAfterGrouping = 0.0;
        }

        // исключительно для тестов
        public DataPerformAlgorithm(List<double> listLenOneFlat, List<double> listLenTwoFlat)
        {
            ListLenOneFlat = listLenOneFlat;
            ListLenTwoFlat = listLenTwoFlat;
            FineAfterGrouping = 0.0;
        }
    }
}
