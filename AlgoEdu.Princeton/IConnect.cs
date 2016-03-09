using System;

namespace AlgoEdu.Princeton
{
    public interface IConnect
    {
        void Union(int p, int q);
        bool Connected(int p, int q);
        int Find(int p);
        int Count();
    }

    public class UnionFind: IConnect
    {
        private readonly int[] _ids;

        public UnionFind(int n)
        {
            _ids = new int[n];

            for (int i = 0; i < n; i++)
            {
                _ids[i] = i;
            }
        }

        public void Union(int p, int q)
        {
            if (p >= _ids.Length) 
                throw new ArgumentException(nameof(p));
            if (q >= _ids.Length)
                throw new ArgumentException(nameof(q));

            int pid = _ids[p];
            int qid = _ids[q];

            for (int i = 0; i < _ids.Length; i++)
            {
                if (_ids[i] == pid) _ids[i] = qid;
            }
        }

        public bool Connected(int p, int q)
        {
            if (p >= _ids.Length)
                throw new ArgumentException(nameof(p));
            if (q >= _ids.Length)
                throw new ArgumentException(nameof(q));

            return _ids[p] == _ids[q];
        }

        public int Find(int p)
        {
            if (p >= _ids.Length)
                throw new ArgumentException(nameof(p));

            return _ids[p];
        }

        public int Count()
        {
            return _ids.Length;
        }
    }

    public class QuickUnion : IConnect
    {
        private readonly int[] _ids;

        public QuickUnion(int n)
        {
            _ids = new int[n];

            for (int i = 0; i < n; i++)
            {
                _ids[i] = i;
            }
        }

        private int Root(int i)
        {
            while (i != _ids[i])
            {
                i = _ids[i];
            }

            return i;
        }

        public void Union(int p, int q)
        {
            int i = Root(p);
            int j = Root(q);

            _ids[i] = j;
        }

        public bool Connected(int p, int q)
        {
            return Root(p) == Root(q);
        }

        public int Find(int p)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }
    }
}
