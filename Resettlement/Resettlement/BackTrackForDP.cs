using System.Collections.Generic;
using System.Linq;

namespace Resettlement
{
    public static class BackTrackForDynPr
    {
        public static List<Container> BackTracking(List<Container> listContainers)
        {
            var resultListContainer = new List<Container>();

            var lastContainer = listContainers.
                Where(z => z.ExceedListOneFlat.Count < 1).
                OrderBy(b => b.FineChain).
                First();

            while (lastContainer.ParentId != null)
            {
                resultListContainer.Add(lastContainer);
                lastContainer = listContainers.
                    Where(a => a.Id == lastContainer.ParentId).
                    Take(1).
                    First();
            }
            // в правильном порядке
            resultListContainer.Reverse();
            return resultListContainer;
        }
    }
}
