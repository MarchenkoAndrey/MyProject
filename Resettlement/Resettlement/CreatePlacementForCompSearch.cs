using System;
using System.Collections.Generic;
using System.Linq;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    //todo переименовать поля
    public static class CreatePlacementForCompSearch
    {
        //двигаем стены из-за ApartureLength
        public static DataPerformAlgorithm CreatePlacement(double[] listOneFlat, double[] listTwoFlat, double step)
        {
            double[] tempArrayTwoFlat;
            Array.Copy(listTwoFlat, tempArrayTwoFlat = new double[listTwoFlat.Length], listTwoFlat.Length);
            var fineCastApartureLen = 0.0;
            var totalFine = 0.0;
            double[] totalListOneFlat;
            Array.Copy(listOneFlat, totalListOneFlat = new double[listOneFlat.Length], listOneFlat.Length);
            
            for (var k = 0; k < listTwoFlat.Length; k = k + 2)
            {
                if (tempArrayTwoFlat[k] - listOneFlat[k] < Constraints.ApartureLength)
                {
                    var leftAddition = Constraints.ApartureLength - (tempArrayTwoFlat[k] - listOneFlat[k]);
                    if (leftAddition <= step)
                    {
                        tempArrayTwoFlat[k] += Math.Round(step, 1);
                        fineCastApartureLen += Math.Round(step, 1);
                    }
                    else
                    {
                        tempArrayTwoFlat[k] += Math.Round(Math.Ceiling(leftAddition / step) * step, 1);
                        fineCastApartureLen += Math.Round(Math.Ceiling(leftAddition / step) * step, 1);
                    }
                }
                if (tempArrayTwoFlat[k + 1] - listOneFlat[k + 1] < Constraints.ApartureLength)
                {
                    var rightAddition = Constraints.ApartureLength -
                                        (tempArrayTwoFlat[k + 1] - listOneFlat[k + 1]);
                    if (rightAddition <= step)
                    {
                        tempArrayTwoFlat[k + 1] += Math.Round(step, 1);
                        fineCastApartureLen += Math.Round(step, 1);
                    }
                    else
                    {
                        tempArrayTwoFlat[k + 1] += Math.Round(Math.Ceiling(rightAddition / step) * step, 1);
                        fineCastApartureLen += Math.Round(Math.Ceiling(rightAddition / step) * step, 1);
                    }
                }
                //Приведение площади
                //На данный момент есть 2 списка удовлетворяющих d (i и tempArrayTwoFlat)
                //считаем длины a и b
                //разность длин тут же определяем как штраф
                //Если b<a добавляем в b                    
                    //формируем новый список bi
                //Если a<b добавляем в a 
                    //Считаем bi-ai, делим добавку между ними так, чтобы не превысить d
                    //Формируем новый список ai

                var lengthA = Math.Round(listOneFlat[k] + listOneFlat[k + 1] + Constraints.EntrywayLength + 3*step, 1); // + добавка
                var lenghtB = Math.Round(tempArrayTwoFlat[k] + tempArrayTwoFlat[k + 1] + 2 * step, 1);
                var diffOfLengths = Math.Round(Math.Abs(lengthA - lenghtB), 1);

                double[] newListA;
                Array.Copy(listOneFlat, newListA = new double[listOneFlat.Length], listOneFlat.Length);

                if (lengthA > lenghtB) throw new Exception("b>a"); // Невозможно из-за предварительного подсчета ограничения d (bi-ai>=1.5) * 2 
                if (lenghtB > lengthA)
                {
                    var listOfBminusA = new List<double>
                    {
                        Math.Round(tempArrayTwoFlat[k] - listOneFlat[k], 1), 
                        Math.Round(tempArrayTwoFlat[k + 1] - listOneFlat[k + 1], 1)
                    };

                    var maxOfDiffBminusA = new Tuple<double, int>(listOfBminusA.Max(), listOfBminusA.IndexOf(listOfBminusA.Max()));
                    var validAddition = maxOfDiffBminusA.Item1 - 1.5;  // hack кратности 0.3
                    
                    if (validAddition >= diffOfLengths)
                        newListA[k + maxOfDiffBminusA.Item2] += diffOfLengths; // увеличить соответствующее a
                    else
                    {
                        newListA[k + maxOfDiffBminusA.Item2] += validAddition;  // увеличить a на validAddition, разницу перекинуть в другой a
                        if (maxOfDiffBminusA.Item2 == 0)
                            newListA[k + 1] += Math.Round(diffOfLengths - validAddition, 1);
                        else
                            newListA[k] += Math.Round(diffOfLengths - validAddition, 1);
                    }
                }
                totalFine += Math.Round(diffOfLengths, 1);
                
                totalListOneFlat[k] = newListA[k];
                totalListOneFlat[k + 1] = newListA[k + 1];
            } 

            return new DataPerformAlgorithm(totalListOneFlat.ToList(), tempArrayTwoFlat.ToList(),
                Math.Round(totalFine + fineCastApartureLen, 1));
        }
    }
}
