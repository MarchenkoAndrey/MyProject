using System.Collections.Generic;

namespace Resettlement
{
    public class ContainerTree
    {
        public List<Container> Containers { get; private set; } // tree

        public ContainerTree(DataGreedyMethode data)
        {
            Containers = new List<Container> {new Container(data)};
        }
    }
}
