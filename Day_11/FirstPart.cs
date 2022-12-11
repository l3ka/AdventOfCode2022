namespace Day_11;

public class FirstPart
{
    private const int NUMBER_OF_ROUNDS = 20;
    private const bool USE_RELIEF = true;
    private const string FILE_NAME = "Day11.txt";
    private readonly string PATH;

    public FirstPart()
    {
        string projectRoot = AppContext.BaseDirectory[..AppContext.BaseDirectory.IndexOf("bin")];

        PATH = Path.Combine(projectRoot, FILE_NAME);
    }

    public async Task<long> Calculate()
    {
        string[] lines = await File.ReadAllLinesAsync(PATH);

        KeepAwayGame game = new(NUMBER_OF_ROUNDS);

        game.AddMonkeys(Parser.Parse(lines, USE_RELIEF));
        game.Play();
        long levelOfMonkeyBusiness = game.MonkeyLevelBusiness();

        return levelOfMonkeyBusiness;
    }
}