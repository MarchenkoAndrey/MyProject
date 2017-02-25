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

            //Todo Зацикливание
            foreach (var baseContainer in coll)
            {
                if (baseContainer.ExceedListOneFlat.Count == 0) // условие завершения
                    break;

                var sortedListOneFlat = new List<double>(baseContainer.ExceedListOneFlat);
                var choiceOneFlat = baseContainer.ExceedListOneFlat[baseContainer.ExceedListOneFlat.Count/2];
                sortedListOneFlat.Remove(choiceOneFlat);

                var arraySortedTwoApartments = baseContainer.ExceedListTwoFlat.ToArray();

                var tempThreeContainers = new List<Container>();
               
                //todo Добавить в отд. класс 2 parameters???
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

                            var resultPackSect = CompALen.OptimalPackContainer(choiceOneFlat, t, currentMassiv[i],
                                        currentMassiv[j], data.WallsWidth);
                            
                            // Претендент на запись выбран. Заполнение претендента
                                
                            newContainer.ParentId = baseContainer.Id;
                            newContainer = FillingData(newContainer, resultPackSect,
                                coll.Containers.Count);
                                
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
                    
                coll.Adds(tempThreeContainers);

            }
            return coll.Containers;
        }

        // Проверка на то, что в списке контейнеров tempThreeContainers нет текущего контейнера
        private static bool ValidateToSameContainers(List<Container> tempThreeContainers, Container newContainer)
        {
            return tempThreeContainers.Any(container => Equals(newContainer, container));
        }

        // Переопределенный метод Equals
        private static bool Equals(Container obj1, Container obj2)
        {
            return (obj1.DataContainer.A1.Equals(obj2.DataContainer.A1) && obj1.DataContainer.A2.Equals(obj2.DataContainer.A2) &&
                obj1.DataContainer.B1.Equals(obj2.DataContainer.B1) && obj1.Fine.Equals(obj2.Fine)) ||
                (obj1.DataContainer.A1.Equals(obj2.DataContainer.A2) && obj1.DataContainer.A2.Equals(obj2.DataContainer.A1) &&
                obj1.DataContainer.B1.Equals(obj2.DataContainer.B2) && obj1.Fine.Equals(obj2.Fine));
        }

        // Заполнение текущего контейнера данными
        private static Container FillingData(Container newContainer, ApartureLen result, int id)
        {
            newContainer.DataContainer.B1 = result.DataContainer.B1;
            newContainer.DataContainer.B2 = result.DataContainer.B2;
            newContainer.DataContainer.A2 = result.DataContainer.A2;
            newContainer.DataContainer.A1 = result.DataContainer.A1;
            newContainer.Id = id;
            newContainer.Fine = result.Fine;
            newContainer.FineChain += result.Fine;
            newContainer.OriginDataContainer.A1 = result.OriginDataContainer.A1;
            newContainer.OriginDataContainer.A2 = result.OriginDataContainer.A2;
            newContainer.OriginDataContainer.B1 = result.OriginDataContainer.B1;
            newContainer.OriginDataContainer.B2 = result.OriginDataContainer.B2;

            return newContainer;
        }

        private static void DeleteExceedFlat(List<Container> tempThreeContainers)
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
