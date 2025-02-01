namespace Route256.Tasks.Main;

public class DarkRoomTask : IContestTask
{
    public void Run(TextReader input, TextWriter output)
    {
        int t = int.Parse(input.ReadLine()!);

        for (int k = 0; k < t; k++)
        {
            var inputArray = Array.ConvertAll(input.ReadLine()!.Split(' '), int.Parse);
            int n = inputArray[0];
            int m = inputArray[1];

            if (n == 1)
            {
                output.WriteLine(1);
                output.WriteLine("1 1 R");
            }
            else if (m == 1)
            {
                output.WriteLine(1);
                output.WriteLine("1 1 D");
            }
            else if (n == m)
            {
                output.WriteLine(2);
                output.WriteLine($"1 1 R\n{n} {m} L");
            }
            else if (n == 2)
            {
                output.WriteLine(2);
                output.WriteLine($"1 1 R\n2 1 R");
            }
            else if (m == 2)
            {
                output.WriteLine(2);
                output.WriteLine($"1 1 D\n1 2 D");
            }
            else if (Math.Abs(m - n) == 1)
            {
                output.WriteLine(2);
                output.WriteLine($"1 1 D\n{n} {m} U");
            }
            else if (m >= n)
            {
                output.WriteLine(2);
                output.WriteLine($"1 1 R\n1 2 D");
            }
            else if (n > m)
            {
                output.WriteLine(2);
                output.WriteLine($"1 1 D\n2 1 R");
            }
        }
    }
}
