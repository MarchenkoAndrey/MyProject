using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace Resettlement
{
    public class PrintResult : UserInterface
    {
        public static void GreedyIterationPrintResult(List<object> greedyAlgorithm, int countFloor, double entryway, double step, int a, bool flag)
        {
            if (flag)
            {
                resultGreedy_label.Text +=
                    ("Итог " + a + "-й итерации жадного алгоритма:\r\n").ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                resultGreedy_label.Text +=
                    ("Итог работы жадного алгоритма:\r\n").ToString(CultureInfo.InvariantCulture);
            }
            resultGreedy_label.Text +=
                 (string.Format("Штраф {0}", greedyAlgorithm[0]) + "\r\n").ToString(CultureInfo.InvariantCulture);

            if (countFloor == 2)
              {
                    resultGreedy_label.Text += "\r\n";
                    var optArrangeSecondFloorResult = CreateSecondFloor.MethodeCreateSecondFloor(greedyAlgorithm[1], greedyAlgorithm[2], entryway, step);
                    foreach (var i in (IEnumerable)optArrangeSecondFloorResult[0])
                    {
                        resultGreedy_label.Text += (string.Format(" {0} ", i));
                    }
                    resultGreedy_label.Text += "\r\n";

                    foreach (var i in (IEnumerable)optArrangeSecondFloorResult[1])
                    {
                        resultGreedy_label.Text += (string.Format(" {0} ", i));
                    }
                    resultGreedy_label.Text += "\r\n";

                    resultGreedy_label.Text += "-------------------------------\r\n";
                                                
                    foreach (var i in (IEnumerable)optArrangeSecondFloorResult[2])
                    {
                        resultGreedy_label.Text += (string.Format(" {0} ", i));
                    }
                    resultGreedy_label.Text += "\r\n";

                    foreach (var i in (IEnumerable)optArrangeSecondFloorResult[3])
                    {
                        resultGreedy_label.Text += (string.Format(" {0} ", i));
                    }
                    resultGreedy_label.Text += "\r\n";
                    resultGreedy_label.Text += (string.Format("Штраф от этажей {0} \r\n",optArrangeSecondFloorResult[4]));
                    resultGreedy_label.Text += "\r\n";
                }
                else if (countFloor == 1 || countFloor.ToString(CultureInfo.InvariantCulture) == "")
                {
                    resultGreedy_label.Text +=
                        ("Оптимальная расстановка однокомнатных квартир: ").ToString(CultureInfo.InvariantCulture);
                    foreach (var i in (IEnumerable)greedyAlgorithm[1])
                    {
                        resultGreedy_label.Text += (string.Format(" {0} ", i));
                    }
                    resultGreedy_label.Text += ("\r\n").ToString(CultureInfo.InvariantCulture);
                    resultGreedy_label.Text +=
                        ("Оптимальная расстановка двухкомнатных квартир: ").ToString(CultureInfo.InvariantCulture);
                    foreach (var i in (IEnumerable)greedyAlgorithm[2])
                    {
                        resultGreedy_label.Text += (string.Format(" {0} ", i));
                    }
                    resultGreedy_label.Text += ("\r\n").ToString(CultureInfo.InvariantCulture);
                    resultGreedy_label.Text += ("\r\n").ToString(CultureInfo.InvariantCulture);
                }
        }

        public static void FullSearchPrintResult(List<object> fullSearch, int countFloor)
        {
            if (countFloor == 2)
            {
                const string resultFullSearch = "Итог полного перебора:";
                resultFullSearch_label.Text += resultFullSearch.ToString(CultureInfo.InvariantCulture) + "\r\n";
                var minFine = string.Format("Суммарный штраф {0}", fullSearch[0]);
                resultFullSearch_label.Text += minFine.ToString(CultureInfo.InvariantCulture) + "\r\n" + "\r\n";
                foreach (var i in (IEnumerable)fullSearch[1])
                {
                    resultFullSearch_label.Text += (string.Format(" {0} ", i));
                }
                resultFullSearch_label.Text += "\r\n";

                foreach (var i in (IEnumerable)fullSearch[2])
                {
                    resultFullSearch_label.Text += (string.Format(" {0} ", i));
                }
                resultFullSearch_label.Text += "\r\n";

                resultFullSearch_label.Text += "-------------------------------\r\n";

                foreach (var i in (IEnumerable)fullSearch[3])
                {
                    resultFullSearch_label.Text += (string.Format(" {0} ", i));
                }
                resultFullSearch_label.Text += "\r\n";

                foreach (var i in (IEnumerable)fullSearch[4])
                {
                    resultFullSearch_label.Text += (string.Format(" {0} ", i));
                }
                resultFullSearch_label.Text += "\r\n";
                resultFullSearch_label.Text += (string.Format("Штраф от этажности {0} \r\n", fullSearch[5]));
            }
            else if (countFloor == 1 || countFloor.ToString(CultureInfo.InvariantCulture) == "")
            {
                const string resultFullSearch = "Итог полного перебора:";
                resultFullSearch_label.Text += resultFullSearch.ToString(CultureInfo.InvariantCulture) + "\r\n";
                var minFine = string.Format("Штраф {0}", fullSearch[0]);
                resultFullSearch_label.Text += minFine.ToString(CultureInfo.InvariantCulture) + "\r\n";

                const string optArrangeOne = "Оптимальная расстановка однокомнатных квартир";
                resultFullSearch_label.Text += optArrangeOne.ToString(CultureInfo.InvariantCulture);
                foreach (var i in (IEnumerable)fullSearch[1])
                {
                    resultFullSearch_label.Text += (string.Format(" {0} ", i));
                }
                resultFullSearch_label.Text += "\r\n";
                const string optArrangeTwo = "Оптимальная расстановка однокомнатных квартир";
                resultFullSearch_label.Text += optArrangeTwo.ToString(CultureInfo.InvariantCulture);
                foreach (var i in (IEnumerable)fullSearch[2])
                {
                    resultFullSearch_label.Text += (string.Format(" {0} ", i));
                }
                resultFullSearch_label.Text += "\r\n";
            }
        }
    }
}
