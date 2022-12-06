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
        Console.WriteLine("First Part");

        FirstPart solution = new();
        int maxAmount = await solution.Calculate();

        Console.WriteLine($"Max Amount: {maxAmount}");
        Console.WriteLine();
    }

    private static async Task SecondSolution()
    {
        Console.WriteLine("Second Part");

        SecondPart solution = new();
        int sumOfTopThree = await solution.Calculate();

        Console.WriteLine($"Sum of Top Three: {sumOfTopThree}");
        Console.WriteLine();
    }
}
