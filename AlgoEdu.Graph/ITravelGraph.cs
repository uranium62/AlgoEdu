using System;

namespace AlgoEdu.Graph
{
    public interface ITravelGraph
    {
        void Walk(byte[,] graph, Action<int> Do); 
    }

    public interface IRootFinder
    {
        int Root(byte[,] graph);

        int[] Roots(byte[,] graph);
    }

    class RootFinder : IRootFinder
    {
        public int Root(byte[,] graph)
        {
            int i, j;

            int width = graph.GetLength(0);
            int height = graph.GetLength(1);

            for (i = 0; i < width; i++)
            {
                for (j = 0; j < height; j++)
                {
                    if (graph[j, i] == 1) break;
                }

                if (j == height) return i;
            }

            throw new ArgumentException("This graph hasn't a root");
        }

        public int[] Roots(byte[,] graph)
        {
            int i, j;

            int width = graph.GetLength(0);
            int height = graph.GetLength(1);

            int[] roots = new int[width];
            int   count = 0;

            for (i = 0; i < width; i++)
            {
                for (j = 0; j < height; j++)
                {
                    if (graph[j, i] == 1) break;
                }

                if (j == height) roots[count++] = i;
            }

            if (count == 0)
            {
                throw new ArgumentException("This graph hasn't a root");
            }
            
            var res = new int[count];
            Array.Copy(roots, res, count);
            return res;
        }
    }
}
