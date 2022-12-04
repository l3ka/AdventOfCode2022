namespace Day_04;

public class FirstPart
{
    private const string FILE_NAME = "Day04.txt";
    private readonly string PATH;

    public FirstPart()
    {
        string projectRoot = AppContext.BaseDirectory[..AppContext.BaseDirectory.IndexOf("bin")];

        PATH = Path.Combine(projectRoot, FILE_NAME);
    }

    public async Task<int> Calculate()
    {
        string[] lines = await File.ReadAllLinesAsync(PATH);

        int fullyContainRanges = 0;

        foreach (string line in lines)
        {
            string firstCleaningArea = line.Split(',')[0];
            string secondCleaningArea = line.Split(',')[1];

            int firstPairFirstNumber = int.Parse(firstCleaningArea.Split('-')[0]);
            int firstPairSecondNumber = int.Parse(firstCleaningArea.Split('-')[1]);

            int secondPairFirstNumber = int.Parse(secondCleaningArea.Split('-')[0]);
            int secondPairSecondNumber = int.Parse(secondCleaningArea.Split('-')[1]);

            if ((firstPairFirstNumber <= secondPairFirstNumber && firstPairSecondNumber >= secondPairSecondNumber) || 
                (secondPairFirstNumber <= firstPairFirstNumber && secondPairSecondNumber >= firstPairSecondNumber))
            {
                ++fullyContainRanges;
            }
        }

        return fullyContainRanges;
    }
}
