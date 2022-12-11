namespace Day_11;

public static class Parser
{
    private static bool USE_RELIEF = true;

    public static List<Monkey> Parse(string[] lines, bool useRelief)
    {
        USE_RELIEF = useRelief;
        List<Monkey> monkeys = new();

        for (int i = 0; i < lines.Length; i += 7)
        {
            Queue<long> startingItems = ProcessStartingItems(lines[i + 1]);
            string operation = ProcessOperation(lines[i + 2]);
            int testValue = ProcessTestValue(lines[i + 3]);
            int[] throwToMonkey = ProcessThrowToMonkey(lines[i + 4], lines[i + 5]);

            Monkey monkey = new(startingItems, operation, testValue, throwToMonkey, USE_RELIEF);
            monkeys.Add(monkey);
        }

        return monkeys;
    }

    private static Queue<long> ProcessStartingItems(string line)
    {
        string[] numbers = line.Replace("Starting items: ", string.Empty).Replace(",", string.Empty).Trim().Split(' ');
        Queue<long> items = new();

        foreach (string number in numbers)
        {
            items.Enqueue(long.Parse(number));
        }

        return items;
    }

    private static string ProcessOperation(string line)
    {
        string[] operations = line.Replace("Operation: new = ", string.Empty).Trim().Split(' ');
        return string.Join(' ', operations);
    }

    private static int ProcessTestValue(string line)
    {
        string testValue = line.Replace("Test: divisible by ", string.Empty).Trim();
        return int.Parse(testValue);
    }

    private static int[] ProcessThrowToMonkey(string firstLine, string secondLine)
    {
        string firstMonkey = firstLine.Replace("If true: throw to monkey ", string.Empty).Trim();
        string secondMonkey = secondLine.Replace("If false: throw to monkey ", string.Empty).Trim();
        return new int[] { int.Parse(firstMonkey), int.Parse(secondMonkey) };
    }
}
