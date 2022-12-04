namespace Day_04;

public class SecondPart
{
    private const string FILE_NAME = "Day04.txt";
    private readonly string PATH;

    public SecondPart()
    {
        string projectRoot = AppContext.BaseDirectory[..AppContext.BaseDirectory.IndexOf("bin")];

        PATH = Path.Combine(projectRoot, FILE_NAME);
    }

    public async Task<int> Calculate()
    {
        string[] lines = await File.ReadAllLinesAsync(PATH);

        int rangeOverlaps = 0;

        foreach (string line in lines)
        {
            string firstCleaningArea = line.Split(',')[0];
            string secondCleaningArea = line.Split(',')[1];

            int firstPairFirstNumber = int.Parse(firstCleaningArea.Split('-')[0]);
            int firstPairSecondNumber = int.Parse(firstCleaningArea.Split('-')[1]);

            int secondPairFirstNumber = int.Parse(secondCleaningArea.Split('-')[0]);
            int secondPairSecondNumber = int.Parse(secondCleaningArea.Split('-')[1]);

            if ((firstPairFirstNumber >= secondPairFirstNumber && firstPairFirstNumber <= secondPairSecondNumber) || 
                (firstPairSecondNumber >= secondPairFirstNumber && firstPairSecondNumber <= secondPairSecondNumber) || 
                (secondPairFirstNumber >= firstPairFirstNumber && secondPairFirstNumber <= firstPairSecondNumber) || 
                (secondPairSecondNumber >= firstPairFirstNumber && secondPairSecondNumber <= firstPairSecondNumber))
            {
                ++rangeOverlaps;
            }
        }

        return rangeOverlaps;
    }
}
