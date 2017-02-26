using System;
using System.Collections;
using System.Collections.Generic;

namespace Resettlement
{
    public class GoToCollection : IEnumerable<Container>
    {
        public List<Container> Containers { get; private set; }
        private int Count { get; set; }

        public GoToCollection(DataMethode data)
        {
            Containers = new List<Container> { new Container(data) };
            Count = 1;
        }
        
        public void Adds(List<Container> containers)
        {
            Containers.AddRange(containers);
            Count += containers.Count;
        }

        public IEnumerator<Container> GetEnumerator()
        {
            for (var i = 0; i < Count; ++i)
            {
                if (Containers[i].ExceedListOneFlat.Count < 1) yield break;
                yield return Containers[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Container this[int index]
        {
            get
            {
                if(index<0 ||index>Count) throw new IndexOutOfRangeException();
                return Containers[index];
            }
            set
            {
                if (index < 0 || index > Count) throw new IndexOutOfRangeException();
                Containers[index] = value;
            }
        }
    }
}
