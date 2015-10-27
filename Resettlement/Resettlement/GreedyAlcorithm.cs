using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resettlement
{
	static class GreedyAlcorithm
	{
		public static List<object> GreedyMethode(List<double> newLengthOneFlat, List<double> newLengthTwoFlat, double step,
			double entryway)
		{
			var list = new List<object>();
			var newListOneFlat = InsertionSort.InsertSort(newLengthOneFlat);
			var newListTwoFlat = InsertionSort.InsertSort(newLengthTwoFlat);
			return list;
		}
	}
}
