namespace Day_10;

/// <summary>
/// Day 10: Cathode-Ray Tube
/// </summary>
public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine($"Day 10 of the Advent of Code!{Environment.NewLine}");

        await FirstSolution();
        await SecondSolution();
    }

    private static async Task FirstSolution()
    {
        Console.WriteLine("First Part");

        FirstPart solution = new();
        int signalStrenghtsSum = await solution.Calculate();

        Console.WriteLine($"Sum of Six Signal Strenghts: {signalStrenghtsSum}");
        Console.WriteLine();
    }

    private static async Task SecondSolution()
    {
        Console.WriteLine("Second Part");

        SecondPart solution = new();
        CRTScreen crtScreen = await solution.Calculate();

        Console.WriteLine($"CRT Screen: ");
        crtScreen.PrintCRTScreen();
        Console.WriteLine();
    }
}
