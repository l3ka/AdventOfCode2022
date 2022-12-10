namespace Day_10;

public class FirstPart
{
    private const string INSTRUCTION_NOOP = "noop";
    private const string INSTRUCTION_ADDX = "addx";

    private readonly int[] signalCycles;

    private const string FILE_NAME = "Day10.txt";
    private readonly string PATH;

    public FirstPart()
    {
        string projectRoot = AppContext.BaseDirectory[..AppContext.BaseDirectory.IndexOf("bin")];

        PATH = Path.Combine(projectRoot, FILE_NAME);

        signalCycles = new int[] { 20, 60, 100, 140, 180, 220 };
    }

    public async Task<int> Calculate()
    {
        string[] lines = await File.ReadAllLinesAsync(PATH);

        int signalStrenghtsSum = 0;
        int cycle = 0;
        int register = 1;

        foreach (string line in lines)
        {
            string instruction = line.Split(' ')[0];

            if (instruction == INSTRUCTION_NOOP)
            {
                ++cycle;
                signalStrenghtsSum += CheckSignalCycle(cycle, register);
            }
            else if (instruction == INSTRUCTION_ADDX)
            {
                int signalStrength = int.Parse(line.Split(' ')[1]);

                ++cycle;
                signalStrenghtsSum += CheckSignalCycle(cycle, register);

                ++cycle;
                signalStrenghtsSum += CheckSignalCycle(cycle, register);

                register += signalStrength;
            }
        }

        return signalStrenghtsSum;
    }

    private int CheckSignalCycle(int cycle, int register) => signalCycles.Contains(cycle) ? cycle * register : 0;
}
