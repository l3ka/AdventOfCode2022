namespace Day_15;

public class SecondPart
{
    private const long MIN_COORDINATE = 0;
    private const long MAX_COORDINATE = 4_000_000;
    private const string FILE_NAME = "Day15.txt";
    private readonly string PATH;

    public SecondPart()
    {
        string projectRoot = AppContext.BaseDirectory[..AppContext.BaseDirectory.IndexOf("bin")];

        PATH = Path.Combine(projectRoot, FILE_NAME);
    }

    public async Task<long> Calculate()
    {
        string[] lines = await File.ReadAllLinesAsync(PATH);

        Parser parser = new(lines);

        HashSet<Sensor> sensors = parser.GetMarkedLocations();

        BeaconExclusionZoneGame game = new(sensors);
        game.FindTuningFrequency(MIN_COORDINATE, MAX_COORDINATE);

        long tuningFrequency = game.GetTuningFrequency();

        return tuningFrequency;
    }
}
