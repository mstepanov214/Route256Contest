using System.Text;

namespace Route256.Tasks;

public class RemoveDigitTask : IContestTask
{
    public void Run(TextReader input, TextWriter output)
    {
        int t = int.Parse(input.ReadLine()!);

        for (int i = 0; i < t; i++)
        {
            string s = input.ReadLine()!;

            if (s.Length == 1)
            {
                output.WriteLine(0);
                continue;
            }

            for (int j = 0; j < s.Length; j++)
            {
                if (j == s.Length - 1 || s[j] < s[j + 1])
                {
                    var sb = new StringBuilder(s.Length - 1);
                    sb.Append(s, 0, j);
                    sb.Append(s, j + 1, s.Length - j - 1);
                    output.WriteLine(sb.ToString());
                    break;
                }
            }
        }
    }
}
