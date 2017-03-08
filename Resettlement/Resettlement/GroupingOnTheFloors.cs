using System;
using System.Collections.Generic;

namespace Resettlement
{
    public static class GroupingOnTheFloors
    {
        private static DataInnerGrouping CalculateGroupingFlat(int optCountFlat, int countFloor, List<double> listLenFlat, bool isOneFlat)
        {
            var dataInGrouping = new DataInnerGrouping();
            
            if (listLenFlat.Count == optCountFlat)
            {
                var resultTuple = EqualCountFlat(listLenFlat, dataInGrouping.FineFlat,
                    dataInGrouping.ListResultFlat, countFloor);
                dataInGrouping.FineFlat = resultTuple.Item1;
                dataInGrouping.ListResultFlat = resultTuple.Item2;
                dataInGrouping.TotalFineFlatExcess = 0.0;
            }
            else
            {
                // Если лишних >2, то для однушек удаляем самые маленькие квартиры, для двушек самые большие
                var totalExceedValuesCount = listLenFlat.Count - optCountFlat;
                var countExcessValuesMoreTwo = totalExceedValuesCount;
                var listAfterConversionTwoValues = new List<double>();
                if (totalExceedValuesCount > 2)
                {
                    countExcessValuesMoreTwo -= 2;
                    // Флаг разделения ситуаций с однушками и двушками
                    if (isOneFlat)
                    {
                        for (var index = 0; index < listLenFlat.Count; ++index)
                        {
                            if (index < countExcessValuesMoreTwo)
                                dataInGrouping.ListExcessFlat.Add(listLenFlat[index]);
                            else
                                listAfterConversionTwoValues.Add(listLenFlat[index]);
                        }
                    }
                    else
                    {
                        for (var index = 0; index < listLenFlat.Count; ++index)
                        {
                            if (index < listLenFlat.Count - countExcessValuesMoreTwo)
                                listAfterConversionTwoValues.Add(listLenFlat[index]);
                            else
                                dataInGrouping.ListExcessFlat.Add(listLenFlat[index]);
                        }
                    }
                    countExcessValuesMoreTwo = 2; // Если мы заходим в >2, то 100% остается в остатке 2.
                }

                //Todo What this??
                var listFlatForCalculate = listAfterConversionTwoValues.Count != 0
                    ? listAfterConversionTwoValues
                    : listLenFlat;

                var listExcessValue = new List<double>();
                switch (countExcessValuesMoreTwo)
                {
                    case 1:
                        foreach (var index in listFlatForCalculate)
                        {
                            //Todo rename
                            var curData = new TempData();
                            var currentListFlat = new List<double>(listFlatForCalculate);
                            currentListFlat.Remove(index);
                        
                            var resultTuple = EqualCountFlat(currentListFlat, curData.CurrentFineFlat,
                                curData.CurrentResultListFlat, countFloor);
                            curData.CurrentFineFlat = resultTuple.Item1;
                            curData.CurrentResultListFlat = resultTuple.Item2;

                            if (curData.CurrentFineFlat < dataInGrouping.TotalFineFlatExcess)
                            {
                                dataInGrouping.TotalFineFlatExcess = Math.Round(curData.CurrentFineFlat, 1);
                                dataInGrouping.ListResultFlat = curData.CurrentResultListFlat;
                                if (listExcessValue.Count != 0)
                                {
                                    listExcessValue.RemoveAt(0);
                                }
                                listExcessValue.Add(index);
                            }
                        }
                        dataInGrouping.ListExcessFlat.AddRange(listExcessValue);
                        break;
                   
                    case 2:
                        for (var index = 0; index < listFlatForCalculate.Count - 1; ++index)
                        {
                            var currentListFlat = new List<double>(listFlatForCalculate);
                            currentListFlat.Remove(listFlatForCalculate[index]);

                            for (var jndex = index + 1; jndex < listFlatForCalculate.Count; ++jndex)
                            {
                                var curData = new TempData();
                                var currentListFlat1 = new List<double>(currentListFlat);
                                currentListFlat1.Remove(listFlatForCalculate[jndex]);                   
                                var res = EqualCountFlat(currentListFlat1, curData.CurrentFineFlat,
                                    curData.CurrentResultListFlat, countFloor);
                                curData.CurrentFineFlat = res.Item1;
                                curData.CurrentResultListFlat = res.Item2;

                                if (curData.CurrentFineFlat < dataInGrouping.TotalFineFlatExcess)
                                {
                                    dataInGrouping.TotalFineFlatExcess = Math.Round(curData.CurrentFineFlat, 1);
                                    dataInGrouping.ListResultFlat = curData.CurrentResultListFlat;
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
                        dataInGrouping.ListExcessFlat.AddRange(listExcessValue);
                        break;
                }
            }
            return dataInGrouping;
        }

        public static ResultDataAfterGrouping GroupingFlat(InputDataAlg data)
        {         
            data.ListLenOneFlat.Sort();
            data.ListLenTwoFlat.Sort();

            var resultOneFlat = CalculateGroupingFlat(data.OptCountFlat, data.CountFloor, data.ListLenOneFlat, true);
            var resultTwoFlat = CalculateGroupingFlat(data.OptCountFlat, data.CountFloor, data.ListLenTwoFlat, false);
            var totalFine = CalculateTotalFine(resultOneFlat, resultTwoFlat);

            return new ResultDataAfterGrouping(resultOneFlat.ListResultFlat, resultTwoFlat.ListResultFlat,
                totalFine, resultOneFlat.ListExcessFlat, resultTwoFlat.ListExcessFlat);
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
