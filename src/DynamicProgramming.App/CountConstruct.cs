namespace DynamicProgramming
{
    /// <summary>
    /// Write a function 'countConstruct(target, wordBank)' that accepts a
    /// target string and an array of strings.
    ///
    /// The function should return the number of ways that the 'target' can
    /// be constructed by concatenating elements of the 'wordBank' array.
    ///
    /// You may reuse elements of 'wordBank' as many times as needed.
    /// </summary>
    public class CountConstruct
    {
        /// <summary>
        /// m = target.Length
        /// n = wordBank.Length
        /// 
        /// Time complexity: O(n^m * m)
        /// Space complexity: O(m^2)
        /// </summary>
        public int CountConstructBruteForce(string target, List<string> wordBank)
        {
            if (target == string.Empty)
            {
                return 1;
            }

            var counter = 0;

            foreach (var word in wordBank)
            {
                if (target.StartsWith(word))
                {
                    var suffix = target[word.Length..];
                    counter += CountConstructBruteForce(suffix, wordBank);
                }
            }

            return counter;
        }

        /// <summary>
        /// m = target.Length
        /// n = wordBank.Length
        /// 
        /// Time complexity: O(n*m^2)
        /// Space complexity: O(m^2)
        /// </summary>
        public int CountConstructMemo(string target, List<string> wordBank, Dictionary<string, int> memo)
        {
            if (memo.ContainsKey(target))
            {
                return memo[target];
            }
            if (target == string.Empty)
            {
                return 1;
            }

            var counter = 0;

            foreach (var word in wordBank)
            {
                if (target.StartsWith(word))
                {
                    var suffix = target[word.Length..];
                    counter += CountConstructMemo(suffix, wordBank, memo);
                }
            }

            memo[target] = counter;
            return counter;
        }

        /// <summary>
        /// m = target.Length
        /// n = wordBank.Length
        /// 
        /// Time complexity: O(n*m^2)
        /// Space complexity: O(m)
        /// </summary>
        public int CountConstructTab(string target, List<string> wordBank)
        {
            var table = new int[target.Length + 1];
            table[0] = 1;

            for (var i = 0; i <= target.Length; i++)
            {
                if (table[i] == 0)
                {
                    continue;
                }

                foreach (var word in wordBank)
                {
                    if (target.Substring(i).StartsWith(word))
                    {
                        table[i + word.Length] += table[i];
                    }
                }
            }

            return table[target.Length];
        }
    }
}
