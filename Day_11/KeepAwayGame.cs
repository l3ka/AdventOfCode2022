namespace Day_11;

public class KeepAwayGame
{
    private readonly int numberOfRoundsToSimulate;
    private readonly List<Monkey> monkeys;

    public KeepAwayGame(int numberOfRoundsToSimulate)
	{
        this.numberOfRoundsToSimulate = numberOfRoundsToSimulate;
        monkeys = new List<Monkey>();
    }

    public void Play()
    {
        SetLeastCommonMultiple();
        int round = 0;
        while (round < numberOfRoundsToSimulate)
        {
            for (int i = 0; i < monkeys.Count; i++)
            {
                Monkey monkey = monkeys[i];

                while (monkey.IsItemsExist())
                {
                    (long itemWithWorryLevel, int throwToMonkey) = monkey.Play();
                    ThrowItem(itemWithWorryLevel, throwToMonkey);
                }
            }
            ++round;
        }
    }

    public long MonkeyLevelBusiness()
    {
        long max1 = long.MinValue;
        long max2 = long.MinValue;

        for (int i = 0; i < monkeys.Count; i++)
        {
            Monkey monkey = monkeys[i];
            long numberOfInspections = monkey.GetNumberOfInspections();

            if (numberOfInspections > max1)
            {
                max2 = max1;
                max1 = numberOfInspections;
            }
            else if (numberOfInspections > max2)
            {
                max2 = numberOfInspections;
            }
        }

        return max1 * max2;
    }

    public void AddMonkeys(List<Monkey> monkeys) => this.monkeys.AddRange(monkeys);

    private void ThrowItem(long itemWithWorryLevel, int throwToMonkey) => monkeys[throwToMonkey].AddItem(itemWithWorryLevel);

    private void SetLeastCommonMultiple()
    {
        long[] divisibleByNumbers = monkeys.Select(el => el.GetDivisibleBy()).ToArray();
        long leastCommonMultiple = LeastCommonMultiple(divisibleByNumbers);
        for (int i = 0; i < monkeys.Count; i++)
        {
            Monkey monkey = monkeys[i];
            monkey.SetLeastCommonMultiple(leastCommonMultiple);
        }
    }

    private long LeastCommonMultiple(long[] numbers)
    {
        long result = 1;

        for (int i = 0; i < numbers.Length; ++i)
        {
            result *= numbers[i] / GreatestCommonDivisor(numbers[i], result);
        }

        return result;
    }

    private long GreatestCommonDivisor(long first, long second) => second == 0 ? first : GreatestCommonDivisor(second, first % second);
}
