namespace Day_09;

public class Point
{
    private int x;
    private int y;

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public int GetX() => x;

    public int GetY() => y;

    public void MoveUp() => ++y;

    public void MoveDown() => --y;

    public void MoveLeft() => --x;

    public void MoveRight() => ++x;

    public void MoveToPoint(Point point) => (x, y) = (point.x, point.y);

    public void MoveForPoint(Point point)
    {
        x += point.x;
        y += point.y;
    }

    public bool IsOnDifferentAxes(Point point) => x != point.x && y != point.y;

    public bool DistanceGreaterThanOne(Point other) => Math.Abs(other.x - x) > 1 || Math.Abs(other.y - y) > 1;
}
