using Route256.Tasks;
using Route256Tests.Attributes;

namespace Route256Tests;

public partial class Route256Tests
{
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
}
