using System;
using System.Linq;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    //Класс для выравнивания конечного отображения
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
            
            for (var k = 0; k < listTwoFlat.Length; k = k + 2) // Заполнение секций
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
                //Приведение площади - отдельный метод
                var resultAddingPlace =
                    ResultAddingPlace.CalculateAddingPlace(new DataContainer
                    {
                        A1 = listOneFlat[k],
                        A2 = listOneFlat[k + 1],
                        B1 = tempArrayTwoFlat[k],
                        B2 = tempArrayTwoFlat[k + 1]
                    }, 
                    step);

                totalFine += Math.Round(resultAddingPlace.FineContainer, 1);

                totalListOneFlat[k] = resultAddingPlace.A1;
                totalListOneFlat[k + 1] = resultAddingPlace.A2;
            } 

            return new DataPerformAlgorithm(totalListOneFlat.ToList(), tempArrayTwoFlat.ToList(),
                Math.Round(totalFine + fineCastApartureLen, 1));
        }
    }
}
