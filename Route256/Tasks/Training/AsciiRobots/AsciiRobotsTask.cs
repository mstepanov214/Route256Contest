namespace Route256.Tasks.Training;

public class AsciiRobotsTask : IContestTask
{
    public void Run(TextReader input, TextWriter output)
    {
        int t = int.Parse(input.ReadLine()!);

        for (int k = 0; k < t; k++)
        {
            var size = input.ReadLine()!.Split(' ').Select(int.Parse).ToArray();
            int n = size[0];
            int m = size[1];

            var scheme = new List<char[]>();
            int xA = -1, yA = -1, xB = -1, yB = -1;

            for (int i = 0; i < n; i++)
            {
                string line = input.ReadLine()!;
                int indexA = line.IndexOf('A');
                if (indexA != -1)
                {
                    xA = indexA;
                    yA = i;
                }
                int indexB = line.IndexOf('B');
                if (indexB != -1)
                {
                    xB = indexB;
                    yB = i;
                }
                scheme.Add(line.ToCharArray());
            }

            if (yA < yB || yA == yB && xA < xB)
            {
                MoveTopLeft(scheme, 'A', xA, yA);
                MoveBotRight(scheme, 'B', xB, yB, n, m);
            }
            else
            {
                MoveTopLeft(scheme, 'B', xB, yB);
                MoveBotRight(scheme, 'A', xA, yA, n, m);
            }

            foreach (var line in scheme)
            {
                output.WriteLine(string.Concat(line));
            }
        }
    }

    static void MoveTopLeft(List<char[]> scheme, char c, int x, int y)
    {
        while (x > 0 || y > 0)
        {
            char left = x == 0 ? '#' : scheme[y][x - 1];
            char top = y == 0 ? '#' : scheme[y - 1][x];

            if (top != '#')
            {
                y--;
            }
            else if (left != '#')
            {
                x--;
            }
            scheme[y][x] = char.ToLower(c);
        }
    }

    static void MoveBotRight(List<char[]> scheme, char c, int x, int y, int n, int m)
    {
        while (x < m - 1 || y < n - 1)
        {
            char right = x == m - 1 ? '#' : scheme[y][x + 1];
            char bot = y == n - 1 ? '#' : scheme[y + 1][x];

            if (bot != '#')
            {
                y++;
            }
            else if (right != '#')
            {
                x++;
            }
            scheme[y][x] = char.ToLower(c);
        }
    }
}
