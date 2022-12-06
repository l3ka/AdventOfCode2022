namespace Day_02;

public class SecondPart
{
    private const string ELFS_CHOICE_ROCK = "A";
    private const string ELFS_CHOICE_PAPER = "B";
    private const string ELFS_CHOICE_SCISOR = "C";

    private const string REQUIRED_OUTCOME_OF_ROUND_LOSE = "X";
    private const string REQUIRED_OUTCOME_OF_ROUND_DRAW = "Y";
    private const string REQUIRED_OUTCOME_OF_ROUND_WIN = "Z";

    private const int POINT_FOR_SHAPE_SELECTED_ROCK = 1;
    private const int POINT_FOR_SHAPE_SELECTED_PAPER = 2;
    private const int POINT_FOR_SHAPE_SELECTED_SCISSORS = 3;

    private const int POINT_FOR_OUTCOME_ROUND_WIN = 6;
    private const int POINT_FOR_OUTCOME_ROUND_DRAW = 3;
    private const int POINT_FOR_OUTCOME_ROUND_LOSE = 0;

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
            int pointsForOutcomeOfTheRound = 
                outcomeOfTheRound == REQUIRED_OUTCOME_OF_ROUND_LOSE ? POINT_FOR_OUTCOME_ROUND_LOSE : 
                outcomeOfTheRound == REQUIRED_OUTCOME_OF_ROUND_DRAW ? POINT_FOR_OUTCOME_ROUND_DRAW :
                POINT_FOR_OUTCOME_ROUND_WIN;

            if (elfsMove == ELFS_CHOICE_ROCK)
            {
                pointsForShapeSelected = outcomeOfTheRound switch
                {
                    REQUIRED_OUTCOME_OF_ROUND_LOSE => POINT_FOR_SHAPE_SELECTED_SCISSORS,
                    REQUIRED_OUTCOME_OF_ROUND_DRAW => POINT_FOR_SHAPE_SELECTED_ROCK,
                    REQUIRED_OUTCOME_OF_ROUND_WIN => POINT_FOR_SHAPE_SELECTED_PAPER,
                    _ => throw new NotSupportedException()
                };
            }
            else if (elfsMove == ELFS_CHOICE_PAPER)
            {
                pointsForShapeSelected = outcomeOfTheRound switch
                {
                    REQUIRED_OUTCOME_OF_ROUND_LOSE => POINT_FOR_SHAPE_SELECTED_ROCK,
                    REQUIRED_OUTCOME_OF_ROUND_DRAW => POINT_FOR_SHAPE_SELECTED_PAPER,
                    REQUIRED_OUTCOME_OF_ROUND_WIN => POINT_FOR_SHAPE_SELECTED_SCISSORS,
                    _ => throw new NotSupportedException()
                };
            }
            else if (elfsMove == ELFS_CHOICE_SCISOR)
            {
                pointsForShapeSelected = outcomeOfTheRound switch
                {
                    REQUIRED_OUTCOME_OF_ROUND_LOSE => POINT_FOR_SHAPE_SELECTED_PAPER,
                    REQUIRED_OUTCOME_OF_ROUND_DRAW => POINT_FOR_SHAPE_SELECTED_SCISSORS,
                    REQUIRED_OUTCOME_OF_ROUND_WIN => POINT_FOR_SHAPE_SELECTED_ROCK,
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
