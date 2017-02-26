using System;
using System.Collections.Generic;
using System.Linq;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    public static class DynamicMethodeSect
    {
        public static List<Container> DynamicMethode(DataMethode data)
        {
            var coll = new GoToCollection(data);
            var hash = new HashSet<double>{0.0};

            foreach (var baseContainer in coll)
            {
                if (baseContainer.ExceedListOneFlat.Count == 0) // условие завершения
                    break;

                var sortedListOneFlat = new List<double>(baseContainer.ExceedListOneFlat);
                var choiceOneFlat = baseContainer.ExceedListOneFlat[baseContainer.ExceedListOneFlat.Count/2];
                sortedListOneFlat.Remove(choiceOneFlat);
                var arraySortedTwoApartments = baseContainer.ExceedListTwoFlat.ToArray();
                var tempThreeContainers = new List<Container>();
 
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
                                currentMassiv[j], data.WallsWidth);

                            // Претендент на запись выбран. Заполнение претендента
                            newContainer = FillingData(newContainer, resultPackSect,
                                coll.Containers.Count, baseContainer.Id);
                           
                            // Проверка валидности его записи
                            // Если записей меньше 3, то записываем
                            // Иначе сравниваем штраф с текущим наибольшим
                            // Если нашли меньше, то (если такой контейнер уже есть, то break)
                            // перезаписываем, обновляя текущий наибольший

                            //Запись в промежуточный результат контейнеров
                            if (tempThreeContainers.Count < Constraints.СountBranch)
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
                            if (ValidateToSameContainers(tempThreeContainers, newContainer)) continue;

                            //нашли контейнер из 3 с наибольшим штрафом
                            var containerWithMaxFine = tempThreeContainers
                                .Select(a => a)
                                .Where(z => z.Id == maxFineId)
                                .Take(1)
                                .First();
                            tempThreeContainers[containerWithMaxFine.Id - 1] = newContainer;

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

                //проверка и удаление по хешсету ветвей
                var resultOfThinning = ThinningChain(tempThreeContainers, hash); 

                coll.Adds(resultOfThinning.Item1);
                hash = resultOfThinning.Item2;
            }
            return coll.Containers;
        }

        private static Tuple<List<Container>, HashSet<double>> ThinningChain(List<Container> tempThreeContainers, HashSet<double> hashSet)
        {
            var resList = new List<Container>(tempThreeContainers);
            foreach (var container in tempThreeContainers)
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
        private static bool ValidateToSameContainers(IEnumerable<Container> tempThreeContainers, Container newContainer)
        {
            return tempThreeContainers.Any(container => Equals(newContainer.GetHashCode(), container.GetHashCode()));
        }

        // Заполнение текущего контейнера данными
        private static Container FillingData(Container newContainer, ApartureLen result, int id, int parentId)
        {
            newContainer.DataContainer.B1 = result.DataContainer.B1;
            newContainer.DataContainer.B2 = result.DataContainer.B2;
            newContainer.DataContainer.A2 = result.DataContainer.A2;
            newContainer.DataContainer.A1 = result.DataContainer.A1;
            newContainer.Id = id;
            newContainer.ParentId = parentId;
            newContainer.Fine = result.Fine;
            newContainer.FineChain += result.Fine;
            newContainer.OriginDataContainer.A1 = result.OriginDataContainer.A1;
            newContainer.OriginDataContainer.A2 = result.OriginDataContainer.A2;
            newContainer.OriginDataContainer.B1 = result.OriginDataContainer.B1;
            newContainer.OriginDataContainer.B2 = result.OriginDataContainer.B2;
            return newContainer;
        }
        // Удаление из оставшихся вариантов использованные
        private static void DeleteExceedFlat(IEnumerable<Container> tempThreeContainers)
        {
            foreach (var container in tempThreeContainers)
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
