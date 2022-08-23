// the codes in this project are based on this course: https://www.youtube.com/watch?v=oBt53YbR9Kk

#region Fibonacci
Console.WriteLine($"{nameof(Fibonacci)}:");

var fibonacci = new Fibonacci();
Console.WriteLine($"\tBrute force: {fibonacci.FibonacciBruteForce(8)}");
Console.WriteLine($"\tMemo: {fibonacci.FibonacciMemo(8, new Dictionary<int, long>())}");
Console.WriteLine($"\tTab: {fibonacci.FibonacciTab(8)}");

Console.WriteLine();
#endregion

#region GridTraveler
Console.WriteLine($"{nameof(GridTraveler)}:");

var gridTraveler = new GridTraveler();
Console.WriteLine($"\tBrute force: {gridTraveler.GridTravelerBruteForce(3, 2)}");
Console.WriteLine($"\tMemo: {gridTraveler.GridTravelerMemo(18, 18, new Dictionary<string, long>())}");
Console.WriteLine($"\tTab: {gridTraveler.GridTravelerTab(18, 18)}");

Console.WriteLine();
#endregion

#region CanSum
Console.WriteLine($"{nameof(CanSum)}:");

var canSum = new CanSum();
Console.WriteLine($"\tBrute force: {canSum.CanSumBruteForce(7, new []{ 2, 3, 6, 7 })}");
Console.WriteLine($"\tMemo: {canSum.CanSumMemo(300, new []{ 2, 3, 6, 7 }, new Dictionary<int, bool>())}");
Console.WriteLine($"\tTab: {canSum.CanSumTab(300, new []{ 2, 3, 6, 7 })}");

Console.WriteLine();
#endregion

#region HowSum
Console.WriteLine($"{nameof(HowSum)}:");

var howSum = new HowSum();
Console.Write("\tBrute force: ");
howSum.HowSumBruteForce(7, new List<int> { 3, 5, 2, 6 })?.ForEach(x => Console.Write($"{x}, "));
Console.WriteLine();
Console.Write("\tMemo: ");
howSum.HowSumMemo(7, new List<int> { 3, 5, 2, 6 }, new Dictionary<int, List<int>?>())?.ForEach(x => Console.Write($"{x}, "));
Console.WriteLine();
Console.Write("\tTab: ");
howSum.HowSumTab(301, new List<int> { 7, 14 })?.ForEach(x => Console.Write($"{x}, "));

Console.WriteLine();
Console.WriteLine();
#endregion

#region BestSum
Console.WriteLine($"{nameof(BestSum)}:");

var bestSum = new BestSum();
Console.Write("\tBrute force: ");
bestSum.BestSumBruteForce(8, new List<int> { 2, 3, 5 })?.ForEach(x => Console.Write($"{x}, "));
Console.WriteLine();
Console.Write("\tMemo: ");
bestSum.BestSumMemo(100, new List<int> { 1, 2, 5, 25 }, new Dictionary<int, List<int>?>())?.ForEach(x => Console.Write($"{x}, "));
Console.WriteLine();
Console.Write("\tTab: ");
bestSum.BestSumTab(100, new List<int> { 1, 2, 5, 25 })?.ForEach(x => Console.Write($"{x}, "));

Console.WriteLine();
Console.WriteLine();
#endregion

#region CanConstruct
Console.WriteLine($"{nameof(CanConstruct)}:");

var canConstruct = new CanConstruct();
Console.WriteLine($"\tBrute force: {canConstruct.CanConstructBruteForce("skateboard", new List<string>{ "bo", "rd", "ate", "t", "ska", "sk", "boar" })}");
Console.WriteLine($"\tMemo: {canConstruct.CanConstructMemo("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef", new List<string> { "ee", "eeee", "eeeee", "eeeeeeee", "eeeeeeeeeee", "eeeeeeeeeeeee", "eeeeeeeeeeeeeeeee" }, new Dictionary<string, bool>())}");
Console.WriteLine($"\tTab: {canConstruct.CanConstructTab("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef", new List<string> { "ee", "eeee", "eeeee", "eeeeeeee", "eeeeeeeeeee", "eeeeeeeeeeeee", "eeeeeeeeeeeeeeeee" })}");

Console.WriteLine();
#endregion

#region CountConstruct
Console.WriteLine($"{nameof(CountConstruct)}:");

var countConstruct = new CountConstruct();
Console.WriteLine($"\tBrute force: {countConstruct.CountConstructBruteForce("purple", new List<string> { "purp", "p", "ur", "le", "purpl" })}");
Console.WriteLine($"\tMemo: {countConstruct.CountConstructMemo("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef", new List<string> { "eef", "eeee", "eeeee", "eeeeeeee", "eeeeeeeeeee", "eeeeeeeeeeeee", "eeeeeeeeeeeeeeeee" }, new Dictionary<string, int>())}");
Console.WriteLine($"\tTab: {countConstruct.CountConstructTab("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef", new List<string> { "eef", "eeee", "eeeee", "eeeeeeee", "eeeeeeeeeee", "eeeeeeeeeeeee", "eeeeeeeeeeeeeeeee" })}");

Console.WriteLine();
#endregion

#region AllConstruct
Console.WriteLine($"{nameof(AllConstruct)}:");

var allConstruct = new AllConstruct();
Console.WriteLine("\tBrute force: ");
allConstruct.AllConstructBruteForce("abcdef", new List<string> { "ab", "abc", "cd", "def", "abcd", "ef", "c" }).ForEach(x =>
{
    Console.Write("\t\t");
    x?.ForEach(y => Console.Write($"{y}, "));
    Console.WriteLine();
});
Console.WriteLine("\tBrute force: ");
allConstruct.AllConstructBruteForce("skateboard", new List<string> { "sk", "bo", "ka", "ar", "eb" }).ForEach(x =>
{
    Console.Write("\t\t");
    x?.ForEach(y => Console.Write($"{y}, "));
    Console.WriteLine();
});
Console.WriteLine();
Console.WriteLine("\tMemo: ");
allConstruct.AllConstructMemo("abcdef", new List<string> { "ab", "abc", "cd", "def", "abcd", "ef", "c" }, new Dictionary<string, List<List<string>?>>()).ForEach(x =>
{
    Console.Write("\t\t");
    x?.ForEach(y => Console.Write($"{y}, "));
    Console.WriteLine();
});

Console.WriteLine("\tTab: ");
allConstruct.AllConstructTab("abcdef", new List<string> { "ab", "abc", "cd", "def", "abcd", "ef", "c" }).ForEach(x =>
{
    Console.Write("\t\t");
    x?.ForEach(y => Console.Write($"{y}, "));
    Console.WriteLine();
});

Console.WriteLine();
#endregion