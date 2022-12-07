namespace Day_07;

/// <summary>
/// Day 7: No Space Left On Device
/// </summary>
public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine($"Day 07 of the Advent of Code!{Environment.NewLine}");

        await FirstSolution();
        await SecondSolution();
    }

    private static async Task FirstSolution()
    {
        Console.WriteLine("First Part");

        FirstPart solution = new();
        long sum = await solution.Calculate();

        Console.WriteLine($"Sum of the Total Sizes of Directories (size lower than 100_000): {sum}");
        Console.WriteLine();
    }

    private static async Task SecondSolution()
    {
        Console.WriteLine("Second Part");

        SecondPart solution = new();
        long sizeOfDirectoryToDelete = await solution.Calculate();

        Console.WriteLine($"Size of the Directory to Delete: {sizeOfDirectoryToDelete}");
        Console.WriteLine();
    }
}
