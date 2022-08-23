namespace DynamicProgramming
{
    /// <summary>
    /// Say that you are a traveler on a 2D grid. You begin in the
    /// top-left corner and your goal is to travel to the bottom-right
    /// corner. You may only move down or right.
    ///
    /// On how many ways can you travel to the goal on a grid with dimensions m*n?
    ///
    /// Write a function 'gridTraveler(m, n)' that calculates this.
    /// </summary>
    public class GridTraveler
    {
        /// <summary>
        /// Time complexity: O(2^n+m)
        /// Space complexity: O(n+m)
        /// </summary>
        public int GridTravelerBruteForce(int m, int n)
        {
            if (m == 1 && n == 1)
            {
                return 1;
            }

            if (m == 0 || n == 0)
            {
                return 0;
            }

            return GridTravelerBruteForce(m - 1, n) + GridTravelerBruteForce(m, n - 1);
        }

        /// <summary>
        /// Time complexity: O(n*m)
        /// Space complexity: O(n+m)
        /// </summary>
        public long GridTravelerMemo(int m, int n, Dictionary<string, long> memo)
        {
            var key = $"{m}, {n}";
            if (memo.ContainsKey(key))
            {
                return memo[key];
            }

            if (m == 1 && n == 1)
            {
                return 1;
            }

            if (m == 0 || n == 0)
            {
                return 0;
            }

            var result = GridTravelerMemo(m - 1, n, memo) + GridTravelerMemo(m, n - 1, memo);
            memo[key] = result;
            return result;
        }

        /// <summary>
        /// Time complexity: O(n*m)
        /// Space complexity: O(n*m)
        /// </summary>
        public long GridTravelerTab(int m, int n)
        {
            var table = new long[m + 1, n + 1];
            table[1, 1] = 1;

            for (var i = 0; i <= m; i++)
            {
                var downIndex = i + 1;
                for (var j = 0; j <= n; j++)
                {
                    var currentElement = table[i, j];

                    if (currentElement <= 0) continue;

                    var rightIndex = j + 1;

                    if (rightIndex <= n)
                    {
                        table[i, rightIndex] += currentElement; // move right
                    }

                    if (downIndex <= m)
                    {
                        table[downIndex, j] += currentElement; // move down
                    }
                }
            }

            return table[m, n];
        }
    }
}
