namespace DynamicProgramming
{
    /// <summary>
    /// Write a function 'canSum(targetSum, numbers)' that takes in a
    /// targetSum and an array of numbers as arguments.
    ///
    /// The function should return a boolean indicating whether or not it
    /// is possible to generate the targetSum using numbers from the array.
    ///
    /// You may use an element of the array as many times as needed.
    /// You may assume that all input numbers are nonnegative.
    /// </summary>
    public class CanSum
    {
        /// <summary>
        /// m = targetSum
        /// n = numbers.Length
        /// 
        /// Time complexity: O(n^m)
        /// Space complexity: O(m)
        /// </summary>
        public bool CanSumBruteForce(int targetSum, int[] numbers)
        {
            if (targetSum == 0)
            {
                return true;
            }
            if (targetSum < 0)
            {
                return false;
            }

            foreach (var item in numbers)
            {
                if (CanSumBruteForce(targetSum - item, numbers))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// m = targetSum
        /// n = numbers.Length
        /// 
        /// Time complexity: O(m*n)
        /// Space complexity: O(m)
        /// </summary>
        public bool CanSumMemo(int targetSum, int[] numbers, IDictionary<int, bool> memo)
        {
            if (memo.ContainsKey(targetSum))
            {
                return memo[targetSum];
            }

            if (targetSum == 0)
            {
                return true;
            }
            if (targetSum < 0)
            {
                return false;
            }

            foreach (var item in numbers)
            {
                memo[targetSum] = CanSumMemo(targetSum - item, numbers, memo);
                if (memo[targetSum])
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// m = targetSum
        /// n = numbers.Length
        /// 
        /// Time complexity: O(m*n)
        /// Space complexity: O(m)
        /// </summary>
        public bool CanSumTab(int targetSum, int[] numbers)
        {
            var table = new bool[targetSum + 1];
            table[0] = true;

            for (var i = 0; i <= targetSum; i++)
            {
                if (!table[i])
                {
                    continue;
                }

                foreach (var num in numbers)
                {
                    var index = num + i;

                    if (index > targetSum)
                    {
                        continue;
                    }

                    table[index] = true;
                    if (index == targetSum)
                    {
                        return table[targetSum];
                    }
                }
            }

            return table[targetSum];
        }
    }
}
