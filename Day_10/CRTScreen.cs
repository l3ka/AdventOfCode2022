namespace Day_10;

public class CRTScreen
{
    private const int CRT_SCREEN_WIDTH = 40;
    private const int CRT_SCREEN_HEIGHT = 6;

    private readonly char[][] crtScreen;
    
    private int cycle;
    private int sprite;

    public CRTScreen()
    {
        cycle = 0;
        sprite = 1;

        crtScreen = new char[CRT_SCREEN_HEIGHT][];
        for (int i = 0; i < crtScreen.Length; ++i)
        {
            crtScreen[i] = new char[CRT_SCREEN_WIDTH];
        }
    }

    public void Draw()
    {
        if (GetSprite().Contains(cycle % CRT_SCREEN_WIDTH))
        {
            crtScreen[cycle / CRT_SCREEN_WIDTH][cycle % CRT_SCREEN_WIDTH] = '#';
        }
        else
        {
            crtScreen[cycle / CRT_SCREEN_WIDTH][cycle % CRT_SCREEN_WIDTH] = '.';
        }
    }

    public int IncrementCycle() => ++cycle;

    public char[][] GetScreen() => crtScreen;

    public void UpdateSprite(int signalStrength) => sprite += signalStrength;

    public void PrintCRTScreen()
    {
        for (int row = 0; row < crtScreen.Length; ++row)
        {
            for (int col = 0; col < crtScreen[row].Length; ++col)
            {
                Console.Write(crtScreen[row][col]);
            }
            Console.WriteLine();
        }
    }

    private int[] GetSprite() => new int[] { sprite - 1, sprite, sprite + 1 };
}
