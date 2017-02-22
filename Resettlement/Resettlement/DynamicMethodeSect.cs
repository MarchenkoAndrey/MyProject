﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Resettlement
{
    public static class DynamicMethodeSect
    {
        public static IEnumerable<Container> DynamicMethode(DataGreedyMethode data)
        {
            var resultDymMethode = new ContainerTree(data);
            const int countBranch = 3;

            foreach (var baseContainer in resultDymMethode.Containers)
            {
                if (baseContainer.ExceedListOneFlat.Count == 0) // условие завершения
                    break;

                var sortedListOneFlat = new List<double>(baseContainer.ExceedListOneFlat);
                var choiceOneFlat = baseContainer.ExceedListOneFlat[baseContainer.ExceedListOneFlat.Count/2];
                sortedListOneFlat.Remove(choiceOneFlat);
                //Todo Превратить в List
                var arraySortedTwoApartments = baseContainer.ExceedListTwoFlat.ToArray();

                var tempThreeContainers = new List<Container>();
               
                //todo Добавить в отд. класс 2 parameters
                var maxFine = double.MinValue;
                var maxFineId = 0;

                for (var i = 0; i < baseContainer.ExceedListTwoFlat.Count; ++i)
                {
                    for (var j = i + 1; j < baseContainer.ExceedListTwoFlat.Count; ++j)
                    {
                        foreach (var t in sortedListOneFlat)
                        {
                            double[] currentMassiv;
                            Array.Copy(arraySortedTwoApartments,
                                currentMassiv = new double[arraySortedTwoApartments.Length],
                                arraySortedTwoApartments.Length);

                            var newContainer = new Container(data);
                            //Todo Убрать повторы!!!
                            var resultPackSect =
                                CompALen.Method(
                                    new ApartureLen(choiceOneFlat, t, currentMassiv[i],
                                        currentMassiv[j]), data.Step);

                            var resultPackSectRev =
                                CompALen.Method(
                                    new ApartureLen(choiceOneFlat, t, currentMassiv[j],
                                        currentMassiv[i]), data.Step);


                            //Считается и добавка ExtraSquare
                            var currentFine =
                                Math.Abs(Math.Round(
                                    resultPackSect.B1 + resultPackSect.B2 + data.AddingB -
                                    (resultPackSect.A1 + resultPackSect.A2 + data.AddingA)
                                    + resultPackSect.ExtraSquare, 1));

                            var currentFineReverse =
                                Math.Abs(Math.Round(
                                    resultPackSectRev.B1 + resultPackSectRev.B2 + data.AddingB -
                                    (resultPackSectRev.A1 + resultPackSectRev.A2 + data.AddingA)
                                    + resultPackSectRev.ExtraSquare, 1));

                            if (currentFineReverse < currentFine)
                            {
                                currentFine = currentFineReverse;
                                resultPackSect = resultPackSectRev;
                            }

                            // претендент на запись выбран.
                            //Заполнение претендента

                            //Todo Old == Now Рано удаляю!!! origin
                                
                            newContainer.ParentId = baseContainer.Id;
                            newContainer = FillingData(newContainer, resultPackSect, currentFine,
                                resultDymMethode.Containers.Count);
                                
                            // Проверка валидности его записи
                            // Если записей меньше 3, то записываем
                            // Иначе сравниваем штраф с текущим наибольшим
                            // Если нашли меньше, то (если такой контейнер уже есть, то break)
                            // перезаписываем, обновляя текущий наибольший

                            //Запись в промежуточный результат контейнеров
                            if (tempThreeContainers.Count < countBranch)
                            {
                                if (ValidateToSameContainers(tempThreeContainers, newContainer)) continue;

                                tempThreeContainers.Add(newContainer);
                                if (newContainer.Fine > maxFine)
                                {
                                    maxFine = newContainer.Fine;
                                    maxFineId = newContainer.Id;
                                }
                                continue;
                            }
                            if (!(newContainer.Fine < maxFine)) continue;
                            //validate containers
                            if (ValidateToSameContainers(tempThreeContainers, newContainer)) continue;

                            //нашли контейнер из 3 с наибольшим штрафом
                            var containerWithMaxFine = tempThreeContainers
                                .Select(a => a)
                                .Where(z => z.Id == maxFineId)
                                .Take(1)
                                .First();
                            tempThreeContainers[containerWithMaxFine.Id-1] = newContainer;

                            //Todo RefreshMaxFine
//                                        maxFine =
//                                            Math.Max(
//                                                Math.Max(tempThreeContainers[0].Fine, tempThreeContainers[1].Fine),
//                                                tempThreeContainers[2].Fine);
                            maxFine = tempThreeContainers
                                .Select(a => a.Fine)
                                .Max();

                            maxFineId = tempThreeContainers
                                .Where(z => z.Fine.Equals(maxFine))
                                .Select(a => a.Id)
                                .Take(1)
                                .First();
                        }
                    }
                }
                //Удаляет использованные квартиры
                DeleteExceedFlat(tempThreeContainers);
                    
                resultDymMethode.Containers.AddRange(tempThreeContainers);
            }
            return resultDymMethode.Containers;
        }

        // Проверка на то, что в списке контейнеров tempThreeContainers нет текущего контейнера
        private static bool ValidateToSameContainers(IEnumerable<Container> tempThreeContainers, Container newContainer)
        {
            return tempThreeContainers.Any(container => Equals(newContainer, container));
        }

        // Переопределенный метод Equals
        private static bool Equals(Container obj1, Container obj2)
        {
            return (obj1.A1.Equals(obj2.A1) && obj1.A2.Equals(obj2.A2) && 
                obj1.B1.Equals(obj2.B1) && obj1.Fine.Equals(obj2.Fine)) ||
                (obj1.A1.Equals(obj2.A2) && obj1.A2.Equals(obj2.A1) &&
                obj1.B1.Equals(obj2.B2) && obj1.Fine.Equals(obj2.Fine));
        }

        // Заполнение текущего контейнера данными
        private static Container FillingData(Container newContainer, ApartureLen result, double fine, int id)
        {
            newContainer.B1 = result.B1;
            newContainer.B2 = result.B2;
            newContainer.A2 = result.A2;
            newContainer.A1 = result.A1;
            newContainer.Id = id;
            newContainer.Fine = fine;
            newContainer.FineChain += fine;
            newContainer.OriginA1 = result.OriginDataContainer.OldA1;
            newContainer.OriginA2 = result.OriginDataContainer.OldA2;
            newContainer.OriginB1 = result.OriginDataContainer.OldB1;
            newContainer.OriginB2 = result.OriginDataContainer.OldB2;

            return newContainer;
        }

        private static void DeleteExceedFlat(List<Container> tempThreeContainers)
        {
            foreach (var container in tempThreeContainers)
            {
                var l = new List<double>(container.ExceedListOneFlat);
                l.Remove(container.OriginA1);
                l.Remove(container.OriginA2);

                var l1 = new List<double>(container.ExceedListTwoFlat);
                l1.Remove(container.OriginB1);
                l1.Remove(container.OriginB2);

                container.ExceedListOneFlat = l;
                container.ExceedListTwoFlat = l1;
            }
//            return tempThreeContainers;
        }
    }
}
