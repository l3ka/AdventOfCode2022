namespace Day_09;

public class FirstPart
{
    private const char MOVE_UP = 'U';
    private const char MOVE_DOWN = 'D';
    private const char MOVE_LEFT = 'L';
    private const char MOVE_RIGHT = 'R';

    private const string FILE_NAME = "Day09.txt";
    private readonly string PATH;

    public FirstPart()
    {
        string projectRoot = AppContext.BaseDirectory[..AppContext.BaseDirectory.IndexOf("bin")];

        PATH = Path.Combine(projectRoot, FILE_NAME);
    }

    public async Task<int> Calculate()
    {
        string[] lines = await File.ReadAllLinesAsync(PATH);

        HashSet<(int x, int y)> visited = new();
        visited.Add((0, 0));

        Point head = new(0, 0);
        Point tail = new(0, 0);

        foreach (string line in lines)
        {
            char direction = line.Split(' ')[0][0];
            int numberOfSteps = int.Parse(line.Split(" ")[1]);

            Move(head, tail, visited, direction, numberOfSteps);
        }

        int numberOfPosition = visited.Count;

        return numberOfPosition;
    }

    private static void Move(Point head, Point tail, HashSet<(int x, int y)> visited, char direction, int numberOfSteps)
    {
        for (int i = 0; i < numberOfSteps; ++i)
        {
            Point previous = new(head.GetX(), head.GetY());

            if (direction == MOVE_UP)
            {
                head.MoveUp();
            }
            else if (direction == MOVE_DOWN)
            {
                head.MoveDown();
            }
            else if (direction == MOVE_LEFT)
            {
                head.MoveLeft();
            }
            else if (direction == MOVE_RIGHT)
            {
                head.MoveRight();
            }

            if (head.DistanceGreaterThanOne(tail))
            {
                tail.MoveToPoint(previous);
                visited.Add((tail.GetX(), tail.GetY()));
            }
        }
    }
}
