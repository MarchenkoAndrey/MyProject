using System;
using System.Collections.Generic;

namespace Resettlement
{
    public static class GroupingOnTheFloors
    {
        public static ResultDataAfterGrouping GroupingApartment(DataAlgorithm data)
        {         
            data.ListLenOneFlat.Sort();
            data.ListLenTwoFlat.Sort();
            var dataInGrouping = new DataInnerGrouping(data);

            if (data.ListLenOneFlat.Count == dataInGrouping.OptimalCountFlat)
            {
                var res = EqualCountFlat(data.ListLenOneFlat, dataInGrouping.FineOneFlat,
                   dataInGrouping.ListResultOneFlat, data.CountFloor);
                dataInGrouping.FineOneFlat = res.Item1;
                dataInGrouping.ListResultOneFlat = res.Item2;
            }
            else
            {
                //as FS, all variants, to choice better
                // Если лишних больше 2, то для однокомнатных удаляем самые маленькие квартиры
                var exceedValuesCount = data.ListLenOneFlat.Count - dataInGrouping.OptimalCountFlat;
                var countExceedValuesMoreTwo = exceedValuesCount;
                var listAfterConversionTwoValues = new List<double>();
                if (exceedValuesCount > 2)
                {
                    countExceedValuesMoreTwo = countExceedValuesMoreTwo - (exceedValuesCount - 2);
                    for (var index = 0; index < countExceedValuesMoreTwo; ++index)
                    {
                        dataInGrouping.ListExcessOneFlat.Add(data.ListLenOneFlat[index]);
                    }
                    for (var index = countExceedValuesMoreTwo; index < data.ListLenOneFlat.Count; ++index)
                    {
                        listAfterConversionTwoValues.Add(data.ListLenOneFlat[index]);
                    }
                }

                var listOneFlatForCalculate = listAfterConversionTwoValues.Count != 0 ? listAfterConversionTwoValues : data.ListLenOneFlat;

                if (countExceedValuesMoreTwo == 1)
                {
                    var listExceedOneValue = new List<double>();
                    foreach (var index in listOneFlatForCalculate)
                    {
                        var curData = new TempData();
                        //var currentResultListOneFlat = new List<double>();
                        var currentListOneFlat = new List<double>(listOneFlatForCalculate);
                        //var currentFineOneFlat = 0.0;
                        currentListOneFlat.Remove(index);
                        var res = EqualCountFlat(currentListOneFlat, curData.CurrentFineFlat,
                            curData.CurrentResultListFlat, data.CountFloor);
                        curData.CurrentFineFlat = res.Item1;
                        curData.CurrentResultListFlat = res.Item2;

                        if (curData.CurrentFineFlat < dataInGrouping.TotalFineOneFlatExcess)
                        {
                            dataInGrouping.TotalFineOneFlatExcess = Math.Round(curData.CurrentFineFlat, 1);
                            dataInGrouping.ListResultOneFlat = curData.CurrentResultListFlat;
                            if (listExceedOneValue.Count != 0)
                            {
                                listExceedOneValue.RemoveAt(0);
                            }
                            listExceedOneValue.Add(index);
                        }
                    }
                    dataInGrouping.ListExcessOneFlat.AddRange(listExceedOneValue);
                }
                else // countExceedValuesMoreTwo == 2
                {
                    var listExceedOneValue = new List<double>();
                    for (var index = 0; index < listOneFlatForCalculate.Count - 1; ++index)
                    {
                        var currentListOneFlat = new List<double>(listOneFlatForCalculate);
                        currentListOneFlat.Remove(listOneFlatForCalculate[index]);

                        for (var jndex = index + 1; jndex < listOneFlatForCalculate.Count; ++jndex)
                        {
                            var curData = new TempData();
                            var currentListOneFlat1 = new List<double>(currentListOneFlat);
                            currentListOneFlat1.Remove(listOneFlatForCalculate[jndex]);
                            var res = EqualCountFlat(currentListOneFlat1, curData.CurrentFineFlat,
                                curData.CurrentResultListFlat, data.CountFloor);
                            curData.CurrentFineFlat = res.Item1;
                            curData.CurrentResultListFlat = res.Item2;

                            if (!(curData.CurrentFineFlat < dataInGrouping.TotalFineOneFlatExcess)) continue;
                            dataInGrouping.TotalFineOneFlatExcess = Math.Round(curData.CurrentFineFlat, 1);
                            dataInGrouping.ListResultOneFlat = curData.CurrentResultListFlat;
                            if (listExceedOneValue.Count != 0)
                            {
                                listExceedOneValue.RemoveAt(0);
                                listExceedOneValue.RemoveAt(0);
                            }
                            listExceedOneValue.Add(listOneFlatForCalculate[index]);
                            listExceedOneValue.Add(listOneFlatForCalculate[jndex]);
                        }
                    }
                    dataInGrouping.ListExcessOneFlat.AddRange(listExceedOneValue);
                }
            }
            
            // для двушек
            if (data.ListLenTwoFlat.Count == dataInGrouping.OptimalCountFlat)
            {
                EqualCountFlat(data.ListLenTwoFlat, dataInGrouping.FineTwoFlat,
                dataInGrouping.ListResultTwoFlat, data.CountFloor);
            }
            else
            {
                //as FS, all variants, to choice better
                var exceedValuesCount = data.ListLenTwoFlat.Count - dataInGrouping.OptimalCountFlat;
                var countExceedValuesMoreTwo = exceedValuesCount;
                var listAfterConversionTwoValues = new List<double>();
                if (exceedValuesCount > 2)
                {
                    countExceedValuesMoreTwo = countExceedValuesMoreTwo - (exceedValuesCount - 2);
                    for (var index = 0; index < data.ListLenTwoFlat.Count - countExceedValuesMoreTwo; ++index)
                    {
                        listAfterConversionTwoValues.Add(data.ListLenTwoFlat[index]);
                    }
                    for (var index = data.ListLenTwoFlat.Count - countExceedValuesMoreTwo; index < data.ListLenTwoFlat.Count; ++index)
                    {
                        dataInGrouping.ListExcessTwoFlat.Add(data.ListLenTwoFlat[index]);
                    }
                }
                var listTwoFlatForCalculate = listAfterConversionTwoValues.Count != 0 ? listAfterConversionTwoValues : data.ListLenTwoFlat;

                if (countExceedValuesMoreTwo == 1)
                {
                    var excessListOneValue = new List<double>();
                    foreach (var index in listTwoFlatForCalculate)
                    {
                        var curData = new TempData();
                       
                        var currentListTwoFlat = new List<double>(listTwoFlatForCalculate);
                        currentListTwoFlat.Remove(index);

                        var res = EqualCountFlat(currentListTwoFlat, curData.CurrentFineFlat,
                            curData.CurrentResultListFlat, data.CountFloor);
                        curData.CurrentFineFlat = res.Item1;
                        curData.CurrentResultListFlat = res.Item2;
                        if (!(curData.CurrentFineFlat < dataInGrouping.TotalFineTwoFlatExcess)) continue;
                        dataInGrouping.TotalFineTwoFlatExcess = Math.Round(curData.CurrentFineFlat, 1);
                        dataInGrouping.ListResultTwoFlat = curData.CurrentResultListFlat;
                        if (excessListOneValue.Count != 0)
                        {
                            excessListOneValue.RemoveAt(0);
                        }
                        excessListOneValue.Add(index);
                    }
                    dataInGrouping.ListExcessTwoFlat.AddRange(excessListOneValue);
                }
                else // countExceedValuesMoreTwo == 2
                {
                    var excessListOneValue = new List<double>();
                    for (var index = 0; index < listTwoFlatForCalculate.Count - 1; ++index)
                    {
                        var currentListTwoFlat = new List<double>(listTwoFlatForCalculate);
                        currentListTwoFlat.Remove(listTwoFlatForCalculate[index]);

                        for (var jndex = index + 1; jndex < listTwoFlatForCalculate.Count; ++jndex)
                        {
                            var curData = new TempData();
                            var currentListTwoFlat1 = new List<double>(currentListTwoFlat);
                            currentListTwoFlat1.Remove(listTwoFlatForCalculate[jndex]);

                            var res = EqualCountFlat(currentListTwoFlat1, curData.CurrentFineFlat,
                                curData.CurrentResultListFlat, data.CountFloor);
                            curData.CurrentFineFlat = res.Item1;
                            curData.CurrentResultListFlat = res.Item2;
                            if (!(curData.CurrentFineFlat < dataInGrouping.TotalFineTwoFlatExcess)) continue;
                            dataInGrouping.TotalFineTwoFlatExcess = Math.Round(curData.CurrentFineFlat, 1);
                            dataInGrouping.ListResultTwoFlat = curData.CurrentResultListFlat;
                            if (excessListOneValue.Count != 0)
                            {
                                excessListOneValue.RemoveAt(0);
                                excessListOneValue.RemoveAt(0);
                            }
                            excessListOneValue.Add(listTwoFlatForCalculate[index]);
                            excessListOneValue.Add(listTwoFlatForCalculate[jndex]);
                        }
                    }
                    dataInGrouping.ListExcessTwoFlat.AddRange(excessListOneValue);
                }
            }
            dataInGrouping.FineOneFlat = Math.Abs(dataInGrouping.FineOneFlat) < 1e-9 ? dataInGrouping.TotalFineOneFlatExcess : dataInGrouping.FineOneFlat;
            dataInGrouping.FineTwoFlat = Math.Abs(dataInGrouping.FineOneFlat) < 1e-9 ? dataInGrouping.TotalFineTwoFlatExcess : dataInGrouping.FineTwoFlat;
            var totalFine = Math.Round(dataInGrouping.FineOneFlat + dataInGrouping.FineTwoFlat, 1);

            return new ResultDataAfterGrouping(dataInGrouping.ListResultOneFlat, dataInGrouping.ListResultTwoFlat,
                totalFine, dataInGrouping.ListExcessOneFlat, dataInGrouping.ListExcessTwoFlat);
        }

