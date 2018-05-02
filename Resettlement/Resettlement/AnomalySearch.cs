using System.Collections.Generic;
using System.Linq;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    public class Anomaly
    {
        public double Value { get; set; }
        public string Reason { get; set; }
        public Anomaly(double value, string reason)
        {
            Value = value;
            Reason = reason;
        }
    }

    public class AnomalySearch
    {
        //Todo 1. Лишние однушки. 2. Выпирающие двушки

        public static List<Anomaly> FindAnomaly(List<double> listFlat, int countFloor)
        {
            var hypothesis1 = FindAnomalyWithOneFlat(listFlat, countFloor);
            var hypothesis2 = FindAnomalyWithBiggerTwoFlat(listFlat, countFloor);

            return new List<Anomaly>(hypothesis1);
        }

        public static List<Anomaly> FindAnomalyWithOneFlat(List<double> listFlat, int countFloor)
        {
            var countOneFlat = listFlat
                .Where(a => a < Constraints.MinSquareTwoApartment)
                .ToList()
                .Count;

            var diff = countOneFlat % countFloor;
            if (diff == 0)
            {
                //Нет однушек или однушки четко пилятся поровну по этажам
                return new List<Anomaly>();
            }

            //Todo вычленение аномалий из списка
            var an = new Anomaly(listFlat[0],"ExceedOneFlat");

            return new List<Anomaly>();
        }

        public static List<Anomaly> FindAnomalyWithBiggerTwoFlat(List<double> listFlat, int countFloor)
        {
            var findAnomal = listFlat.Where(a => a > Constraints.MinSquareTwoApartment).ToList();
            var averageAnomal = findAnomal.Sum() / findAnomal.Count;
            var resultAnomal = findAnomal.Where(a => a > averageAnomal + 2).ToList();
            return new List<Anomaly>();
        }
    }
}
