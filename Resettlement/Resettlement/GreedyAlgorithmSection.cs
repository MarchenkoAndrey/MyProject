using System;
using System.Collections.Generic;
using System.Linq;

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

            var maxFine = 0.0;
            var index1 = 0; // индексы нужны для удаления из второго списка
            var index2 = 0;
            for (var n = 0; n < dataGrM.OptCountFlatOnFloor; n = n + 2)             // цикл заполнения секций
            {
                double choiceOneFlat;
                //Если есть ненулевое значение и оно встретилось в первый раз, то записываем его
                if (Math.Abs(firstOneFlat) > 1e-9 && resultGreedy.IsFlagFirstEntry)
                {
                    choiceOneFlat = firstOneFlat;
                }
                else
                {
                    choiceOneFlat = listLenOneFlat[listLenOneFlat.Count / 2];
                }
                resultGreedy.IsFlagFirstEntry = false;

                var sortedListOneFlat = new List<double>(listLenOneFlat);
                sortedListOneFlat.Remove(choiceOneFlat);
                var fine = double.MaxValue;

                finalPlacementOneFlat[n] = choiceOneFlat;
                var arraySortedTwoApartments = listLenTwoFlat.ToArray();

                for (var i = 0; i < listLenTwoFlat.Count; ++i)
                {
                    for (var j = i + 1; j < listLenTwoFlat.Count; ++j)
                    {
                        foreach (var t in sortedListOneFlat)
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
                            var resultPackSect =
                                CompALen.Method(
                                    new ApartureLen(choiceOneFlat, t, currentMassiv[i],
                                        currentMassiv[j], currentExtraSquare), dataGrM.Step);

                            var currentFine =
                                Math.Abs(Math.Round(
                                    resultPackSect.B1 + resultPackSect.B2 + dataGrM.AddingB -
                                    (resultPackSect.A1 + resultPackSect.A2 + dataGrM.AddingA)
                                    + resultPackSect.ExtraSquare, 1));
                            if (currentFine < fine)
                            {
                                fine = currentFine;
                                finalPlacementTwoFlat[n] = resultPackSect.B1;
                                index1 = i;
                                finalPlacementTwoFlat[n + 1] = resultPackSect.B2;
                                index2 = j;
                                finalPlacementOneFlat[n + 1] = resultPackSect.A2;
                            }
                        }
                    }
                }
                //удаление занятых вариантов из списка и суммирование штрафа
                resultGreedy.Fine = Math.Round(resultGreedy.Fine + fine, 1);

                if (maxFine < fine)
                {
                    maxFine = fine;
                    resultGreedy.NewFirstOneFlat = finalPlacementOneFlat[n]; // Запись контейнера с наибольшим штрафом
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