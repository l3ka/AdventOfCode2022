namespace Day_15;

/// <summary>
/// Day 15: Beacon Exclusion Zone
/// </summary>
public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine($"Day 15 of the Advent of Code!{Environment.NewLine}");

        await FirstSolution();
        await SecondSolution();
    }

    private static async Task FirstSolution()
    {
        Console.WriteLine("First Part");

        FirstPart solution = new();
        long numberOfPositions = await solution.Calculate();

        Console.WriteLine($"Number of Positions that cannot contain a beacon (In the row where y=2000000): {numberOfPositions}");
        Console.WriteLine();
    }

    private static async Task SecondSolution()
    {
        Console.WriteLine("Second Part");

        SecondPart solution = new();
        long tuningFrequency = await solution.Calculate();

        Console.WriteLine($"Tuning Frequency of the Distress Beacon: {tuningFrequency}");
        Console.WriteLine();
    }
}
