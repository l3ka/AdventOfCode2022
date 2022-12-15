namespace Day_14;

public class Point
{
    public const char ROCK = '#';
    public const char AIR = '.';
    public const char SAND = '+';

    public int X { get; set; }

    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public bool Equal(Point other) => X == other.X && Y == other.Y;
}
