namespace DynamicProgramming
{
    /// <summary>
    /// Write a function 'canConstruct(target, wordBank)' that accepts a
    /// target string and an array of strings.
    ///
    /// The function should return a boolean indicating whether or not the
    /// 'target' can be constructed by concatenating elements of the
    /// 'wordBank' array.
    ///
    /// You may reuse elements of 'wordBank' as many times as needed.
    /// </summary>
    public class CanConstruct
    {
        /// <summary>
        /// m = target.Length
        /// n = wordBank.Length
        /// 
        /// Time complexity: O(n^m * m)
        /// Space complexity: O(m^2)
        /// </summary>
        public bool CanConstructBruteForce(string target, List<string> wordBank)
        {
            if (target == string.Empty)
            {
                return true;
            }

            foreach (var word in wordBank)
            {
                if (target.StartsWith(word))
                {
                    var suffix = target[word.Length..];
                    if (CanConstructBruteForce(suffix, wordBank))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// m = target.Length
        /// n = wordBank.Length
        /// 
        /// Time complexity: O(n*m^2)
        /// Space complexity: O(m^2)
        /// </summary>
        public bool CanConstructMemo(string target, List<string> wordBank, Dictionary<string, bool> memo)
        {
            if (memo.ContainsKey(target))
            {
                return memo[target];
            }
            if (target == string.Empty)
            {
                return true;
            }

            foreach (var word in wordBank)
            {
                if (target.StartsWith(word))
                {
                    var suffix = target[word.Length..];
                    if (CanConstructMemo(suffix, wordBank, memo))
                    {
                        memo[target] = true;
                        return true;
                    }
                }
            }

            memo[target] = false;
            return false;
        }

        /// <summary>
        /// m = target.Length
        /// n = wordBank.Length
        /// 
        /// Time complexity: O(n*m^2)
        /// Space complexity: O(m)
        /// </summary>
        public bool CanConstructTab(string target, List<string> wordBank)
        {
            var table = new bool[target.Length + 1];
            table[0] = true;
            
            for (var i = 0; i <= target.Length; i++)
            {
                if (!table[i])
                {
                    continue;
                }

                foreach (var word in wordBank)
                {
                    if (target.Substring(i).StartsWith(word))
                    {
                        table[i + word.Length] = true;
                    }
                }
            }

            return table[target.Length];
        }
    }
}
