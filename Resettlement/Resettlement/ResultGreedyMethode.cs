using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resettlement
{
    public class ResultGreedyMethode
    {
        public double Fine;
        public double[] FinalPlaceOneFlat;
        public double[] FinalPlaceTwoFlat;
        public List<double> ListLenOneFlat;
        public List<double> ListLengthTBA;
        public double NewFirstOneFlat;

        public ResultGreedyMethode()
        {
        }

        public ResultGreedyMethode(double fine, double[] list1, double[] list2, List<double> list3,
            List<double> list4, double newFirstA)
        {
            Fine = fine;
            FinalPlaceOneFlat = list1;
            FinalPlaceTwoFlat = list2;
            ListLenOneFlat = list3;
            ListLengthTBA = list4;
            NewFirstOneFlat = newFirstA;
        }
    }
}
