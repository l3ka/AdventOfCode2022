namespace Day_05;

public class SecondPart
{
    private const int NUMBER_OF_STACKS = 9;
    private const string FILE_NAME = "Day05.txt";
    private readonly string PATH;

    public SecondPart()
    {
        string projectRoot = AppContext.BaseDirectory[..AppContext.BaseDirectory.IndexOf("bin")];

        PATH = Path.Combine(projectRoot, FILE_NAME);
    }

    public async Task<string> Calculate()
    {
        string[] lines = await File.ReadAllLinesAsync(PATH);

        string crates = string.Empty;

        Stack<string>[] stacks = PrepareStacks(lines);
        Move(lines, stacks);

        foreach (var stack in stacks)
        {
            crates += stack.Pop();
        }

        return crates;
    }

    private static Stack<string>[] PrepareStacks(string[] lines)
    {
        Stack<string>[] stacks = new Stack<string>[NUMBER_OF_STACKS];
        for (int i = 0; i < NUMBER_OF_STACKS; ++i)
        {
            stacks[i] = new Stack<string>();
        }

        for (int index = 0; index < lines.Length; ++index)
        {
            if (string.IsNullOrWhiteSpace(lines[index]) || int.TryParse(lines[index].Trim()[0].ToString(), out int _))
            {
                break;
            }
            string[] parts = lines[index].Split(' ');
            for (int i = 0, j = 0; i < parts.Length; ++j)
            {
                if (!string.IsNullOrWhiteSpace(parts[i]))
                {
                    stacks[j].Push(parts[i][1].ToString());
                    ++i;
                }
                else
                {
                    i += 4;
                }
            }
        }

        ReverseStacks(stacks);

        return stacks;
    }

    private static void ReverseStacks(Stack<string>[] stacks)
    {
        for (int i = 0; i < stacks.Length; ++i)
        {
            Queue<string> helper = new();
            Stack<string> stack = stacks[i];

            while (stack.TryPeek(out string _))
            {
                helper.Enqueue(stack.Pop());
            }
            while (helper.TryPeek(out string _))
            {
                stack.Push(helper.Dequeue());
            }
        }
    }

    private static void Move(string[] lines, Stack<string>[] stacks)
    {
        int index = 0;
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                ++index;
                break;
            }
            ++index;
        }

        for (; index < lines.Length; ++index)
        {
            string[] parts = lines[index].Split(' ');

            int move = int.Parse(parts[1]);
            int from = int.Parse(parts[3]);
            int to = int.Parse(parts[5]);

            Stack<string> temp = new();
            for (int i = 0; i < move; ++i)
            {
                string value = stacks[from - 1].Pop();
                temp.Push(value);
            }
            for (int i = 0; i < move; ++i)
            {
                string value = temp.Pop();
                stacks[to - 1].Push(value);
            }
        }
    }
}
