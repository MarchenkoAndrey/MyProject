using System.Collections.Generic;

namespace Resettlement
{
    public class ResultDataAfterGrouping
    {
        public List<double> ListResultOneFlat;
        public List<double> ListResultTwoFlat;
        public double Fine;
        public List<double> ListExcessOneFlat;
        public List<double> ListExcessTwoFlat;

        public ResultDataAfterGrouping(List<double> list1, List<double> list2, double fine, List<double> list4,
            List<double> list5)
        {
            ListResultOneFlat = list1;
            ListResultTwoFlat = list2;
            Fine = fine;
            ListExcessOneFlat = list4;
            ListExcessTwoFlat = list5;
        }

        public ResultDataAfterGrouping()
        {
        }
    }
}
