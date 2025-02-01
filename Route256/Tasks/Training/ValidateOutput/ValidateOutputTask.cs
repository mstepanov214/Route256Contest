using System.Text;

namespace Route256.Tasks.Training;

public class ValidateOutputTask : IContestTask
{
    public void Run(TextReader input, TextWriter output)
    {
        int t = int.Parse(input.ReadLine()!);

        for (int i = 0; i < t; i++)
        {
            int n = int.Parse(input.ReadLine()!);
            string numbersInput = input.ReadLine()!;
            string resultInput = input.ReadLine()!;

            if (numbersInput.Length != resultInput.Length)
            {
                output.WriteLine("no");
                continue;
            }

            var numbers = numbersInput.Split(' ').Select(int.Parse);

            var sb = new StringBuilder();
            string expected = sb.AppendJoin(' ', numbers.Order()).ToString();

            output.WriteLine(expected == resultInput ? "yes" : "no");
        }
    }
}

