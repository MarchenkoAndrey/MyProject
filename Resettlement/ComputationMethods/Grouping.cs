using System.Collections.Generic;
using System.Linq.Expressions;
using ComputationMethods.GeneralData;

namespace ComputationMethods
{
    public class Grouping
    {
        public double TotalCountSections;
        public IEnumerable<double> ListApartmentGrouping;
        public IEnumerable<double> BringingListApartmentGrouping;
        public double SumFineAfterGrouping;
        public IEnumerable<double> ListSquaresBedroomApartmentNotGrouping;
    }
}
