using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures
{
    public class AVLNode<T> where T : IComparable<T>
    {
        public AVLNode<T> root;
        public T Value;
        public AVLNode<T> left;
        public AVLNode<T> right;
        public AVLNode<T> Parent;
        public int ChildCount
        {
            get
            {
                int count = 0;
                if (left != null)
                {
                    count++;
                }
                if (right != null)
                {
                    count++;
                }
                return count;
            }

        }
        public bool IsLeftChild => Parent == null ? false : Parent.left == this;
        public bool IsRightChild => Parent == null ? false : Parent.right == this;

        public int getHeight()
        {
            int leftheight = 0;
            int rightheight = 0;
            if (left != null)
            {
                leftheight = left.getHeight() + 1;
            }

            if (right != null)
            {
                rightheight = right.getHeight() + 1;
            }
            
            if (leftheight < rightheight)
            {
                return rightheight;
            }
            return leftheight;
        }
        public AVLNode (T value)
        {
            Value = value;
        }
      
    }
}
