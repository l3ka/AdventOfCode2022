namespace Day_15;

public class Sensor
{
    private readonly Point point;
    private readonly Beacon beacon;
    private readonly long Range;

    public Sensor(Point point, Beacon beacon)
    {
        this.point = point;
        this.beacon = beacon;
        Range = point.ManhattanDistance(beacon.GetCoordinate());
    }

    public Point GetCoordinate() => point;

    public Beacon GetClosestBeacon() => beacon;

    public bool CrossContain(long yCoordinate) => Math.Abs(point.GetY() - yCoordinate) <= GetRange();

    public bool Contain(long x, long y) => point.ManhattanDistance(new Point(x, y)) <= GetRange();

    public long GetRange() => Range;
}
