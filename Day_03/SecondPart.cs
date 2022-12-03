namespace Day_03;

public class SecondPart
{
    private const string FILE_NAME = "Day03.txt";
    private readonly string PATH;

    public SecondPart()
    {
        string projectRoot = AppContext.BaseDirectory[..AppContext.BaseDirectory.IndexOf("bin")];

        PATH = Path.Combine(projectRoot, FILE_NAME);
    }

    public async Task<int> Calculate()
    {
        string[] lines = await File.ReadAllLinesAsync(PATH);

        int prioritySum = 0;

        for (int i = 0; i < lines.Length - 2; i += 3)
        {
            string firstWord = lines[i];
            string secondWord = lines[i + 1];
            string thirdWord = lines[i + 2];

            prioritySum += FindCommon(firstWord, secondWord, thirdWord);
        }

        return prioritySum;
    }

    private static int FindCommon(string firstWord, string secondWord, string thirdWord)
    {
        if (string.IsNullOrWhiteSpace(firstWord) && string.IsNullOrWhiteSpace(secondWord) && string.IsNullOrWhiteSpace(thirdWord))
        {
            return 0;
        }

        HashSet<char> firstCharacterSet = new();
        HashSet<char> secondCharacterSet = new();
        HashSet<char> thirdCharacterSet = new();

        foreach (var character in firstWord)
        {
            firstCharacterSet.Add(character);
        }
        foreach (var character in secondWord)
        {
            secondCharacterSet.Add(character);
        }
        foreach (var character in thirdWord)
        {
            thirdCharacterSet.Add(character);
        }

        char? commonCharacter = firstCharacterSet.Intersect(secondCharacterSet).Intersect(thirdCharacterSet).FirstOrDefault();
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
