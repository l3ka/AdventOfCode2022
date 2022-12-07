namespace Day_07;

public class FirstPart
{
    private const long TRESHOLD = 100_000;
    private const string ROOT_DIRECTORY = "/";
    private const string COMMAND_CD = "$ cd";
    private const string COMMAND_LS = "$ ls";

    private const string FILE_NAME = "Day07.txt";
    private readonly string PATH;

    public FirstPart()
    {
        string projectRoot = AppContext.BaseDirectory[..AppContext.BaseDirectory.IndexOf("bin")];

        PATH = Path.Combine(projectRoot, FILE_NAME);
    }

    public async Task<long> Calculate()
    {
        string[] lines = await System.IO.File.ReadAllLinesAsync(PATH);

        Directory? currentDirectory = new(ROOT_DIRECTORY, 0);

        for (int i = 1; i < lines.Length; ++i)
        {
            if (lines[i].StartsWith(COMMAND_CD))
            {
                string directoryName = lines[i].Split(' ')[2];

                currentDirectory = directoryName.Contains("..") ?
                    currentDirectory?.GetParent() :
                    currentDirectory?.GetSubDirectoryByName(directoryName);
            }
            else if (lines[i].StartsWith(COMMAND_LS))
            {
                continue;
            }
            else
            {
                if (lines[i].StartsWith("dir"))
                {
                    string directoryName = lines[i].Split(' ')[1];
                    Directory directory = new(directoryName, 0, currentDirectory);
                    currentDirectory?.AddSubDirectory(directory);
                }
                else if (int.TryParse(lines[i].Split(' ')[0], out int fileSize))
                {
                    string fileName = lines[i].Split(' ')[1];
                    currentDirectory?.AddFile(new File(fileName, fileSize));
                }
            }
        }

        Directory? root = currentDirectory?.GetRoot();

        return root?.CalculateSum(TRESHOLD) ?? 0;
    }
}
