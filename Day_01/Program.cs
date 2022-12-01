namespace Day_01;

/// <summary>
/// Day 1: Calorie Counting 
/// </summary>
public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine($"Day 01 of the Advent of Code!{Environment.NewLine}");

        await FirstSolution();
        await SecondSolution();
    }

    private static async Task FirstSolution()
    {
        Console.WriteLine("First Solution");

        Solution solution = new();
        int maxAmount = await solution.FindMaxAmount();
        int sumOfTopThree = await solution.FindSumOfTopThree();

        Console.WriteLine($"Max Amount: {maxAmount}");
        Console.WriteLine($"Sum of Top Three: {sumOfTopThree}");
        Console.WriteLine();
    }

    private static async Task SecondSolution()
    {
        Console.WriteLine("Second Solution");

        AdvancedSolution solutionAdvanced = new();
        await solutionAdvanced.Calculate();

        Console.WriteLine($"Max Amount: {solutionAdvanced.MaxAmount}");
        Console.WriteLine($"Sum of Top Three: {solutionAdvanced.SumOfTopThree}");
        Console.WriteLine();
    }
}
