using System;
using System.Collections.Generic;
using System.Linq;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    public static class DynamicMethodeSect
    {
        public static List<Container> DynamicMethode(DataMethode data, bool isVersion)
        {
            var collectionContainers = new CollectionContainers(data);
            var hashContainer = new HashSet<double>{0.0};

            foreach (var baseContainer in collectionContainers)
            {
                if (baseContainer.ExceedListOneFlat.Count == 0) // условие завершения
                    break;

                var sortedListOneFlat = new List<double>(baseContainer.ExceedListOneFlat);
//                var choiceOneFlat = baseContainer.ExceedListOneFlat[baseContainer.ExceedListOneFlat.Count/2];
                var choiceOneFlat = baseContainer.ExceedListOneFlat[0]; // начинаем с первого
                sortedListOneFlat.Remove(choiceOneFlat);
                var arraySortedTwoApartments = baseContainer.ExceedListTwoFlat.ToArray();
                var childContainers = new List<Container>();
 
                var maxFine = double.MinValue;
                var maxFineId = 0;

                for (var i = 0; i < baseContainer.ExceedListTwoFlat.Count; ++i)
                {
                    for (var j = i + 1; j < baseContainer.ExceedListTwoFlat.Count; ++j)
                    {
                        foreach (var t in sortedListOneFlat)
                        {
                            var newContainer = new Container(baseContainer);

                            double[] currentMassiv;
                            Array.Copy(arraySortedTwoApartments,
                                currentMassiv = new double[arraySortedTwoApartments.Length],
                                arraySortedTwoApartments.Length);

                            var resultPackSect = MethodsForApartureLen.OptimalPackContainer(choiceOneFlat, t, currentMassiv[i],
                                currentMassiv[j], data.WallsWidth, isVersion);

                            // Претендент на запись выбран. Заполнение претендента
                            newContainer = FillingData(newContainer, resultPackSect, baseContainer.Id);
                           
                            // Проверка валидности его записи
                            // Если записей меньше 3, то записываем
                            // Иначе сравниваем штраф с текущим наибольшим
                            // Если нашли меньше, то (если такой контейнер уже есть, то break)
                            // перезаписываем, обновляя текущий наибольший

                            //Запись в промежуточный результат контейнеров
                            if (childContainers.Count < Constraints.СountBranch)
                            {
                                if (ValidateToSameContainers(childContainers, newContainer)) continue;

                                childContainers.Add(newContainer);
                                if (newContainer.Fine > maxFine)
                                {
                                    maxFine = newContainer.Fine;
                                    maxFineId = newContainer.Id;
                                }
                                continue;
                            }
                            if (!(newContainer.Fine < maxFine)) continue;
                            if (ValidateToSameContainers(childContainers, newContainer)) continue;

                            //нашли контейнер из 3 с наибольшим штрафом
                            var containerWithMaxFine = childContainers
                                .Select(a => a)
                                .Where(z => z.Id == maxFineId)
                                .Take(1)
                                .First();
                            childContainers[childContainers.IndexOf(containerWithMaxFine)] = newContainer;

                            //обновили максимум и его Id
                            maxFine = childContainers
                                .Select(a => a.Fine)
                                .Max();

                            maxFineId = childContainers
                                .Where(z => z.Fine.Equals(maxFine))
                                .Select(a => a.Id)
                                .Take(1)
                                .First();
                        }
                    }
                }
                //Удаляет использованные квартиры
                DeleteExceedFlat(childContainers);

                //проверка и удаление по хешсету ветвей
                var resultOfThinning = ThinningChain(childContainers, hashContainer);
                collectionContainers.Adds(resultOfThinning.Item1);
                hashContainer = resultOfThinning.Item2;
            }
            return collectionContainers.Containers;
        }

        private static Tuple<List<Container>, HashSet<double>> ThinningChain(List<Container> childContainers, HashSet<double> hashSet)
        {
            var resList = new List<Container>(childContainers);
            foreach (var container in childContainers)
            {
                var currHash = Math.Abs(container.OriginDataContainer.GetHashCode()+container.Fine.GetHashCode()*1039);
                if (hashSet.Contains(currHash))
                {
                    resList.Remove(container);
                }
                else
                {
                    hashSet.Add(currHash);
                    container.Id = currHash;
                }
            }
            return new Tuple<List<Container>, HashSet<double>>(resList,hashSet);
        }

        // Проверка на то, что в списке контейнеров tempThreeContainers нет текущего контейнера
        private static bool ValidateToSameContainers(IEnumerable<Container> childContainers, Container newContainer)
        {
            return childContainers.Any(container => Equals(newContainer.Id, container.Id));
        }

        // Заполнение текущего контейнера данными
        private static Container FillingData(Container newContainer, ApartureLen result, int parentId)
        {
            newContainer.DataContainer.B1 = result.DataContainer.B1;
            newContainer.DataContainer.B2 = result.DataContainer.B2;
            newContainer.DataContainer.A2 = result.DataContainer.A2;
            newContainer.DataContainer.A1 = result.DataContainer.A1;
           
            newContainer.ParentId = parentId;
            newContainer.Fine = result.Fine;
            newContainer.FineChain += Math.Round(result.Fine,1);
            newContainer.OriginDataContainer.A1 = result.OriginDataContainer.A1;
            newContainer.OriginDataContainer.A2 = result.OriginDataContainer.A2;
            newContainer.OriginDataContainer.B1 = result.OriginDataContainer.B1;
            newContainer.OriginDataContainer.B2 = result.OriginDataContainer.B2;
            newContainer.Id = Math.Abs(newContainer.OriginDataContainer.GetHashCode() + newContainer.Fine.GetHashCode() * 1039);

            return newContainer;
        }
        // Удаление из оставшихся вариантов использованные
        private static void DeleteExceedFlat(IEnumerable<Container> childContainers)
        {
            foreach (var container in childContainers)
            {
                var l = new List<double>(container.ExceedListOneFlat);
                l.Remove(container.OriginDataContainer.A1);
                l.Remove(container.OriginDataContainer.A2);

                var l1 = new List<double>(container.ExceedListTwoFlat);
                l1.Remove(container.OriginDataContainer.B1);
                l1.Remove(container.OriginDataContainer.B2);

                container.ExceedListOneFlat = l;
                container.ExceedListTwoFlat = l1;
            }
        }
    }
}
