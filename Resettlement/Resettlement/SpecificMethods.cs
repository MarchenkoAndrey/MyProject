using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resettlement
{
    class SpecificMethods
    {
        //TODO specific
        //            dataAlgorithm.ListSquaresOneBedroomApartmentBringingToMin = Calculate.BringingToMin(dataAlgorithm.ListSquaresOneBedroomApartment, Constraints.MinSquareOneBedroomApartment);
        //            dataAlgorithm.ListSquaresTwoBedroomApartmentBringingToMin = Calculate.BringingToMin(dataAlgorithm.ListSquaresTwoBedroomApartment, Constraints.MinSquareTwoBedroomApartment);
        //            dataAlgorithm.ListSquaresThreeBedroomApartmentBringingToMin = Calculate.BringingToMin(dataAlgorithm.ListSquaresThreeBedroomApartment, Constraints.MinSquareThreeBedroomApartment);

        //            dataAlgorithm.SumSquaresAfterBrindingToMin = Calculate.CalculateSumList(dataAlgorithm.ListSquaresOneBedroomApartmentBringingToMin) +
        //                Calculate.CalculateSumList(dataAlgorithm.ListSquaresTwoBedroomApartmentBringingToMin) +
        //                Calculate.CalculateSumList(dataAlgorithm.ListSquaresThreeBedroomApartmentBringingToMin);

        //            dataAlgorithm.ListSquaresOneBedroomApartmentBringingToMin.OrderBy(value=>value);
        //            dataAlgorithm.ListSquaresTwoBedroomApartmentBringingToMin.OrderBy(value => value);
        //            dataAlgorithm.ListSquaresThreeBedroomApartmentBringingToMin.OrderBy(value => value);

        //анализ общей площади 
        //            dataAlgorithm.TotalCountSections = (int)Math.Ceiling(dataAlgorithm.SumSquaresOriginal/Constraints.MaxSquareSection);

        //сделать группировку
        //            var gr1 = new Grouping();
        //            var gr2 = new Grouping();
        //            var gr3 = new Grouping();
        //            gr1.ListApartmentGrouping = dataAlgorithm.ListSquaresOneBedroomApartmentBringingToMin;
        //            gr2.ListApartmentGrouping = dataAlgorithm.ListSquaresTwoBedroomApartmentBringingToMin;
        //            gr3.ListApartmentGrouping = dataAlgorithm.ListSquaresThreeBedroomApartmentBringingToMin;
        //            gr1 = Grouping(dataAlgorithm.TotalCountSections, gr1);
        //            gr2 = Grouping(dataAlgorithm.TotalCountSections, gr2);
        //            gr3 = Grouping(dataAlgorithm.TotalCountSections, gr3);

        //        private static Grouping Grouping(int totalCountSections, Grouping gr)   // countfloor = 4
        //        {
        //            var it = Constraints.CountFloor - 1;
        //            for (var i = 0; i <= gr.ListApartmentGrouping.Count() / totalCountSections; ++i)
        //            {
        //                gr.SumFineAfterGrouping +=
        //                    (gr.ListApartmentGrouping[it] - gr.ListApartmentGrouping[it - 3]) +
        //                    (gr.ListApartmentGrouping[it] - gr.ListApartmentGrouping[it - 2]) +
        //                    (gr.ListApartmentGrouping[it] - gr.ListApartmentGrouping[it - 1]);
        //                gr.BringingListApartmentGrouping.Add(gr.ListApartmentGrouping[it]);
        //                it += Constraints.CountFloor;
        //            }
        //            for (var j = (gr.ListApartmentGrouping.Count / totalCountSections + 1) * Constraints.CountFloor;
        //                j < gr.ListApartmentGrouping.Count;
        //                ++j)
        //            {
        //                gr.ListSquaresBedroomApartmentNotGrouping.Add(gr.ListApartmentGrouping[j]);
        //            }
        //            return gr;
        //        }
    }
}