        private static Tuple<double, List<double>> EqualCountFlat(List<double> listFlat, double fineFlat,
            List<double> resultListFlat, int countFloor)
        {
            //Todo fixed
            for (var i = countFloor-1; i <= listFlat.Count; i += countFloor)
            {
                for (var j = 1; j < countFloor; j++)
                {
                    fineFlat += Math.Round(listFlat[i] - listFlat[i - j], 1);
                }
                resultListFlat.Add(listFlat[i]);
            }


//            switch (countFloor)
//            {
//                case 2:
//                    for (var i = 0; i < listFlat.Count; i = i + 2)
//                    {
//                        fineFlat += Math.Round(listFlat[i + 1] - listFlat[i], 1);
//                        resultListFlat.Add(listFlat[i + 1]);
//                    }
//                    break;
//                case 3:
//                    for (var i = 0; i < listFlat.Count; i = i + 3)
//                    {
//                        fineFlat += Math.Round(listFlat[i + 2] - listFlat[i] + (listFlat[i + 2] - listFlat[i + 1]), 1);
//                        resultListFlat.Add(listFlat[i + 2]);
//                    }
//                    break;
//                case 4:
//                    for (var i = 0; i < listFlat.Count; i = i + 4)
//                    {
//                        fineFlat +=
//                            Math.Round(
//                                listFlat[i + 3] - listFlat[i] + (listFlat[i + 3] - listFlat[i + 1]) +
//                                (listFlat[i + 3] - listFlat[i + 2]), 1);
//                        resultListFlat.Add(listFlat[i + 3]);
//                    }
//                    break;
//            }
            return Tuple.Create(fineFlat, resultListFlat);
        }

//        private static Tuple<double,List<double>> CalculateList(List<double> listFlat, double fineFlat,
//            List<double> resultListFlat, int countFloor)
//        {
//
//            switch (countFloor)
//            {
//                case 2:
//                    for (var i = 0; i < listFlat.Count; i = i + 2)
//                    {
//                        fineFlat += Math.Round(listFlat[i + 1] - listFlat[i], 1);
//                        resultListFlat.Add(listFlat[i + 1]);
//                    }
//                    break;
//                case 3:
//                    for (var i = 0; i < listFlat.Count; i = i + 3)
//                    {
//                        fineFlat += Math.Round(listFlat[i + 2] - listFlat[i] + (listFlat[i + 2] - listFlat[i + 1]), 1);
//                        resultListFlat.Add(listFlat[i + 2]);
//                    }
//                    break;
//                case 4:
//                    for (var i = 0; i < listFlat.Count; i = i + 4)
//                    {
//                        fineFlat +=
//                            Math.Round(
//                                listFlat[i + 3] - listFlat[i] + (listFlat[i + 3] - listFlat[i + 1]) +
//                                (listFlat[i + 3] - listFlat[i + 2]), 1);
//                        resultListFlat.Add(listFlat[i + 3]);
//                    }
//                    break;
//            }
//            return Tuple.Create(fineFlat, resultListFlat);
//        }
    }
}
