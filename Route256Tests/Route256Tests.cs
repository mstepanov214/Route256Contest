using Route256.Tasks;
using Route256.Tasks.Main;
using Route256.Tasks.Training;

namespace Route256Tests;

[TestClass]
public class Route256Tests
{
    #region Training round

    [DataTestMethod, Timeout(1000)]
    [TestCasesDirectory("TestCases\\RemoveDigit")]
    public void RemoveDigitTest(string inputPath, string answerPath)
    {
        var task = new RemoveDigitTask();
        RunTest(inputPath, answerPath, task);
    }

    [DataTestMethod, Timeout(1000)]
    [TestCasesDirectory("TestCases\\ValidateOutput")]
    public void ValidateOutputTest(string inputPath, string answerPath)
    {
        var task = new ValidateOutputTask();
        RunTest(inputPath, answerPath, task);
    }

    [DataTestMethod, Timeout(1000)]
    [TestCasesDirectory("TestCases\\VirusFiles")]
    public void VirusFilesTest(string inputPath, string answerPath)
    {
        var task = new VirusFilesTask();
        RunTest(inputPath, answerPath, task);
    }

    [DataTestMethod, Timeout(3000)]
    [TestCasesDirectory("TestCases\\OrderPlanner")]
    public void OrderPlannerTest(string inputPath, string answerPath)
    {
        var task = new OrderPlannerTask();
        RunTest(inputPath, answerPath, task);
    }

    [DataTestMethod, Timeout(1000)]
    [TestCasesDirectory("TestCases\\AsciiRobots")]
    public void AsciiRobotsTest(string inputPath, string answerPath)
    {
        var task = new AsciiRobotsTask();
        RunTest(inputPath, answerPath, task);
    }

    #endregion

    #region Main round

    [DataTestMethod, Timeout(1000)]
    [TestCasesDirectory("TestCases\\DarkRoom")]
    public void DarkRoomTest(string inputPath, string answerPath)
    {
        var task = new DarkRoomTask();
        RunTest(inputPath, answerPath, task);
    }

    [DataTestMethod, Timeout(2000)]
    [TestCasesDirectory("TestCases\\ValidateProducts")]
    public void ValidateProductsTest(string inputPath, string answerPath)
    {
        var task = new ValidateProductsTask();
        RunTest(inputPath, answerPath, task);
    }

    [DataTestMethod, Timeout(2000)]
    [TestCasesDirectory("TestCases\\EvenStrings")]
    public void EvenStringsTest(string inputPath, string answerPath)
    {
        var task = new EvenStringsTask();
        RunTest(inputPath, answerPath, task);
    }

    [DataTestMethod, Timeout(2000)]
    [TestCasesDirectory("TestCases\\CompactBoxes")]
    public void CompactBoxesTest(string inputPath, string answerPath)
    {
        var task = new CompactBoxesTask();
        RunTest(inputPath, answerPath, task);
    }

    #endregion

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
