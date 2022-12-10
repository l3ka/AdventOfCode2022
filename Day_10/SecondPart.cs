namespace Day_10;

public class SecondPart
{
    private const string INSTRUCTION_NOOP = "noop";
    private const string INSTRUCTION_ADDX = "addx";

    private const string FILE_NAME = "Day10.txt";
    private readonly string PATH;

    public SecondPart()
    {
        string projectRoot = AppContext.BaseDirectory[..AppContext.BaseDirectory.IndexOf("bin")];

        PATH = Path.Combine(projectRoot, FILE_NAME);
    }

    public async Task<CRTScreen> Calculate()
    {
        string[] lines = await File.ReadAllLinesAsync(PATH);

        CRTScreen cRTScreen = new();

        foreach (string line in lines)
        {
            string instruction = line.Split(' ')[0];

            if (instruction == INSTRUCTION_NOOP)
            {
                cRTScreen.Draw();
                cRTScreen.IncrementCycle();
            }
            else if (instruction == INSTRUCTION_ADDX)
            {
                int signalStrength = int.Parse(line.Split(' ')[1]);

                cRTScreen.Draw();
                cRTScreen.IncrementCycle();

                cRTScreen.Draw();
                cRTScreen.IncrementCycle();

                cRTScreen.UpdateSprite(signalStrength);
            }
        }

        return cRTScreen;
    }
}