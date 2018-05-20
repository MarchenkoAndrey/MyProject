using System.Collections.Generic;
using System.Linq;

namespace Resettlement
{
    public class SeverBiggerFlats
    {
        public static List<Flat> ToDefineBiggerFlats(List<Flat> listFlats, int countFloor)
        {
            var f = listFlats.OrderByDescending(a => a.CastSquare).ToList();

            var count = listFlats.Count % countFloor;
            var result = f.GetRange(0, countFloor + count).ToList();

            return result;
        }
        public static List<Flat> ToDeleteBiggerFlats(List<Flat> listFlats, List<Flat> listExcessFlats)
        {
            foreach (var elem in listExcessFlats)
            {
                listFlats.RemoveAll(a => a.Id == elem.Id);
            }
            return listFlats;
        }
    }
}