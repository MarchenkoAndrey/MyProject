using System;
using System.Collections.Generic;

namespace Resettlement
{
    public static class GroupingOnTheFloors
    {
        private static DataInnerGrouping GeneralMethodGroup(int optCountF, int countFloor, List<double> listLenFlat, bool isOneFlat)
        {
            var dataInGrouping = new DataInnerGrouping();
            
            if (listLenFlat.Count == optCountF)
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
                var exceedValuesCount = listLenFlat.Count - optCountF;
                var countExceedValuesMoreTwo = exceedValuesCount;
                var listAfterConversionTwoValues = new List<double>();
                if (exceedValuesCount > 2)
                {
                    countExceedValuesMoreTwo -= 2;
                    if (isOneFlat)
                    {
                        for (var index = 0; index < countExceedValuesMoreTwo; ++index)
                        {
                            dataInGrouping.ListExcessFlat.Add(listLenFlat[index]);
                        }
                        for (var index = countExceedValuesMoreTwo; index < listLenFlat.Count; ++index)
                        {
                            listAfterConversionTwoValues.Add(listLenFlat[index]);
                        }
                    }
                    else
                    {
                        for (var index = 0; index < listLenFlat.Count - countExceedValuesMoreTwo; ++index)
                        {
                            listAfterConversionTwoValues.Add(listLenFlat[index]);
                        }
                        for (var index = listLenFlat.Count - countExceedValuesMoreTwo; index < listLenFlat.Count; ++index)
                        {
                            dataInGrouping.ListExcessFlat.Add(listLenFlat[index]);
                        }
                    }
                    countExceedValuesMoreTwo = 2; // Если мы заходим в >2, то 100% лишних остается 2
                }

                var listFlatForCalculate = listAfterConversionTwoValues.Count != 0
                    ? listAfterConversionTwoValues
                    : listLenFlat;

                if (countExceedValuesMoreTwo == 1)
                {
                    var listExceedValue = new List<double>();
                    foreach (var index in listFlatForCalculate)
                    {
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
                            if (listExceedValue.Count != 0)
                            {
                                listExceedValue.RemoveAt(0);
                            }
                            listExceedValue.Add(index);
                        }
                    }
                    dataInGrouping.ListExcessFlat.AddRange(listExceedValue);
                }
                else // countExceedValuesMoreTwo == 2
                {
                    var listExceedValue = new List<double>();
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

                            if (!(curData.CurrentFineFlat < dataInGrouping.TotalFineFlatExcess)) continue;
                            dataInGrouping.TotalFineFlatExcess = Math.Round(curData.CurrentFineFlat, 1);
                            dataInGrouping.ListResultFlat = curData.CurrentResultListFlat;
                            if (listExceedValue.Count != 0)
                            {
                                listExceedValue.RemoveAt(0);
                                listExceedValue.RemoveAt(0);
                            }
                            listExceedValue.Add(listFlatForCalculate[index]);
                            listExceedValue.Add(listFlatForCalculate[jndex]);
                        }
                    }
                    dataInGrouping.ListExcessFlat.AddRange(listExceedValue);
                }
            }
            return dataInGrouping;
        }

        public static ResultDataAfterGrouping GroupingFlat(InputDataAlg data)
        {         
            data.ListLenOneFlat.Sort();
            data.ListLenTwoFlat.Sort();

            var resultOneFlat = GeneralMethodGroup(data.OptCountFlat, data.CountFloor, data.ListLenOneFlat, true);
            var resultTwoFlat = GeneralMethodGroup(data.OptCountFlat, data.CountFloor, data.ListLenTwoFlat, false);

            //Todo rewrite!
            resultOneFlat.FineFlat = Math.Abs(resultOneFlat.FineFlat) < 1e-9 ? resultOneFlat.TotalFineFlatExcess : resultOneFlat.FineFlat;
            resultTwoFlat.FineFlat = Math.Abs(resultTwoFlat.FineFlat) < 1e-9 ? resultTwoFlat.TotalFineFlatExcess : resultTwoFlat.FineFlat;
            var totalFine = Math.Round(resultOneFlat.FineFlat + resultTwoFlat.FineFlat, 1);

            return new ResultDataAfterGrouping(resultOneFlat.ListResultFlat, resultTwoFlat.ListResultFlat,
                totalFine, resultOneFlat.ListExcessFlat, resultTwoFlat.ListExcessFlat);
        }

        private static Tuple<double, List<double>> EqualCountFlat(List<double> listFlat, double fineFlat,
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
