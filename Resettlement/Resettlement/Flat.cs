using System;
using System.Collections.Generic;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    public class Flat
    {
        public int Id { get; set; }
        public double InputSquare { get; set; }
        public double CastSquare { get; set; }
        public FlatType Type { get; set; }
        public double Fine { get; set; }

        public static List<Flat> Initialize(List<double> listSquares1, FlatType type1, List<double> listSquares2, FlatType type2)
        {
            var list = new List<Flat>();
            var i = 1;
            foreach (var elem in listSquares1)
            {
                list.Add(new Flat {Id = i, Fine = 0, InputSquare = elem, CastSquare = elem, Type = type1});
                i++;
            }

            foreach (var elem in listSquares2)
            {
                list.Add(new Flat { Id = i, Fine = 0, InputSquare = elem, CastSquare = elem, Type = type2 });
                i++;
            }

            return list;
        }

        // Приведение площади квартир к минимальному допустимому значению
        public static void CastToMinimalSquare(List<Flat> list)
        {
                foreach (var elem in list)
                {
                    if (elem.Type==FlatType.OneFlat)
                    {
                        if (elem.CastSquare < Constraints.MinSquareOneApartment)
                        {
                            elem.Fine = Math.Round(Constraints.MinSquareOneApartment - elem.CastSquare, 2);
                            elem.CastSquare = Constraints.MinSquareOneApartment;
                        }
                    }
                    else
                    {
                        if (elem.CastSquare < Constraints.MinSquareTwoApartment)
                        {
                            elem.Fine = Math.Round(Constraints.MinSquareTwoApartment - elem.CastSquare, 2);
                            elem.CastSquare = Constraints.MinSquareTwoApartment;
                        }
                    }
                }    
        }

        //Вычисление суммы исходных площадей
        public static double CalculateSumInputSquares(List<Flat> list)
        {
            var result = 0.0;
            foreach (var elem in list)
            {
                result += Math.Round(elem.InputSquare, 2);
            }
            return result;
        }
        
        //Вычисление суммы приведенных площадей
        public static double CalculateSumCastSquares(List<Flat> list)
        {
            var result = 0.0;
            foreach (var elem in list)
            {
                result += Math.Round(elem.CastSquare, 2);
            }
            return result;
        }
        
        //получение списка приведенных площадей из списка квартир
        public static List<double> ReceiveListCastSquares(List<Flat> list)
        {
            var result = new List<double>();
            foreach (var elem in list)
            {
                result.Add(elem.CastSquare);
            }
            return result;
        }
        //Метод вычитания балкона из площади каждой квартиры
        public static List<Flat> DiffBalcony(List<Flat> sourceList)
        {
            foreach (var elem in sourceList)
            {
                elem.CastSquare = Math.Round(elem.CastSquare - Constraints.SquareBalcony, 3);
            }
            return sourceList;
        }
    }
}