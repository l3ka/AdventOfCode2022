namespace Day_15;

public class Beacon
{
    private readonly Point point;

    public Beacon(Point point)
    {
        this.point = point;
    }

    public Point GetCoordinate() => point;
}
