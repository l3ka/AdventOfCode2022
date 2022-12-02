namespace Day_02;

/// <summary>
/// Day 2: Rock Paper Scissors
/// </summary>
public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine($"Day 02 of the Advent of Code!{Environment.NewLine}");

        await FirstSolution();
        await SecondSolution();
    }

    private static async Task FirstSolution()
    {
        Console.WriteLine("First Part");

        FirstPart solution = new();
        int totalPoints = await solution.Calculate();

        Console.WriteLine($"Total Points: {totalPoints}");
        Console.WriteLine();
    }

    private static async Task SecondSolution()
    {
        Console.WriteLine("Second Part");

        SecondPart solution = new();
        int totalPoints = await solution.Calculate();

        Console.WriteLine($"Total Points: {totalPoints}");
        Console.WriteLine();
    }
}
