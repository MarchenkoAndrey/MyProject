using System.Collections.Generic;

namespace Resettlement
{
    public class ResultGreedyMethode
    {
        public double Fine;
        public List<double> FinalPlaceOneFlat { get; private set; }
        public List<double> FinalPlaceTwoFlat { get; private set; }
        public List<double> ListLenExceedOneFlat { get; set; }
        public List<double> ListLenExceedTwoFlat { get; set; }
        public double NewFirstOneFlat { get; set; }
        public int NumIter { get; set; }
        public bool IsFlagFirstEntry { get; set; }

        public ResultGreedyMethode()
        {
            Fine = 0.0;
            ListLenExceedOneFlat = new List<double>();
            ListLenExceedTwoFlat = new List<double>();
            FinalPlaceOneFlat = new List<double>();
            FinalPlaceTwoFlat = new List<double>();
            NumIter = 0;
            IsFlagFirstEntry = true;
        }

        public ResultGreedyMethode(double max)
        {
            Fine = max;
            ListLenExceedOneFlat = new List<double>();
            ListLenExceedTwoFlat = new List<double>();
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
