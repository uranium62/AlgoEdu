using System.Collections.Generic;

namespace AlgoEdu.Sort
{
    public struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class GrohamScan
    {
        public Stack<Point> Scan(Point[] p)
        {
            int idx = FindFirstPoint(p);
            var stack = new Stack<Point>();
            
            

            return stack;
        }

        private int FindFirstPoint(Point[] p)
        {
            int i, j;
            for (i = 0, j = 0; i < p.Length; i++)
            {
                if (p[i].y < p[j].y) j = i;
            }
            return j;
        }
    }
}
