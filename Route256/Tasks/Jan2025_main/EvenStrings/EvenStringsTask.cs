using System.Text;

namespace Route256.Tasks;

public class EvenStringsTask : IContestTask
{
    public void Run(TextReader input, TextWriter output)
    {
        int t = int.Parse(input.ReadLine()!);

        for (int k = 0; k < t; k++)
        {
            int n = int.Parse(input.ReadLine()!);
            var words = new Dictionary<string, int>();
            var odds = new Dictionary<string, int>();
            var evens = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string word = input.ReadLine()!;
                (string odd, string even) = GetSubstrings(word);

                odds.TryAdd(odd, 0);
                odds[odd]++;

                if (word.Length > 1)
                {
                    evens.TryAdd(even, 0);
                    evens[even]++;
                    words.TryAdd(word, 0);
                    words[word]++;
                }
            }

            long oddPairsCount = odds.Values.Sum(CountPairs);
            long evenPairsCount = evens.Values.Sum(CountPairs);
            long equalPairsCount = words.Values.Sum(CountPairs);

            output.WriteLine(oddPairsCount + evenPairsCount - equalPairsCount);
        }
    }

    static long CountPairs(int N)
    {
        return N * (N - 1) / 2;
    }

    static (string, string) GetSubstrings(string str)
    {
        var sbOdd = new StringBuilder(str.Length / 2);
        var sbEven = new StringBuilder(str.Length / 2);

        for (int i = 0; i < str.Length; i++)
        {
            if (int.IsOddInteger(i + 1))
            {
                sbOdd.Append(str[i]);
            }
            else
            {
                sbEven.Append(str[i]);
            }
        }
        return (sbOdd.ToString(), sbEven.ToString());
    }
}
