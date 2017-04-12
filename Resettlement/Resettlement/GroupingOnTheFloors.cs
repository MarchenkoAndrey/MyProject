using System;
using System.Collections.Generic;

namespace Resettlement
{
    public static class GroupingOnTheFloors
    {
        private static DataInnerGrouping CalculateGroupingFlat(int optCountFlat, int countFloor, List<double> listFlat, bool isOneFlat)
        {
            var dataInGrouping = new DataInnerGrouping();
            
            if (listFlat.Count == optCountFlat)
            {
                var resultTuple = EqualCountFlat(listFlat, dataInGrouping.FineFlat,
                    dataInGrouping.ListResultFlat, countFloor);
                dataInGrouping.FineFlat = resultTuple.Item1;
                dataInGrouping.ListResultFlat = resultTuple.Item2;
                dataInGrouping.TotalFineFlatExcess = 0.0;
            }
            else
            {
                // Если лишних >2, то для однушек удаляем самые маленькие квартиры, для двушек самые большие
                var totalExcessValuesCount = listFlat.Count - optCountFlat;
                var countExcessValuesMoreTwo = totalExcessValuesCount-2; // сколько лишних квартир сверх числа 2.
                var countExcessValuesLessTwo = totalExcessValuesCount > 2
                    ? totalExcessValuesCount - countExcessValuesMoreTwo
                    : totalExcessValuesCount;
                var listAfterConversionTwoValues = new List<double>();
                if (countExcessValuesMoreTwo > 0)
                {
                    // Флаг разделения ситуаций с однушками и двушками
                    if (isOneFlat)
                    {
                        for (var index = 0; index < listFlat.Count; ++index)
                        {
                            if (index < countExcessValuesMoreTwo)
                                dataInGrouping.ListExcessFlat.Add(listFlat[index]);
                            else
                                listAfterConversionTwoValues.Add(listFlat[index]);
                        }
                    }
                    else
                    {
                        for (var index = 0; index < listFlat.Count; ++index)
                        {
                            if (index < listFlat.Count - countExcessValuesMoreTwo)
                                listAfterConversionTwoValues.Add(listFlat[index]);
                            else
                                dataInGrouping.ListExcessFlat.Add(listFlat[index]);
                        }
                    }
                }

                var listFlatForCalculate = listAfterConversionTwoValues.Count != 0
                    ? listAfterConversionTwoValues
                    : listFlat;

                var listExcessValue = new List<double>();
                switch (countExcessValuesLessTwo)
                {
                    case 1:
                        foreach (var index in listFlatForCalculate)
                        {
                            var currentFineFlat = 0.0;
                            var currentResultListFlat = new List<double>();
                            var currentListFlat = new List<double>(listFlatForCalculate);
                            currentListFlat.Remove(index);
                        
                            var resultTuple = EqualCountFlat(currentListFlat, currentFineFlat,
                                currentResultListFlat, countFloor);
                            currentFineFlat = resultTuple.Item1;
                            currentResultListFlat = resultTuple.Item2;

                            if (currentFineFlat < dataInGrouping.TotalFineFlatExcess)
                            {
                                dataInGrouping.TotalFineFlatExcess = Math.Round(currentFineFlat, 1);
                                dataInGrouping.ListResultFlat = currentResultListFlat;
                                if (listExcessValue.Count != 0)
                                {
                                    listExcessValue.RemoveAt(0);
                                }
                                listExcessValue.Add(index);
                            }
                        }
                        break;
                   
                    case 2:
                        for (var index = 0; index < listFlatForCalculate.Count - 1; ++index)
                        {
                            var currentListFlat = new List<double>(listFlatForCalculate);
                            currentListFlat.Remove(listFlatForCalculate[index]);

                            for (var jndex = index + 1; jndex < listFlatForCalculate.Count; ++jndex)
                            {
                                var currentFineFlat = 0.0;
                                var currentResultListFlat = new List<double>();
                                var currentListFlatCopy = new List<double>(currentListFlat);
                                currentListFlatCopy.Remove(listFlatForCalculate[jndex]);                   
                                var resultTuple = EqualCountFlat(currentListFlatCopy, currentFineFlat,
                                    currentResultListFlat, countFloor);
                                currentFineFlat = resultTuple.Item1;
                                currentResultListFlat = resultTuple.Item2;

                                if (currentFineFlat < dataInGrouping.TotalFineFlatExcess)
                                {
                                    dataInGrouping.TotalFineFlatExcess = Math.Round(currentFineFlat, 1);
                                    dataInGrouping.ListResultFlat = currentResultListFlat;
                                    if (listExcessValue.Count != 0)
                                    {
                                        listExcessValue.RemoveAt(0);
                                        listExcessValue.RemoveAt(0);
                                    }
                                    listExcessValue.Add(listFlatForCalculate[index]);
                                    listExcessValue.Add(listFlatForCalculate[jndex]);
                                }
                            }
                        }
                        break;
                }
                dataInGrouping.ListExcessFlat.AddRange(listExcessValue);
            }
            return dataInGrouping;
        }

        public static ResultDataAfterGrouping GroupingFlat(InputDataAlg data)
        {         
            data.ListLenOneFlat.Sort();
            data.ListLenTwoFlat.Sort();

            var resultCalculateOneFlat = CalculateGroupingFlat(data.OptCountFlat, data.CountFloor, data.ListLenOneFlat, true);
            var resultCalculateTwoFlat = CalculateGroupingFlat(data.OptCountFlat, data.CountFloor, data.ListLenTwoFlat, false);
            var totalFine = CalculateTotalFine(resultCalculateOneFlat, resultCalculateTwoFlat);

            return new ResultDataAfterGrouping(resultCalculateOneFlat.ListResultFlat, resultCalculateTwoFlat.ListResultFlat,
                totalFine, resultCalculateOneFlat.ListExcessFlat, resultCalculateTwoFlat.ListExcessFlat);
        }

        private static double CalculateTotalFine(DataInnerGrouping resultOneFlat, DataInnerGrouping resultTwoFlat)
        {
            if (resultOneFlat.FineFlat < 0.1)
                resultOneFlat.FineFlat = resultOneFlat.TotalFineFlatExcess;
            if (resultTwoFlat.FineFlat < 0.1)
                resultTwoFlat.FineFlat = resultTwoFlat.TotalFineFlatExcess;
            return Math.Round(resultOneFlat.FineFlat + resultTwoFlat.FineFlat, 1);
        }

        private static Tuple<double, List<double>> EqualCountFlat(IReadOnlyList<double> listFlat, double fineFlat,
            List<double> resultListFlat, int countFloor)
        {
            for (var i = countFloor-1; i < listFlat.Count; i += countFloor)
            {
                for (var j = 1; j < countFloor; j++)
                {
                    fineFlat += Math.Round(listFlat[i] - listFlat[i - j], 1);
                }
                resultListFlat.Add(listFlat[i]);
            }
            return Tuple.Create(fineFlat, resultListFlat);
        }
    }
}
