using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures
{
    public class SinglyLinkedList<T>
    {

        public Node<T> Head;
        public Node<T> Tail;


        public int Count;
        public SinglyLinkedList()
        {
            Count = 0;
            Head = null;
            Tail = null;
        }
        
      
        //addlast
        public void AddLast(T val)
        {
            
            if(Count == 0)
            {

                Head = new Node<T>(val);
                Tail = Head;
            }
            else
            {
                // without a tail variable
                //Node<T> temp = Head;

                //while(temp.Next != null)
                //{
                //    temp = temp.Next;
                //}

                //temp.Next = new Node<T>(val);
                Tail.Next = new Node<T>(val);
                Tail = Tail.Next;


            }

            Count++;

        }



        // addfirst

        public void AddFirst(T val)
        {
            if (Count == 0)
            {

                Head = new Node<T>(val);
                Tail = Head;
            }
            else
            {
                Node<T> temp = new Node<T>(val);
                temp.Next = Head;
                Head = temp;

            }
            Count++;

        }

        // add after

        public void AddAfter(Node<T> node, T val)
        {
            // if node is null, just insert it in the end of the list
            if (node == null)
            {
                
                AddLast(val);
                return;
            }

            Node<T> temp = new Node<T>(val);
            temp.Next = node.Next;
            node.Next = temp;

            if (node.Equals(Tail))
            {
                Tail = temp;
            }
            Count++;
        }

        // add before

        public void AddBefore(Node<T> node, T val)
        {
            if (node == null)
            {
                AddLast(val);
                return;
            }
            if (node == Head)
            {
                AddFirst(val);
                return;
            }


            Node<T> item = Head;
            while (!item.Equals(null) && !item.Next.Equals(node))
            {
                item = item.Next;
            }
            Node<T> temp = new Node<T>(val);

            item.Next = temp;
            temp.Next = node;

            Count++;
        }



      

        // remove first
        public bool RemoveFirst()
        {
            if (Count.Equals(0))
            {
                return false;
            }
            else
            {
                Node<T> temp = Head;
                Head = Head.Next;
                temp.Next = null;
                Count--;
                return true;
            }
        }

        // remove last

        public bool RemoveLast()
        {
            if (Count == 0)
            {
                return false;
            }
            else
            {

                // find the node right before the last one

                Node<T> temp = Head;

                while (temp.Next != Tail)
                {
                    temp = temp.Next;
                }

                temp.Next = null;

                
                Count--;
                return true;
                
            }
        }
        public void Remove(T val)
        {


            if (val.Equals(Tail.Value))
            {
                RemoveLast();
                return;
            }
            else if (val.Equals(Head.Value))
            {
                RemoveFirst();
                return;
            }
            else
            {
                Node<T> item = Head;
                while(item != null)
                {
                    if (item.Next != null && item.Next.Value.Equals(val))
                    {
                        Node<T> temp = item.Next;
                        item.Next = item.Next.Next;
                        temp.Next = null;
                        Count--;
                        return;
                    }
                    item = item.Next;
                }
                /*
                Node<T> temp = Head;
                while (!temp.Next.Equals(val))
                {
                    temp = temp.Next;
                }
                ////////////////////temp.Next = null;
                temp.Next = temp.Next.Next;
                Count--;
                return;

        /
                */


            }

        }
        // find

        public Node<T> Find (T val)
        {
            Node<T> item = Head;
            while(item != null)
            {
                if (item.Value.Equals(val))
                {
                    return item;
                }
                item = item.Next;
            }
            return null;
        }

        // contains

        public bool Contains(T item)
        {
            return Find(item) != null;
        }
        

        // printlist

        public void PrintList()
        {
            Node<T> temp = Head;

            while  (temp != null)
            {
                Console.WriteLine(temp.Value);
                temp = temp.Next;        
            }
        }


    }
}
