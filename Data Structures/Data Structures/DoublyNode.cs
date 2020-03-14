using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures
{
    public class DoublyNode<T>
    {
        public DoublyNode<T> Next;
        public DoublyNode<T> Prev;

        public T Value;

        public DoublyNode(T val)
        {
            Value = val;
            Next = null;
        }
        
        public override string ToString()
        {
            return Value.ToString();
        }

    }

}
