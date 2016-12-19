using System;
using System.Collections.Generic;
using System.Linq;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    public static class GreedyAlgorithmSection
    {
        public static ResultGreedyMethode GreedyMethode(DataGreedyMethode data, double firstOneFlat)
        {
            var listLenOneFlat = new List<double>(data.ListLenOneFlat);
            var listLenTwoFlat = new List<double>(data.ListLenTwoFlat);

            //Todo Зачем все эти объявления?? В конструктор
            var resultGreedy = new ResultGreedyMethode();
            var finalPlacementOneFlat = new double[data.OptCountFlatOnFloor];
            var finalPlacementTwoFlat = new double[data.OptCountFlatOnFloor];

            var maxFine = double.MaxValue;
            var isFlagFirstEntry = true;
            var index1 = 0;
            var index2 = 0;
            for (var n = 0; n < data.OptCountFlatOnFloor; n = n + 2)             // цикл заполнения секций
            {
                double choiceOneFlat;
                //TODO Зачем 2 условия вместе
                if (Math.Abs(firstOneFlat) > 1e-9 && isFlagFirstEntry)
                {
                    choiceOneFlat = firstOneFlat;
                }
                else
                {
                    choiceOneFlat = listLenOneFlat[listLenOneFlat.Count / 2];
                }
                isFlagFirstEntry = false;
                var sortedListOneFlat = new List<double>();
                var isFlagMeetFlat = true;
                foreach (var elem in listLenOneFlat) // divided from list given value oneApartment
                {
                    if (Math.Abs(elem - choiceOneFlat) < 1e-9 && isFlagMeetFlat)
                    {
                        isFlagMeetFlat = false;
                    }
                    else
                    {
                        sortedListOneFlat.Add(elem);
                    }
                }
                var fine = double.MaxValue;

                finalPlacementOneFlat[n] = choiceOneFlat;
                var arraySortedTwoApartments = listLenTwoFlat.ToArray();

                for (var i = 0; i < listLenTwoFlat.Count; ++i)
                {
                    for (var j = i + 1; j < listLenTwoFlat.Count; ++j)
                    {
                        for (var h = 0; h < sortedListOneFlat.Count; ++h)
                        {
                            var currentExtraSquare = 0.0;
                            double[] currentMassiv;
                            Array.Copy(arraySortedTwoApartments,
                                currentMassiv = new double[arraySortedTwoApartments.Length],
                                arraySortedTwoApartments.Length);
                            //TODO когда остается 2 варианта добавить 2 разных варианта сочетания
                            if (data.OptCountFlatOnFloor - n == 2)
                            {
                                Array.Reverse(currentMassiv);
                            }
//                            var s =
//                                CompALen.Method(
//                                    new ApartureLen(choiceOneFlat, sortedListOneFlat[h], currentMassiv[i],
//                                        currentMassiv[j], currentExtraSquare), data.Step);

                            if (currentMassiv[i] - choiceOneFlat < Constraints.ApartureLength)
                            {
                                var tempFine1 =
                                    Math.Round(Constraints.ApartureLength - (currentMassiv[i] - choiceOneFlat), 2);
                                if (tempFine1 <= data.Step)
                                {
                                    currentMassiv[i] += Math.Round(data.Step, 1);
                                    currentExtraSquare += Math.Round(data.Step, 1);
                                }
                                else
                                {
                                    currentMassiv[i] += Math.Round(Math.Ceiling(tempFine1/data.Step)*data.Step, 1);
                                    currentExtraSquare += Math.Round(Math.Ceiling(tempFine1/data.Step)*data.Step, 1);
                                }
                            }
                            if (currentMassiv[j] - sortedListOneFlat[h] < Constraints.ApartureLength)
                            {
                                var tempFine2 =
                                    Math.Round(Constraints.ApartureLength - (currentMassiv[j] - sortedListOneFlat[h]), 2);
                                if (tempFine2 <= data.Step)
                                {
                                    currentMassiv[j] += Math.Round(data.Step, 1);
                                    currentExtraSquare += Math.Round(data.Step, 1);
                                }
                                else
                                {
                                    currentMassiv[j] += Math.Round(Math.Ceiling(tempFine2/data.Step)*data.Step, 1);
                                    currentExtraSquare += Math.Round(Math.Ceiling(tempFine2/data.Step)*data.Step, 1);
                                }
                            }

//                        var currentFine =
//                                Math.Abs(Math.Round(
//                                    s.B1 + s.B2 + 2 * data.Step - s.A1 - data.Entryway - 3 * data.Step -
//                                    s.A2 + currentExtraSquare, 1));
//                            if (currentFine < fine)
//                            {
//                                fine = currentFine;
//                                finalPlacementTwoFlat[n] = s.B1;
//                                index1 = i;
//                                finalPlacementTwoFlat[n + 1] = s.B2;
//                                index2 = j;
//                                finalPlacementOneFlat[n + 1] = s.A2;
//                                choiceOneFlat = s.A1;
//                        }
                        var currentFine =
                                Math.Abs(Math.Round(
                                    currentMassiv[i] + currentMassiv[j] + 2 * data.Step - choiceOneFlat - data.Entryway - 3 * data.Step -
                                    sortedListOneFlat[h] + currentExtraSquare, 1));
                            if (currentFine < fine)
                            {
                                fine = currentFine;
                                finalPlacementTwoFlat[n] = currentMassiv[i];
//                                resultGreedy.FinalPlaceTwoFlat.Add(currentMassiv[i]);
                                index1 = i;
                                finalPlacementTwoFlat[n + 1] = currentMassiv[j];
//                                resultGreedy.FinalPlaceTwoFlat.Add(currentMassiv[j]);
                                index2 = j;
                                finalPlacementOneFlat[n + 1] = sortedListOneFlat[h];
//                                resultGreedy.FinalPlaceOneFlat.Add(sortedListOneFlat[h]);
                            }
                        }
                    }
                }
                //удаление занятых вариантов из списка и суммирование штрафа
                resultGreedy.Fine = Math.Round(resultGreedy.Fine + fine, 1);
                if (maxFine > fine)
                {
                    maxFine = fine;
                    resultGreedy.NewFirstOneFlat = finalPlacementOneFlat[n];
                }
                listLenOneFlat.Remove(finalPlacementOneFlat[n]);
                listLenOneFlat.Remove(finalPlacementOneFlat[n + 1]);
                if (index1 > index2)
                {
                    listLenTwoFlat.RemoveAt(index1);
                    listLenTwoFlat.RemoveAt(index2);
                }
                else
                {
                    listLenTwoFlat.RemoveAt(index2);
                    listLenTwoFlat.RemoveAt(index1);
                }

            }
            return new ResultGreedyMethode(resultGreedy.Fine, finalPlacementOneFlat.ToList(), finalPlacementTwoFlat.ToList(),
                  resultGreedy.NewFirstOneFlat);
        }
    }
}