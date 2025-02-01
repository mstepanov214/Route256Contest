using System.Text.Json;

namespace Route256.Tasks.Main;

public class CompactBoxesTask : IContestTask
{
    Dictionary<(int i, int j), int> visited = new();

    public void Run(TextReader input, TextWriter output)
    {
        int t = int.Parse(input.ReadLine()!);
        var pile = new List<Dictionary<string, object>>();

        for (int k = 0; k < t; k++)
        {
            var inputArray = Array.ConvertAll(input.ReadLine()!.Split(' '), int.Parse);
            int n = inputArray[0];
            int m = inputArray[1];

            var matrix = new List<List<char>>();

            for (int i = 0; i < n; i++)
            {
                matrix.Add(input.ReadLine()!.ToList());
            }

            var boxes = new Dictionary<string, object>();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    SkipRangeIfVisited(i, ref j);

                    if (IsTopLeft(i, j, matrix))
                    {
                        var box = GetBox(i, j, matrix);
                        boxes.Merge(box);
                    }
                }
            }

            pile.Add(boxes.OrderByKeys());
            visited.Clear();
        }

        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            MaxDepth = 1024
        };
        string json = JsonSerializer.Serialize(pile, options);

        output.WriteLine(json);
    }

    Dictionary<string, object> GetBox(int i, int j, List<List<char>> matrix)
    {
        string no = GetNumber(i, j, matrix);
        (int height, int width) = GetSize(i, j, matrix);

        var box = CreateEmptyBox(no, height, width);
        var nestedBoxes = new Dictionary<string, object>();

        for (int x = i + 1; x < i + height - 1; x++)
        {
            visited.Add((x - 1, j), width);

            for (int y = j + 1; y < j + width - 1; y++)
            {
                SkipRangeIfVisited(x, ref y);

                if (IsTopLeft(x, y, matrix))
                {
                    var nestedBox = GetBox(x, y, matrix);
                    nestedBoxes.Merge(nestedBox);
                }
            }
        }
        if (nestedBoxes.Count > 0)
        {
            box[no] = nestedBoxes;
        }
        return box;
    }

    static bool IsTopLeft(int i, int j, List<List<char>> matrix)
    {
        return i < matrix.Count - 1
            && j < matrix[i].Count - 1
            && matrix[i][j] == '+'
            && matrix[i][j + 1] == '-'
            && matrix[i + 1][j] == '|';
    }

    static string GetNumber(int i, int j, List<List<char>> matrix)
    {
        i++;
        j++;
        string result = string.Empty;
        while (char.IsAsciiLetterOrDigit(matrix[i][j]))
        {
            result += matrix[i][j++];
        }
        return result;
    }

    static (int, int) GetSize(int i, int j, List<List<char>> matrix)
    {
        int row = i + 1;
        int col = j + 1;

        while (true)
        {
            if (matrix[i][col] == '-')
            {
                col++;
            }
            if (matrix[row][j] == '|')
            {
                row++;
            }
            if (matrix[i][col] == '+' && matrix[row][j] == '+')
            {
                break;
            }
        }
        return (row + 1 - i, col + 1 - j);
    }

    static Dictionary<string, object> CreateEmptyBox(string no, int height, int width)
    {
        return new Dictionary<string, object>
        {
            { no, (width - 2) * (height - 2) }
        };
    }

    void SkipRangeIfVisited(int i, ref int j)
    {
        while (visited.ContainsKey((i, j)))
        {
            j += visited[(i, j)];
        }
    }
}

static class DictionaryExtensions
{
    public static void Merge(this Dictionary<string, object> seed, Dictionary<string, object> other)
    {
        foreach (var obj in other)
        {
            seed[obj.Key] = obj.Value;
        }
    }

    public static Dictionary<string, object> OrderByKeys(this Dictionary<string, object> dictionary)
    {
        return dictionary
            .OrderBy(obj => obj.Key, StringComparer.Ordinal)
            .ToDictionary(
                obj => obj.Key,
                obj => obj.Value is Dictionary<string, object> dict
                    ? dict.OrderByKeys()
                    : obj.Value);
    }
}
