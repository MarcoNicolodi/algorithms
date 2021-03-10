using System;
using System.Linq;

namespace algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new int[] { 5, 2, 4, 7, 1, 3, 2 };
            //InsertionSort2(items).ToList().ForEach(i => Console.WriteLine(i));
            InsertionSort3(items).ToList().ForEach(i => Console.WriteLine(i));
            //SelectionSort(items).ToList().ForEach(i => Console.WriteLine(i));
            //Console.WriteLine(LinearSearch(items, 1));
            //Console.WriteLine(LinearSearch(items, 8));

            //var items = Enumerable.Range(50, 100).ToArray();
            //Console.WriteLine(BinarySearch(items, 73));
            //Console.WriteLine(BinarySearch3(items, 73));
            
        }

        private static int[] InsertionSort(int[] items)
        {
            //a partir do segundo item
            //compara com items anteriores e troca de posicao ate que esse item seja menor, ou acabe o vetor

            //its called insertion sort because we are aways inserting a new element to the already ordered subarray to the left

            if(items.Length <= 1) {
                return items;
            }

            for (int i = 1; i <= items.Length - 1; i++)
            {
                var j = i - 1;
                var item = items[i];
                while(j >= 0 && items[j] > item) {
                    var tmp = items[j];
                    items[j] = item;
                    items[j+1] = tmp;
                    j--;
                }
            }

            return items;
        }

        private static int[] SelectionSort(int[] items) 
        {
            //for each item
            //searches for the lowest item to the right and swipes position

            //This algorithm is called selection sort because it repeatedly selects the next-smallest element and swaps it into place.

            //no case is is particullary good or badfor selection sort, because the inner loop ill aways run O(n2) (removing constants and lower order terms)
            //even if the array is almost sorted
            for (int i = 0; i <= items.Length - 1; i++)
            {
                var lower = i;
                for (int j = i + 1; j <= items.Length - 1; j++)
                {
                    if(items[j] < items[lower]) {
                        lower = j;
                    }
                }

                var tmp = items[i];
                items[i] = items[lower];
                items[lower] = tmp;
            }

            return items;
        }

        // private static int[] BubbleSort(int[] items) {
        //     throw new NotImplementedException();
        // }



        private static int? LinearSearch(int[] items, int value)
        {
            for (int i = 0; i < items.Length - 1; i++)
            {
                if(items[i] == value) {
                    return i;
                }
            }

            return null;
        }

        private static int BinarySearch(int[] items, int target) {
            double min = 0;
            double max = items.Length - 1;
            
            while(max >= min) {
                
                var guess = (int)Math.Floor((max + min) / 2);
                
                if(items[guess] == target) {
                    return guess;
                } else if (target > items[guess]) {
                    min = guess + 1;
                } else {
                    max = guess - 1;
                }
            }

            return -1;
        }

        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        private static int BinarySearch3(int[] items, int target) 
        {
            int min = 0;
            int max = items.Length - 1;
            return BinarySearch3Recursive(items, target, min, max);
        }

        private static int BinarySearch3Recursive(int[] items, int target, int min, int max) {
            if(min > max) 
            {
                return -1;    
            }

            int guess = (int)Math.Floor((double)(min+max)/2);

            if(items[guess] == target) {
                return guess;
            } else if(items[guess] > target) {
                return BinarySearch3Recursive(items, target, min, guess - 1);
            } else {
                return BinarySearch3Recursive(items, target, guess + 1, max);
            }
        }

        private static int[] SelectionSort2(int[] items) {
            for (int i = 0; i <= items.Length - 2; i++)
            {
                var min = i;
                for (int j = i + 1; j <= items.Length - 1; j++)
                {
                    if(items[j] < items[min]) {
                        min = j;
                    }
                }

                if(min != i) {
                    var aux = items[i];
                    items[i] = items[min];
                    items[min] = aux;
                }
            }

            return items;
        }

        private static int[] InsertionSort2(int[] items) {
            for (int i = 1; i <= items.Length - 1; i++)
            {
                var currentItem = items[i];
                var j = i - 1;
                while(j >= 0 && currentItem < items[j]) {
                    var aux = items[j];
                    items[j] = currentItem;
                    items[j + 1] = aux;
                    j--;
                }
            }

            return items;
        }

        private static int[] InsertionSort3(int[] items) {
            for (int i = 1; i < items.Length - 1; i++)
            {
                var key = items[i];
                var j = i - 1;

                while(j > 0 && key < items[j]) {
                    items[j + 1] = items[j];
                    --j;
                }

                items[j] = key;
            }

            return items;
        }
    }
}
