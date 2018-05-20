using System.Collections.Generic;
using System.Linq;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    public class Anomaly
    {
        public Flat Flat { get; set; }
        public string Reason { get; set; }
        public Anomaly(Flat flat, string reason)
        {
            Flat = flat;
            Reason = reason;
        }
    }

    public class AnomalySearch
    {
        public static List<Anomaly> FindAnomaly(List<Flat> listFlat)
        {
            var listSquares = Flat.ReceiveListSquares(listFlat);
            listSquares.Sort();

            var hyp1 = FindBiggerFlat(listSquares);

            //по площадям ищем квартиры
            var cur = new List<Flat>();
            foreach (var elem in hyp1)
            {
               cur = listFlat.Where(a => Equals(a.CastSquare, elem)).Take(1).ToList();
            }

            //по квартирам строим список аномалий
            var result = new List<Anomaly>();
            foreach (var elem in cur)
            {
                result.Add(new Anomaly(elem, MessagesText.AnomalyBiggerFlat));
            }
            return result;
        }
        public static List<double> FindBiggerFlat(List<double> listFlat)
        {
            var findAnomal = listFlat.Where(a => a > Constraints.MinSquareTwoApartment-Constraints.SquareBalcony).ToList();
            var averageAnomal = findAnomal.Sum() / findAnomal.Count;
            var resultAnomal = findAnomal.Where(a => a > averageAnomal + 2).ToList();
            return new List<double>(resultAnomal);
        }
    }
}
