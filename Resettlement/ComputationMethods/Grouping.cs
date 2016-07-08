using System.Collections.Generic;
using System.Linq.Expressions;
using ComputationMethods.GeneralData;

namespace ComputationMethods
{
    public class Grouping
    {
        public double TotalCountSections;
        public List<double> ListApartmentGrouping;
        public List<double> BringingListApartmentGrouping = new List<double>();
        public double SumFineAfterGrouping;
        public List<double> ListSquaresBedroomApartmentNotGrouping = new List<double>();
    }
}
