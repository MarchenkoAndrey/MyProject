﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Resettlement
{
    public static class GreedyMethodeSect
    {
        public static ResultGreedyMethode GreedyMethode(DataMethode dataGrM, double firstOneFlat, string positionStart)
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
                //Если есть ненулевое значение и оно встретилось в первый раз, то записываем его
                double choiceOneFlat;
                switch (positionStart)
                {
                    case "First":
                        choiceOneFlat = Math.Abs(firstOneFlat) > 1e-9 && resultGreedy.IsFlagFirstEntry
                         ? firstOneFlat
                         : listLenOneFlat[0];
                        break;
                    case "Middle":
                        choiceOneFlat = Math.Abs(firstOneFlat) > 1e-9 && resultGreedy.IsFlagFirstEntry
                       ? firstOneFlat
                       : listLenOneFlat[listLenOneFlat.Count / 2];
                        break;
                    case "Penultimate":
                        choiceOneFlat = Math.Abs(firstOneFlat) > 1e-9 && resultGreedy.IsFlagFirstEntry
                        ? firstOneFlat
                        : listLenOneFlat[listLenOneFlat.Count-2];
                        break;
                    default:
                        throw new Exception();
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
                            double[] currentMassiv;
                            Array.Copy(arraySortedTwoApartments,
                                currentMassiv = new double[arraySortedTwoApartments.Length],
                                arraySortedTwoApartments.Length);

                            ApartureLen resultPackSectReverse;
                            switch (dataGrM.OptCountFlatOnFloor-n)
                            {
                                case 2:
                                {
                                    resultPackSectReverse =
                                        MethodsForApartureLen.CalculateOptimalPackContainer(
                                            new ApartureLen(choiceOneFlat, t, currentMassiv[j],
                                                currentMassiv[i]), dataGrM.WallsWidth);
                                    break;
                                }
                                
                                default:
                                    resultPackSectReverse = new ApartureLen(double.MaxValue);
                                break;
                            }
                            var resultPackSect =
                                MethodsForApartureLen.CalculateOptimalPackContainer(
                                    new ApartureLen(choiceOneFlat, t, currentMassiv[i],
                                        currentMassiv[j]), dataGrM.WallsWidth);

                            var currentFineReverse =
                                Math.Abs(Math.Round(
                                    resultPackSectReverse.DataContainer.B1 + resultPackSectReverse.DataContainer.B2 + dataGrM.AddingB -
                                    (resultPackSectReverse.DataContainer.A1 + resultPackSectReverse.DataContainer.A2 + dataGrM.AddingA)
                                    + resultPackSectReverse.ExtraSquare, 1));

                            var currentFine =
                                Math.Abs(Math.Round(
                                    resultPackSect.DataContainer.B1 + resultPackSect.DataContainer.B2 + dataGrM.AddingB -
                                    (resultPackSect.DataContainer.A1 + resultPackSect.DataContainer.A2 + dataGrM.AddingA)
                                    + resultPackSect.ExtraSquare, 1));

                            if (currentFineReverse < currentFine)
                            {
                                currentFine = currentFineReverse;
                                resultPackSect = resultPackSectReverse;
                            }

                            if (!(currentFine < fine)) continue;
                            fine = currentFine;
                            finalPlacementTwoFlat[n] = resultPackSect.DataContainer.B1;
                            index1 = i;
                            finalPlacementTwoFlat[n + 1] = resultPackSect.DataContainer.B2;
                            index2 = j;
                            finalPlacementOneFlat[n + 1] = resultPackSect.DataContainer.A2;
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