using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures
{
    public class LinkedListQueue<T>
    {
        SinglyLinkedList<T> listQueue;
        public int Count;
        public LinkedListQueue()
        {
            listQueue = new SinglyLinkedList<T>();
        }

        public void Enqueue (T value)
        {
            listQueue.AddLast(value);
            Count++;
        }

        public T Dequeue()
        { 
            if (Count == 0 )
            {
                throw new InvalidOperationException("queue empty");
            }
            T temp = listQueue.Head.Value;
            listQueue.RemoveFirst();
            Count--;
            return temp;
            
        
        }

        public T Peek()
        {
            if (Count == 0)
            {
                
                throw new InvalidOperationException("queue empty");   
            }
            return listQueue.Head.Value;
        }

        public void PrintList()
        {
            Console.WriteLine("----------------------->");
            listQueue.PrintList();
            Console.WriteLine("<-----------------------");
        }












    }
}
