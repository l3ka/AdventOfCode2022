namespace Day_03;

public class SecondPart
{
    private const char CHARACTER_UPPER_A = 'A';
    private const char CHARACTER_UPPER_Z = 'Z';
    private const char CHARACTER_LOWER_A = 'a';

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

        int priorityGroupSum = 0;

        for (int i = 0; i < lines.Length - 2; i += 3)
        {
            priorityGroupSum += CalculatePriority(lines[i], lines[i + 1], lines[i + 2]);
        }

        return priorityGroupSum;
    }

    private static int CalculatePriority(string firstWord, string secondWord, string thirdWord)
    {
        HashSet<char> firstCharacterSet = CreateCharacterHashSet(firstWord);
        HashSet<char> secondCharacterSet = CreateCharacterHashSet(secondWord);
        HashSet<char> thirdCharacterSet = CreateCharacterHashSet(thirdWord);

        char commonCharacter = firstCharacterSet
            .Intersect(secondCharacterSet)
            .Intersect(thirdCharacterSet)
            .FirstOrDefault();

        return commonCharacter >= CHARACTER_UPPER_A && commonCharacter <= CHARACTER_UPPER_Z ?
            commonCharacter - CHARACTER_UPPER_A + 27 :
            commonCharacter - CHARACTER_LOWER_A + 1;
    }

    private static HashSet<char> CreateCharacterHashSet(string word)
    {
        HashSet<char> characterSet = new();

        foreach (var character in word)
        {
            characterSet.Add(character);
        }
        
        return characterSet;
    }
}
