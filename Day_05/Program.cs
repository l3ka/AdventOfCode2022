namespace Day_05;

/// <summary>
/// Day 5: Supply Stacks
/// </summary>
public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine($"Day 05 of the Advent of Code!{Environment.NewLine}");

        await FirstSolution();
        await SecondSolution();
    }

    private static async Task FirstSolution()
    {
        Console.WriteLine("First Part");

        FirstPart solution = new();
        string crates = await solution.Calculate();

        Console.WriteLine($"Crates: {crates}");
        Console.WriteLine();
    }

    private static async Task SecondSolution()
    {
        Console.WriteLine("Second Part");

        SecondPart solution = new();
        string crates = await solution.Calculate();

        Console.WriteLine($"Crates: {crates}");
        Console.WriteLine();
    }
}
