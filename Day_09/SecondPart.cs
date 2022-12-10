namespace Day_09;

public class SecondPart
{
    private const int NUMBER_OF_KNOTS = 10;

    private const string FILE_NAME = "Day09.txt";
    private readonly string PATH;

    public SecondPart()
    {
        string projectRoot = AppContext.BaseDirectory[..AppContext.BaseDirectory.IndexOf("bin")];

        PATH = Path.Combine(projectRoot, FILE_NAME);
    }

    public async Task<int> Calculate()
    {
        string[] lines = await File.ReadAllLinesAsync(PATH);

        HashSet<(int x, int y)> visited = new();
        visited.Add((0, 0));

        Rope rope = new(NUMBER_OF_KNOTS);

        foreach (string line in lines)
        {
            char direction = line.Split(' ')[0][0];
            int numberOfSteps = int.Parse(line.Split(" ")[1]);

            rope.Move(visited, direction, numberOfSteps);
        }

        int numberOfPosition = visited.Count;

        return numberOfPosition;
    }
}
