namespace Day_14;

public class SandTetris
{
    private readonly int minHorizontal = int.MaxValue;
    private readonly int maxHorizontal = int.MinValue;
    private readonly int maxDepth = int.MinValue;

    private int grainsOfSand;
    private readonly char[][] board;

    private Point START = new(500, 0);

    public SandTetris(string[] lines)
	{
        (minHorizontal, maxHorizontal, maxDepth) = FindDimensions(lines);
        board = CreateBoard();
        PopulateBoardWithRocks(lines);
	}
    
    public int GetNumberOfGrainsInRest() => grainsOfSand;

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
        board[START.Y][START.X - minHorizontal] = Point.SAND;

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
            if (nextPoint.X < minHorizontal || nextPoint.X > maxHorizontal || nextPoint.Y > maxDepth)
            {
                return false;
            }

            if (board[nextPoint.Y][nextPoint.X - minHorizontal] == Point.AIR)
            {
                return AddSandGrainToBoard(nextPoint);
            }
        }

        if (START.Equal(point))
        {
            return false;
        }

        board[point.Y][point.X - minHorizontal] = Point.SAND;
        return true;
    }

    private static (int, int, int) FindDimensions(string[] lines)
    {
        int minHorizontal = int.MaxValue;
        int maxHorizontal = int.MinValue;
        int maxDepth = int.MinValue;

        foreach (var line in lines)
        {
            string[] pairs = line.Split(" -> ");

            foreach (var pair in pairs)
            {
                int distanceToTheRight = int.Parse(pair.Split(',')[0]);
                int distanceDown = int.Parse(pair.Split(',')[1]);

                if (distanceDown > maxDepth)
                {
                    maxDepth = distanceDown;
                }
                if (distanceToTheRight < minHorizontal)
                {
                    minHorizontal = distanceToTheRight;
                }
                if (distanceToTheRight > maxHorizontal)
                {
                    maxHorizontal = distanceToTheRight;
                }
            }
        }

        return (minHorizontal, maxHorizontal, maxDepth);
    }

    private char[][] CreateBoard()
	{
        int numberOfColumns = maxHorizontal - minHorizontal + 1;
        char[][] board = new char[maxDepth + 1][];

		for (int i = 0; i < board.Length; i++)
		{
			board[i] = new char[numberOfColumns];
            for (int j = 0; j < board[i].Length; j++)
            {
                board[i][j] = Point.AIR;
            }
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
                    PopulateVerticalWithRocks(previousRow, currentRow, previousColumn - minHorizontal);
                }
                if (previousRow == currentRow)
                {
                    PopulateHorizontalWithRocks(previousRow, previousColumn - minHorizontal, currentColumn - minHorizontal);
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
