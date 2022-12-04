namespace Day_04;

/// <summary>
/// Day 4: Camp Cleanup
/// </summary>
public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine($"Day 04 of the Advent of Code!{Environment.NewLine}");

        await FirstSolution();
        await SecondSolution();
    }

    private static async Task FirstSolution()
    {
        Console.WriteLine("First Part");

        FirstPart solution = new();
        int fullyContainRanges = await solution.Calculate();

        Console.WriteLine($"Fully Contain Ranges: {fullyContainRanges}");
        Console.WriteLine();
    }

    private static async Task SecondSolution()
    {
        Console.WriteLine("Second Part");

        SecondPart solution = new();
        int rangeOverlaps = await solution.Calculate();

        Console.WriteLine($"Range Overlaps: {rangeOverlaps}");
        Console.WriteLine();
    }
}
