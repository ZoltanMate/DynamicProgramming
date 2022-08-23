namespace DynamicProgramming
{
    /// <summary>
    /// Write a function 'howSum(targetSum, numbers)' that takes in a
    /// targetSum and an array of numbers as arguments.
    ///
    /// The function should return an array containing any combination of
    /// elements that add up to exactly the targetSum. If there is no
    /// combination that adds up to the targetSum, then return null.
    ///
    /// If there are multiple combinations possible, you may return any
    /// single one.
    /// </summary>
    public class HowSum
    {
        /// <summary>
        /// m = targetSum
        /// n = numbers.Length
        /// 
        /// Time complexity: O(n^m * m)
        /// Space complexity: O(m)
        /// </summary>
        public List<int>? HowSumBruteForce(int targetSum, List<int> arr)
        {
            if (targetSum == 0)
            {
                return new List<int>();
            }
            if (targetSum < 0)
            {
                return null;
            }

            foreach (var item in arr)
            {
                var remainder = targetSum - item;
                var result = HowSumBruteForce(remainder, arr);
                if (result != null)
                {
                    result.Add(item);
                    return result;
                }
            }

            return null;
        }

        /// <summary>
        /// m = targetSum
        /// n = numbers.Length
        /// 
        /// Time complexity: O(n*m^2)
        /// Space complexity: O(m^2)
        /// </summary>
        public List<int>? HowSumMemo(int targetSum, List<int> arr, Dictionary<int, List<int>?> memo)
        {
            if (memo.ContainsKey(targetSum))
            {
                return memo[targetSum];
            }
            if (targetSum == 0)
            {
                return new List<int>();
            }
            if (targetSum < 0)
            {
                return null;
            }

            foreach (var item in arr)
            {
                var remainder = targetSum - item;
                var result = HowSumMemo(remainder, arr, memo);
                if (result != null)
                {
                    result.Add(item);
                    memo[targetSum] = result;
                    return memo[targetSum];
                }
            }

            memo[targetSum] = null;
            return null;
        }

        /// <summary>
        /// m = targetSum
        /// n = numbers.Length
        /// 
        /// Time complexity: O(n*m^2)
        /// Space complexity: O(m^2)
        /// </summary>
        public List<int>? HowSumTab(int targetSum, List<int> arr)
        {
            var table = new List<int>?[targetSum + 1];
            table[0] = new List<int>();

            for (var i = 0; i <= targetSum; i++)
            {
                if (table[i] == null)
                {
                    continue;
                }

                foreach (var num in arr)
                {
                    var index = num + i;

                    if (index > targetSum)
                    {
                        continue;
                    }

                    table[index] = new List<int>(table[i]!) { num };

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
