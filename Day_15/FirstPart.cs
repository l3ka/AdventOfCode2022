namespace Day_15;

public class FirstPart
{
    private const long Y_COORDINATE = 2_000_000;
    private const string FILE_NAME = "Day15.txt";
    private readonly string PATH;

    public FirstPart()
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
        game.FindFreePositions(Y_COORDINATE);

        long numberOfPositions = game.GetNumberOfPosition();

        return numberOfPositions;
    }
}
