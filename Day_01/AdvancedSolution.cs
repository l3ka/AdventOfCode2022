namespace Day_01;

public class AdvancedSolution
{
    private const string FILE_NAME = "Day01.txt";
    private readonly string PATH;

    public int MaxAmount { get; private set; }
    public int SumOfTopThree { get; private set; }

    public AdvancedSolution()
    {
        string projectRoot = AppContext.BaseDirectory[..AppContext.BaseDirectory.IndexOf("bin")];

        PATH = Path.Combine(projectRoot, FILE_NAME);
    }

    public async Task Calculate()
    {
        const int SUM_OF_TOP_THREE = 3;
        string[] lines = await File.ReadAllLinesAsync(PATH);
        List<int> sums = new();
        int sum = 0;
        int maxSum = 0;

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                if (sum > maxSum)
                {
                    maxSum = sum;
                }
                sums.Add(sum);
                sum = 0;
                continue;
            }
            sum += int.Parse(line);
        }

        SumOfTopThree = sums.OrderByDescending(el => el).Take(SUM_OF_TOP_THREE).Sum();
        MaxAmount = maxSum;
    }
}
