namespace Day_03;

public class FirstPart
{
    private const char CHARACTER_UPPER_A = 'A';
    private const char CHARACTER_UPPER_Z = 'Z';
    private const char CHARACTER_LOWER_A = 'a';

    private const string FILE_NAME = "Day03.txt";
    private readonly string PATH;

    public FirstPart()
    {
        string projectRoot = AppContext.BaseDirectory[..AppContext.BaseDirectory.IndexOf("bin")];

        PATH = Path.Combine(projectRoot, FILE_NAME);
    }

    public async Task<int> Calculate()
    {
        string[] lines = await File.ReadAllLinesAsync(PATH);

        int prioritySum = 0;

        foreach (string line in lines)
        {
            prioritySum += CalculatePriority(line);
        }

        return prioritySum;
    }

    private static int CalculatePriority(string word)
    {
        if (string.IsNullOrWhiteSpace(word))
        {
            return 0;
        }

        HashSet<char> firstPart = new();
        HashSet<char> secondPart = new();

        for (int i = 0; i < word.Length; ++i)
        {
            if (i < word.Length / 2)
            {
                firstPart.Add(word[i]);
            }
            else
            {
                secondPart.Add(word[i]);
            }
        }

        char commonCharacter = firstPart.Intersect(secondPart).FirstOrDefault();

        return commonCharacter >= CHARACTER_UPPER_A && commonCharacter <= CHARACTER_UPPER_Z ?
            commonCharacter - CHARACTER_UPPER_A + 27 :
            commonCharacter - CHARACTER_LOWER_A + 1;
    }
}
