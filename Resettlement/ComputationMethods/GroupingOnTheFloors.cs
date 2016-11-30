using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputationMethods
{
    public static class GroupingOnTheFloors
    {
        public static List<object> GroupingApartment(List<double> listLengthsOneBedroomApartment,
            List<double> listLengthsTwoBedroomAppartment, int countFloor)
        {         
            var listResult = new List<object>();
            var fineOneBedroomApartment = 0.0;
            var fineTwoBedroomApartment = 0.0;
            listLengthsOneBedroomApartment.Sort();
            listLengthsTwoBedroomAppartment.Sort();
            var listResultOneBedroomApartment= new List<double>();
            var listResultTwoBedroomApartment = new List<double>();
            var listExcessDataOneBedroomApartment = new List<double>();
            var listExcessDataTwoBedroomApartment = new List<double>();
            var optimalCountApartment = OptimalNumberApartments.CalculateOptimalNumberApartments(listLengthsOneBedroomApartment,
                 listLengthsTwoBedroomAppartment, countFloor);
            var totalFineOneBedroomApartmentBecauseExcessData = 1000.0;
            var totalFineTwoBedroomApartmentBecauseExcessData = 1000.0;

            if (listLengthsOneBedroomApartment.Count == optimalCountApartment)
            {
                EqualCountApartment(listLengthsOneBedroomApartment, fineOneBedroomApartment,
                   listResultOneBedroomApartment, countFloor, out fineOneBedroomApartment, out listResultOneBedroomApartment);
            }
            else
            {
                //as FS, all variants, to choice better
                var exceedValuesCount = listLengthsOneBedroomApartment.Count - optimalCountApartment;
                var countExceedValuesMoreTwo = exceedValuesCount;
                var listAfterConversionTwoValues = new List<double>();
                if (exceedValuesCount > 2)
                {
                    countExceedValuesMoreTwo = countExceedValuesMoreTwo - (exceedValuesCount - 2);
                    for (var index = 0; index < countExceedValuesMoreTwo; ++index)
                    {
                        listExcessDataOneBedroomApartment.Add(listLengthsOneBedroomApartment[index]);
                    }
                    for (var index = countExceedValuesMoreTwo; index < listLengthsOneBedroomApartment.Count; ++index)
                    {
                        listAfterConversionTwoValues.Add(listLengthsOneBedroomApartment[index]);
                    }
                }

                var listOneBedroomApartmentForCalculate = listAfterConversionTwoValues.Count != 0 ? listAfterConversionTwoValues : listLengthsOneBedroomApartment;

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
                            listResultOneBedroomApartment = currentResultListOneBedroomApartment;
                            if (listExceedOneValue.Count != 0)
                            {
                                listExceedOneValue.RemoveAt(0);
                            }
                            listExceedOneValue.Add(index);
                        }
                    }
                    listExcessDataOneBedroomApartment.AddRange(listExceedOneValue);
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
                                listResultOneBedroomApartment = currentResultListOneBedroomApartment;
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
                    listExcessDataOneBedroomApartment.AddRange(listExceedOneValue);
                }
            }
            if (listLengthsTwoBedroomAppartment.Count == optimalCountApartment)
            {
                EqualCountApartment(listLengthsTwoBedroomAppartment, fineTwoBedroomApartment,
                listResultTwoBedroomApartment, countFloor, out fineTwoBedroomApartment, out listResultTwoBedroomApartment);
            }
            else
            {
                //as FS, all variants, to choice better
                var exceedValuesCount = listLengthsTwoBedroomAppartment.Count - optimalCountApartment;
                var countExceedValuesMoreTwo = exceedValuesCount;
                var listAfterConversionTwoValues = new List<double>();
                if (exceedValuesCount > 2)
                {
                    countExceedValuesMoreTwo = countExceedValuesMoreTwo - (exceedValuesCount - 2);
                    for (var index = 0; index < listLengthsTwoBedroomAppartment.Count() - countExceedValuesMoreTwo; ++index)
                    {
                        listAfterConversionTwoValues.Add(listLengthsTwoBedroomAppartment[index]);
                    }
                    for (var index = listLengthsTwoBedroomAppartment.Count() - countExceedValuesMoreTwo; index < listLengthsTwoBedroomAppartment.Count; ++index)
                    {
                        listExcessDataTwoBedroomApartment.Add(listLengthsTwoBedroomAppartment[index]);
                    }
                }
                var listTwoBedroomApartmentForCalculate = listAfterConversionTwoValues.Count != 0 ? listAfterConversionTwoValues : listLengthsTwoBedroomAppartment;

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
                            listResultTwoBedroomApartment = currentResultListTwoBedroomApartment;
                            if (excessListOneValue.Count != 0)
                            {
                                excessListOneValue.RemoveAt(0);
                            }
                            excessListOneValue.Add(index);
                        }
                    }
                    listExcessDataTwoBedroomApartment.AddRange(excessListOneValue);
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
                                listResultTwoBedroomApartment = currentResultListTwoBedroomApartment;
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
                    listExcessDataTwoBedroomApartment.AddRange(excessListOneValue);
                }
            }
            listResult.Add(listResultOneBedroomApartment);
            listResult.Add(listResultTwoBedroomApartment);
            fineOneBedroomApartment = Math.Abs(fineOneBedroomApartment) < 1e-9 ? totalFineOneBedroomApartmentBecauseExcessData : fineOneBedroomApartment;
            fineTwoBedroomApartment = Math.Abs(fineOneBedroomApartment) < 1e-9 ? totalFineTwoBedroomApartmentBecauseExcessData : fineTwoBedroomApartment;
            var totalFine = Math.Round(fineOneBedroomApartment + fineTwoBedroomApartment, 1);
            listResult.Add(totalFine);
            listResult.Add(listExcessDataOneBedroomApartment);
            listResult.Add(listExcessDataTwoBedroomApartment);
            return listResult;
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
