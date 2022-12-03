namespace Day_03;

public class FirstPart
{
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

        int priorityGroupSum = 0;

        foreach (string line in lines)
        {
            priorityGroupSum += FindCommon(line);
        }

        return priorityGroupSum;
    }

    private static int FindCommon(string word)
    {
        if (string.IsNullOrWhiteSpace(word))
        {
            return 0;
        }

        HashSet<char> firstPart = new();
        HashSet<char> secondPart = new();

        for (int i = 0; i < word.Length; i++)
        {
            if (i < word.Length  / 2)
            {
                firstPart.Add(word[i]);
            }
            else
            {
                secondPart.Add(word[i]);
            }
        }

        char? commonCharacter = firstPart.Intersect(secondPart).FirstOrDefault();
        int priority = 0;

        if (!commonCharacter.HasValue)
        {
            return 0;
        }
        else if (commonCharacter >= 'A' && commonCharacter <= 'Z')
        {
            priority = (int)(commonCharacter - 'A' + 27);
        }
        else if (commonCharacter >= 'a' && commonCharacter <= 'z')
        {
            priority = (int)(commonCharacter - 'a' + 1);
        }

        return priority;
    }
}
