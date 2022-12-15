namespace Day_14;

public class SandTetrisNonScaled
{
    private readonly int maxDepth = int.MinValue;
    private readonly char[][] board;

    private Point START = new(500, 0);
    private int grainsOfSand;

    public SandTetrisNonScaled(string[] lines)
    {
        maxDepth = FindDimensions(lines);
        board = CreateBoard();
        PopulateBoardWithRocks(lines);
    }

    public int GetNumberOfGrainsInRest() => grainsOfSand + 1;

    public void PrintBoard()
    {
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                Console.Write(board[i][j]);
            }
            Console.WriteLine();
        }
    }

    public void Play(Point startPoint)
    {
        START = startPoint;
        board[START.Y][START.X] = Point.SAND;

        while (AddSandGrainToBoard(startPoint))
        {
            ++grainsOfSand;
        }
    }

    private bool AddSandGrainToBoard(Point point)
    {
        Point[] nextPoints = new[]
        {
            new Point(point.X, point.Y + 1),
            new Point(point.X - 1, point.Y + 1),
            new Point(point.X + 1, point.Y + 1)
        };

        foreach (var nextPoint in nextPoints)
        {
            if (board[nextPoint.Y][nextPoint.X] == Point.AIR && nextPoint.Y < maxDepth + 2)
            {
                return AddSandGrainToBoard(nextPoint);
            }
        }

        if (START.Equal(point))
        {
            return false;
        }

        board[point.Y][point.X] = Point.SAND;
        return true;
    }

    private static int FindDimensions(string[] lines)
    {
        int maxDepth = int.MinValue;
        foreach (var line in lines)
        {
            string[] pairs = line.Split(" -> ");

            foreach (var pair in pairs)
            {
                int distanceDown = int.Parse(pair.Split(',')[1]);

                if (distanceDown > maxDepth)
                {
                    maxDepth = distanceDown;
                }
            }
        }

        return maxDepth;
    }

    private char[][] CreateBoard()
    {
        int numberOfColumns = 4 * (maxDepth + 3);

        char[][] board = new char[maxDepth + 3][];
        for (int i = 0; i < board.Length; i++)
        {
            board[i] = new char[numberOfColumns];
            for (int j = 0; j < board[i].Length; j++)
            {
                board[i][j] = Point.AIR;
            }
        }
        for (int j = 0; j < board[0].Length; j++)
        {
            board[^1][j] = Point.ROCK;
        }

        return board;
    }

    private void PopulateBoardWithRocks(string[] lines)
    {
        foreach (var line in lines)
        {
            string[] pairs = line.Split(" -> ");

            int previousColumn = int.Parse(pairs[0].Split(',')[0]);
            int previousRow = int.Parse(pairs[0].Split(',')[1]);

            for (int i = 1; i < pairs.Length; ++i)
            {
                int currentColumn = int.Parse(pairs[i].Split(',')[0]);
                int currentRow = int.Parse(pairs[i].Split(',')[1]);

                if (previousColumn == currentColumn)
                {
                    PopulateVerticalWithRocks(previousRow, currentRow, previousColumn);
                }
                if (previousRow == currentRow)
                {
                    PopulateHorizontalWithRocks(previousRow, previousColumn, currentColumn);
                }

                previousColumn = currentColumn;
                previousRow = currentRow;
            }
        }
    }

    private void PopulateVerticalWithRocks(int fromRow, int toRow, int column)
    {
        int from = fromRow < toRow ? fromRow : toRow;
        int to = fromRow > toRow ? fromRow : toRow;

        for (; from <= to; ++from)
        {
            board[from][column] = Point.ROCK;
        }
    }

    private void PopulateHorizontalWithRocks(int row, int fromColumn, int toColumn)
    {
        int from = fromColumn < toColumn ? fromColumn : toColumn;
        int to = fromColumn > toColumn ? fromColumn : toColumn;

        for (; from <= to; ++from)
        {
            board[row][from] = Point.ROCK;
        }
    }
}
