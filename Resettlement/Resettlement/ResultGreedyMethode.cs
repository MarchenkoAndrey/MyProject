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
            Fine = 0.0;
            ListLenOneFlat = new List<double>();
            ListLenTwoFlat = new List<double>();
            FinalPlaceOneFlat = new List<double>();
            FinalPlaceTwoFlat = new List<double>();
            NumIter = 0;
        }

        public ResultGreedyMethode(double max)
        {
            Fine = max;
            ListLenOneFlat = new List<double>();
            ListLenTwoFlat = new List<double>();
            FinalPlaceOneFlat = new List<double>();
            FinalPlaceTwoFlat = new List<double>();
            NumIter = 0;
        }

        public ResultGreedyMethode(double fine, List<double> list1, List<double> list2, double newFirst)
        {
            Fine = fine;
            FinalPlaceOneFlat = list1;
            FinalPlaceTwoFlat = list2;
            NewFirstOneFlat = newFirst;
            NumIter = 0;
        }
    }
}
