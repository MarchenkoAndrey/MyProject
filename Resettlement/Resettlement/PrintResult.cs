using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace Resettlement
{
    public partial class PrintResult : Form
    {
       
        public static void GreedyIterationPrintResult(List<object> greedyAlgorithm, int countFloor, double entryway, double step, int a, bool flag, Label resultGreedy_label)
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

            var s1 = (double []) greedyAlgorithm[1];
            for (var i=0; i<s1.Length;++i)
            {
                s1[i] = Math.Round(s1[i],1);
            }

            var s2 = (double[])greedyAlgorithm[1];
            for (var i = 0; i < s2.Length; ++i)
            {
                s2[i] = Math.Round(s2[i], 1);
            }


            resultGreedy_label.Text +=
                 (string.Format("Штраф {0}", greedyAlgorithm[0]) + "\r\n").ToString(CultureInfo.InvariantCulture);
            if (countFloor == 2)
            {
                  for (var index = 0; index < 2; ++index)
                  {
                      resultGreedy_label.Text += "\r\n";
                      foreach (var i in (IEnumerable)greedyAlgorithm[1])
                      {
                          resultGreedy_label.Text += (string.Format(" {0} ", i));
                      }
                      resultGreedy_label.Text += "\r\n";

                      foreach (var i in (IEnumerable)greedyAlgorithm[2])
                      {
                          resultGreedy_label.Text += (string.Format(" {0} ", i));
                      }
                      resultGreedy_label.Text += "\r\n";

                      if(index==0)
                      resultGreedy_label.Text += "-------------------------------";
                  }                  
              }

            if (countFloor == 3)
            {
                for (var index = 0; index < 3; ++index)
                {
                    resultGreedy_label.Text += "\r\n";
                    foreach (var i in (IEnumerable)greedyAlgorithm[1])
                    {
                        resultGreedy_label.Text += (string.Format(" {0} ", i));
                    }
                    resultGreedy_label.Text += "\r\n";

                    foreach (var i in (IEnumerable)greedyAlgorithm[2])
                    {
                        resultGreedy_label.Text += (string.Format(" {0} ", i));
                    }
                    resultGreedy_label.Text += "\r\n";

                    if (index == 0 || index == 1)
                        resultGreedy_label.Text += "-------------------------------";
                }
            }

                else if (countFloor == 1)
                {
                    resultGreedy_label.Text +=
                        ("Оптимальная расстановка контейнеров: ").ToString(CultureInfo.InvariantCulture);
                    resultGreedy_label.Text += ("\r\n").ToString(CultureInfo.InvariantCulture);
                    var b = 0;
                    resultGreedy_label.Text += "|";
                    foreach (var i in (IEnumerable)greedyAlgorithm[1])
                    {
                        resultGreedy_label.Text += (string.Format(" {0:0.0} ", i));
                        ++b;
                        if (b % 2 == 0)
                        {
                            resultGreedy_label.Text += "|";
                        }
                        
                    }
                    resultGreedy_label.Text += ("\r\n").ToString(CultureInfo.InvariantCulture);

                    b = 0;
                    resultGreedy_label.Text += "|";
                    foreach (var i in (IEnumerable)greedyAlgorithm[2])
                    {
                        resultGreedy_label.Text += (string.Format(" {0:0.0} ", i));
                        ++b;
                        if (b % 2 == 0)
                            resultGreedy_label.Text += "|";
                    }
                    resultGreedy_label.Text += ("\r\n").ToString(CultureInfo.InvariantCulture);
                    
                    var ss1 = (List<double>)greedyAlgorithm[4];
                    if (ss1.Count != 0)
                    {
                        resultGreedy_label.Text += "Варианты прямоугольников a(i), не попавших в итоговый ответ";
                        foreach (var i in (IEnumerable)ss1)
                        {
                            resultGreedy_label.Text += (string.Format(" {0:0.0} ", i));
                        }
                    }

                    resultGreedy_label.Text += ("\r\n").ToString(CultureInfo.InvariantCulture);
                    var ss2 = (List<double>)greedyAlgorithm[5];
                    if (ss2.Count != 0)
                    {
                        resultGreedy_label.Text += "Варианты прямоугольников b(i), не попавших в итоговый ответ";
                        foreach (var i in (IEnumerable)ss2)
                        {
                            resultGreedy_label.Text += (string.Format(" {0:0.0} ", i));
                        }
                    }
                }
        }

        public static void FullSearchPrintResult(List<object> fullSearch, int countFloor, Label resultFullSearch_label)
        {
            if (countFloor == 2)
            {
                const string resultFullSearch = "Итог полного перебора:";
                resultFullSearch_label.Text += resultFullSearch.ToString(CultureInfo.InvariantCulture) + "\r\n";
                var minFine = string.Format("Штраф 1-этажа {0}", fullSearch[0]);
                resultFullSearch_label.Text += minFine.ToString(CultureInfo.InvariantCulture) + "\r\n" + "\r\n";
                for (var index = 0; index < 2; ++index)
                {
                    foreach (var i in (IEnumerable) fullSearch[1])
                    {
                        resultFullSearch_label.Text += (string.Format(" {0} ", i));
                    }
                    resultFullSearch_label.Text += "\r\n";

                    foreach (var i in (IEnumerable) fullSearch[2])
                    {
                        resultFullSearch_label.Text += (string.Format(" {0} ", i));
                    }
                    resultFullSearch_label.Text += "\r\n";

                    if (index == 0)
                    {
                        resultFullSearch_label.Text += "-------------------------------\r\n";
                    }
                }
            }
            if (countFloor == 3)
            {
                const string resultFullSearch = "Итог полного перебора:";
                resultFullSearch_label.Text += resultFullSearch.ToString(CultureInfo.InvariantCulture) + "\r\n";
                var minFine = string.Format("Штраф 1-этажа {0}", fullSearch[0]);
                resultFullSearch_label.Text += minFine.ToString(CultureInfo.InvariantCulture) + "\r\n" + "\r\n";
                for (var index = 0; index < 3; ++index)
                {
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

                    if (index == 0 || index == 1)
                    {
                        resultFullSearch_label.Text += "-------------------------------\r\n";
                    }
                }
            }

            else if (countFloor == 1)
            {
                const string resultFullSearch = "Итог полного перебора:";
                resultFullSearch_label.Text += resultFullSearch.ToString(CultureInfo.InvariantCulture) + "\r\n";
                var minFine = string.Format("Штраф {0}", fullSearch[0]);
                resultFullSearch_label.Text += minFine.ToString(CultureInfo.InvariantCulture) + "\r\n";

                const string optArrangeOne = "Оптимальная расстановка контейнеров";
                resultFullSearch_label.Text += optArrangeOne.ToString(CultureInfo.InvariantCulture);
                resultFullSearch_label.Text += "\r\n";
                var b = 0;
                resultFullSearch_label.Text += "|";
                foreach (var i in (IEnumerable)fullSearch[1])
                {
                    resultFullSearch_label.Text += (string.Format(" {0:0.0} ", i));
                    ++b;
                    if (b%2 == 0)
                    {
                        resultFullSearch_label.Text += "|";
                    }
                   
                }
                resultFullSearch_label.Text += "\r\n";

                b = 0;
                resultFullSearch_label.Text += "|";
                foreach (var i in (IEnumerable)fullSearch[2])
                {
                    resultFullSearch_label.Text += (string.Format(" {0:0.0} ", i));
                    ++b;
                    if (b % 2 == 0)
                    {
                        resultFullSearch_label.Text += "|";
                    }
                   
                }
                resultFullSearch_label.Text += "\r\n";
                var ss1 = (List<double>)fullSearch[3];
                if (ss1.Count != 0)
                {
                    resultFullSearch_label.Text += "Варианты прямоугольников a(i), не попавших в итоговый ответ";
                    foreach (var i in (IEnumerable)ss1)
                    {
                        resultFullSearch_label.Text += (string.Format(" {0:0.0} ", i));
                    }
                }

                resultFullSearch_label.Text += ("\r\n").ToString(CultureInfo.InvariantCulture);
                var ss2 = (List<double>)fullSearch[4];
                if (ss2.Count != 0)
                {
                    resultFullSearch_label.Text += "Варианты прямоугольников b(i), не попавших в итоговый ответ";
                    foreach (var i in (IEnumerable)ss2)
                    {
                        resultFullSearch_label.Text += (string.Format(" {0:0.0} ", i));
                    }
                }

                resultFullSearch_label.Text += "\r\n";
            }
        }
    }
}
