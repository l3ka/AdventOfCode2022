namespace Day_03;

/// <summary>
/// Day 3: Rucksack Reorganization
/// </summary>
public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine($"Day 03 of the Advent of Code!{Environment.NewLine}");

        await FirstSolution();
        await SecondSolution();
    }

    private static async Task FirstSolution()
    {
        Console.WriteLine("First Part");

        FirstPart solution = new();
        int prioritySum = await solution.Calculate();

        Console.WriteLine($"Priority Sum: {prioritySum}");
        Console.WriteLine();
    }

    private static async Task SecondSolution()
    {
        Console.WriteLine("Second Part");

        SecondPart solution = new();
        int priorityGroupSum = await solution.Calculate();

        Console.WriteLine($"Priority Group Sum: {priorityGroupSum}");
        Console.WriteLine();
    }
}
