namespace Route256Tests;

internal static class AssertExtensions
{
    public static void AreEqualLineByLine(this Assert _, TextReader expected, TextReader actual)
    {
        int lineNumber = 1;

        string? expectedLine;
        string? actualLine;

        while ((expectedLine = expected.ReadLine()) != null
            && (actualLine = actual.ReadLine()) != null)
        {
            Assert.AreEqual(
                expectedLine ?? "<EOF>",
                actualLine ?? "<EOF>",
                $"Difference at line {lineNumber}.");

            lineNumber++;
        }
    }
}