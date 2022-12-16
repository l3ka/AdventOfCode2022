namespace Day_15;

public class Point
{
    private readonly long x;
    private readonly long y;

    public Point(long x, long y)
    {
        this.x = x;
        this.y = y;
    }

    public long ManhattanDistance(Point other) => Math.Abs(x - other.x) + Math.Abs(y - other.y);

    public long GetX() => x;

    public long GetY() => y;
}
