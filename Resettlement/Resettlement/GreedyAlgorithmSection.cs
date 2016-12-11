using System;
using System.Collections.Generic;
using System.Linq;
using ComputationMethods;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    public static class GreedyAlgorithmSection
    {
        public static ResultGreedyMethode GreedyMethode(InputDataAlg data, double firstOneFlat)
        {
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
                if (Math.Abs(firstOneFlat) > 1e-9 && isFlagFirstEntry)
                {
                    choiceOneFlat = firstOneFlat;
                }
                else
                {
                    choiceOneFlat = data.ListLenOneFlat[data.ListLenOneFlat.Count / 2];
                }
                isFlagFirstEntry = false;
                var sortedListOneFlat = new List<double>();
                var isFlagMeetFlat = true;
                foreach (var elem in data.ListLenOneFlat) // divided from list given value oneApartment
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
//                resultGreedy.FinalPlaceOneFlat.Add(choiceMinOneFlat);
                var arraySortedTwoApartments = ChangeTypeVariable.ChangeListIntoArray(data.ListLenTwoFlat);

                for (var i = 0; i < data.ListLenTwoFlat.Count; ++i)
                {
                    for (var j = i + 1; j < data.ListLenTwoFlat.Count; ++j)
                    {
                        for (var h = 0; h < sortedListOneFlat.Count; ++h)
                        {
                            var currentExtraSquare = 0.0;
                            double[] currentMassiv;
                            Array.Copy(arraySortedTwoApartments, currentMassiv = new double[arraySortedTwoApartments.Length], arraySortedTwoApartments.Length);
                            //TODO когда остается 2 варианта добавить 2 разных варианта сочетания
                            if (data.OptCountFlatOnFloor - n == 2)
                            {
                                Array.Reverse(currentMassiv);
                            }
                            if (currentMassiv[i] - choiceOneFlat < Constraints.ApartureLength)
                            {
                                var tempFine1 = Math.Round(Constraints.ApartureLength - (currentMassiv[i] - choiceOneFlat), 2);
                                if (tempFine1 <= data.Step)
                                {
                                    currentMassiv[i] += Math.Round(data.Step, 1);
                                    currentExtraSquare += Math.Round(data.Step, 1);
                                }
                                else
                                {
                                    currentMassiv[i] += Math.Round(Math.Ceiling(tempFine1 / data.Step) * data.Step, 1);
                                    currentExtraSquare += Math.Round(Math.Ceiling(tempFine1 / data.Step) * data.Step, 1);
                                }
                            }
                            if (currentMassiv[j] - sortedListOneFlat[h] < Constraints.ApartureLength)
                            {
                                var tempFine2 = Math.Round(Constraints.ApartureLength - (currentMassiv[j] - sortedListOneFlat[h]), 2);
                                if (tempFine2 <= data.Step)
                                {
                                    currentMassiv[j] += Math.Round(data.Step, 1);
                                    currentExtraSquare += Math.Round(data.Step, 1);
                                }
                                else
                                {
                                    currentMassiv[j] += Math.Round(Math.Ceiling(tempFine2 / data.Step) * data.Step, 1);
                                    currentExtraSquare += Math.Round(Math.Ceiling(tempFine2 / data.Step) * data.Step, 1);
                                }
                            }
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
                resultGreedy.Fine += Math.Round(fine, 1);
                if (maxFine > fine)
                {
                    maxFine = fine;
//                    resultGreedy.NewFirstOneFlat = resultGreedy.FinalPlaceOneFlat[n];
                    resultGreedy.NewFirstOneFlat = finalPlacementOneFlat[n];
                }

                //Todo Лишние только с помощью удаления находятся?
                data.ListLenOneFlat.Remove(finalPlacementOneFlat[n]);
                data.ListLenOneFlat.Remove(finalPlacementOneFlat[n + 1]);
                if (index1 > index2)
                {
                    data.ListLenTwoFlat.RemoveAt(index1);
                    data.ListLenTwoFlat.RemoveAt(index2);
                }
                else
                {
                    data.ListLenTwoFlat.RemoveAt(index2);
                    data.ListLenTwoFlat.RemoveAt(index1);
                }

            }
            return new ResultGreedyMethode(resultGreedy.Fine, finalPlacementOneFlat.ToList(), finalPlacementTwoFlat.ToList(),
                 data.ListLenOneFlat, data.ListLenTwoFlat, resultGreedy.NewFirstOneFlat);
        }
    }
}