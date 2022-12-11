namespace Day_11;

/// <summary>
/// Day 11: Monkey in the Middle
/// </summary>
public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine($"Day 11 of the Advent of Code!{Environment.NewLine}");

        await FirstSolution();
        await SecondSolution();
    }

    private static async Task FirstSolution()
    {
        Console.WriteLine("First Part");

        FirstPart solution = new();
        long levelOfMonkeyBusiness = await solution.Calculate();

        Console.WriteLine($"Level of Monkey Business After 20 Rounds of Stuff-Slinging Simian Shenanigans: {levelOfMonkeyBusiness}");
        Console.WriteLine();
    }

    private static async Task SecondSolution()
    {
        Console.WriteLine("Second Part");

        SecondPart solution = new();
        long levelOfMonkeyBusiness = await solution.Calculate();

        Console.WriteLine($"Level of Monkey Business After 10_000 Rounds: {levelOfMonkeyBusiness}");
        Console.WriteLine();
    }
}