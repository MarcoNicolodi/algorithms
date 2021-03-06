using System;
using System.Collections.Generic;
using System.Linq;

namespace algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new int[] { 5, 2, 4, 7, 1, 3, 2 };
            //InsertionSort2(items).ToList().ForEach(i => Console.WriteLine(i));
            //InsertionSort3(items).ToList().ForEach(i => Console.WriteLine(i));
            //SelectionSort(items).ToList().ForEach(i => Console.WriteLine(i));
            //Console.WriteLine(LinearSearch(items, 1));
            //Console.WriteLine(LinearSearch(items, 8));

            //var items = Enumerable.Range(50, 100).ToArray();
            //Console.WriteLine(BinarySearch(items, 73));
            //Console.WriteLine(BinarySearch3(items, 73));
            //Console.WriteLine(RecursiveFactorial(15));
            //Console.WriteLine(IsPalindrome3("repaper"));
            //Console.WriteLine(PowerOf(2, -3));
            //Console.WriteLine(MemoizedFactorial(10));
            Console.WriteLine(FibBottomUp(6));
            
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
            for (int i = 1; i <= items.Length - 1; i++)
            {
                InsertionSort3Insert(items, i - 1, items[i]);
            }

            return items;
        }

        private static void InsertionSort3Insert(int[] items, int rightIndex, int value) 
        {
            int j;
            for(j = rightIndex; j >= 0 && items[j] > value; j--) {
                items[j + 1] = items[j];
            }
            items[j + 1] = value;
        }

        private static int IteractiveFactorial (int n) 
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result = result * i;
            }

            return result;
        }

        private static long RecursiveFactorial(long n) 
        {
            if (n <= 1) 
                return 1;

            return n * RecursiveFactorial(n - 1);
        }

        private static long MemoizedFactorial(long n) 
            => FactorialWithMemo(n, new Dictionary<long, long>());
        

        private static long FactorialWithMemo(long n, Dictionary<long, long> memo) {
            if(memo.TryGetValue(n, out long value)) 
            {
                return value;
            } else {
                long result;
                
                if(n <= 1) {
                    result = 1;
                } else {
                    result =  n * FactorialWithMemo(n - 1, memo);
                }

                memo.TryAdd(n, result);
                return result;
            }
        }
        
        private static bool IsPalindrome(String word) {
            var length = word.Length;

            if(length == 1) return true;
            
            if(length == 2) {
                var letters = word.ToCharArray();
                return letters[0] == letters[1];
            }

            char[] currentLetters = {word[0], word[length - 1]};
            var remainingletters = word.Substring(1,length - 2);

            return currentLetters[0] == currentLetters[1] && IsPalindrome(remainingletters);
        }

        private static bool IsPalindrome2(String word) => IsPalindrome2Recursive(word.ToCharArray());

        private static bool IsPalindrome2Recursive(char[] letters) {
            var length = letters.Length;

            if(length == 1) return true;
            
            if(length == 2) {
                return letters[0] == letters[1];
            }

            char[] currentLetters = {letters[0], letters[length - 1]};
            var remainingletters = letters.Skip(1).SkipLast(1).ToArray();

            return currentLetters[0] == currentLetters[1] && IsPalindrome2Recursive(remainingletters);
        }

        private static bool IsPalindrome3(String word) {
            if(word.Length <= 1) return true;

            var firstLetter = word[0];
            var lastLetter = word[word.Length -1];

            return firstLetter == lastLetter && IsPalindrome3(word.Substring(1, word.Length - 2));
        }

        private static bool IsPalindrome4(String word) =>
            word.Length <= 1 || word[0] ==  word[word.Length -1] && IsPalindrome3(word.Substring(1, word.Length - 2));


        //https://www.khanacademy.org/computing/computer-science/algorithms/recursive-algorithms/a/computing-powers-of-a-number
        
        private static float PowerOf(float number, int expoent) 
        {
            if(expoent < 0) 
            {
                return 1 / PowerOf(number, expoent * -1);
            }

            if(expoent == 0) return 1;

            if(expoent == 1) return number;

            if(expoent % 2 == 0) {
                return PowerOf(number, expoent / 2) * PowerOf(number, expoent / 2);
            } 

            return number * PowerOf(number, expoent -1);
        }

        private static int Fib(int nth) {
            if(nth == 0) return 0;
            if(nth == 1) return 1;

            return Fib(nth - 2) + Fib(nth - 1);
        }

        private static long MemoizedFib(long nth) => FibWithMemo(nth, new Dictionary<long, long>());

        private static long FibWithMemo(long nth, Dictionary<long, long> memo) {
            if(memo.TryGetValue(nth, out long value)) {
                return value;
            } else {
                if(nth == 0) return 0;
                if(nth == 1) return 1;
                
                var result = FibWithMemo(nth - 2, memo) + FibWithMemo(nth - 1, memo);
                memo.TryAdd(nth, result);
                return result;
            }
        }

        private static long FibBottomUp(int nth) {
            if (nth == 0 || nth == 1) return nth;

             long twoBehind = 0;
             long oneBehind = 1;
             long result = 0;
             for(var i = 0; i <= nth -1; i++) {
                result = twoBehind + oneBehind;
                twoBehind = oneBehind;
                oneBehind = result;
             }

             return result;
        }
    }
}
