using System;
using System.Collections.Generic;
using System.Linq;

namespace Resettlement
{
    public static class GreedyMethodeSect
    {
        public static ResultGreedyMethode GreedyMethode(DataMethode dataGrM, double firstOneFlat, string positionStart, bool isVersion)
        {
            var listLenOneFlat = new List<double>(dataGrM.ListLenOneFlat);
            var listLenTwoFlat = new List<double>(dataGrM.ListLenTwoFlat);

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
                var arraySortedTwoFlat = listLenTwoFlat.ToArray();

                for (var i = 0; i < listLenTwoFlat.Count; ++i)
                {
                    for (var j = i + 1; j < listLenTwoFlat.Count; ++j)
                    {
                        foreach (var t in sortedListOneFlat)
                        {
                            double[] currentMassiv;
                            Array.Copy(arraySortedTwoFlat,
                                currentMassiv = new double[arraySortedTwoFlat.Length],
                                arraySortedTwoFlat.Length);

                            ApartureLen resultPackSectReverse;
                            switch (dataGrM.OptCountFlatOnFloor-n)
                            {
                                case 2:
                                {
                                    resultPackSectReverse =
                                        MethodsForApartureLen.CalculateOptimalPackContainer(
                                            new ApartureLen(choiceOneFlat, t, currentMassiv[j],
                                                currentMassiv[i]), dataGrM.WallsWidth, isVersion);
                                    break;
                                }
                                
                                default:
                                    resultPackSectReverse = new ApartureLen(double.MaxValue);
                                break;
                            }
                            var resultPackSect =
                                MethodsForApartureLen.CalculateOptimalPackContainer(
                                    new ApartureLen(choiceOneFlat, t, currentMassiv[i],
                                        currentMassiv[j]), dataGrM.WallsWidth, isVersion);

                            //Todo change expression 2.4 = parameters: p1 p2
                            /*
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
                            */
                           var currentFineReverse =
                           Math.Abs(Math.Round(
                               resultPackSectReverse.DataContainer.B1 - 2.4 + resultPackSectReverse.DataContainer.B2 - 2.4 
                               + dataGrM.EntrywayPlusCorridor + 2 * dataGrM.WallsWidth -
                               (resultPackSectReverse.DataContainer.A1 + 2.4 + resultPackSectReverse.DataContainer.A2 + 2.4
                               + 2 * dataGrM.WallsWidth)
                               + resultPackSectReverse.ExtraSquare, 1));

                           var currentFine =
                                Math.Abs(Math.Round(
                                    resultPackSect.DataContainer.B1 -2.4 + resultPackSect.DataContainer.B2 - 2.4
                                    + dataGrM.EntrywayPlusCorridor + 2 * dataGrM.WallsWidth -
                                    (resultPackSect.DataContainer.A1 +2.4 + resultPackSect.DataContainer.A2 + 2.4
                                    + 2 * dataGrM.WallsWidth)
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
            //приведение длин для конечного отображения
            if (!isVersion)
            {
                for (var k = 0; k < finalPlacementOneFlat.Length; k = k + 2)
                {
                    var resultAddingPlace =
                        ResultAddingPlace.CalculateAddingPlace(new DataContainer
                        {
                            A1 = finalPlacementOneFlat[k],
                            A2 = finalPlacementOneFlat[k + 1],
                            B1 = finalPlacementTwoFlat[k],
                            B2 = finalPlacementTwoFlat[k + 1]
                        },
                            0.3);
                    finalPlacementOneFlat[k] = resultAddingPlace.A1;
                    finalPlacementOneFlat[k + 1] = resultAddingPlace.A2;
                }
            }

            return new ResultGreedyMethode(resultGreedy.Fine, finalPlacementOneFlat.ToList(), finalPlacementTwoFlat.ToList(),
                  resultGreedy.NewFirstOneFlat);
        }
    }
}