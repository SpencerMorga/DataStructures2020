using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures
{
    public class BSTnode<T>
    {
        public T Value;
        public BSTnode<T> Left;
        public BSTnode<T> Right;
        public BSTnode<T> Parent;
        public bool IsLeftChild => Parent == null ? false : Parent.Left == this;
        public bool IsRightChild => Parent == null ? false : Parent.Right == this;
        public int ChildCount
        {
            get
            {
                int count = 0;
                if (Left != null)
                {
                    count++;
                }
                if (Right != null)
                {
                    count++;
                }
                return count;
            }
        }
        public BSTnode(T value)
        {
            Value = value;
        }
    }

    public class BST<T> where T : IComparable<T>
    {
        public BSTnode<T> Root { get; private set; }
        int Count = 0;

        public BST()
        {
            Root = null;
            Count = 0;
        }

        public bool Insert(T value)
        {
            Count++;
            if (Root == null)
            {
                Root = new BSTnode<T>(value);
                return true;
            }

            BSTnode<T> current = Root;
            while (current != null)
            {
                if (value.CompareTo(current.Value) < 0)
                {
                    if (current.Left == null)
                    {
                        current.Left = new BSTnode<T>(value);
                        break;
                    }
                    current = current.Left;
                }
                else
                {
                    if (current.Right == null)
                    {
                        current.Right = new BSTnode<T>(value);
                        break;
                    }
                    current = current.Right;
                }
            }
            return true;
        }

        public void Remove(T val)
        {

            BSTnode<T> node = Find(val);

            if (node.ChildCount == 2)
            {
                BSTnode<T> candidate = Maximum(node.Left);
                node.Value = candidate.Value;
                node = candidate;
            }
            else if (node.ChildCount == 0)
            {
                if (node == Root)
                {
                    Root = null;
                }
                else if (node.IsLeftChild)
                {
                    node.Parent.Left = null;
                }
                else if (node.IsRightChild)
                {
                    node.Parent.Right = null;
                }
            }
            else if (node.ChildCount == 1)
            {
                BSTnode<T> child = node.Left == null ? node.Right : node.Left;

                if (node == Root)
                {
                    Root = null;
                }
                else if (node.IsLeftChild)
                {
                    node.Parent.Left = child;
                }
                else if (node.IsRightChild)
                {
                    node.Parent.Right = child;
                }
            }

        }

        private BSTnode<T> Find(T value)
        {
            BSTnode<T> current = Root;
            while (current != null)
            {
                int comp = value.CompareTo(current.Value);

                if (comp < 0)
                {
                    current = current.Left;
                }
                else if (comp > 0)
                {
                    current = current.Right;
                }
                else if (comp == 0)
                {
                    return current;
                }
            }

            return null;
        }
        private BSTnode<T> Minimum(BSTnode<T> node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }

            return node;
        }

        private BSTnode<T> Maximum(BSTnode<T> node)
        {
            while (node.Right != null)
            {
                node = node.Right;
            }
            return node;
        }

        //traversals

        public Queue<T> PreOrder()
        {
            Queue<T> nodes = new Queue<T>();

            Stack<BSTnode<T>> stack = new Stack<BSTnode<T>>();
            stack.Push(Root);

            while (stack.Count > 0)
            {
                BSTnode<T> curr = stack.Pop();

                nodes.Enqueue(curr.Value);

                if (curr.Right != null)
                {
                    stack.Push(curr.Right);
                }
                if (curr.Left != null)
                {
                    stack.Push(curr.Left);
                }
            }


            return nodes;


        }
        public void PreOrderPrint(Queue<T> nodes)
        {
            Console.WriteLine("--------->");
            T[] node = nodes.ToArray<T>();
            for (int i = 0; i < node.Length; i++)
            {
                if (node[i] != null)
                {
                    Console.WriteLine(node[i]);
                }
            }
            Console.WriteLine("<----------");
        }

        //------------------------------------------->

        public Queue<T> InOrder()
        {
            Queue<T> nodes = new Queue<T>();
            Stack<BSTnode<T>> stack = new Stack<BSTnode<T>>();
            BSTnode<T> current = Root;
            while (current != null || stack.Count != 0)
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                else
                {
                    current = stack.Pop();
                    nodes.Enqueue(current.Value);
                    current = current.Right;
                }
            }
            return nodes;
        }

        public void InOrderPrint(Queue<T> nodes)
        {
            Console.WriteLine("---------->");
            T[] node = nodes.ToArray<T>();
            for (int i = 0; i < node.Length; i++)
            {
                if (node[i] != null)
                {
                    Console.WriteLine(node[i]);
                }
            }
            Console.WriteLine("<---------");
        }

        //------------------------------------------->

        public Stack<T> PostOrder()
        {
            Stack<T> nodes = new Stack<T>();

            Stack<BSTnode<T>> stack = new Stack<BSTnode<T>>();
            stack.Push(Root);

            while (stack.Count > 0)
            {
                BSTnode<T> curr = stack.Pop();

                nodes.Push(curr.Value);

                if (curr.Left != null)
                {
                    stack.Push(curr.Left);
                }

                if (curr.Right != null)
                {
                    stack.Push(curr.Right);
                }
            }

            return nodes;
        }

        public void PostOrderPrint(Stack<T> nodes)
        {
            Console.WriteLine("<---------");
            T[] node = nodes.ToArray<T>();
            for (int i = 0; i < node.Length; i++)
            {
                if (node[i] != null)
                {
                    Console.WriteLine(node[i]);
                }
            }
            Console.WriteLine("<---------");
        }

        //------------------------------------------->
        public Queue<T> BreadthFirst()
        {
            Queue<T> nodes = new Queue<T>();

            Queue<BSTnode<T>> queue = new Queue<BSTnode<T>>();
            BSTnode<T> curr = Root;

            while (curr != null)
            {
                nodes.Enqueue(curr.Value);

                if (curr.Left != null)
                {
                    queue.Enqueue(curr.Left);
                }
                if (curr.Right != null)
                {
                    queue.Enqueue(curr.Right);
                }
            }
            return nodes;
        }

        public void BreadthFirstPrint(Queue<T> nodes)
        {
            Console.WriteLine("<---------");
            T[] node = nodes.ToArray<T>();
            for (int i = 0; i < node.Length; i++)
            {
                if (node[i] != null)
                {
                    Console.WriteLine(node[i]);
                }
            }
            Console.WriteLine("<---------");
        }

        public void DrawTree()
        {
            DrawTreeRec(Root, 50, 0, 5);
        }

        private void DrawTreeRec(BSTnode<T> node, int x, int y, int dx)
        {
            if (node == null)
            {
                return;
            }

            Console.SetCursorPosition(x, y);

            Console.WriteLine(node.Value);

            DrawTreeRec(node.Left, x - dx, y + 1, dx - 2);
            DrawTreeRec(node.Right, x + dx, y + 1, dx - 2);
        }
    }
}
