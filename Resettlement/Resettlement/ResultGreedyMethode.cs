using System.Collections.Generic;

namespace Resettlement
{
    public class ResultGreedyMethode
    {
        public double Fine;
        public List<double> FinalPlaceOneFlat { get; set; }
        public List<double> FinalPlaceTwoFlat { get; set; }
        public List<double> ListLenOneFlat { get; set; }
        public List<double> ListLenTwoFlat { get; set; }
        public double NewFirstOneFlat { get; set; }
        public int NumIter { get; set; }

        public ResultGreedyMethode()
        {
            Fine = double.MaxValue;
            ListLenOneFlat = new List<double>();
            ListLenTwoFlat = new List<double>();
            FinalPlaceOneFlat = new List<double>();
            FinalPlaceTwoFlat = new List<double>();
            NumIter = 0;
        }

        public ResultGreedyMethode(double fine, List<double> list1, List<double> list2, List<double> list3,
            List<double> list4, double newFirstA)
        {
            Fine = fine;
            FinalPlaceOneFlat = list1;
            FinalPlaceTwoFlat = list2;
            ListLenOneFlat = list3;
            ListLenTwoFlat = list4;
            NewFirstOneFlat = newFirstA;
            NumIter = 0;
        }
    }
}
