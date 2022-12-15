namespace Day_14;

/// <summary>
/// Day 14: Regolith Reservoir
/// </summary>
public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine($"Day 14 of the Advent of Code!{Environment.NewLine}");

        await FirstSolution();
        await SecondSolution();
    }

    private static async Task FirstSolution()
    {
        Console.WriteLine("First Part");

        FirstPart solution = new();
        long unitsOfSandGrainsToRest = await solution.Calculate();

        Console.WriteLine($"Units of Sand that Come to Rest Before Sand Starts Flowing into the Abyss below: {unitsOfSandGrainsToRest}");
        Console.WriteLine();
    }

    private static async Task SecondSolution()
    {
        Console.WriteLine("Second Part");

        SecondPart solution = new();
        long unitsOfSandGrainsToRest = await solution.Calculate();

        Console.WriteLine($"Units of Sand that Come to Rest Before the Source of the Sand becomes blocked: {unitsOfSandGrainsToRest}");
        Console.WriteLine();
    }
}
