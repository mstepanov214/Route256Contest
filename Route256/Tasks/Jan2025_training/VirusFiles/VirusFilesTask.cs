using System.Text;
using System.Text.Json;

namespace Route256.Tasks;

public class VirusFilesTask : IContestTask
{
    public void Run(TextReader input, TextWriter output)
    {
        int t = int.Parse(input.ReadLine()!);

        for (int i = 0; i < t; i++)
        {
            int n = int.Parse(input.ReadLine()!);

            var sb = new StringBuilder();

            for (int j = 0; j < n; j++)
            {
                sb.Append(input.ReadLine()!);
            }

            JsonSerializerOptions options = new()
            {
                PropertyNameCaseInsensitive = true,
                MaxDepth = 1024
            };

            FolderNode root = JsonSerializer.Deserialize<FolderNode>(sb.ToString(), options)!;

            output.WriteLine(CountHackedFiles(root));
        }
    }

    static int CountHackedFiles(FolderNode node)
    {
        int count = 0;

        if (node.Files?.Any(file => file.EndsWith(".hack")) == true)
        {
            count += CountFiles(node);
        }
        else
        {
            count += node.Folders?.Sum(CountHackedFiles) ?? 0;
        }
        return count;
    }

    static int CountFiles(FolderNode node)
    {
        return (node.Files?.Count ?? 0) +
               (node.Folders?.Sum(CountFiles) ?? 0);
    }

    class FolderNode
    {
        public required string Dir { get; set; }
        public IList<string>? Files { get; set; }
        public IList<FolderNode>? Folders { get; set; }
    }
}