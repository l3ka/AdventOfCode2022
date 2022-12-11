namespace Day_11;

public class Monkey
{
    private readonly Queue<long> items;
    private readonly Operation operation;
    private readonly int divisibleBy;
    private readonly int[] throwToMonkey;
    private readonly bool useRelief;

    private long worryLevel;
    private long numberOfInspection;
    private long leastCommonMultiple;

    public Monkey(Queue<long> items, string operation, int divisibleBy, int[] throwToMonkey, bool useRelief)
	{
		this.items = new Queue<long>(items);
		this.operation = new Operation(operation);
		this.divisibleBy = divisibleBy;
		this.throwToMonkey = throwToMonkey;
        this.useRelief = useRelief;
    }

    public (long, int) Play()
    {
        Inspection();
        Operation();
        Relief();
        int throwToMonkey = Test();

        return (worryLevel, throwToMonkey);
    }

    public void AddItem(long item) => items.Enqueue(item);

    public bool IsItemsExist() => items.Any();

    public long GetNumberOfInspections() => numberOfInspection;

    public long GetDivisibleBy() => divisibleBy;

    public long SetLeastCommonMultiple(long leastCommonMultiple) => this.leastCommonMultiple = leastCommonMultiple;

    private void Inspection() => ++numberOfInspection;

    private void Operation()
    {
        worryLevel = items.Dequeue();
        worryLevel = operation.Execute(worryLevel);
    }

    private void Relief() => worryLevel = useRelief ? worryLevel / 3 : worryLevel % leastCommonMultiple;

    private int Test() => throwToMonkey[worryLevel % divisibleBy == 0 ? 0 : 1];
}
