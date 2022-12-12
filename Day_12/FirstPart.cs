namespace Day_12;

public class FirstPart
{
    private const bool MULTIPLE_STARTS = false;
    private const string FILE_NAME = "Day12.txt";
    private readonly string PATH;

    public FirstPart()
    {
        string projectRoot = AppContext.BaseDirectory[..AppContext.BaseDirectory.IndexOf("bin")];

        PATH = Path.Combine(projectRoot, FILE_NAME);
    }

    public async Task<long> Calculate()
    {
        string[] lines = await File.ReadAllLinesAsync(PATH);

        Forest forest = new(lines, MULTIPLE_STARTS);

        int shortestRoute = int.MaxValue;

        foreach (int route in forest.FindRoutes())
        {
            if (route < shortestRoute)
            {
                shortestRoute = route;
            }
        }

        return shortestRoute;
    }
}
