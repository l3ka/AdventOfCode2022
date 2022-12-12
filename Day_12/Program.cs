namespace Day_12;

/// <summary>
/// Day 12: Hill Climbing Algorithm
/// </summary>
public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine($"Day 12 of the Advent of Code!{Environment.NewLine}");

        await FirstSolution();
        await SecondSolution();
    }

    private static async Task FirstSolution()
    {
        Console.WriteLine("First Part");

        FirstPart solution = new();
        long numberOfSteps = await solution.Calculate();

        Console.WriteLine($"Number of Steps, from S to E: {numberOfSteps}");
        Console.WriteLine();
    }

    private static async Task SecondSolution()
    {
        Console.WriteLine("Second Part");

        SecondPart solution = new();
        long numberOfSteps = await solution.Calculate();

        Console.WriteLine($"Number of Steps, from any start (both S and a) to E: {numberOfSteps}");
        Console.WriteLine();
    }
}
