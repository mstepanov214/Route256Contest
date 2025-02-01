/*
Рекомендуется использовать быстрый (буферизованный) ввод и вывод
using var input = new StreamReader(Console.OpenStandardInput());
using var output = new StreamWriter(Console.OpenStandardOutput());

var s = input.ReadLine().Split();
int a = int.Parse(s[0]);
int b = int.Parse(s[1]);
output.Write(a + b);
*/

using System.Text;
using Route256.Tasks.Training;

string inputStr = "3\r\n9\r\n0\r\n9123";

var stream = new MemoryStream(Encoding.UTF8.GetBytes(inputStr));
using var input = new StreamReader(stream);
using var output = new StreamWriter(Console.OpenStandardOutput());

var task = new RemoveDigitTask();
task.Run(input, output);
