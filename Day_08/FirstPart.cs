namespace Day_08;

public class FirstPart
{
    private const string FILE_NAME = "Day08.txt";
    private readonly string PATH;

    public FirstPart()
    {
        string projectRoot = AppContext.BaseDirectory[..AppContext.BaseDirectory.IndexOf("bin")];

        PATH = Path.Combine(projectRoot, FILE_NAME);
    }

    public async Task<int> Calculate()
    {
        string[] lines = await File.ReadAllLinesAsync(PATH);
        int numberOfVisibleTrees = 0;

        int[][] forest = CreateForest(lines);

        for (int row = 0; row < forest.Length; ++row)
        {
            for (int column = 0; column < forest[row].Length; ++column)
            {
                if (CheckVisibilities(forest, row, column))
                {
                    ++numberOfVisibleTrees;
                }
            }
        }

        return numberOfVisibleTrees;
    }

    private static int[][] CreateForest(string[] lines)
    {
        int[][] forest = new int[lines.Length][];

        for (int row = 0; row < lines.Length; ++row)
        {
            forest[row] = new int[lines[row].Length];
            for (int column = 0; column < lines[row].Length; ++column)
            {
                forest[row][column] = int.Parse(lines[row][column].ToString());
            }
        }

        return forest;
    }

    private static bool CheckVisibilities(int[][] forest, int row, int column)
    {
        if (row == 0 || row == forest.Length - 1 || column == 0 || column == forest[row].Length - 1)
        {
            return true;
        }

        return CheckLeft(forest, row, column) || 
            CheckRight(forest, row, column) ||
            CheckTop(forest, row, column) ||
            CheckBottom(forest, row, column);
    }

    private static bool CheckLeft(int[][] forest, int row, int column)
    {
        for (int i = 0; i < column; ++i)
        {
            if (forest[row][i] >= forest[row][column])
            {
                return false;
            }
        }

        return true;
    }

    private static bool CheckRight(int[][] forest, int row, int column)
    {
        for (int i = column + 1; i < forest[row].Length; ++i)
        {
            if (forest[row][i] >= forest[row][column])
            {
                return false;
            }
        }

        return true;
    }

    private static bool CheckTop(int[][] forest, int row, int column)
    {
        for (int i = 0; i < row; ++i)
        {
            if (forest[i][column] >= forest[row][column])
            {
                return false;
            }
        }

        return true;
    }

    private static bool CheckBottom(int[][] forest, int row, int column)
    {
        for (int i = row + 1; i < forest.Length; ++i)
        {
            if (forest[i][column] >= forest[row][column])
            {
                return false;
            }
        }

        return true;
    }
}
