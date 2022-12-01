namespace Day_01;

public  class Solution
{
    private const string FILE_NAME = "Day01.txt";
    private readonly string PATH;

    public Solution()
    {
        string projectRoot = AppContext.BaseDirectory[..AppContext.BaseDirectory.IndexOf("bin")];

        PATH = Path.Combine(projectRoot, FILE_NAME);
    }

    public async Task<int> FindMaxAmount()
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

    public async Task<int> FindSumOfTopThree()
    {
        string[] lines = await File.ReadAllLinesAsync(PATH);
        List<int> sums = new List<int>();
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
