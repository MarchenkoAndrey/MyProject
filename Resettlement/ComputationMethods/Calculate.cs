using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputationMethods
{
    //Todo Specific
    #region Specific
    public static class Calculate
    {
        public static double CalculateSumList(IEnumerable<double> list)
        {
            return list.Aggregate(0.0, (current, elem) => Math.Round(current + elem, 2));
        }

        public static List<double> BringingToMin(IEnumerable<double> list, double min)
        {
            return list.Select(elem => elem < min ? min : elem).ToList();
        }
    }
    

#endregion
}
