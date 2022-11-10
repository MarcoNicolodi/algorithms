using System;
using System.Collections.Generic;
using System.Linq;

namespace algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //var items = new int[] { 5, 2, 4, 7, 1, 3, 2 };
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
            //Console.WriteLine(FibBottomUp(6));

            //Add2Numbers(new ListNode(2, new ListNode(4, new ListNode(3))),new ListNode(5, new ListNode(6)));
            //LeetCode152MaximumProductSubarray(new int[]{2,3,-2,4});
            
            var binaryTreeArray = new int?[]{3,9,20,null,null,15,7};
            var head = BinaryTreeFromArrayLevelOrder(binaryTreeArray);


            //var depth = LeetCode104MaxDepthOfBinaryTreeBFS(head);
            var depth = LeetCode104MaxDepthOfBinaryTreeDFSIterative(head);

        }

        private static int[] InsertionSort(int[] items)
        {
            //a partir do segundo item
            //compara com items anteriores e troca de posicao ate que esse item seja menor, ou acabe o vetor

            //its called insertion sort because we are aways inserting a new element to the already ordered subarray to the left

            if (items.Length <= 1)
            {
                return items;
            }

            for (int i = 1; i <= items.Length - 1; i++)
            {
                var j = i - 1;
                var item = items[i];
                while (j >= 0 && items[j] > item)
                {
                    var tmp = items[j];
                    items[j] = item;
                    items[j + 1] = tmp;
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
                    if (items[j] < items[lower])
                    {
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
                if (items[i] == value)
                {
                    return i;
                }
            }

            return null;
        }

        private static int BinarySearch(int[] items, int target)
        {
            double min = 0;
            double max = items.Length - 1;

            while (max >= min)
            {

                var guess = (int)Math.Floor((max + min) / 2);

                if (items[guess] == target)
                {
                    return guess;
                }
                else if (target > items[guess])
                {
                    min = guess + 1;
                }
                else
                {
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

        private static int BinarySearch3Recursive(int[] items, int target, int min, int max)
        {
            if (min > max)
            {
                return -1;
            }

            int guess = (int)Math.Floor((double)(min + max) / 2);

            if (items[guess] == target)
            {
                return guess;
            }
            else if (items[guess] > target)
            {
                return BinarySearch3Recursive(items, target, min, guess - 1);
            }
            else
            {
                return BinarySearch3Recursive(items, target, guess + 1, max);
            }
        }

        private static int[] SelectionSort2(int[] items)
        {
            for (int i = 0; i <= items.Length - 2; i++)
            {
                var min = i;
                for (int j = i + 1; j <= items.Length - 1; j++)
                {
                    if (items[j] < items[min])
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    var aux = items[i];
                    items[i] = items[min];
                    items[min] = aux;
                }
            }

            return items;
        }

        private static int[] InsertionSort2(int[] items)
        {
            for (int i = 1; i <= items.Length - 1; i++)
            {
                var currentItem = items[i];
                var j = i - 1;
                while (j >= 0 && currentItem < items[j])
                {
                    var aux = items[j];
                    items[j] = currentItem;
                    items[j + 1] = aux;
                    j--;
                }
            }

            return items;
        }

        private static int[] InsertionSort3(int[] items)
        {
            for (int i = 1; i <= items.Length - 1; i++)
            {
                InsertionSort3Insert(items, i - 1, items[i]);
            }

            return items;
        }

        private static void InsertionSort3Insert(int[] items, int rightIndex, int value)
        {
            int j;
            for (j = rightIndex; j >= 0 && items[j] > value; j--)
            {
                items[j + 1] = items[j];
            }
            items[j + 1] = value;
        }

        private static int IteractiveFactorial(int n)
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


        private static long FactorialWithMemo(long n, Dictionary<long, long> memo)
        {
            if (memo.TryGetValue(n, out long value))
            {
                return value;
            }
            else
            {
                long result;

                if (n <= 1)
                {
                    result = 1;
                }
                else
                {
                    result = n * FactorialWithMemo(n - 1, memo);
                }

                memo.TryAdd(n, result);
                return result;
            }
        }

        private static bool IsPalindrome(String word)
        {
            var length = word.Length;

            if (length == 1) return true;

            if (length == 2)
            {
                var letters = word.ToCharArray();
                return letters[0] == letters[1];
            }

            char[] currentLetters = { word[0], word[length - 1] };
            var remainingletters = word.Substring(1, length - 2);

            return currentLetters[0] == currentLetters[1] && IsPalindrome(remainingletters);
        }

        private static bool IsPalindrome2(String word) => IsPalindrome2Recursive(word.ToCharArray());

        private static bool IsPalindrome2Recursive(char[] letters)
        {
            var length = letters.Length;

            if (length == 1) return true;

            if (length == 2)
            {
                return letters[0] == letters[1];
            }

            char[] currentLetters = { letters[0], letters[length - 1] };
            var remainingletters = letters.Skip(1).SkipLast(1).ToArray();

            return currentLetters[0] == currentLetters[1] && IsPalindrome2Recursive(remainingletters);
        }

        private static bool IsPalindrome3(String word)
        {
            if (word.Length <= 1) return true;

            var firstLetter = word[0];
            var lastLetter = word[word.Length - 1];

            return firstLetter == lastLetter && IsPalindrome3(word.Substring(1, word.Length - 2));
        }

        private static bool IsPalindrome4(String word) =>
            word.Length <= 1 || word[0] == word[word.Length - 1] && IsPalindrome3(word.Substring(1, word.Length - 2));


        //https://www.khanacademy.org/computing/computer-science/algorithms/recursive-algorithms/a/computing-powers-of-a-number

        private static float PowerOf(float number, int expoent)
        {
            if (expoent < 0)
            {
                return 1 / PowerOf(number, expoent * -1);
            }

            if (expoent == 0) return 1;

            if (expoent == 1) return number;

            if (expoent % 2 == 0)
            {
                return PowerOf(number, expoent / 2) * PowerOf(number, expoent / 2);
            }

            return number * PowerOf(number, expoent - 1);
        }

        private static int Fib(int nth)
        {
            if (nth == 0) return 0;
            if (nth == 1) return 1;

            return Fib(nth - 2) + Fib(nth - 1);
        }

        private static long MemoizedFib(long nth) => FibWithMemo(nth, new Dictionary<long, long>());

        private static long FibWithMemo(long nth, Dictionary<long, long> memo)
        {
            if (memo.TryGetValue(nth, out long value))
            {
                return value;
            }
            else
            {
                if (nth == 0) return 0;
                if (nth == 1) return 1;

                var result = FibWithMemo(nth - 2, memo) + FibWithMemo(nth - 1, memo);
                memo.TryAdd(nth, result);
                return result;
            }
        }

        private static long FibBottomUp(int nth)
        {
            if (nth == 0 || nth == 1) return nth;

            long twoBehind = 0;
            long oneBehind = 1;
            long result = 0;
            for (var i = 0; i <= nth - 1; i++)
            {
                result = twoBehind + oneBehind;
                twoBehind = oneBehind;
                oneBehind = result;
            }

            return result;
        }


        private static bool LeetCode242(string s1, string s2)
        {
            //valid anagram
            //build two hashmaps and compare letter occurrence count

            if (s1.Length != s2.Length) return false;

            var ocurrencess1 = new Dictionary<char, int>();
            foreach (char s in s1)
            {
                if (ocurrencess1.ContainsKey(s))
                {
                    ocurrencess1[s] = ocurrencess1[s] + 1;
                }
                else
                {
                    ocurrencess1.Add(s, 1);
                }
            }

            var ocurrencess2 = new Dictionary<char, int>();
            foreach (char s in s2)
            {
                if (ocurrencess2.ContainsKey(s))
                {
                    ocurrencess2[s] = ocurrencess2[s] + 1;
                }
                else
                {
                    ocurrencess2.Add(s, 1);
                }
            }

            foreach (var letter in ocurrencess1.Keys)
            {

                if (!ocurrencess2.ContainsKey(letter) || ocurrencess2[letter] != ocurrencess1[letter])
                {
                    return false;
                }
            }

            return true;
        }

        public int[] LeetCode1TwoSum(int[] nums, int target)
        {
            //https://www.youtube.com/watch?v=KLlXCFG5TnA
            //visited hashmap solution O(n)
            var visited = new Dictionary<int, int>();
            int[] result = new int[2];

            for (int i = 0; i <= nums.Length - 1; i++)
            {
                var desired = target - nums[i];

                if (visited.TryGetValue(desired, out int match))
                    return new int[2] { i, match };


                if (!visited.ContainsKey(nums[i]))
                    visited.Add(nums[i], i);
            }

            return result;
        }

        private static int[] LeetCode167TwoSumInputIsOrdered(int[] numbers, int target)
        {
            //https://www.youtube.com/watch?v=cQ1Oz4ckceM
            //two pointers solution O(n)
            int left = 0;
            int right = numbers.Length - 1;
            int[] result = new int[2];

            while (left < right)
            {
                if (numbers[left] + numbers[right] < target)
                    left++;
                else if (numbers[left] + numbers[right] > target)
                    right--;
                else if (numbers[left] + numbers[right] == target)
                {
                    result[0] = left + 1;
                    result[1] = right + 1;
                    break;
                }

            }

            return result;
        }

        private static IList<IList<int>> ThreeSum(int[] numbers)
        {
            //return the triplets of indexes of numbers that sum to zero
            //https://www.youtube.com/watch?v=jzZsG8n2R9A
            //time: sorting takes O(n logn), plus two loops: O(n logn) + O(n^2) = O(n^2)
            Array.Sort(numbers);
            IList<IList<int>> result = new List<IList<int>>();
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (i > 0 && numbers[i] == numbers[i - 1]) continue;

                int left = i + 1;
                int right = numbers.Length - 1;

                while (left < right)
                {
                    if (numbers[left] + numbers[right] + numbers[i] < 0)
                    {
                        left++;
                    }
                    else if (numbers[left] + numbers[right] + numbers[i] > 0)
                    {
                        right--;
                    }
                    else
                    {
                        result.Add(new int[3] { numbers[i], numbers[left], numbers[right] });
                        left++;
                        while (left < right && numbers[left] == numbers[left - 1])
                            left++;
                    }
                }
            }

            return result;
        }

        private static int[] LeetCode347TopKFrequentElements(int[] nums, int k)
        {
            //https://leetcode.com/problems/top-k-frequent-elements/
            //https://www.youtube.com/watch?v=YPTqKIgVk-k

            var frequencies = new Dictionary<int, int>();
            for (int i = 0; i <= nums.Length - 1; i++)
            {
                if (frequencies.ContainsKey(nums[i]))
                {
                    frequencies[nums[i]]++;
                }
                else
                {
                    frequencies[nums[i]] = 1;
                }
            }

            var buckets = new Queue<int>[nums.Count() + 1];

            foreach (var frequency in frequencies)
            {
                var num = frequency.Key;
                var count = frequency.Value;

                if (buckets[count] == null)
                    buckets[count] = new Queue<int>() { };

                buckets[count].Enqueue(num);
            }

            var result = new List<int>();

            for (int i = buckets.Length - 1; i >= 0 && result.Count < k; i--)
            {
                if (buckets[i] != null)
                {
                    while (buckets[i].TryDequeue(out int num) && result.Count < k)
                    {
                        result.Add(num);
                    }
                }
            }

            return result.ToArray();
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public static ListNode Add2Numbers(ListNode l1, ListNode l2)
        {
            //aka add two linked lists
            //https://leetcode.com/problems/add-two-numbers/
            //https://www.youtube.com/watch?v=wgFPrzTjm7s&t=301s
            
            var dummy = new ListNode();
            var result = dummy;
            var carry = 0m;

            while(l1 != null || l2 != null || carry != 0)
            {
                var sum = (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val) + carry;
                var val = sum % 10;
                carry = Math.Floor(sum / 10);
                l1 = l1?.next;
                l2 = l2?.next;
                result.next = new ListNode((int) val);
                result = result.next;
            }

            return dummy.next;
        }

        // public static void LeetCode143ReorderList(ListNode head)
        // {
        //     //https://leetcode.com/problems/reorder-list/

        //     var nodesArr = new ListNode[]{};
        //     var  i = 0;
        //     var loopNode = head;
            
        //     //turn into array so it can be reordered;
        //     while(loopNode.next != null)
        //     {
        //         nodesArr[i] = loopNode;
        //         loopNode = head.next;
        //     }



        // }

        public static int LeetCode152MaximumProductSubarray(int[] nums)
        {
            //https://leetcode.com/problems/maximum-product-subarray/
            //https://www.youtube.com/watch?v=lXVy6YWFcRM
            var result = nums.First();
            var min = 1;
            var max = 1;
            foreach (var num in nums)
            {
                var tmpMin = min;
                min = Math.Min(Math.Min(num, num * min), num * max);
                max = Math.Max(Math.Max(num, num * tmpMin), num * max);

                if(max > result)
                    result = max;
            
            }

            return result;
        }

 
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public static TreeNode BinaryTreeFromArrayLevelOrder(int?[] binaryTreeArray)
        {
            if(binaryTreeArray.Length == 0 || binaryTreeArray[0] == null)
                return null;

            var head = new TreeNode(binaryTreeArray[0].Value);
            _BinaryTreeFromArrayLevelOrder(head, binaryTreeArray, 0);

            return head;
        }

        public static void _BinaryTreeFromArrayLevelOrder(TreeNode node, int?[] binaryTreeArray, int i)
        {
            if(2*i+1 <= binaryTreeArray.Length - 1 && binaryTreeArray[2*i+1] is int leftVal)
            {
                node.left = new TreeNode(leftVal);
                _BinaryTreeFromArrayLevelOrder(node.left, binaryTreeArray, 2*i+1);
            }
            if(2*i+2 <= binaryTreeArray.Length - 1 && binaryTreeArray[2*i+2] is int rightVal)
            {
                node.right = new TreeNode(rightVal);
                _BinaryTreeFromArrayLevelOrder(node.right, binaryTreeArray, 2*i+2);
            }
        }

        public static int LeetCode104MaxDepthOfBinaryTreeDFSRecursive(TreeNode root) 
        {
            //https://leetcode.com/problems/maximum-depth-of-binary-tree/
            //https://www.youtube.com/watch?v=hTM3phVI6YQ
            if(root == null) return 0;

            return 1 + Math.Max(LeetCode104MaxDepthOfBinaryTreeDFSRecursive(root.left), LeetCode104MaxDepthOfBinaryTreeDFSRecursive(root.right));
        }

        public static int LeetCode104MaxDepthOfBinaryTreeDFSIterative(TreeNode root)
        {
            //https://leetcode.com/problems/maximum-depth-of-binary-tree/
            //https://www.youtube.com/watch?v=hTM3phVI6YQ

            if(root == null) return 0;

            var stack = new Stack<KeyValuePair<TreeNode, int>>();
            stack.Push(new KeyValuePair<TreeNode, int>(root, 1));
            var result = 1;

            while(stack.TryPop(out KeyValuePair<TreeNode, int> nodeDepth))
            {
                var node = nodeDepth.Key;
                var depth = nodeDepth.Value;
                result = Math.Max(depth, result);

                if(node.left != null)
                    stack.Push(new KeyValuePair<TreeNode, int>(node.left, depth + 1));
                if(node.right != null)
                    stack.Push(new KeyValuePair<TreeNode, int>(node.right, depth + 1));
            }

            return result;
        }

        public static int LeetCode104MaxDepthOfBinaryTreeBFS(TreeNode root) 
        {
            //https://leetcode.com/problems/maximum-depth-of-binary-tree/
            //https://www.youtube.com/watch?v=hTM3phVI6YQ
            if(root == null) return 0;

            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            var depth = 0;
            while(q.TryPeek(out _))
            {
                var tmp = new List<TreeNode>();
                while(q.TryDequeue(out TreeNode node))
                {
                    if(node.left != null)
                        tmp.Add(node.left);

                    if(node.right != null)
                        tmp.Add(node.right);

                }

                tmp.ForEach(node => {q.Enqueue(node);});

                depth++;
            }

            return depth;
        }

    }
}
