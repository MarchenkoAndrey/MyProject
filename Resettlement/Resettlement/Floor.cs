using System.Collections.Generic;

namespace Resettlement
{
    public class Floor
    {
        public int Number { get; set; }
        public List<Flat> Flats { get; set; }

        public Floor(int number)
        {
            Number = number;
            Flats = new List<Flat>();
        }
    }
}
