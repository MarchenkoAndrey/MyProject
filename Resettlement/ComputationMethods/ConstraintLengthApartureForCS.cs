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
            double[] temporalArrayTwoBedroomApartment;
            Array.Copy(j, temporalArrayTwoBedroomApartment = new double[j.Length], j.Length);
            var currentFineFirstFloor = 0.0;
            var listSquareSectionsTwoBedroomApartment = new List<double>();
            var listSquareSectionsOneBedroomApartment = new List<double>();
            var listResult = new List<object>();

            for (var k = 0; k < j.Length; k = k + 2)
            {
                if (temporalArrayTwoBedroomApartment[k] - i[k] < Constraints.ApartureLength)
                {
                    var leftAddition = Constraints.ApartureLength - (temporalArrayTwoBedroomApartment[k] - i[k]);
                    if (leftAddition <= step)
                    {
                        temporalArrayTwoBedroomApartment[k] += Math.Round(step, 1);
                        currentFineFirstFloor += Math.Round(step, 1);
                    }
                    else
                    {
                        temporalArrayTwoBedroomApartment[k] += Math.Round(Math.Ceiling(leftAddition / step) * step, 1);
                        currentFineFirstFloor += Math.Round(Math.Ceiling(leftAddition / step) * step, 1);
                    }
                }
                if (temporalArrayTwoBedroomApartment[k + 1] - i[k + 1] < Constraints.ApartureLength)
                {
                    var rightAddition = Constraints.ApartureLength -
                                        (temporalArrayTwoBedroomApartment[k + 1] - i[k + 1]);
                    if (rightAddition <= step)
                    {
                        temporalArrayTwoBedroomApartment[k + 1] +=
                            Math.Round(step, 1);
                        currentFineFirstFloor += Math.Round(step, 1);
                    }
                    else
                    {
                        temporalArrayTwoBedroomApartment[k + 1] += Math.Round(Math.Ceiling(rightAddition / step) * step, 1);
                        currentFineFirstFloor += Math.Round(Math.Ceiling(rightAddition / step) * step, 1);
                    }
                }
                listSquareSectionsOneBedroomApartment.Add(Math.Round(i[k] + i[k + 1] + entryway + 3 * step, 1));
                listSquareSectionsTwoBedroomApartment.Add(
                    Math.Round(temporalArrayTwoBedroomApartment[k] + temporalArrayTwoBedroomApartment[k + 1] + 2 * step, 1));
                // delta1 + delta2
            }
            listResult.Add(listSquareSectionsOneBedroomApartment);
            listResult.Add(listSquareSectionsTwoBedroomApartment);
            listResult.Add(currentFineFirstFloor);
            listResult.Add(temporalArrayTwoBedroomApartment);

            return listResult;
        }
    }
}
