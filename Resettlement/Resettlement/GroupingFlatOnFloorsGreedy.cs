using System.Collections.Generic;
using System.Linq;

namespace Resettlement
{
    //жадный алгоритм для разбиения на примерно равные группы квартир по этажам
    public class GroupingFlatOnFloorsGreedy
    {
        public static List<List<double>> GroupingFlatOnFloorsGreed(List<double> listFlat, int countFloor)
        {
            var f1 = new List<double>();
            var f2 = new List<double>();
            var f3 = new List<double>();
            var f4 = new List<double>();
            var f5 = new List<double>();
            switch (countFloor)
            {
                case 2:
                    for (var i = listFlat.Count - 1; i >= 0; i--)
                    {
                        if (f1.Sum() < f2.Sum())
                            f1.Add(listFlat[i]);
                        else
                        {
                            f2.Add(listFlat[i]);
                        }
                    }

                    return new List<List<double>> {f1, f2};

                case 3:
                    for (var i = listFlat.Count - 1; i >= 0; i--)
                    {
                        if (f1.Sum() < f2.Sum())
                            f1.Add(listFlat[i]);
                        else if (f2.Sum() < f3.Sum())
                        {
                            f2.Add(listFlat[i]);
                        }
                        else
                        {
                            f3.Add(listFlat[i]);
                        }
                    }

                    return new List<List<double>> {f1, f2, f3};

                case 4:
                    for (var i = listFlat.Count - 1; i >= 0; i--)
                    {
                        if (f1.Sum() < f2.Sum())
                            f1.Add(listFlat[i]);
                        else if (f2.Sum() < f3.Sum())
                        {
                            f2.Add(listFlat[i]);
                        }
                        else if (f3.Sum() < f4.Sum())
                        {
                            f3.Add(listFlat[i]);
                        }
                        else
                        {
                            f4.Add(listFlat[i]);
                        }
                    }

                    return new List<List<double>> {f1, f2, f3, f4};
                case 5:
                    for (var i = listFlat.Count - 1; i >= 0; i--)
                    {
                        if (f1.Sum() < f2.Sum())
                            f1.Add(listFlat[i]);
                        else if (f2.Sum() < f3.Sum())
                        {
                            f2.Add(listFlat[i]);
                        }
                        else if (f3.Sum() < f4.Sum())
                        {
                            f3.Add(listFlat[i]);
                        }
                        else if (f4.Sum() < f5.Sum())
                        {
                            f4.Add(listFlat[i]);
                        }
                        else
                        {
                            f5.Add(listFlat[i]);
                        }
                    }

                    return new List<List<double>> {f1, f2, f3, f4, f5};

                default:
                    return new List<List<double>> {listFlat};
            }
        }
    }   
}
