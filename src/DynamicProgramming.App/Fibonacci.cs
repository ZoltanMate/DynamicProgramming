namespace DynamicProgramming
{
    /// <summary>
    /// Write a function 'fib(n)' that takes in a number as an argument.
    /// The function should return the n-th number of the Fibonacci sequence.
    ///
    /// The 0th number of the sequence is 0.
    /// The 1st and 2nd number of the sequence is 1.
    /// 
    /// To generate the next number of the sequence, we sum the previous two.
    /// </summary>
    public class Fibonacci
    {
        /// <summary>
        /// Time complexity: O(2^n)
        /// Space complexity: O(n)
        /// </summary>
        public int FibonacciBruteForce(int n)
        {
            if (n <= 2) return 1;

            return FibonacciBruteForce(n - 1) + FibonacciBruteForce(n - 2);
        }

        /// <summary>
        /// Time complexity: O(n)
        /// Space complexity: O(n)
        /// </summary>
        public long FibonacciMemo(int n, IDictionary<int, long> memo)
        {
            if (memo.ContainsKey(n)) return memo[n];

            if (n <= 2) return 1;

            memo.Add(n, FibonacciMemo(n - 1, memo) + FibonacciMemo(n - 2, memo));

            return memo[n];
        }

        /// <summary>
        /// Time complexity: O(n)
        /// Space complexity: O(n)
        /// </summary>
        public long FibonacciTab(int n)
        {
            var table = new int[n + 1];
            table[1] = 1;

            for (var i = 0; i < n; i++)
            {
                table[i + 1] += table[i];
                if (i + 2 < table.Length)
                {
                    table[i + 2] += table[i];
                }
            }

            return table[n];
        }
    }
}
