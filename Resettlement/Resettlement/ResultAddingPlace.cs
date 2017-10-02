using System;
using System.Collections.Generic;
using System.Linq;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    class ResultAddingPlace
    {
        public double A1;
        public double A2;
        public double FineContainer;

        public ResultAddingPlace(double a1, double a2, double fineContainer)
        {
            A1 = a1;
            A2 = a2;
            FineContainer = fineContainer;
        }

        public static ResultAddingPlace CalculateAddingPlace(DataContainer container, double step)
        {
            //Считаем длину нижней части секции (lengthA) и верхней части секции (lengthB) у контейнера
            var lengthA = Math.Round(container.A1 + container.A2 + Constraints.EntrywayLength + 3 * step, 1);
            var lengthB = Math.Round(container.B1 + container.B2 + 2 * step, 1);
            //Берем модуль разности этих длин
            var diffOfLengths = Math.Round(Math.Abs(lengthA - lengthB), 1);
            //Копируем весь список квартир из нижней части
            var newListA = new List<double>{container.A1, container.A2};
            //Если длина A больше длины Б, генерация исключения об ошибке из-за предварительного подсчета ограничения d (bi-ai>=1.5)
            if (lengthA > lengthB) throw new Exception("b>a");
            //Если длина А меньше длины B, то
            if (lengthB > lengthA)
            {
                //Создаем список в первом контейнере (B1-A1, B2-A2)
                var listOfBminusA = new List<double>
                    {
                        Math.Round(container.B1 - container.A1, 1), 
                        Math.Round(container.B2 - container.A2, 1)
                    };
                //Берем максимум и индекс списка listOfBminusA
                var maxOfDiffBminusA = new Tuple<double, int>(listOfBminusA.Max(), listOfBminusA.IndexOf(listOfBminusA.Max()));
                //Вычитаем 1.5. Ограничение в 1.25, но также ограничение на шаг в 0.3, поэтому 1.5
                var validAddition = maxOfDiffBminusA.Item1 - 1.5;
                //Если подсчитанная добавка может закрыть собой всю разницу, то закрываем в этом месте всю разницу (за счет увеличения Ai)
                if (validAddition >= diffOfLengths)
                    newListA[maxOfDiffBminusA.Item2] += diffOfLengths;
                else
                {
                    //Иначе значение Ai увеличивается на подсчитанную добавку, остатки пойдут в следующее значение Ai (из другого контейнера)
                    newListA[maxOfDiffBminusA.Item2] += validAddition;
                    if (maxOfDiffBminusA.Item2 == 0)
                        newListA[1] += Math.Round(diffOfLengths - validAddition, 1);
                    else
                        newListA[0] += Math.Round(diffOfLengths - validAddition, 1);
                }
            }
            return new ResultAddingPlace(newListA[0], newListA[1], diffOfLengths);
        }
    }
}
