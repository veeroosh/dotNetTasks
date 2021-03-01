using System;

namespace Sort
{
    class InsertionSort
    {
        private int[] array;
        private int size;
        
        static void Main(string[] args)
        {
            InsertionSort insertion = new InsertionSort();
            Console.WriteLine("Enter the size: ");
            insertion.size = int.Parse(Console.ReadLine());
            Console.WriteLine("Fill the array: ");

            insertion.array = new int[insertion.size];
            
            for (int i = 0; i < insertion.size; ++i)
                insertion.array[i] = int.Parse(Console.ReadLine());

            insertion.sort();
            
            Console.WriteLine("Sorted array: ");
            for (int i = 0; i < insertion.size; ++i)
                Console.Write(insertion.array[i]+" ");
        }

        private void sort()
        {
            for (int i = 1; i < size; ++i)
            {
                int j = i - 1;
                while (j >= 0 && array[j] > array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                    --j;
                }
            }
        }
        
    }
}