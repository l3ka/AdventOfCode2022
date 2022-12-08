namespace Day_08;

/// <summary>
/// Day 8: Treetop Tree House
/// </summary>
public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine($"Day 08 of the Advent of Code!{Environment.NewLine}");

        await FirstSolution();
        await SecondSolution();
    }

    private static async Task FirstSolution()
    {
        Console.WriteLine("First Part");

        FirstPart solution = new();
        long numberOfVisibleTrees = await solution.Calculate();

        Console.WriteLine($"Number of Visible Tree: {numberOfVisibleTrees}");
        Console.WriteLine();
    }

    private static async Task SecondSolution()
    {
        Console.WriteLine("Second Part");

        SecondPart solution = new();
        long highestSceniceScore = await solution.Calculate();

        Console.WriteLine($"Highest Scenic Score: {highestSceniceScore}");
        Console.WriteLine();
    }
}
