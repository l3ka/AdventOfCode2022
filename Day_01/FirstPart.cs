namespace Day_01;

public class FirstPart
{
    private const string FILE_NAME = "Day01.txt";
    private readonly string PATH;

    public FirstPart()
    {
        string projectRoot = AppContext.BaseDirectory[..AppContext.BaseDirectory.IndexOf("bin")];

        PATH = Path.Combine(projectRoot, FILE_NAME);
    }

    public async Task<int> Calculate()
    {
        string[] lines = await File.ReadAllLinesAsync(PATH);

        int maxSum = 0;
        int sum = 0;

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                if (sum > maxSum)
                {
                    maxSum = sum;
                }
                sum = 0;
                continue;
            }
            sum += int.Parse(line);
        }

        return maxSum;
    }
}
