using System;
using System.Collections.Generic;
using System.Linq;
using ComputationMethods;

namespace Resettlement
{
    public static class GroupingOnTheFloors
    {
        public static ResultDataAfterGrouping GroupingApartment(List<double> listLenOneFlat,
            List<double> listLenTwoFlat, int countFloor)
        {         
            var fineOneFlat = 0.0;
            var fineTwoFlat = 0.0;
            listLenOneFlat.Sort();
            listLenTwoFlat.Sort();
            var listResultOneFlat= new List<double>();
            var listResultTwoFlat = new List<double>();
            var listExcessOneFlat = new List<double>();
            var listExcessTwoFlat = new List<double>();
            var optimalCountApartment = OptimalNumberApartments.CalculateOptimalNumberApartments(listLenOneFlat,
                 listLenTwoFlat, countFloor);
            var totalFineOneBedroomApartmentBecauseExcessData = 1000.0;
            var totalFineTwoBedroomApartmentBecauseExcessData = 1000.0;

            if (listLenOneFlat.Count == optimalCountApartment)
            {
                EqualCountApartment(listLenOneFlat, fineOneFlat,
                   listResultOneFlat, countFloor, out fineOneFlat, out listResultOneFlat);
            }
            else
            {
                //as FS, all variants, to choice better
                var exceedValuesCount = listLenOneFlat.Count - optimalCountApartment;
                var countExceedValuesMoreTwo = exceedValuesCount;
                var listAfterConversionTwoValues = new List<double>();
                if (exceedValuesCount > 2)
                {
                    countExceedValuesMoreTwo = countExceedValuesMoreTwo - (exceedValuesCount - 2);
                    for (var index = 0; index < countExceedValuesMoreTwo; ++index)
                    {
                        listExcessOneFlat.Add(listLenOneFlat[index]);
                    }
                    for (var index = countExceedValuesMoreTwo; index < listLenOneFlat.Count; ++index)
                    {
                        listAfterConversionTwoValues.Add(listLenOneFlat[index]);
                    }
                }

                var listOneBedroomApartmentForCalculate = listAfterConversionTwoValues.Count != 0 ? listAfterConversionTwoValues : listLenOneFlat;

                if (countExceedValuesMoreTwo == 1)
                {
                    var listExceedOneValue = new List<double>();
                    foreach (var index in listOneBedroomApartmentForCalculate)
                    {
                        var currentResultListOneBedroomApartment = new List<double>();
                        var currentListOneBedroomApartment = new List<double>(listOneBedroomApartmentForCalculate);
                        var currentFineOneBedroomApartment = 0.0;
                        currentListOneBedroomApartment.Remove(index);
                        CalculateList(currentListOneBedroomApartment, currentFineOneBedroomApartment,
                            currentResultListOneBedroomApartment, countFloor,
                            out currentFineOneBedroomApartment, out currentResultListOneBedroomApartment);

                        if (currentFineOneBedroomApartment < totalFineOneBedroomApartmentBecauseExcessData)
                        {
                            totalFineOneBedroomApartmentBecauseExcessData = Math.Round(currentFineOneBedroomApartment, 1);
                            listResultOneFlat = currentResultListOneBedroomApartment;
                            if (listExceedOneValue.Count != 0)
                            {
                                listExceedOneValue.RemoveAt(0);
                            }
                            listExceedOneValue.Add(index);
                        }
                    }
                    listExcessOneFlat.AddRange(listExceedOneValue);
                }
                else // countExceedValuesMoreTwo == 2
                {
                    var listExceedOneValue = new List<double>();
                    for (var index = 0; index < listOneBedroomApartmentForCalculate.Count - 1; ++index)
                    {
                        var currentListOneBedroomApartment = new List<double>(listOneBedroomApartmentForCalculate);
                        currentListOneBedroomApartment.Remove(listOneBedroomApartmentForCalculate[index]);

                        for (var jndex = index + 1; jndex < listOneBedroomApartmentForCalculate.Count; ++jndex)
                        {
                            var currentResultListOneBedroomApartment = new List<double>();
                            var currentFineOneBedroomApartment = 0.0;
                            var currentListOneBedroomApartment1 = new List<double>(currentListOneBedroomApartment);
                            currentListOneBedroomApartment1.Remove(listOneBedroomApartmentForCalculate[jndex]);
                            CalculateList(currentListOneBedroomApartment1, currentFineOneBedroomApartment,
                           currentResultListOneBedroomApartment, countFloor,
                           out currentFineOneBedroomApartment, out currentResultListOneBedroomApartment);

                            if (currentFineOneBedroomApartment < totalFineOneBedroomApartmentBecauseExcessData)
                            {
                                totalFineOneBedroomApartmentBecauseExcessData = Math.Round(currentFineOneBedroomApartment, 1);
                                listResultOneFlat = currentResultListOneBedroomApartment;
                                if (listExceedOneValue.Count != 0)
                                {
                                    listExceedOneValue.RemoveAt(0);
                                    listExceedOneValue.RemoveAt(0);
                                }
                                listExceedOneValue.Add(listOneBedroomApartmentForCalculate[index]);
                                listExceedOneValue.Add(listOneBedroomApartmentForCalculate[jndex]);
                            }
                        }
                    }
                    listExcessOneFlat.AddRange(listExceedOneValue);
                }
            }
            if (listLenTwoFlat.Count == optimalCountApartment)
            {
                EqualCountApartment(listLenTwoFlat, fineTwoFlat,
                listResultTwoFlat, countFloor, out fineTwoFlat, out listResultTwoFlat);
            }
            else
            {
                //as FS, all variants, to choice better
                var exceedValuesCount = listLenTwoFlat.Count - optimalCountApartment;
                var countExceedValuesMoreTwo = exceedValuesCount;
                var listAfterConversionTwoValues = new List<double>();
                if (exceedValuesCount > 2)
                {
                    countExceedValuesMoreTwo = countExceedValuesMoreTwo - (exceedValuesCount - 2);
                    for (var index = 0; index < listLenTwoFlat.Count() - countExceedValuesMoreTwo; ++index)
                    {
                        listAfterConversionTwoValues.Add(listLenTwoFlat[index]);
                    }
                    for (var index = listLenTwoFlat.Count() - countExceedValuesMoreTwo; index < listLenTwoFlat.Count; ++index)
                    {
                        listExcessTwoFlat.Add(listLenTwoFlat[index]);
                    }
                }
                var listTwoBedroomApartmentForCalculate = listAfterConversionTwoValues.Count != 0 ? listAfterConversionTwoValues : listLenTwoFlat;

                if (countExceedValuesMoreTwo == 1)
                {
                    var excessListOneValue = new List<double>();
                    foreach (var index in listTwoBedroomApartmentForCalculate)
                    {
                        var currentResultListTwoBedroomApartment = new List<double>();
                        var currentListTwoBedroomApartment = new List<double>(listTwoBedroomApartmentForCalculate);
                        var currentFineTwoBedroomApartment = 0.0;
                        currentListTwoBedroomApartment.Remove(index);

                        CalculateList(currentListTwoBedroomApartment, currentFineTwoBedroomApartment,
                            currentResultListTwoBedroomApartment, countFloor,
                            out currentFineTwoBedroomApartment, out currentResultListTwoBedroomApartment);

                        if (currentFineTwoBedroomApartment < totalFineTwoBedroomApartmentBecauseExcessData)
                        {
                            totalFineTwoBedroomApartmentBecauseExcessData = Math.Round(currentFineTwoBedroomApartment, 1);
                            listResultTwoFlat = currentResultListTwoBedroomApartment;
                            if (excessListOneValue.Count != 0)
                            {
                                excessListOneValue.RemoveAt(0);
                            }
                            excessListOneValue.Add(index);
                        }
                    }
                    listExcessTwoFlat.AddRange(excessListOneValue);
                }
                else // countExceedValuesMoreTwo == 2
                {
                    var excessListOneValue = new List<double>();
                    for (var index = 0; index < listTwoBedroomApartmentForCalculate.Count - 1; ++index)
                    {
                        var currentListTwoBedroomApartment = new List<double>(listTwoBedroomApartmentForCalculate);
                        currentListTwoBedroomApartment.Remove(listTwoBedroomApartmentForCalculate[index]);

                        for (var jndex = index + 1; jndex < listTwoBedroomApartmentForCalculate.Count; ++jndex)
                        {
                            var currentResultListTwoBedroomApartment = new List<double>();
                            var currentFineTwoBedroomApartment = 0.0;
                            var currentListTwoBedroomApartment1 = new List<double>(currentListTwoBedroomApartment);
                            currentListTwoBedroomApartment1.Remove(listTwoBedroomApartmentForCalculate[jndex]);

                            CalculateList(currentListTwoBedroomApartment1, currentFineTwoBedroomApartment,
                           currentResultListTwoBedroomApartment, countFloor,
                           out currentFineTwoBedroomApartment, out currentResultListTwoBedroomApartment);

                            if (currentFineTwoBedroomApartment < totalFineTwoBedroomApartmentBecauseExcessData)
                            {
                                totalFineTwoBedroomApartmentBecauseExcessData = Math.Round(currentFineTwoBedroomApartment, 1);
                                listResultTwoFlat = currentResultListTwoBedroomApartment;
                                if (excessListOneValue.Count != 0)
                                {
                                    excessListOneValue.RemoveAt(0);
                                    excessListOneValue.RemoveAt(0);
                                }
                                excessListOneValue.Add(listTwoBedroomApartmentForCalculate[index]);
                                excessListOneValue.Add(listTwoBedroomApartmentForCalculate[jndex]);
                            }
                        }
                    }
                    listExcessTwoFlat.AddRange(excessListOneValue);
                }
            }
            fineOneFlat = Math.Abs(fineOneFlat) < 1e-9 ? totalFineOneBedroomApartmentBecauseExcessData : fineOneFlat;
            fineTwoFlat = Math.Abs(fineOneFlat) < 1e-9 ? totalFineTwoBedroomApartmentBecauseExcessData : fineTwoFlat;
            var totalFine = Math.Round(fineOneFlat + fineTwoFlat, 1);

            return new ResultDataAfterGrouping(listResultOneFlat,listResultTwoFlat,
                totalFine,listExcessOneFlat,listExcessTwoFlat);
        }

