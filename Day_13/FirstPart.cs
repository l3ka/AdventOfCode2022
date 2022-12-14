namespace Day_13;

public class FirstPart
{
    private const int RIGHT_ORDER = -1;

    private const string FILE_NAME = "Day13.txt";
    private readonly string PATH;

    public FirstPart()
    {
        string projectRoot = AppContext.BaseDirectory[..AppContext.BaseDirectory.IndexOf("bin")];

        PATH = Path.Combine(projectRoot, FILE_NAME);
    }

    public async Task<long> Calculate()
    {
        string[] lines = await File.ReadAllLinesAsync(PATH);

        List<int> indices = new();
        PacketData packetData = new();

        for (int i = 0, index = 1; i < lines.Length; i += 3, ++index)
        {
            string firstPair = lines[i];
            string secondPair = lines[i + 1];

            if (packetData.CheckPacketOrder(firstPair, secondPair) == RIGHT_ORDER)
            {
                indices.Add(index);
            }
        }

        int sumOfIndices = indices.Sum();

        return sumOfIndices;
    }
}
