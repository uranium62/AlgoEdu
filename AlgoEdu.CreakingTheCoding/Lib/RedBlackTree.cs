using System.Collections.Generic;

namespace AlgoEdu.CreakingTheCoding.Lib
{
    public class RedBlackTree<T>
        
    {
        private RedBlackNode<T> _root;

        public RedBlackTree()
        {
            _root = null;
            Count = 0;
        }

        private void RotateLeft(RedBlackNode<T> x)
        {
            var y = x.Right;

            /* establish x->right link */
            x.Right = y.Left;
            if (y.Left != null) y.Left.Parent = x;

            /* establish y->parent link */
            if (y != null) y.Parent = x.Parent;
            if (x.Parent != null)
            {
                if (x == x.Parent.Left)
                    x.Parent.Left = y;
                else
                    x.Parent.Right = y;
            }
            else {
                _root = y;
            }

            /* link x and y */
            y.Left = x;
            x.Parent = y;
        }

        private void RotateRight(RedBlackNode<T> x)
        {
            var y = x.Left;

            /* establish x->left link */
            x.Left = y.Right;
            if (y.Right != null) y.Right.Parent = x;

            /* establish y->parent link */
            if (y != null) y.Parent = x.Parent;
            if (x.Parent != null)
            {
                if (x == x.Parent.Right)
                    x.Parent.Right = y;
                else
                    x.Parent.Left = y;
            }
            else {
                _root = y;
            }

            /* link x and y */
            y.Right = x;
            x.Parent = y;
        }

        private void AddFixup(RedBlackNode<T> x)
        {
            while (x != _root && x.Parent.Color == RedBlackColor.Red)
            {
                if (x.Parent == x.Parent.Parent.Left)
                {
                    var y = x.Parent.Parent.Right;
                    if (y.Color == RedBlackColor.Red)
                    {
                        /* uncle is RED */
                        x.Parent.Color = RedBlackColor.Black;
                        x.Color = RedBlackColor.Black;
                        x.Parent.Parent.Color = RedBlackColor.Red;
                        x = x.Parent.Parent;
                    }
                    else
                    {
                        /* uncle is BLACK */
                        if (x == x.Parent.Right)
                        {
                            /* make x a left child */
                            x = x.Parent;
                            RotateLeft(x);
                        }

                        /* recolor and rotate */
                        x.Parent.Color = RedBlackColor.Black;
                        x.Parent.Parent.Color = RedBlackColor.Red;
                        RotateRight(x.Parent.Parent);
                    }
                }
                else
                {
                    /* mirror image of above code */
                    var y = x.Parent.Parent.Left;
                    if (y.Color == RedBlackColor.Red)
                    {
                        /* uncle is RED */
                        x.Parent.Color = RedBlackColor.Black;
                        y.Color = RedBlackColor.Black;
                        x.Parent.Parent.Color = RedBlackColor.Red;
                        x = x.Parent.Parent;
                    }
                    else
                    {
                        /* uncle is BLACK */
                        if (x == x.Parent.Left)
                        {
                            x = x.Parent;
                            RotateRight(x);
                        }
                        x.Parent.Color = RedBlackColor.Black;
                        x.Parent.Parent.Color = RedBlackColor.Red;
                        RotateLeft(x.Parent.Parent);
                    }
                }
            }
            _root.Color = RedBlackColor.Black;
        }

