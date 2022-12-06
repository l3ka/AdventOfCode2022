namespace Day_02;

public class FirstPart
{
    private const string ELFS_CHOICE_ROCK = "A";
    private const string ELFS_CHOICE_PAPER = "B";
    private const string ELFS_CHOICE_SCISOR = "C";

    private const string MY_CHOICE_ROCK = "X";
    private const string MY_CHOICE_PAPER = "Y";
    private const string MY_CHOICE_SCISOR = "Z";

    private const int POINT_FOR_SHAPE_SELECTED_ROCK = 1;
    private const int POINT_FOR_SHAPE_SELECTED_PAPER = 2;
    private const int POINT_FOR_SHAPE_SELECTED_SCISSORS = 3;

    private const int POINT_FOR_OUTCOME_ROUND_WIN = 6;
    private const int POINT_FOR_OUTCOME_ROUND_DRAW = 3;
    private const int POINT_FOR_OUTCOME_ROUND_LOSE = 0;

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

            int pointsForShapeSelected = 
                myMove == MY_CHOICE_ROCK ? POINT_FOR_SHAPE_SELECTED_ROCK : 
                myMove == MY_CHOICE_PAPER ? POINT_FOR_SHAPE_SELECTED_PAPER :
                POINT_FOR_SHAPE_SELECTED_SCISSORS;
            int pointsForOutcomeOfTheRound = 0;

            if (elfsMove == ELFS_CHOICE_ROCK)
            {
                pointsForOutcomeOfTheRound = myMove switch
                {
                    MY_CHOICE_ROCK => POINT_FOR_OUTCOME_ROUND_DRAW,
                    MY_CHOICE_PAPER => POINT_FOR_OUTCOME_ROUND_WIN,
                    MY_CHOICE_SCISOR => POINT_FOR_OUTCOME_ROUND_LOSE,
                    _ => throw new NotSupportedException()
                };
            }
            else if (elfsMove == ELFS_CHOICE_PAPER)
            {
                pointsForOutcomeOfTheRound = myMove switch
                {
                    MY_CHOICE_ROCK => POINT_FOR_OUTCOME_ROUND_LOSE,
                    MY_CHOICE_PAPER => POINT_FOR_OUTCOME_ROUND_DRAW,
                    MY_CHOICE_SCISOR => POINT_FOR_OUTCOME_ROUND_WIN,
                    _ => throw new NotSupportedException()
                };
            }
            else if (elfsMove == ELFS_CHOICE_SCISOR)
            {
                pointsForOutcomeOfTheRound = myMove switch
                {
                    MY_CHOICE_ROCK => POINT_FOR_OUTCOME_ROUND_WIN,
                    MY_CHOICE_PAPER => POINT_FOR_OUTCOME_ROUND_LOSE,
                    MY_CHOICE_SCISOR => POINT_FOR_OUTCOME_ROUND_DRAW,
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
