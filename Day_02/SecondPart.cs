namespace Day_02;

public class SecondPart
{
    private const string ELFS_ROCK = "A";
    private const string ELFS_PAPER = "B";
    private const string ELFS_SCISOR = "C";

    private const string LOSE = "X";
    private const string DRAW = "Y";
    private const string WIN = "Z";

    private const string FILE_NAME = "Day02.txt";
    private readonly string PATH;

    public SecondPart()
    {
        string projectRoot = AppContext.BaseDirectory[..AppContext.BaseDirectory.IndexOf("bin")];

        PATH = Path.Combine(projectRoot, FILE_NAME);
    }

    public async Task<int> Calculate()
    {
        string[] lines = await File.ReadAllLinesAsync(PATH);

        int totalPoint = 0;

        foreach (var line in lines)
        {
            string elfsMove = line.Split(' ')[0];
            string outcomeOfTheRound = line.Split(' ')[1];

            int pointsForShapeSelected = 0;
            int pointsForOutcomeOfTheRound = outcomeOfTheRound == LOSE ? 0 : outcomeOfTheRound == DRAW ? 3 : 6;

            if (elfsMove == ELFS_ROCK)
            {
                pointsForShapeSelected = outcomeOfTheRound switch
                {
                    LOSE => 3,
                    DRAW => 1,
                    WIN => 2,
                    _ => throw new NotSupportedException()
                };
            }
            else if (elfsMove == ELFS_PAPER)
            {
                pointsForShapeSelected = outcomeOfTheRound switch
                {
                    LOSE => 1,
                    DRAW => 2,
                    WIN => 3,
                    _ => throw new NotSupportedException()
                };
            }
            else if (elfsMove == ELFS_SCISOR)
            {
                pointsForShapeSelected = outcomeOfTheRound switch
                {
                    LOSE => 2,
                    DRAW => 3,
                    WIN => 1,
                    _ => throw new NotSupportedException()
                };
            }
            else
            {
                throw new NotSupportedException();
            }

            totalPoint += pointsForShapeSelected + pointsForOutcomeOfTheRound;
        }

        return totalPoint;
    }
}
