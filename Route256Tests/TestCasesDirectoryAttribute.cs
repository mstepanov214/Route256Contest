using System.Reflection;

namespace Route256Tests;

[AttributeUsage(AttributeTargets.Method)]
public class TestCasesDirectoryAttribute : Attribute, ITestDataSource
{
    private readonly string _path;

    public TestCasesDirectoryAttribute(string path)
    {
        _path = path;
    }

    public IEnumerable<object[]> GetData(MethodInfo methodInfo)
    {
        var files = Directory.EnumerateFiles(_path);

        if (!files.Any())
        {
            throw new ArgumentException($"Directory is empty: {_path}");
        }

        if (int.IsOddInteger(files.Count()))
        {
            throw new ArgumentException($"Odd number of files: {_path}");
        }

        return files.Chunk(2);
    }

    public string? GetDisplayName(MethodInfo methodInfo, object?[]? data)
    {
        return $"{methodInfo.Name}_{Path.GetFileName((string)data![0]!)}";
    }
}
