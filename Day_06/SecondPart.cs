namespace Day_06;

public class SecondPart
{
    private const int START_OF_MESSAGE_LENGTH = 14;
    private const string FILE_NAME = "Day06.txt";
    private readonly string PATH;

    public SecondPart()
    {
        string projectRoot = AppContext.BaseDirectory[..AppContext.BaseDirectory.IndexOf("bin")];

        PATH = Path.Combine(projectRoot, FILE_NAME);
    }

    public async Task<int> Calculate()
    {
        string signal = await File.ReadAllTextAsync(PATH);
        HashSet<char> characters = new HashSet<char>();
        int startOfMessageIndex = 0;

        for (int i = 0, j = 0; i < signal.Length; )
        {
            if (!characters.Contains(signal[i]))
            {
                characters.Add(signal[i]);
                ++i;
            }
            else
            {
                characters.Remove(signal[j]);
                ++j;
            }

            if (characters.Count == START_OF_MESSAGE_LENGTH)
            {
                startOfMessageIndex = i;
                break;
            }
        }

        return startOfMessageIndex;
    }
}
