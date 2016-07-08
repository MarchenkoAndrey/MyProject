using System.Collections.Generic;
namespace ComputationMethods
{
    public static class InsertionSort
    {
        public static List<double> InsertSort(List<double> list)
        {
            int i, j;
            for (i = 0; i < list.Count; ++i)
            {
                var key = list[i]; // запомним i-ый элемент
                j = i - 1; // будем идти начиная с i-1 элемента
                while (j >= 0 && list[j] > key)
                // пока не достигли начала массива
                // или не нашли элемент больше i-1-го
                // который хранится в переменной key
                {
                    list[j + 1] = list[j]; //проталкиваем элемент вверх
                    j--;
                }
                list[j + 1] = key; // возвращаем i-1 элемент
            }
            return list;
        }
    }
}