namespace Day_08;

public class SecondPart
{
    private const string FILE_NAME = "Day08.txt";
    private readonly string PATH;

    public SecondPart()
    {
        string projectRoot = AppContext.BaseDirectory[..AppContext.BaseDirectory.IndexOf("bin")];

        PATH = Path.Combine(projectRoot, FILE_NAME);
    }

    public async Task<int> Calculate()
    {
        string[] lines = await File.ReadAllLinesAsync(PATH);

        int[][] forest = CreateForest(lines);
        int maxScenicScore = 0;

        for (int row = 0; row < forest.Length; ++row)
        {
            for (int column = 0; column < forest[row].Length; ++column)
            {
                int scenicScore = CalculateScenicScore(forest, row, column);
                if (scenicScore > maxScenicScore)
                {
                    maxScenicScore = scenicScore;
                }
            }
        }

        return maxScenicScore;
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

    private static int CalculateScenicScore(int[][] forest, int row, int column) =>
        CalculateLeftScenic(forest, row, column) *
        CalculateRightScenic(forest, row, column) *
        CalculateTopScenic(forest, row, column) *
        CalculateBottomScenic(forest, row, column);

    private static int CalculateLeftScenic(int[][] forest, int row, int column)
    {
        int leftView = 0;
        for (int i = column - 1; i >= 0; --i)
        {
            if (forest[row][i] <= forest[row][column])
            {
                ++leftView;
            }
            if (forest[row][i] >= forest[row][column])
            {
                break;
            }
        }
        return leftView;
    }

    private static int CalculateRightScenic(int[][] forest, int row, int column)
    {
        int rightView = 0;
        for (int i = column + 1; i < forest[row].Length; ++i)
        {
            if (forest[row][i] <= forest[row][column])
            {
                ++rightView;
            }
            if (forest[row][i] >= forest[row][column])
            {
                break;
            }
        }
        return rightView;
    }

    private static int CalculateTopScenic(int[][] forest, int row, int column)
    {
        int topView = 0;
        for (int i = row - 1; i >= 0; --i)
        {
            if (forest[i][column] <= forest[row][column])
            {
                ++topView;
            }
            if (forest[i][column] >= forest[row][column])
            {
                break;
            }
        }
        return topView;
    }

    private static int CalculateBottomScenic(int[][] forest, int row, int column)
    {
        int bottomView = 0;
        for (int i = row + 1; i < forest.Length; ++i)
        {
            if (forest[i][column] <= forest[row][column])
            {
                ++bottomView;
            }
            if (forest[i][column] >= forest[row][column])
            {
                break;
            }
        }
        return bottomView;
    }
}
