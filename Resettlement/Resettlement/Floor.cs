using System.Collections.Generic;

namespace Resettlement
{
    
    public class Floor
    {
        public int Number { get; set; }
        public List<Flat> Flats { get; set; }

        public double Fine { get; set; }
    }
}
