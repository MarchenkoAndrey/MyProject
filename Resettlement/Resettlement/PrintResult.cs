using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Resettlement.GeneralData;

namespace Resettlement
{
    public static class PrintResult
    {
        public static void GreedyIterationPrintResult(List<object> greedyAlgorithm, int countFloor, int a, bool flag, Label resultGreedyLabel)
        {
            if (flag)
            {
                resultGreedyLabel.Text +=
                    string.Format(MessagesText.ResultIterationHeuristicAlgorithm,a).ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                resultGreedyLabel.Text +=
                    MessagesText.TotalResultHeuristicAlgorithm.ToString(CultureInfo.InvariantCulture);
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
                 string.Format(MessagesText.ValueFunctionalF, greedyAlgorithm[0]).ToString(CultureInfo.InvariantCulture);


            if (countFloor == 2 || countFloor == 3 || countFloor == 4)
            {
                if (!flag)
                {
                    for (var index = 0; index < countFloor; ++index)
                    {
                        var line = 0;
                        resultGreedyLabel.Text += MessagesText.DividingLine;
                        foreach (var i in (IEnumerable) greedyAlgorithm[1])
                        {
                            resultGreedyLabel.Text += (string.Format(" {0:0.0} ", i));
                            ++line;
                            if (line%2 == 0)
                            {
                                resultGreedyLabel.Text += MessagesText.DividingLine;
                            }
                        }
                        resultGreedyLabel.Text += MessagesText.NextLine;

                        line = 0;
                        resultGreedyLabel.Text += MessagesText.DividingLine;

                        foreach (var i in (IEnumerable) greedyAlgorithm[2])
                        {
                            resultGreedyLabel.Text += (string.Format(" {0:0.0} ", i));
                            ++line;
                            if (line%2 == 0)
                            {
                                resultGreedyLabel.Text += MessagesText.DividingLine;
                            }
                        }
                        resultGreedyLabel.Text += MessagesText.NextLine;

                        var strokeLength = "";
                        for (var i = 0; i < s1.Length; ++i)
                        {
                            strokeLength += MessagesText.StrokeLength;
                        }
                        if (index != countFloor - 1)
                        {
                            resultGreedyLabel.Text += strokeLength;
                        }
                        resultGreedyLabel.Text += MessagesText.NextLine;
                    }
                }
                if (!flag)
                {
                    var listOneParam = (List<double>) greedyAlgorithm[4];
                    var listTwoParam = (List<double>) greedyAlgorithm[5];
                    if (listOneParam.Count > 0)
                    {
                        resultGreedyLabel.Text += MessagesText.RectanglesAiNotList;

                        foreach (var i in listOneParam)
                        {
                            resultGreedyLabel.Text += (string.Format(" {0:0.0} ", i));
                        }
                        resultGreedyLabel.Text += (MessagesText.NextLine);
                    }

                    if (listTwoParam.Count > 0)
                    {
                        resultGreedyLabel.Text += MessagesText.RectanglesBiNotList;
                        foreach (var i in listTwoParam)
                        {
                            resultGreedyLabel.Text += (string.Format(" {0:0.0} ", i));
                        }
                        resultGreedyLabel.Text += (MessagesText.NextLine);
                    }
                }
            }

                else if (countFloor == 1)
                {
                    resultGreedyLabel.Text +=
                        MessagesText.OptimalContainerPackage.ToString(CultureInfo.InvariantCulture);
                    resultGreedyLabel.Text += (MessagesText.NextLine).ToString(CultureInfo.InvariantCulture);
                    var line = 0;
                    resultGreedyLabel.Text += MessagesText.DividingLine;
                    foreach (var i in (IEnumerable)greedyAlgorithm[1])
                    {
                        resultGreedyLabel.Text += (string.Format(" {0:0.0} ", i));
                        ++line;
                        if (line % 2 == 0)
                        {
                            resultGreedyLabel.Text += MessagesText.DividingLine;
                        }
                        
                    }
                    resultGreedyLabel.Text += (MessagesText.NextLine).ToString(CultureInfo.InvariantCulture);

                    line = 0;
                    resultGreedyLabel.Text += MessagesText.DividingLine;
                    foreach (var i in (IEnumerable)greedyAlgorithm[2])
                    {
                        resultGreedyLabel.Text += (string.Format(" {0:0.0} ", i));
                        ++line;
                        if (line % 2 == 0)
                            resultGreedyLabel.Text += MessagesText.DividingLine;
                    }
                    resultGreedyLabel.Text += (MessagesText.NextLine).ToString(CultureInfo.InvariantCulture);
                    
                    var ss1 = (List<double>)greedyAlgorithm[4];
                    if (ss1.Count != 0)
                    {
                        resultGreedyLabel.Text += MessagesText.RectanglesAiNotList;
                        foreach (var i in (IEnumerable)ss1)
                        {
                            resultGreedyLabel.Text += (string.Format(" {0:0.0} ", i));
                        }
                    }

                    resultGreedyLabel.Text += (MessagesText.NextLine).ToString(CultureInfo.InvariantCulture);
                    var ss2 = (List<double>)greedyAlgorithm[5];
                    if (ss2.Count != 0)
                    {
                        resultGreedyLabel.Text += MessagesText.RectanglesBiNotList;
                        foreach (var i in (IEnumerable)ss2)
                        {
                            resultGreedyLabel.Text += (string.Format(" {0:0.0} ", i));
                        }
                        resultGreedyLabel.Text += (MessagesText.NextLine).ToString(CultureInfo.InvariantCulture);
                    }  
                }
        }

        public static void FullSearchPrintResult(List<object> fullSearch, int countFloor, Label resultFullSearchLabel)
        {
            if (countFloor == 2 || countFloor==3 || countFloor==4)
            {
                var s1 = (double[])fullSearch[1];
                var s2 = s1.Length;
                const string resultFullSearch = MessagesText.ResultComprehensiveSearch;
                resultFullSearchLabel.Text += resultFullSearch.ToString(CultureInfo.InvariantCulture) + MessagesText.NextLine;
                var minFine = string.Format(MessagesText.ValueFunctionalF, fullSearch[0]);
                resultFullSearchLabel.Text += minFine.ToString(CultureInfo.InvariantCulture) + MessagesText.NextLine + MessagesText.NextLine;
                for (var index = 0; index < countFloor; ++index)
                {
                    var line = 0;
                    resultFullSearchLabel.Text += MessagesText.DividingLine;
                    foreach (var i in (IEnumerable) fullSearch[1])
                    {
                        resultFullSearchLabel.Text += (string.Format(" {0:0.0} ", i));
                        ++line;
                        if (line % 2 == 0)
                        {
                            resultFullSearchLabel.Text += MessagesText.DividingLine;
                        }
                    }
                    resultFullSearchLabel.Text += MessagesText.NextLine;

                    line = 0;
                    resultFullSearchLabel.Text += MessagesText.DividingLine;
                    foreach (var i in (IEnumerable) fullSearch[2])
                    {
                        resultFullSearchLabel.Text += (string.Format(" {0:0.0} ", i));
                        ++line;
                        if (line % 2 == 0)
                        {
                            resultFullSearchLabel.Text += MessagesText.DividingLine;
                        }
                    }
                    resultFullSearchLabel.Text += MessagesText.NextLine;

                    var strokeLength = "";
                    for (var i = 0; i < s2; ++i)
                    {
                        strokeLength += MessagesText.StrokeLength;
                    }
                    if (index != countFloor - 1)
                    {
                        resultFullSearchLabel.Text += strokeLength;
                    }
                    resultFullSearchLabel.Text += MessagesText.NextLine;
                }

                var listOneParam = (List<double>) fullSearch[3];
                var listTwoParam = (List<double>) fullSearch[4];
                if (listOneParam.Count > 0)
                {
                    resultFullSearchLabel.Text += MessagesText.RectanglesAiNotList;

                    foreach (var i in listOneParam)
                    {
                        resultFullSearchLabel.Text += (string.Format(" {0:0.0} ", i));
                    }
                    resultFullSearchLabel.Text += (MessagesText.NextLine);
                }

                if (listTwoParam.Count > 0)
                {
                    resultFullSearchLabel.Text += MessagesText.RectanglesBiNotList;
                    foreach (var i in listTwoParam)
                    {
                        resultFullSearchLabel.Text += (string.Format(" {0:0.0} ", i));
                    }
                    resultFullSearchLabel.Text += (MessagesText.NextLine);
                }

            }   

            else if (countFloor == 1)
            {
                const string resultFullSearch = MessagesText.ResultComprehensiveSearch;
                resultFullSearchLabel.Text += resultFullSearch.ToString(CultureInfo.InvariantCulture) + MessagesText.NextLine;
                var minFine = string.Format(MessagesText.Fine, fullSearch[0]);
                resultFullSearchLabel.Text += minFine.ToString(CultureInfo.InvariantCulture) + MessagesText.NextLine;

                const string optArrangeOne = MessagesText.OptimalContainerPackage;
                resultFullSearchLabel.Text += optArrangeOne.ToString(CultureInfo.InvariantCulture);
                resultFullSearchLabel.Text += MessagesText.NextLine;
                var b = 0;
                resultFullSearchLabel.Text += MessagesText.DividingLine;
                foreach (var i in (IEnumerable)fullSearch[1])
                {
                    resultFullSearchLabel.Text += (string.Format(" {0:0.0} ", i));
                    ++b;
                    if (b%2 == 0)
                    {
                        resultFullSearchLabel.Text += MessagesText.DividingLine;
                    }
                   
                }
                resultFullSearchLabel.Text += MessagesText.NextLine;

                b = 0;
                resultFullSearchLabel.Text += MessagesText.DividingLine;
                foreach (var i in (IEnumerable)fullSearch[2])
                {
                    resultFullSearchLabel.Text += (string.Format(" {0:0.0} ", i));
                    ++b;
                    if (b % 2 == 0)
                    {
                        resultFullSearchLabel.Text += MessagesText.DividingLine;
                    }
                   
                }
                resultFullSearchLabel.Text += MessagesText.NextLine;
                var ss1 = (List<double>)fullSearch[3];
                if (ss1.Count != 0)
                {
                    resultFullSearchLabel.Text += MessagesText.RectanglesAiNotList;
                    foreach (var i in (IEnumerable)ss1)
                    {
                        resultFullSearchLabel.Text += (string.Format(" {0:0.0} ", i));
                    }
                }

                resultFullSearchLabel.Text += (MessagesText.NextLine).ToString(CultureInfo.InvariantCulture);
                var ss2 = (List<double>)fullSearch[4];
                if (ss2.Count != 0)
                {
                    resultFullSearchLabel.Text += MessagesText.RectanglesBiNotList;
                    foreach (var i in (IEnumerable)ss2)
                    {
                        resultFullSearchLabel.Text += (string.Format(" {0:0.0} ", i));
                    }
                }

                resultFullSearchLabel.Text += MessagesText.NextLine;
            }
        }
    }
}
