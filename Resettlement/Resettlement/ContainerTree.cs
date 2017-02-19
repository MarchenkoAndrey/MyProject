using System.Collections.Generic;

namespace Resettlement
{
    public class ContainerTree
    {
        public List<Container> Containers { get; set; } // tree

        public ContainerTree(DataGreedyMethode data)
        {
            Containers.Add(new Container
            {
                Id = 0,
                ParentId = null,
                Fine = 0.0,
                FineChain = 0.0,
                ExceedListOneFlat = data.ListLenOneFlat,
                ExceedListTwoFlat = data.ListLenTwoFlat
            });
        }
    }
}
