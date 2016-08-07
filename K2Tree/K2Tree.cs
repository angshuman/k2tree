using System;
using System.Collections.Generic;

namespace TripleStore.Graph
{
    public class K2Tree
    {
        private K2Tree[] _tree;
        private byte _height;
        public int[] Values;

        public K2Tree(byte height)
        {
            _height = height;
        }

        public void Set(int x, int y)
        {
            if (_height == 0)
            {
                Values = new int[2];
                Values[0] = x;
                Values[1] = y;
                return;
            }

            int bit0 = GetBit(x);
            int bit1 = GetBit(y);

            var path = 2 * bit0 + bit1;
            if (_tree == null)
            {
                _tree = new K2Tree[4];
            }
            if (_tree[path] == null)
            {
                _tree[path] = new K2Tree((byte)(_height - 1));
            }

            _tree[path].Set(x, y);
        }

        public bool Get(int x, int y)
        {
            if (_height == 0)
            {
                return (Values != null);
            }

            int bit0 = GetBit(x);
            int bit1 = GetBit(y);

            var path = 2 * bit0 + bit1;

            if (_tree[path] == null)
            {
                return false;
            }

            return _tree[path].Get(x, y);
        }

        public int[] GetByX(int x)
        {
            if (_height == 0)
            {
                return new int[] { Values[1] };
            }

            int bit0 = GetBit(x);

            var path1 = 2 * bit0 + 0;
            var path2 = 2 * bit0 + 1;

            List<int> res = new List<int>();

            if (_tree[path1] != null)
            {
                res.AddRange(_tree[path1].GetByX(x));
            }
            if (_tree[path2] != null)
            {
                res.AddRange(_tree[path2].GetByX(x));
            }

            return res.ToArray();
        }

        public int[] GetByY(int y)
        {
            if (_height == 0)
            {
                return new int[] { Values[0] };
            }

            int bit1 = GetBit(y);

            var path1 = 2 * 0 + bit1;
            var path2 = 2 * 1 + bit1;

            List<int> res = new List<int>();

            if (_tree[path1] != null)
            {
                res.AddRange(_tree[path1].GetByY(y));
            }
            if (_tree[path2] != null)
            {
                res.AddRange(_tree[path2].GetByY(y));
            }

            return res.ToArray();
        }

        private int GetBit(int val)
        {
            return (val / (int)Math.Pow(2, _height - 1)) % 2;
        }
    }
}
