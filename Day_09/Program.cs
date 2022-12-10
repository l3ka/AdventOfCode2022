namespace Day_09;

/// <summary>
/// Day 9: Rope Bridge
/// </summary>
public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine($"Day 09 of the Advent of Code!{Environment.NewLine}");

        await FirstSolution();
        await SecondSolution();
    }

    private static async Task FirstSolution()
    {
        Console.WriteLine("First Part");

        FirstPart solution = new();
        int numberOfPosition = await solution.Calculate();

        Console.WriteLine($"Number of Position the tail od the Rope Visit at Least One (with 2 knots): {numberOfPosition}");
        Console.WriteLine();
    }

    private static async Task SecondSolution()
    {
        Console.WriteLine("Second Part");

        SecondPart solution = new();
        int numberOfPosition = await solution.Calculate();

        Console.WriteLine($"Number of Position the tail od the Rope Visit at Least One (with 10 knots): {numberOfPosition}");
        Console.WriteLine();
    }
}
