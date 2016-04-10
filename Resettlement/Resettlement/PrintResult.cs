using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace Resettlement
{
    public static class PrintResult
    {
        public static void GreedyIterationPrintResult(List<object> greedyAlgorithm, int countFloor, int a, bool flag, Label resultGreedyLabel)
        {
            if (flag)
            {
                resultGreedyLabel.Text +=
                    ("Result " + a + " iteration of heuristic algorithm:\r\n").ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                resultGreedyLabel.Text +=
                    ("Total result of heuristic algorithm:\r\n").ToString(CultureInfo.InvariantCulture);
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

            resultGreedyLabel.Text +=
                 (string.Format("Value of the functional F: {0}", greedyAlgorithm[0]) + "\r\n").ToString(CultureInfo.InvariantCulture);


            if (countFloor == 2 || countFloor == 3 || countFloor == 4)
            {
                if (!flag)
                {
                    for (var index = 0; index < countFloor; ++index)
                    {
                        var line = 0;
                        resultGreedyLabel.Text += "|";
                        foreach (var i in (IEnumerable) greedyAlgorithm[1])
                        {
                            resultGreedyLabel.Text += (string.Format(" {0:0.0} ", i));
                            ++line;
                            if (line%2 == 0)
                            {
                                resultGreedyLabel.Text += "|";
                            }
                        }
                        resultGreedyLabel.Text += "\r\n";

                        line = 0;
                        resultGreedyLabel.Text += "|";

                        foreach (var i in (IEnumerable) greedyAlgorithm[2])
                        {
                            resultGreedyLabel.Text += (string.Format(" {0:0.0} ", i));
                            ++line;
                            if (line%2 == 0)
                            {
                                resultGreedyLabel.Text += "|";
                            }
                        }
                        resultGreedyLabel.Text += "\r\n";

                        var strokeLength = "";
                        for (var i = 0; i < s1.Length; ++i)
                        {
                            strokeLength += "--------";
                        }
                        if (index != countFloor - 1)
                        {
                            resultGreedyLabel.Text += strokeLength;
                        }
                        resultGreedyLabel.Text += "\r\n";
                    }
                }
                if (!flag)
                {
                    var listOneParam = (List<double>) greedyAlgorithm[4];
                    var listTwoParam = (List<double>) greedyAlgorithm[5];
                    if (listOneParam.Count > 0)
                    {
                        resultGreedyLabel.Text += "Rectangles a(i) not included in the total result";

                        foreach (var i in listOneParam)
                        {
                            resultGreedyLabel.Text += (string.Format(" {0:0.0} ", i));
                        }
                        resultGreedyLabel.Text += ("\r\n");
                    }

                    if (listTwoParam.Count > 0)
                    {
                        resultGreedyLabel.Text += "Rectangles b(i) not included in the total result";
                        foreach (var i in listTwoParam)
                        {
                            resultGreedyLabel.Text += (string.Format(" {0:0.0} ", i));
                        }
                        resultGreedyLabel.Text += ("\r\n");
                    }
                }
            }

                else if (countFloor == 1)
                {
                    resultGreedyLabel.Text +=
                        ("Optimal containers packaging: ").ToString(CultureInfo.InvariantCulture);
                    resultGreedyLabel.Text += ("\r\n").ToString(CultureInfo.InvariantCulture);
                    var line = 0;
                    resultGreedyLabel.Text += "|";
                    foreach (var i in (IEnumerable)greedyAlgorithm[1])
                    {
                        resultGreedyLabel.Text += (string.Format(" {0:0.0} ", i));
                        ++line;
                        if (line % 2 == 0)
                        {
                            resultGreedyLabel.Text += "|";
                        }
                        
                    }
                    resultGreedyLabel.Text += ("\r\n").ToString(CultureInfo.InvariantCulture);

                    line = 0;
                    resultGreedyLabel.Text += "|";
                    foreach (var i in (IEnumerable)greedyAlgorithm[2])
                    {
                        resultGreedyLabel.Text += (string.Format(" {0:0.0} ", i));
                        ++line;
                        if (line % 2 == 0)
                            resultGreedyLabel.Text += "|";
                    }
                    resultGreedyLabel.Text += ("\r\n").ToString(CultureInfo.InvariantCulture);
                    
                    var ss1 = (List<double>)greedyAlgorithm[4];
                    if (ss1.Count != 0)
                    {
                        resultGreedyLabel.Text += "Rectangles a(i) not included in the total result";
                        foreach (var i in (IEnumerable)ss1)
                        {
                            resultGreedyLabel.Text += (string.Format(" {0:0.0} ", i));
                        }
                    }

                    resultGreedyLabel.Text += ("\r\n").ToString(CultureInfo.InvariantCulture);
                    var ss2 = (List<double>)greedyAlgorithm[5];
                    if (ss2.Count != 0)
                    {
                        resultGreedyLabel.Text += "Rectangles b(i) not included in the total result";
                        foreach (var i in (IEnumerable)ss2)
                        {
                            resultGreedyLabel.Text += (string.Format(" {0:0.0} ", i));
                        }
                        resultGreedyLabel.Text += ("\r\n").ToString(CultureInfo.InvariantCulture);
                    }  
                }
        }

        public static void FullSearchPrintResult(List<object> fullSearch, int countFloor, Label resultFullSearchLabel)
        {
            if (countFloor == 2 || countFloor==3 || countFloor==4)
            {
                var s1 = (double[])fullSearch[1];
                var s2 = s1.Length;
                const string resultFullSearch = "Result of comprehensive search:";
                resultFullSearchLabel.Text += resultFullSearch.ToString(CultureInfo.InvariantCulture) + "\r\n";
                var minFine = string.Format("Value of the functional F: {0}", fullSearch[0]);
                resultFullSearchLabel.Text += minFine.ToString(CultureInfo.InvariantCulture) + "\r\n" + "\r\n";
                for (var index = 0; index < countFloor; ++index)
                {
                    var line = 0;
                    resultFullSearchLabel.Text += "|";
                    foreach (var i in (IEnumerable) fullSearch[1])
                    {
                        resultFullSearchLabel.Text += (string.Format(" {0:0.0} ", i));
                        ++line;
                        if (line % 2 == 0)
                        {
                            resultFullSearchLabel.Text += "|";
                        }
                    }
                    resultFullSearchLabel.Text += "\r\n";

                    line = 0;
                    resultFullSearchLabel.Text += "|";
                    foreach (var i in (IEnumerable) fullSearch[2])
                    {
                        resultFullSearchLabel.Text += (string.Format(" {0:0.0} ", i));
                        ++line;
                        if (line % 2 == 0)
                        {
                            resultFullSearchLabel.Text += "|";
                        }
                    }
                    resultFullSearchLabel.Text += "\r\n";

                    var strokeLength = "";
                    for (var i = 0; i < s2; ++i)
                    {
                        strokeLength += "--------";
                    }
                    if (index != countFloor - 1)
                    {
                        resultFullSearchLabel.Text += strokeLength;
                    }
                    resultFullSearchLabel.Text += "\r\n";
                }

                var listOneParam = (List<double>) fullSearch[3];
                var listTwoParam = (List<double>) fullSearch[4];
                if (listOneParam.Count > 0)
                {
                    resultFullSearchLabel.Text += "Rectangles a(i) not included in the total result";

                    foreach (var i in listOneParam)
                    {
                        resultFullSearchLabel.Text += (string.Format(" {0:0.0} ", i));
                    }
                    resultFullSearchLabel.Text += ("\r\n");
                }

                if (listTwoParam.Count > 0)
                {
                    resultFullSearchLabel.Text += "Rectangles b(i) not included in the total result";
                    foreach (var i in listTwoParam)
                    {
                        resultFullSearchLabel.Text += (string.Format(" {0:0.0} ", i));
                    }
                    resultFullSearchLabel.Text += ("\r\n");
                }

            }   

            else if (countFloor == 1)
            {
                const string resultFullSearch = "Result of full search";
                resultFullSearchLabel.Text += resultFullSearch.ToString(CultureInfo.InvariantCulture) + "\r\n";
                var minFine = string.Format("Fine {0}", fullSearch[0]);
                resultFullSearchLabel.Text += minFine.ToString(CultureInfo.InvariantCulture) + "\r\n";

                const string optArrangeOne = "Optimal containers packaging";
                resultFullSearchLabel.Text += optArrangeOne.ToString(CultureInfo.InvariantCulture);
                resultFullSearchLabel.Text += "\r\n";
                var b = 0;
                resultFullSearchLabel.Text += "|";
                foreach (var i in (IEnumerable)fullSearch[1])
                {
                    resultFullSearchLabel.Text += (string.Format(" {0:0.0} ", i));
                    ++b;
                    if (b%2 == 0)
                    {
                        resultFullSearchLabel.Text += "|";
                    }
                   
                }
                resultFullSearchLabel.Text += "\r\n";

                b = 0;
                resultFullSearchLabel.Text += "|";
                foreach (var i in (IEnumerable)fullSearch[2])
                {
                    resultFullSearchLabel.Text += (string.Format(" {0:0.0} ", i));
                    ++b;
                    if (b % 2 == 0)
                    {
                        resultFullSearchLabel.Text += "|";
                    }
                   
                }
                resultFullSearchLabel.Text += "\r\n";
                var ss1 = (List<double>)fullSearch[3];
                if (ss1.Count != 0)
                {
                    resultFullSearchLabel.Text += "Rectangles a(i) not included in the total result";
                    foreach (var i in (IEnumerable)ss1)
                    {
                        resultFullSearchLabel.Text += (string.Format(" {0:0.0} ", i));
                    }
                }

                resultFullSearchLabel.Text += ("\r\n").ToString(CultureInfo.InvariantCulture);
                var ss2 = (List<double>)fullSearch[4];
                if (ss2.Count != 0)
                {
                    resultFullSearchLabel.Text += "Rectangles b(i) not included in the total result";
                    foreach (var i in (IEnumerable)ss2)
                    {
                        resultFullSearchLabel.Text += (string.Format(" {0:0.0} ", i));
                    }
                }

                resultFullSearchLabel.Text += "\r\n";
            }
        }
    }
}
