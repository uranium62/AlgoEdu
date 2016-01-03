using System;
using System.Collections.Generic;

namespace AlgoEdu.Graph
{
    class BFS : ITravelGraph
    {
        private readonly IRootFinder _finder;

        public BFS(IRootFinder finder)
        {
            _finder = finder;
        }

        public void Walk(byte[,] graph, Action<int> Do)
        {
           
           
        }
    }
}
