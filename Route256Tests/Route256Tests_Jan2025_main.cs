using Route256.Tasks;
using Route256Tests.Attributes;

namespace Route256Tests;

public partial class Route256Tests
{
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
}
