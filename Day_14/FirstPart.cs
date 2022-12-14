namespace Day_14;

public class FirstPart
{
    private const string FILE_NAME = "Day14.txt";
    private readonly string PATH;

    public FirstPart()
    {
        string projectRoot = AppContext.BaseDirectory[..AppContext.BaseDirectory.IndexOf("bin")];

        PATH = Path.Combine(projectRoot, FILE_NAME);
    }

    public async Task<long> Calculate()
    {
        string[] lines = await File.ReadAllLinesAsync(PATH);

        Point startPoint = new(500, 0);

        SandTetris sandTetris = new(lines);

        sandTetris.Play(startPoint);
        sandTetris.PrintBoard();
        int numberOfGrainsOfSandInRest = sandTetris.GetNumberOfGrainsInRest();
        
        return numberOfGrainsOfSandInRest;
    }
}
