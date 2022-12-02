namespace Day_02;

public class FirstPart
{
    private const string ELFS_ROCK = "A";
    private const string ELFS_PAPER = "B";
    private const string ELFS_SCISOR = "C";

    private const string MY_ROCK = "X";
    private const string MY_PAPER = "Y";
    private const string MY_SCISOR = "Z";

    private const string FILE_NAME = "Day02.txt";
    private readonly string PATH;

    public FirstPart()
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
            string myMove = line.Split(' ')[1];

            int pointsForShapeSelected = myMove == MY_ROCK ? 1 : myMove == MY_PAPER ? 2 : 3;
            int pointsForOutcomeOfTheRound = 0;

            if (elfsMove == ELFS_ROCK)
            {
                pointsForOutcomeOfTheRound = myMove switch
                {
                    MY_ROCK => 3,
                    MY_PAPER => 6,
                    MY_SCISOR => 0,
                    _ => throw new NotSupportedException()
                };
            }
            else if (elfsMove == ELFS_PAPER)
            {
                pointsForOutcomeOfTheRound = myMove switch
                {
                    MY_ROCK => 0,
                    MY_PAPER => 3,
                    MY_SCISOR => 6,
                    _ => throw new NotSupportedException()
                };
            }
            else if (elfsMove == ELFS_SCISOR)
            {
                pointsForOutcomeOfTheRound = myMove switch
                {
                    MY_ROCK => 6,
                    MY_PAPER => 0,
                    MY_SCISOR => 3,
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
