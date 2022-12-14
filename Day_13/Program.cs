namespace Day_13;

/// <summary>
/// Day 13: Distress Signal
/// </summary>
public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine($"Day 13 of the Advent of Code!{Environment.NewLine}");

        await FirstSolution();
        await SecondSolution();
    }

    private static async Task FirstSolution()
    {
        Console.WriteLine("First Part");

        FirstPart solution = new();
        long sumOfIndices = await solution.Calculate();

        Console.WriteLine($"Sum of Indices of Parts that are in Right Order: {sumOfIndices}");
        Console.WriteLine();
    }

    private static async Task SecondSolution()
    {
        Console.WriteLine("Second Part");

        SecondPart solution = new();
        long decoderKey = await solution.Calculate();

        Console.WriteLine($"Decoder Key for the Distress Signal: {decoderKey}");
        Console.WriteLine();
    }
}