        public static void EqualCountApartment(List<double> listSortAscApartment, double fineApartment,
            List<double> listResultApartment, int countFloor, out double totalFineApartment, out List<double> totalListResultApartment)
        {
            switch (countFloor)
            {
                case 2:
                    for (var i = 0; i < listSortAscApartment.Count; i = i + 2)
                    {
                        fineApartment += Math.Round(listSortAscApartment[i + 1] - listSortAscApartment[i], 1);
                        listResultApartment.Add(listSortAscApartment[i + 1]);
                    }
                    break;
                case 3:
                    for (var i = 0; i < listSortAscApartment.Count; i = i + 3)
                    {
                        fineApartment +=
                            Math.Round(
                                listSortAscApartment[i + 2] - listSortAscApartment[i] +
                                (listSortAscApartment[i + 2] - listSortAscApartment[i + 1]), 1);
                        listResultApartment.Add(listSortAscApartment[i + 2]);
                    }
                    break;
                case 4:
                    for (var i = 0; i < listSortAscApartment.Count; i = i + 4)
                    {
                        fineApartment += Math.Round(listSortAscApartment[i + 3] - listSortAscApartment[i] +
                            (listSortAscApartment[i + 3] - listSortAscApartment[i + 1]) + (listSortAscApartment[i + 3] - listSortAscApartment[i + 2]), 1);
                        listResultApartment.Add(listSortAscApartment[i + 3]);
                    }
                    break;
                default:
//                    MessageBox.Show(ErrorsText.Error);
                    break;
            }
            totalFineApartment = fineApartment;
            totalListResultApartment = listResultApartment;
        }

