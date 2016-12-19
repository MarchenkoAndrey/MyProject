using System;
using System.Collections.Generic;
using System.Linq;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    public static class GreedyAlgorithmSection
    {
        public static ResultGreedyMethode GreedyMethode(DataGreedyMethode dataGrM, double firstOneFlat)
        {
            var listLenOneFlat = new List<double>(dataGrM.ListLenOneFlat);
            var listLenTwoFlat = new List<double>(dataGrM.ListLenTwoFlat);

            //Todo Зачем все эти объявления?? В конструктор
            var resultGreedy = new ResultGreedyMethode();
            var finalPlacementOneFlat = new double[dataGrM.OptCountFlatOnFloor];
            var finalPlacementTwoFlat = new double[dataGrM.OptCountFlatOnFloor];

            var maxFine = double.MaxValue;
            var isFlagFirstEntry = true;
            var index1 = 0;
            var index2 = 0;
            for (var n = 0; n < dataGrM.OptCountFlatOnFloor; n = n + 2)             // цикл заполнения секций
            {
                double choiceOneFlat;
                //Если есть значение и оно в первый раз, то его и записываем
                if (Math.Abs(firstOneFlat) > 1e-9 && isFlagFirstEntry)
                {
                    choiceOneFlat = firstOneFlat;
                }
                else
                {
                    choiceOneFlat = listLenOneFlat[listLenOneFlat.Count / 2];
                }
                isFlagFirstEntry = false;

                var sortedListOneFlat = new List<double>(listLenOneFlat);
                sortedListOneFlat.Remove(choiceOneFlat);
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
                            if (dataGrM.OptCountFlatOnFloor - n == 2)
                            {
                                Array.Reverse(currentMassiv);
                            }
                            var s =
                                CompALen.Method(
                                    new ApartureLen(choiceOneFlat, sortedListOneFlat[h], currentMassiv[i],
                                        currentMassiv[j], currentExtraSquare), dataGrM.Step);

                        var currentFine =
                                Math.Abs(Math.Round(
                                    s.B1 + s.B2 + 2 * dataGrM.Step - s.A1 - dataGrM.Entryway - 3 * dataGrM.Step -
                                    s.A2 + currentExtraSquare, 1));
                            if (currentFine < fine)
                            {
                                fine = currentFine;
                                finalPlacementTwoFlat[n] = s.B1;
                                index1 = i;
                                finalPlacementTwoFlat[n + 1] = s.B2;
                                index2 = j;
                                finalPlacementOneFlat[n + 1] = s.A2;
                            }
                        }
                    }
                }
                //удаление занятых вариантов из списка и суммирование штрафа
                resultGreedy.Fine = Math.Round(resultGreedy.Fine + fine, 1);

                //Todo новые итерации не улучшаются
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