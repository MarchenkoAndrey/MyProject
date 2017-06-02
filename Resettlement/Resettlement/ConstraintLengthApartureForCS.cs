using System;
using System.Collections.Generic;
using System.Linq;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    //todo переименовать поля
    public static class ConstraintLengthApartureForCs
    {
        //двигаем стены из-за ApartureLength
        public static DataPerformAlgorithm LengthAparture(double[] i, double[] j, double step, double entryway)
        {
            double[] tempArrayTwoFlat;
            Array.Copy(j, tempArrayTwoFlat = new double[j.Length], j.Length);
            var currentFineFirstFloor = 0.0;
            var totFine = 0.0;
            double[] totListA;
            Array.Copy(i, totListA = new double[i.Length], i.Length);
            
            for (var k = 0; k < j.Length; k = k + 2)
            {
                if (tempArrayTwoFlat[k] - i[k] < Constraints.ApartureLength)
                {
                    var leftAddition = Constraints.ApartureLength - (tempArrayTwoFlat[k] - i[k]);
                    if (leftAddition <= step)
                    {
                        tempArrayTwoFlat[k] += Math.Round(step, 1);
                        currentFineFirstFloor += Math.Round(step, 1);
                    }
                    else
                    {
                        tempArrayTwoFlat[k] += Math.Round(Math.Ceiling(leftAddition / step) * step, 1);
                        currentFineFirstFloor += Math.Round(Math.Ceiling(leftAddition / step) * step, 1);
                    }
                }
                if (tempArrayTwoFlat[k + 1] - i[k + 1] < Constraints.ApartureLength)
                {
                    var rightAddition = Constraints.ApartureLength -
                                        (tempArrayTwoFlat[k + 1] - i[k + 1]);
                    if (rightAddition <= step)
                    {
                        tempArrayTwoFlat[k + 1] += Math.Round(step, 1);
                        currentFineFirstFloor += Math.Round(step, 1);
                    }
                    else
                    {
                        tempArrayTwoFlat[k + 1] += Math.Round(Math.Ceiling(rightAddition / step) * step, 1);
                        currentFineFirstFloor += Math.Round(Math.Ceiling(rightAddition / step) * step, 1);
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

                var lenA = Math.Round(i[k] + i[k + 1] + entryway + 3*step, 1);
                var lenB = Math.Round(tempArrayTwoFlat[k] + tempArrayTwoFlat[k + 1] + 2 * step, 1);
                var fineDifflen = Math.Round(Math.Abs(lenA - lenB), 1);

                double[] newListA;
                Array.Copy(i, newListA = new double[i.Length], i.Length);

                if (lenA > lenB) throw new Exception("b>a"); //Невозможно из-за предварительного подсчета ограничения d (bi-ai>=1.5) * 2 
                if (lenB > lenA)
                {
                    var listss = new List<double>
                    {
                        Math.Round(tempArrayTwoFlat[k] - i[k], 1), 
                        Math.Round(tempArrayTwoFlat[k + 1] - i[k + 1], 1)
                    };

                    var maxss = new Tuple<double, int>(listss.Max(), listss.IndexOf(listss.Max()));
                    var diffss = maxss.Item1 - 1.5; // hack кратности 0.3
                    if (diffss >= fineDifflen)
                    {
                        //увеличить соответствующее a
                        newListA[k + maxss.Item2] += fineDifflen;
                    }
                    else
                    {
                        //увеличить a на diffss, разницу перекинуть в другой a
                        newListA[k + maxss.Item2] += diffss;
                        if (maxss.Item2 == 0)
                        {
                            newListA[k + 1] +=  Math.Round(fineDifflen - diffss, 1);
                        }
                        else
                        {
                            newListA[k] +=  Math.Round(fineDifflen - diffss, 1);
                        }
                    }
                }
                totFine+=Math.Round(fineDifflen, 1);
                
                totListA[k] = newListA[k];
                totListA[k + 1] = newListA[k + 1];
            } 

            return new DataPerformAlgorithm(totListA.ToList(), tempArrayTwoFlat.ToList(),
                Math.Round(totFine + currentFineFirstFloor, 1));
        }
    }
}
