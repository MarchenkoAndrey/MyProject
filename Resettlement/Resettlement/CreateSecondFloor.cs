using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resettlement
{
    static class CreateSecondFloor
    {
        public static List<double[]> MethodeCreateSecondFloor(object optArrangeOne, object optArrangeTwo, double entryway, double step)
        {
            var optArrangeOneMas = (double[]) optArrangeOne;
            var optArrangeTwoMas = (double[]) optArrangeTwo;
            var result = new List<double[]>();
            var n = optArrangeOneMas.Length/2;
 
			var squareSectionsOneFlats = new List<double>();
            var squareSectionsTwoFlats = new List<double>();
			for (var i = 0; i < optArrangeOneMas.Length; i=i+2)
			{
				squareSectionsOneFlats.Add(Math.Round(optArrangeOneMas[i] + optArrangeOneMas[i + 1] + entryway + 3*step,1));
			}
            for (var j = 0; j < optArrangeTwoMas.Length; j=j+2)
            {
                squareSectionsTwoFlats.Add(Math.Round(optArrangeTwoMas[j] + optArrangeTwoMas[j + 1] + 2*step, 1));
            }

            for (var s = 0; s < squareSectionsOneFlats.Count; ++s)
            {
                var h = squareSectionsTwoFlats[s] - squareSectionsOneFlats[s]; 
            }

            return result;
        }
    }
}
