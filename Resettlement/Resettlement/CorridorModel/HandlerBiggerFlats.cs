using System;
using System.Collections.Generic;
using System.Linq;
using Resettlement.CorridorModel.Models;

namespace Resettlement.CorridorModel
{
    /// <summary>
    ///     Класс для обработки аномалий
    /// </summary>
    public class HandlerBiggerFlats
    {
        public static List<Flat> ToDefineBiggerFlats(List<Flat> listFlats, int countFloor)
        {
            var f = listFlats.OrderByDescending(a => a.CastSquare).ToList();

            var count = listFlats.Count % countFloor;
            var result = f.GetRange(0, countFloor + count).ToList();

            return result;
        }
        public static List<Flat> ToDeleteBiggerFlats(List<Flat> listFlats, List<Flat> listExcessFlats)
        {
            foreach (var elem in listExcessFlats)
            {
                listFlats.RemoveAll(a => a.Id == elem.Id);
            }
            return listFlats;
        }

        /// <summary>
        ///     Определим правильную группировку. Для этого рассмотрим 3 варианта:
        ///         а) Привести все к одному виду
        ///         б) Привести все, кроме одной, к одному виду
        ///         в) Привести все, кроме двух, к одному виду
        ///     Придумать веса для выбора варианта. Среди вариантов б и в выигрывает с меньшим штрафом. А как сравнить с вариантом а?
        ///     Вводим коэффициент 2% для варианта а. Если выгода от других вариантов меньше 2%, то не стоит даже запариваться.
        /// </summary>
        public static List<Flat> ToGroupBiggerFlats(List<Flat> listExcessFlats)
        {
            listExcessFlats = listExcessFlats.OrderBy(a => a.CastSquare).ToList();
            var list = Flat.ReceiveListCastSquares(listExcessFlats);
            //определение правильной группировки
            var strategyOfGrouping = new Dictionary<char, double>
            {
                ['A'] = list.Last() * list.Count * 0.95,
                ['B'] = list.Last() + list[list.Count - 2] * (list.Count - 1),
                ['C'] = list.Last() * 2 + list[list.Count - 3] * (list.Count - 2)
            };
            //Вычисление максимального
            var max = listExcessFlats.Last().CastSquare;
            var max_1 = listExcessFlats[listExcessFlats.Count - 2].CastSquare;
            var max_2 = listExcessFlats[listExcessFlats.Count - 3].CastSquare;
            switch (strategyOfGrouping.OrderBy(a=>a.Value).First().Key)
            {
                case 'A':
                    foreach (var elem in listExcessFlats)
                    {
                        elem.Fine += Math.Round(max - elem.CastSquare, 2);
                        elem.CastSquare = max;
                    }
                    break;
                case 'B':
                    //группа без самой большой
                    for (var i = 0; i < listExcessFlats.Count - 1; i++)
                    {
                        listExcessFlats[i].Fine += Math.Round(max_1 - listExcessFlats[i].CastSquare, 2);
                        listExcessFlats[i].CastSquare = max_1;
                    }
                    break;
                case 'C':
                    //первая группа
                    for (var i = 0; i < listExcessFlats.Count - 2; i++)
                    {
                        listExcessFlats[i].Fine += Math.Round(max_2 - listExcessFlats[i].CastSquare, 2);
                        listExcessFlats[i].CastSquare = max_2;
                    }
                    //вторая группа
                    for (var i = listExcessFlats.Count - 2; i < listExcessFlats.Count; i++)
                    {
                        listExcessFlats[i].Fine += Math.Round(max - listExcessFlats[i].CastSquare, 2);
                        listExcessFlats[i].CastSquare = max;
                    }
                    break;
            }
            return listExcessFlats;
        }
    }
}