        private void DeleteFixup(RedBlackNode<T> x)
        {
            while (x != _root && x.Color == RedBlackColor.Black)
            {
                if (x == x.Parent.Left)
                {
                    var w = x.Parent.Right;
                    if (w.Color == RedBlackColor.Red)
                    {
                        w.Color = RedBlackColor.Black;
                        x.Parent.Color = RedBlackColor.Red;
                        RotateLeft(x.Parent);
                        w = x.Parent.Right;
                    }
                    if (w.Left.Color == RedBlackColor.Black && w.Right.Color == RedBlackColor.Black)
                    {
                        w.Color = RedBlackColor.Red;
                        x = x.Parent;
                    }
                    else {
                        if (w.Right.Color == RedBlackColor.Black)
                        {
                            w.Left.Color = RedBlackColor.Black;
                            w.Color = RedBlackColor.Red;
                            RotateRight(w);
                            w = x.Parent.Right;
                        }
                        w.Color = x.Parent.Color;
                        x.Parent.Color = RedBlackColor.Black;
                        w.Right.Color = RedBlackColor.Black;
                        RotateLeft(x.Parent);
                        x = _root;
                    }
                }
                else {
                    var w = x.Parent.Left;
                    if (w.Color == RedBlackColor.Red)
                    {
                        w.Color = RedBlackColor.Black;
                        x.Parent.Color = RedBlackColor.Red;
                        RotateRight(x.Parent);
                        w = x.Parent.Left;
                    }
                    if (w.Right.Color == RedBlackColor.Black && w.Left.Color == RedBlackColor.Black)
                    {
                        w.Color = RedBlackColor.Red;
                        x = x.Parent;
                    }
                    else {
                        if (w.Left.Color == RedBlackColor.Black)
                        {
                            w.Right.Color = RedBlackColor.Black;
                            w.Color = RedBlackColor.Red;
                            RotateLeft(w);
                            w = x.Parent.Left;
                        }
                        w.Color = x.Parent.Color;
                        x.Parent.Color = RedBlackColor.Black;
                        w.Left.Color = RedBlackColor.Black;
                        RotateRight(x.Parent);
                        x = _root;
                    }
                }
            }
            x.Color = RedBlackColor.Black;
        }

        public void Add(T val)
        {
            RedBlackNode<T> current, parent, x;

            current = _root;
            parent = null;

            while (current != null)
            {
                if (Comparer<T>.Default.Compare(current.Value, val) == 0)
                {
                    return;
                }

                parent = current;

                if (Comparer<T>.Default.Compare(current.Value, val) > 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            x = new RedBlackNode<T>(val)
            {
                Parent = parent
            };

            if (parent != null)
            {
                if (Comparer<T>.Default.Compare(parent.Value, val) > 0)
                {
                    parent.Left = x;
                }
                else
                {
                    parent.Right = x;
                }
            }
            else
            {
                _root = x;
            }

            AddFixup(x);
            Count++;
        }

        public void Delete(RedBlackNode<T> z)
        {
            RedBlackNode<T> x, y;

            if (z == null) return;

            if (z.Left == null || z.Right == null)
            {
                /* y has a NIL node as a child */
                y = z;
            }
            else {
                /* find tree successor with a NIL node as a child */
                y = z.Right;
                while (y.Left != null) y = y.Left;
            }

            /* x is y's only child */
            if (y.Left != null)
                x = y.Left;
            else
                x = y.Right;

            /* remove y from the parent chain */
            x.Parent = y.Parent;
            if (y.Parent != null)
                if (y == y.Parent.Left)
                    y.Parent.Left = x;
                else
                    y.Parent.Right = x;
            else
                _root = x;

            if (y != z) z.Value = y.Value;


            if (y.Color == RedBlackColor.Black)
                DeleteFixup(x);

            Count--;
        }

        public RedBlackNode<T> Find(T val)
        {
            var current = _root;
            while (current != null)
            {
                if (Comparer<T>.Default.Compare(current.Value, val) == 0)
                    return current;
                if (Comparer<T>.Default.Compare(current.Value, val) > 0)
                    current = current.Left;
                else
                    current = current.Right;

            }
            return null;
        }

        public int Count { get; private set; }

    }

    public class RedBlackNode<T>
    {
        public T Value { get; set; }
        public RedBlackNode<T> Left   { get; set; } 
        public RedBlackNode<T> Right  { get; set; } 
        public RedBlackNode<T> Parent { get; set; }
        public RedBlackColor Color { get; set; }

        public RedBlackNode()
        {
            Color = RedBlackColor.Red;
        }

        public RedBlackNode(T value)
        {
            Value = value;
            Color = RedBlackColor.Red;
        }
    }

    public enum RedBlackColor
    {
        Red,
        Black
    }

}
