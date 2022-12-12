namespace Day_12;

public class Forest
{
    private const char START_POSITION = 'S';
    private const char END_POSITION = 'E';

    private readonly bool multipleStarts;
    private readonly char[][] forest;
    private readonly List<Point> starts;
    private Point end;    

    public Forest(string[] lines, bool multipleStarts)
    {
        this.multipleStarts = multipleStarts;
        starts = new();
        forest = Createforest(lines);
    }

    public List<int> FindRoutes()
    {
        List<int> routes = new();

        foreach (var start in starts)
        {
            int route = FindRoute(start);
            if (route > 0)
            {
                routes.Add(route);
            }
        }

        return routes;
    }

    private int FindRoute(Point start)
    {
        HashSet<(int, int)> visited = new();
        Queue<Point> points = new();
        points.Enqueue(start);
        int costOfRoute = 0;

        while (points.Any())
        {
            Point point = points.Dequeue();

            if (!visited.Add((point.GetRow(), point.GetColumn())))
            {
                continue;
            }

            if (point.Equals(end))
            {
                costOfRoute = point.GetCounter();
                break;
            }

            List<Point> neighbors = FindNeighborsPoints(point);
            foreach (var neighbor in neighbors)
            {
                points.Enqueue(neighbor);
            }
        }

        return costOfRoute;
    }

    private List<Point> FindNeighborsPoints(Point point)
    {
        List<Point> neighbors = new();

        int row = point.GetRow();
        int column = point.GetColumn();
        int value = point.GetValue();
        int newCounter = point.GetCounter() + 1;

        // Look Up
        if (row > 0 && AtMostOnehigherElevation(forest[row - 1][column], value))
        {
            neighbors.Add(new Point(row - 1, column, forest[row - 1][column], newCounter));
        }

        // Look Down
        if (row < forest.Length - 1 && AtMostOnehigherElevation(forest[row + 1][column], value))
        {
            neighbors.Add(new Point(row + 1, column, forest[row + 1][column], newCounter));
        }

        // Look Left
        if (column > 0 && AtMostOnehigherElevation(forest[row][column - 1], value))
        {
            neighbors.Add(new Point(row, column - 1, forest[row][column - 1], newCounter));
        }

        // Look Right
        if (column < forest[row].Length - 1 && AtMostOnehigherElevation(forest[row][column + 1], value))
        {
            neighbors.Add(new Point(row, column + 1, forest[row][column + 1], newCounter));
        }

        return neighbors;
    }

    private static bool AtMostOnehigherElevation(int next, int current) => next - current <= 1; 

    private char[][] Createforest(string[] lines)
    {
        char[][] forest = new char[lines.Length][];
        for (int row = 0; row < lines.Length; ++row)
        {
            forest[row] = new char[lines[row].Length];
        }

        for (int row = 0; row < lines.Length; ++row)
        {
            for (int column = 0; column < lines[row].Length; ++column)
            {
                forest[row][column] = lines[row][column];

                if (forest[row][column] == START_POSITION || (multipleStarts && forest[row][column] == 'a'))
                {
                    starts.Add(new Point(row, column));

                }
                if (forest[row][column] == END_POSITION)
                {
                    end = new Point(row, column);
                }
            }
        }

        return forest;
    }
}
