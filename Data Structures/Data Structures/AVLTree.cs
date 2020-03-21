using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures
{
    public class AVLTree<T> where T : IComparable<T>
    {
        public AVLNode<T> root;

        
        
        
        public void Add(T value)
        {
            if (root == null)
            {
                root = new AVLNode<T>(value);
                return;
            }
            AVLNode<T> current = root;

            while (true)
            {
                if (value.CompareTo(current.Value) < 0)
                {
                    if (current.left == null)
                    {
                        AVLNode<T> node = new AVLNode<T>(value);
                        current.left = node;
                        current.left.Parent = current;
                        RecursiveBalacing(node);

                        break;
                    }
                    current = current.left;
                    
                }
                else
                {
                    if (current.right == null)
                    {
                        AVLNode<T> node = new AVLNode<T>(value);
                        current.right = node;
                        current.right.Parent = current;
                        RecursiveBalacing(node);
                        break;
                    }
                    current = current.right;
                    
                }

            }
        }
        
        public void Delete(T value)
        {
            AVLNode<T> current = Find(value);

            if (current.ChildCount == 0)
            {
                if (current.IsLeftChild)
                {
                    current.Parent.left = null;

                    RecursiveBalacing(current.Parent);
                }
                else if (current.IsRightChild)
                {
                    current.Parent.right = null;
                    //current = null;
                    RecursiveBalacing(current.Parent);
                }
                else if (current == root)
                {
                    root = null;
                }
            }
            else if (current.ChildCount == 2)
            {
                AVLNode<T> candidate = Maximum(current.left);
                current.Value = candidate.Value;
               
                if (candidate.Parent != current)
                {
                    candidate.Parent.right = candidate.left;
                    RecursiveBalacing(candidate.Parent);
                }
                if (current != root)
                {

                    current.Parent = candidate.Parent;
                    candidate.Parent.left = candidate;
                    current.left = candidate.left;
                    candidate.left = null;
                }

                
            }
            else if (current.ChildCount == 1)
            {
                AVLNode<T> child = current.left == null ? current.right : current.left;
                if (current.IsLeftChild)
                {
                    current.Parent.left = child;
                    // current = null;
                    RecursiveBalacing(current.Parent);
                }
                else if (current.IsRightChild)
                {
                    current.Parent.right = child;
                    // current = null;
                    RecursiveBalacing(current.Parent);
                }
                else if (current == root)
                {
                    // current = null;
                    root = child;
                    RecursiveBalacing(root);
                }
            }


        }

        internal void Visualize()
        {
            Visualize(root, Console.WindowWidth /2 , 0, 5, 1);
        }

        private void Visualize(AVLNode<T> root, int x, int y, int dx, int maxlevel)
        {
            if (root == null || maxlevel == 5)
            {
                return;
            }

            maxlevel++;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(root.Value);
            Visualize(root.left, x - dx, y + 1, dx - 2, maxlevel);
            Visualize(root.right, x + dx, y + 1, dx - 2, maxlevel);


        }

        private AVLNode<T> Find(T value)
        {
            AVLNode<T> current = root;
            while (current != null)
            {
                int comp = value.CompareTo(current.Value);

                if (comp < 0)
                {
                    current = current.left;
                }
                else if (comp > 0)
                {
                    current = current.right;
                }
                else if (comp == 0)
                {
                    return current;
                }
            }

            return null;
        }
        private AVLNode<T> Maximum(AVLNode<T> node)
        {
            while (node.right != null)
            {
                node = node.right;
            }
            return node;
        }

        public void RecursiveBalacing(AVLNode<T> current)
        {
            int balance = CalculatedBalance(current);
            if (balance < -1)
            {
                if (current.right.left != null)
                {
                    RightRotation(current.right);
                    LeftRotation(current);
                    if (current.Parent != null && current.Parent.right != null)
                    {
                        RecursiveBalacing(current.Parent.right);
                    }
                    if (current.left != null)
                    {
                       RecursiveBalacing(current.left);
                    }
                    
                }
                else
                {
                    LeftRotation(current);
                }
            }
            else if (balance > 1)
            {
                if (current.left.right != null)
                {
                    LeftRotation(current.left);
                    RightRotation(current);
                    if (current.Parent != null && current.Parent.left != null)
                    {
                        RecursiveBalacing(current.Parent.left);
                    }
                    if (current.right != null)
                    {
                        RecursiveBalacing(current.right);
                    }
                
                }
                else
                {
                    RightRotation(current);
                }
            }
            if (current.Parent != null)
            {
                RecursiveBalacing(current.Parent);
            }

        }

        //if tree leans towards right side, it has a balance of > 1
        //node has to be transferred to left subtree
        public int CalculatedBalance(AVLNode<T> current)
        {
            int LeftHeight = 0;
            int RightHeight = 0;
            if (current.left != null)
            {
                LeftHeight = current.left.getHeight() + 1;
            }
            if (current.right != null)
            {
                RightHeight = current.right.getHeight() + 1;
            }
            return LeftHeight - RightHeight;
        }
        public LinkedList<T> PreOrder()
        {
            LinkedList<T> list = new LinkedList<T>();
            Stack<AVLNode<T>> stack = new Stack<AVLNode<T>>();
            stack.Push(root);

            while (list.Count > 0)
            {
                AVLNode<T> current = stack.Pop();
                list.AddLast(current.Value);
                if (current.right != null)
                {
                    stack.Push(current.right);
                }
                if (current.left != null)
                {
                    stack.Push(current.left);
                }
            }
            return list;
        }
        public void PreOrderPrint(LinkedList<T> lists)
        {
            Console.WriteLine("======pre.order=======>");
            T[] list = lists.ToArray<T>();
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] != null)
                {
                    Console.WriteLine(list[i]);
                }        
            }
            Console.WriteLine("<========pre.order======");

        }
        
        public LinkedList<T> BreadthFirst()
        {
            LinkedList<T> list = new LinkedList<T>();
            AVLnode<T> current = Root;
            
            while (current != null)
            {
                list.Add(current.Value)
                
                if (current.left != null)
                {
                     list.Add(current.left);
                }
                 if (current.right != null)
                {
                     list.Add(current.right)
                }

            }
            return nodes;
        }
        
        public void BreadthFirstPrint (LinkedList<T> list)
        {
            Console.WriteLine("====brdt.fst.=====>");
            T[] list = lists.ToArray<T>();
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] != null)
                {
                    Console.WriteLine(list[i]);
                }        
            }
            Console.WriteLine("<====brdt.fst.===");
        }

        public void LeftRotation(AVLNode<T> node)
        {
            if (node.Parent == null)
            {
                if (node.right.left != null)
                {
                    RightRotation(node.right);
                }
                node.right.left = node;
                node.right.Parent = null;
                root = node.right;
                node.Parent = root;
                node.right = null;

            }
            else
            {
                if (node.right.left != null)
                {
                    RightRotation(node.right);
                }
                node.right.Parent = node.Parent;//1
                if (node == node.Parent.left)
                {
                    node.Parent.left = node.right;
                }
                else
                {
                    node.Parent.right = node.right;
                }
                node.right.left = node;
                node.Parent = node.right;
                node.right = null;            
            }
        }
        public void RightRotation(AVLNode<T> node)
        {
            if (node.Parent == null)
            {
                if (node.left.right != null)
                {
                    LeftRotation(node.left);
                }
                node.left.right = node;
                node.left.Parent = null;
                root = node.left;
                node.Parent = root;
                node.left = null;
            }
            else
            {
                if (node.left.right != null)
                {
                    LeftRotation(node.left);
                }
                node.left.Parent = node.Parent;
                if (node == node.Parent.right)
                {
                    node.Parent.right = node.left;
                }
                else
                {
                    node.Parent.left = node.left;
                }
                node.left.right = node;
                node.Parent = node.left;
                node.left = null;
            }
        }
        
       
    }

}
