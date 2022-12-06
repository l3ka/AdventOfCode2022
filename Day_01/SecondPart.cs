namespace Day_01;

public class SecondPart
{
    private const string FILE_NAME = "Day01.txt";
    private readonly string PATH;

    public SecondPart()
    {
        string projectRoot = AppContext.BaseDirectory[..AppContext.BaseDirectory.IndexOf("bin")];

        PATH = Path.Combine(projectRoot, FILE_NAME);
    }

    public async Task<int> Calculate()
    {
        string[] lines = await File.ReadAllLinesAsync(PATH);
        List<int> sums = new();
        int sum = 0;

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                sums.Add(sum);
                sum = 0;
                continue;
            }
            sum += int.Parse(line);
        }

        return sums.OrderByDescending(el => el).Take(3).Sum();
    }
}
