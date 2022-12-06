namespace Day_06;

public class FirstPart
{
    private const int START_OF_PACKET_LENGTH = 4;
    private const string FILE_NAME = "Day06.txt";
    private readonly string PATH;

    public FirstPart()
    {
        string projectRoot = AppContext.BaseDirectory[..AppContext.BaseDirectory.IndexOf("bin")];

        PATH = Path.Combine(projectRoot, FILE_NAME);
    }

    public async Task<int> Calculate()
    {
        string signal = await File.ReadAllTextAsync(PATH);
        HashSet<char> characters = new();
        int startOfPacketIndex = 0;

        for (int i = 0, j = 0; i < signal.Length; )
        {
            if (!characters.Contains(signal[i]))
            {
                characters.Add(signal[i]);
                ++i;

                if (characters.Count == START_OF_PACKET_LENGTH)
                {
                    startOfPacketIndex = i;
                    break;
                }
            }
            else
            {
                characters.Remove(signal[j]);
                ++j;
            }
        }

        return startOfPacketIndex;
    }
}
