namespace DynamicProgramming
{
    /// <summary>
    /// Write a function 'bestSum(targetSum, numbers)' that takes in a
    /// targetSum and an array of numbers as arguments.
    ///
    /// The function should return an array containing the shortest
    /// combination of numbers that add up to exactly the targetSum.
    ///
    /// If there is a tie for the shortest combination, you may return any
    /// one of the shortest.
    /// </summary>
    public class BestSum
    {
        /// <summary>
        /// m = targetSum
        /// n = numbers.Length
        /// 
        /// Time complexity: O(n^m * m)
        /// Space complexity: O(m^2)
        /// </summary>
        public List<int>? BestSumBruteForce(int targetSum, List<int> arr)
        {
            if (targetSum == 0)
            {
                return new List<int>();
            }

            if (targetSum < 0)
            {
                return null;
            }

            List<int>? shortestResult = null;

            foreach (var item in arr)
            {
                var remainder = targetSum - item;
                var result = BestSumBruteForce(remainder, arr);
                if (result != null)
                {
                    result.Add(item);
                    if (shortestResult is null || shortestResult.Count > result.Count)
                    {
                        shortestResult = result;
                    }
                }
            }

            return shortestResult;
        }

        /// <summary>
        /// m = targetSum
        /// n = numbers.Length
        /// 
        /// Time complexity: O(n*m^2)
        /// Space complexity: O(m^2)
        /// </summary>
        public List<int>? BestSumMemo(int targetSum, List<int> numbers, Dictionary<int, List<int>?> memo)
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

            List<int>? shortestCombination = null;

            foreach (var num in numbers)
            {
                var remainder = targetSum - num;
                var remainderCombination = BestSumMemo(remainder, numbers, memo);
                if (remainderCombination != null)
                {
                    var combination = remainderCombination.ToList();
                    combination.Add(num);
                    if (shortestCombination is null || combination.Count < shortestCombination.Count)
                    {
                        shortestCombination = combination;
                    }
                }
            }

            memo[targetSum] = shortestCombination?.ToList();
            return shortestCombination;
        }

        /// <summary>
        /// Time complexity: O(n*m^2)
        /// Space complexity: O(m^2)
        /// </summary>
        public List<int>? BestSumTab(int targetSum, List<int> arr)
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

                    var combination = new List<int>(table[i]!) { num };

                    table[index] = table[index] is null || combination.Count < table[index]!.Count ? combination : table[index];
                }
            }

            return table[targetSum];
        }
    }
}
