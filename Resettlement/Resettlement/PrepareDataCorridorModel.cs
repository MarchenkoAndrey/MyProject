using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ComputationMethods;
using ComputationMethods.GeneralData;

namespace Resettlement
{
    public class PrepareDataCorridorModel
    {
        //        var widthOfApartment = InputConstraints.C(valueC.Text.ToString(CultureInfo.InvariantCulture));
        //        var step = InputConstraints.Q(valueQ.Text.ToString(CultureInfo.InvariantCulture));
        //        public double SumDelta { get; set; }

        public PrepareDataCorridorModel()
        {
            var building = new Building();

            var listSquaresOneFlat = ReadFromFileAndRecordingInputDataInList.ReadFile(FilesDefault.DefaultListOneFlat);
            var listSquaresTwoFlat = ReadFromFileAndRecordingInputDataInList.ReadFile(FilesDefault.DefaultListTwoFlat);


            building.Flats.AddRange(Flat.Initialize(listSquaresOneFlat, FlatType.OneFlat, listSquaresTwoFlat, FlatType.TwoFlat));

            //Исходное количество квартир
            building.InputCountFlat = building.Flats.Count;
            //todo ввод с экрана
            building.CountFloor = 4;
            
            //Приведение к минимально допустимым площадям
            Flat.CastToMinimalSquare(building.Flats);

            //Отсечение лишних (секция 500 м2) квартир по площади (самые мелкие однокомнатные)
            //Todo оставить ровное количество квартир по этажам!!! в MVP сойдет
            building = SeverExcessFlats.ToSeverExcessFlats(building);

            //Вычисление штрафа приведения
            building.Fine.CastToMin = Math.Round(
                Flat.CalculateSumCastSquares(building.Flats) -
                Flat.CalculateSumInputSquares(building.Flats), 2);
            //Площадь после приведения
            building.SumSquare =
                Math.Round(Flat.CalculateSumCastSquares(building.Flats), 2);
            
            building.CountFlat = building.Flats.Count;
            if (building.CountFlat < 4 * building.CountFloor)
                MessageBox.Show(MessagesText.TooLittleData);

            building.Flats = Flat.DiffBalcony(building.Flats);

            //Метод по разбивке квартир по этажам на примерно равные группы

            var res = SplitFlatsOnFlours(building);
            
            //Выравниваем площади за счет добавок
            //Todo 1.Поправить инициализацию лишних r, 2. Выровнять площадь на этажах
        }
        
        //Метод по разбивке квартир по этажам на равные части
        public static Dictionary<int, List<Flat>> SplitFlatsOnFlours(Building building)
        {
            var listFlats = building.Flats.OrderBy(a => a.CastSquare).ToList();
            
            //исключаем из выравнивателя группу самых крупных квартир для дальнейшего анализа. Размер группы - количество этажей
            var listExcessFlats = HandlerBiggerFlats.ToDefineBiggerFlats(listFlats, building.CountFloor);
            listFlats = HandlerBiggerFlats.ToDeleteBiggerFlats(listFlats, listExcessFlats);

            // словарь: [этаж - список квартир] 
            var listFlatsOnFloor = new Dictionary<int, List<Flat>>();
            // инициализация словаря
            for (var i = 1; i <= building.CountFloor; ++i)
            {
                listFlatsOnFloor[i] = new List<Flat>();
            }

            for (var l = 0; l < listFlats.Count; l+= building.CountFloor)
            {
                var cur = listFlats.GetRange(l, building.CountFloor);
                var max = cur.Select(b => b.CastSquare).Max();

                var number = 1;
                foreach (var elem in cur)
                {
                    elem.Fine += Math.Round(max - elem.CastSquare, 2);
                    elem.CastSquare = max;

                    //добавление на этажи
                    listFlatsOnFloor[number].Add(elem);
                    number++;
                }
            }

            //группировка аномальных
            listExcessFlats = HandlerBiggerFlats.ToGroupBiggerFlats(listExcessFlats);
            //добавление аномальных квартир (большие наверх)
            //Самые крупные квартиры оставляем на последние этажи, чтобы там за счет коридора в углу построить секцию
            var numberFloor = 1;
            foreach (var elem in listExcessFlats)
            {
                listFlatsOnFloor[numberFloor].Add(elem);
                numberFloor++;
            }
            
            return listFlatsOnFloor;
        }
    }
}
