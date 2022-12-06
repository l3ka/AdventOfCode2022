namespace Day_06;

/// <summary>
/// Day 6: Tuning Trouble
/// </summary>
public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine($"Day 06 of the Advent of Code!{Environment.NewLine}");

        await FirstSolution();
        await SecondSolution();
    }

    private static async Task FirstSolution()
    {
        Console.WriteLine("First Part");

        FirstPart solution = new();
        int startOfPacketIndex = await solution.Calculate();

        Console.WriteLine($"Start of Packet Marker: {startOfPacketIndex}");
        Console.WriteLine();
    }

    private static async Task SecondSolution()
    {
        Console.WriteLine("Second Part");

        SecondPart solution = new();
        int startOfMessageIndex = await solution.Calculate();

        Console.WriteLine($"Start of Message Marker: {startOfMessageIndex}");
        Console.WriteLine();
    }
}
