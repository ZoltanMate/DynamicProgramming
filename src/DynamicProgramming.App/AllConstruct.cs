namespace DynamicProgramming
{
    /// <summary>
    /// Write a function 'allConstruct(target, wordBank)' that accepts a
    /// target string and an array of strings.
    ///
    /// The function should return a 2D array containing all of the ways
    /// that the 'target' can be constructed by concatenating elements of
    /// the 'wordBank' array. Each element of the 2D array should represent
    /// one combination that constructs the 'target'.
    ///
    /// You may reuse elements of 'wordBank' as many times as needed.
    /// </summary>
    public class AllConstruct
    {
        /// <summary>
        /// m = target.Length
        /// n = wordBank.Length
        /// 
        /// Time complexity: O(n^m)
        /// Space complexity: O(m)
        /// </summary>
        public List<List<string>?> AllConstructBruteForce(string target, List<string> wordBank)
        {
            if (target == string.Empty)
            {
                return new List<List<string>?>
                {
                    new()
                };
            }

            var result = new List<List<string>?>();

            foreach (var word in wordBank)
            {
                if (target.StartsWith(word))
                {
                    var suffix = target.Substring(word.Length);
                    var suffixWays = AllConstructBruteForce(suffix, wordBank);
                    var targetWays = new List<List<string>>();
                    foreach (var suffixWay in suffixWays)
                    {
                        if (suffixWay != null)
                        {
                            targetWays.Add(new List<string> { word }.Concat(suffixWay).ToList());
                        }
                    }

                    if (targetWays.Any())
                    {
                        result.AddRange(targetWays);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// m = target.Length
        /// n = wordBank.Length
        /// 
        /// Time complexity: O(n^m)
        /// Space complexity: O(m)
        /// </summary>
        public List<List<string>?> AllConstructMemo(string target, List<string> wordBank, Dictionary<string, List<List<string>?>> memo)
        {
            if (memo.ContainsKey(target))
            {
                return memo[target];
            }

            if (target == string.Empty)
            {
                return new List<List<string>?>
                {
                    new()
                };
            }

            var result = new List<List<string>?>();

            foreach (var word in wordBank)
            {
                if (target.StartsWith(word))
                {
                    var suffix = target.Substring(word.Length);
                    var suffixWays = AllConstructMemo(suffix, wordBank, memo);
                    var targetWays = new List<List<string>>();
                    foreach (var suffixWay in suffixWays)
                    {
                        if (suffixWay != null)
                        {
                            targetWays.Add(new List<string> { word }.Concat(suffixWay).ToList());
                        }
                    }

                    if (targetWays.Any())
                    {
                        result.AddRange(targetWays);
                    }
                }
            }

            memo[target] = result;
            return result;
        }

        /// <summary>
        /// m = target.Length
        /// n = wordBank.Length
        /// 
        /// Time complexity: O(n^m)
        /// Space complexity: O(n^m)
        /// </summary>
        public List<List<string>?> AllConstructTab(string target, List<string> wordBank)
        {
            var table = new List<List<string>?>[target.Length + 1];
            
            table[0] = new List<List<string>?>
            {
                new()
            };
            for (var i = 1; i < table.Length; i++)
            {
                table[i] = new List<List<string>?>();
            }

            for (var i = 0; i <= target.Length; i++)
            {
                if (table[i].All(x => x == null))
                {
                    continue;
                }

                foreach (var word in wordBank)
                {
                    if (target.Substring(i).StartsWith(word))
                    {
                        var newCombinations = table[i].Select(x => new List<string>(x!) { word }).ToList();
                        table[i + word.Length].AddRange(newCombinations);
                    }
                }
            }

            return table[target.Length];
        }
    }
}
