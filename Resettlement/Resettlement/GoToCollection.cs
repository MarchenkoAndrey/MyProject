using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Resettlement
{
//    class GoToCollection : IEnumerable<Container>
//    {
//        private Container First;
//        private Container Last;
//
//        public void Add(Container container)
//        {
//            Container temp = new Container(container.Fine);
//
//            if (First == null)
//            {
//                First = temp;
//                Last = First;
//            }
//            else
//            {
//                Last.Next = temp;
//                Last = Last.Next;
//            }
//        }
//
//        public IEnumerator<Container> GetEnumerator()
//        {
//            Container temp = First;
//            do
//            {
//                yield return temp;
//                temp = temp.Next;
//            } while (temp.ExceedListOneFlat.Count != 0);
//        }
//
//        IEnumerator IEnumerable.GetEnumerator()
//        {
//            return GetEnumerator();
//        }
//    }
}
