using System;
using System.Collections.Generic;

namespace AlgoEdu.Graph
{
    class DAF : ITravelGraph
    {
        private readonly IRootFinder _finder;

        public DAF(IRootFinder finder)
        {
            _finder = finder;
        }

        public void Walk(byte[,] graph, Action<int> Do)
        {
            var roots = _finder.Roots(graph);

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < roots.Length; i++)
            {
                stack.Push(roots[i]);
            }

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();

                for (int i = 0; i < graph.GetLength(vertex); i++)
                {
                    if (graph[vertex, i] == 1)
                    {
                        graph[vertex, i] = 2;
                        stack.Push(i);
                    }
                }
            }
        }
    }

}
