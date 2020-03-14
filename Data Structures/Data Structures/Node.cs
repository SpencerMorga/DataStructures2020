using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures
{
    public class Node<T>
    {

        public T Value;
        public Node<T> Next;


        public Node(T val)
        {
            Value = val;
            Next = null;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        internal void Invalidate()
        {
            
            Next = null;
        }

    }
}