        private static void CalculateList(List<double> currentListApartment, double currentFineApartment,
            List<double> currentResultListApartment, int countFloor, out double totalCurrentFineApartment, out List<double> totalCurrentResultListApartment)
        {
            switch (countFloor)
            {
                case 2:
                    for (var i = 0; i < currentListApartment.Count; i = i + 2)
                    {
                        currentFineApartment +=
                            Math.Round(currentListApartment[i + 1] - currentListApartment[i], 1);

                        currentResultListApartment.Add(currentListApartment[i + 1]);
                    }
                    break;
                case 3:
                    for (var i = 0; i < currentListApartment.Count; i = i + 3)
                    {
                        currentFineApartment +=
                            Math.Round(
                                currentListApartment[i + 2] - currentListApartment[i] +
                                (currentListApartment[i + 2] - currentListApartment[i + 1]), 1);

                        currentResultListApartment.Add(currentListApartment[i + 2]);
                    }
                    break;
                case 4:
                    for (var i = 0; i < currentListApartment.Count; i = i + 4)
                    {
                        currentFineApartment +=
                            Math.Round(
                                currentListApartment[i + 3] - currentListApartment[i] +
                                (currentListApartment[i + 3] - currentListApartment[i + 1]) +
                                (currentListApartment[i + 3] - currentListApartment[i + 2]), 1);

                        currentResultListApartment.Add(currentListApartment[i + 3]);
                    }
                    break;
                default:
//                    MessageBox.Show(ErrorsText.Error);
                    break;
            }
            totalCurrentFineApartment = currentFineApartment;
            totalCurrentResultListApartment = currentResultListApartment;
        }
    }
}
