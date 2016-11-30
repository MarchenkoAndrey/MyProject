using System;
using System.Collections.Generic;
using ComputationMethods.GeneralData;

namespace ComputationMethods
{
    public static class ConstraintLengthApartureForCS
    {
        //двигаем стены из-за ApartureLength
        public static List<object> LengthAparture(double[] i, double[] j, double step, double entryway)
        {
            double[] tempArrayTwoFlat;
            Array.Copy(j, tempArrayTwoFlat = new double[j.Length], j.Length);
            var currentFineFirstFloor = 0.0;
            var listSquareSectTwoFlat = new List<double>();
            var listSquareSectOneFlat = new List<double>();
            var listResult = new List<object>();

            for (var k = 0; k < j.Length; k = k + 2)
            {
                if (tempArrayTwoFlat[k] - i[k] < Constraints.ApartureLength)
                {
                    var leftAddition = Constraints.ApartureLength - (tempArrayTwoFlat[k] - i[k]);
                    if (leftAddition <= step)
                    {
                        tempArrayTwoFlat[k] += Math.Round(step, 1);
                        currentFineFirstFloor += Math.Round(step, 1);
                    }
                    else
                    {
                        tempArrayTwoFlat[k] += Math.Round(Math.Ceiling(leftAddition / step) * step, 1);
                        currentFineFirstFloor += Math.Round(Math.Ceiling(leftAddition / step) * step, 1);
                    }
                }
                if (tempArrayTwoFlat[k + 1] - i[k + 1] < Constraints.ApartureLength)
                {
                    var rightAddition = Constraints.ApartureLength -
                                        (tempArrayTwoFlat[k + 1] - i[k + 1]);
                    if (rightAddition <= step)
                    {
                        tempArrayTwoFlat[k + 1] +=
                            Math.Round(step, 1);
                        currentFineFirstFloor += Math.Round(step, 1);
                    }
                    else
                    {
                        tempArrayTwoFlat[k + 1] += Math.Round(Math.Ceiling(rightAddition / step) * step, 1);
                        currentFineFirstFloor += Math.Round(Math.Ceiling(rightAddition / step) * step, 1);
                    }
                }
                listSquareSectOneFlat.Add(Math.Round(i[k] + i[k + 1] + entryway + 3 * step, 1));
                listSquareSectTwoFlat.Add(
                    Math.Round(tempArrayTwoFlat[k] + tempArrayTwoFlat[k + 1] + 2 * step, 1));
                // delta1 + delta2
            }
            listResult.Add(listSquareSectOneFlat);
            listResult.Add(listSquareSectTwoFlat);
            listResult.Add(currentFineFirstFloor);
            listResult.Add(tempArrayTwoFlat);

            return listResult;
        }
    }
}
