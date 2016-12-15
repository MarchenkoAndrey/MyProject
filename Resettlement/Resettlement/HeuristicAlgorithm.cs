using System;
using System.Diagnostics;
using System.Globalization;
using ComputationMethods;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    partial class UserInterface
    {
        private void PerformHAlg(InputDataAlg data)
        {
            ValidateConditions.Validate(data);

            realizat_label.Text = "".ToString(CultureInfo.InvariantCulture);
            lossesOne_label.Text = "".ToString(CultureInfo.InvariantCulture);
            resultGreedy_label.Text = "".ToString(CultureInfo.InvariantCulture);

            var flatCount = data.ListLenOneFlat.Count + data.ListLenTwoFlat.Count;
            realizat_label.Text += string.Format(MessagesText.RealizationForRectangles,flatCount).ToString(CultureInfo.InvariantCulture);
            lossesOne_label.Text += string.Format(MessagesText.SummarizeAdditionLengthForH, data.SumDelta.ToString(CultureInfo.InvariantCulture));

            var resultDataAfterGrouping = new ResultDataAfterGrouping();
            //var arr = new Arrangement(new Container());
//            var cont = new Container(data);

            var fineAfterGrouping = 0.0;
            if (data.CountFloor > 1)
            {
                resultDataAfterGrouping = GroupingOnTheFloors.GroupingFlat(data);
                data.ListLenOneFlat = PreparationSquares.FlatsWithTheAdditiveLength(resultDataAfterGrouping.ListResultOneFlat);
                data.ListLenTwoFlat = PreparationSquares.FlatsWithTheAdditiveLength(resultDataAfterGrouping.ListResultTwoFlat);
                fineAfterGrouping = resultDataAfterGrouping.Fine;
            }       

            var myStopWatchGreedy = new Stopwatch();
            myStopWatchGreedy.Start();
            var firstOneFlat = 0.0; // в RGreedyMethode
            var numberIteration = 0;
            var totalOptimalResult = new ResultGreedyMethode(double.MaxValue);

            while (numberIteration < Constraints.NumberOfIteration)
            {
                numberIteration++;
               
                var resultGreedyIter = GreedyAlgorithmSection.GreedyMethode(data, firstOneFlat);
                firstOneFlat = resultGreedyIter.NewFirstOneFlat;
                resultGreedyIter.NumIter = numberIteration;
                resultGreedyIter.Fine = Math.Round(resultGreedyIter.Fine * data.CountFloor, 1);
                resultGreedyIter.Fine = Math.Round(resultGreedyIter.Fine + fineAfterGrouping, 1); //Todo каждый раз суммируется??

                //Запись в контейнеры
                //Сравнение расстановок
                if (totalOptimalResult.Fine > resultGreedyIter.Fine)
                {
                    totalOptimalResult = resultGreedyIter;
                }
                    resultGreedyIter.ListLenOneFlat = resultDataAfterGrouping.ListExcessOneFlat;
                    resultGreedyIter.ListLenTwoFlat = resultDataAfterGrouping.ListExcessTwoFlat;
                

                //Вывод результата по итерациям
                PrintResult.GreedyIterationPrintResult(resultGreedyIter, data.CountFloor, true, resultGreedy_label);
            }
            myStopWatchGreedy.Stop();
            PrintResult.GreedyIterationPrintResult(totalOptimalResult, data.CountFloor, false, resultGreedy_label);

            resultGreedy_label.Text +=
                  string.Format(MessagesText.WorkTimeHeuristicAlgoruthm,
                   myStopWatchGreedy.ElapsedMilliseconds / 1000.0).ToString(CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture);
        }
    }
}
