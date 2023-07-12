using System.Linq;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

List<int> numbers = new List<int>();
for (int i = 0; i < 99; i++) numbers.Add(i);

IEnumerable<int> firsAndLastFive = numbers.Take(5).Concat(numbers.TakeLast(5));
foreach (int i in firsAndLastFive) Console.Write($"{i} ");

Console.WriteLine();
Console.WriteLine("=========================================================");

// The Sum method adds up all the values in the sequence and returnstheir sum.
Console.WriteLine("SUM : " + String.Join(", ", Enumerable.Range(1, 5).Sum()));

Console.WriteLine("AVERAGE : " + Enumerable.Range(1, 6).Average());
Console.WriteLine("MIN : " + new int[] { 3, 7, 9, 1, 10, 2, -3 }.Min());
Console.WriteLine("MAX : " + new int[] { 3, 7, 9, 1, 10, 2, -3 }.Max());
Console.WriteLine("COUNT : " + Enumerable.Range(10, 3721).Count());

// Range(5, 100) returns {100, 101, 102, 103,104}, and Last() gets the last number in that sequence.
Console.WriteLine("LAST : " + Enumerable.Range(5, 100).Last());

// Skip(4) skips the first 4 elements in the sequence, Sum adds them up
Console.WriteLine("SKIP / SUM : " + new int[] { 3, 8, 7, 6, 9, 6, 2 }.Skip(4).Sum());

// Range(10, 731) returned a sequence of 731 numbers starting with 10.
// Reverse does exactly what it sounds like—it reverses the order—so the last element in the reversed sequence is 10.
Console.WriteLine("REVERSE / LAST : " + Enumerable.Range(10, 731).Reverse().Last());

Console.WriteLine();
Console.WriteLine("=========================================================");
int[] values = new int[] { 0, 12, 44, 36, 92, 54, 13, 8 };
IEnumerable<int> result = from v in values where v > 37 orderby -v select v;
Console.WriteLine("request : " + String.Join(", ", result));