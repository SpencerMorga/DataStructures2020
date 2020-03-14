using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures
{
    public class DoublyLinkedLIists <T>
    {
        public DoublyNode<T> Head;
        DoublyNode<T> Tail;

        public int Count;

        public DoublyLinkedLIists()
        {
            Count = 0;
            Head = null;
            Tail = null;
        }

        // addfirst

        public void AddFirst(T val)
        {
            if (Head == null)
            {
                Head = new DoublyNode<T>(val);
                Tail = Head;
                Tail.Next = Head;
                Head.Prev = Tail;
            }
            else
            {
                DoublyNode<T> temp = new DoublyNode<T>(val);
                temp.Next = Head;
                Head.Prev = temp;
                Head = temp;
                Head.Prev = Tail;
                Tail.Next = Head;
            }
            Count++;
        }

        //addlast
        public void AddLast(T val)
        {
            if (Head == null)
            {
                Head = new DoublyNode<T>(val);
                Tail = Head;
                Head.Prev = Tail;
                Tail.Next = Head;
            }
            else
            {
                var temp = new DoublyNode<T>(val);
                Tail.Next = temp;
                temp.Prev = Tail;
                Tail = temp;
                Tail.Next = Head;
                Head.Prev = Tail;
            }
            Count++;
        }

        //addbefore
        public void AddBefore(DoublyNode<T> Node, T val)
        {

            if (Node == null)
            {
                AddLast(val);
                return;
            }
            else if (Node == Head)
            {
                AddFirst(val);
                return;
            }
            

            DoublyNode<T> temp = new DoublyNode<T>(val);
            
            var nodeBefore = Node.Prev;

            nodeBefore.Next = temp;
            temp.Next = Node;
            temp.Prev = nodeBefore;
            Node.Prev = temp;
            Count++;
        }
            
        //addafter
        public void AddAfter(DoublyNode<T> Node, T val)
        {


            if (Node == null)
            {

                AddLast(val);
                return;
            }
            else if (Node == Tail)
            {
                AddLast(val);
                return;
            }
           

            DoublyNode<T> temp = new DoublyNode<T>(val);
            temp.Prev = Node;
            temp.Next = Node.Next;
            Node.Next.Prev = temp;
            Node.Next = temp;
            Count++;

        }

        //removefirst
        public bool RemoveFirst()
        {
            if (Count == 0)
            {
                return false;
            }
            DoublyNode<T> temp = Head;
            Head = Head.Next;
            temp.Next = null;
            Head.Prev = Tail;
            Tail.Next = Head;
            Count--;
            return true;
        }

        public bool RemoveLast()
        {
            if (Head == null)
            {
                return false;
            }
            else if (Head == Tail)
            {
                Head = null;
                Tail = Head;
                return true;
            }

            DoublyNode<T> temp = Tail.Prev;
            temp.Next = null;
            Tail = temp;
            Tail.Next = Head;
            Head.Prev = Tail;
            Count--;
            return true;
        }
                     
        // remove
        public bool Remove(T val)
        {
            if (val.Equals(Head.Value))
            {
                RemoveFirst();
                return true;
            }
            else if (val.Equals(Tail.Value))
            {
                RemoveLast();
                return true;
            }          
            else if (val == null)
            {
                throw new ArgumentException();
            }

            DoublyNode<T> item = Find(val);
            item.Prev.Next = item.Next;
            item.Next.Prev = item.Prev;
            Count--;
            return true;
        }
       
        public DoublyNode<T> Find (T val)
        {
            DoublyNode<T> pos = Head;
            while (pos != null)
            {
                if (pos.Value.Equals(val))
                {
                    return pos;
                }
                pos = pos.Next;
            }
            return null;
        }

        public void PrintListForwards()
        {

            Console.WriteLine("---------------------------------------------->");
            DoublyNode<T> temp = Head;

            while (true)
            {
                Console.WriteLine(temp.Value);
                temp = temp.Next;

                if (temp == Head)
                {
                    break;
                }
            }
            Console.WriteLine("<----------------------------------------------");

        }


        public void PrintListBackwards()
        {
            Console.WriteLine("---------------------------------------------->");

            DoublyNode<T> temp = Tail;

            while (true)
            {
                Console.WriteLine(temp.Value);
                temp = temp.Prev;

                if (temp == Tail)
                {
                    break;
                }
            }
            Console.WriteLine("<----------------------------------------------");
        }


           
        //     |     ______     |   _______
        //  ___|___             |    
        //     |       |        |     
        //     |       |        |     /
        //     |     __|_       |    |
        //     /    /  | \      | /  |
        //    /     \__/  \     |/   \_____/
    }
}
