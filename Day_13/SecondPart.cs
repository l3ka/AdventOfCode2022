namespace Day_13;

public class SecondPart
{
    private const string FIRST_PAIR_TO_ADD = "[[2]]";
    private const string SECOND_PAIR_TO_ADD = "[[6]]";
    private const string FILE_NAME = "Day13.txt";
    private readonly string PATH;

    public SecondPart()
    {
        string projectRoot = AppContext.BaseDirectory[..AppContext.BaseDirectory.IndexOf("bin")];

        PATH = Path.Combine(projectRoot, FILE_NAME);
    }

    public async Task<long> Calculate()
    {
        string[] lines = await File.ReadAllLinesAsync(PATH);

        List<string> packets = lines.ToList();

        packets = packets.Where(packet => !string.IsNullOrWhiteSpace(packet)).ToList();
        packets.AddRange(new string[] { FIRST_PAIR_TO_ADD, SECOND_PAIR_TO_ADD });
        packets.Sort(new PacketData().CheckPacketOrder);

        int firstPairIndex = packets.IndexOf(FIRST_PAIR_TO_ADD) + 1;
        int secondPairIndex = packets.IndexOf(SECOND_PAIR_TO_ADD) + 1;

        int decoderKey = firstPairIndex * secondPairIndex;

        return decoderKey;
    }
}
