using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures
{
    class List<T>
    {
        T[] array;

        public List()
        {
            array = new T[0];
        }

        public void Add(T value)
        {
            // create a temp array with one size bigger than old array
            // copy everything from old array into new array
            // in the new array last position insert value
            // set array to equal temp array
            T[] temparray = new T[array.Length + 1];


            for (int i = 0; i < array.Length; i++)
            {
                temparray[i] = array[i];
            }

            temparray[temparray.Length - 1] = value;
            
            array = temparray;
        }


        // create a remove function that removes a value from the array
        public void Remove(T numToRemove)
        {
            T[] temparray2 = new T[array.Length - 1];

            // copy all the values except the numToRemove
            int count = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (!numToRemove.Equals(array[i]))
                {
                    temparray2[count] = array[i];
                    count++;
                }
       
                   

            }

            array = temparray2;
            
            
        }


    }
}
