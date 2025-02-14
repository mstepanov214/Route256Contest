using Route256.Tasks;

namespace Route256Tests;

[TestClass]
public partial class Route256Tests
{
    private static void RunTest(string inputPath, string answerPath, IContestTask task)
    {
        string inputData = File.ReadAllText(inputPath);
        string expectedOutput = File.ReadAllText(answerPath);

        using var input = new StringReader(inputData);
        using var output = new StringWriter();

        task.Run(input, output);
        string result = output.ToString().ReplaceLineEndings("\n");

        Assert.AreEqual(expectedOutput, result);
    }
}
