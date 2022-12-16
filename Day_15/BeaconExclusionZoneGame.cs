namespace Day_15;

public class BeaconExclusionZoneGame
{
    private readonly HashSet<Sensor> sensors;
    private readonly HashSet<long> numberOfFreeXPositions;
    private long tuningFrequency;

    public BeaconExclusionZoneGame(HashSet<Sensor> sensors)
	{
        this.sensors = sensors;
        numberOfFreeXPositions = new HashSet<long>();
        tuningFrequency = 0;
    }

    public long GetNumberOfPosition() => numberOfFreeXPositions.Count;

    public long GetTuningFrequency() => tuningFrequency;

    public void FindFreePositions(long yCoordinate)
    {
        foreach (var sensor in sensors)
        {
            if (!sensor.CrossContain(yCoordinate))
            {
                continue;
            }

            long sensorX = sensor.GetCoordinate().GetX();
            long sensorRange = sensor.GetRange();

            for (long x = sensorX - sensorRange; x < sensorX + sensorRange; ++x)
            {
                if (sensor.Contain(x, yCoordinate))
                {
                    numberOfFreeXPositions.Add(x);
                }
            }

            if (sensor.GetClosestBeacon().GetCoordinate().GetY() == yCoordinate)
            {
                numberOfFreeXPositions.Remove(sensor.GetClosestBeacon().GetCoordinate().GetX());
            }
        }
    }

    public void FindTuningFrequency(long minCoordinate, long maxCoordinate)
    {
        foreach (var sensor in sensors)
        {
            long sensorX = sensor.GetCoordinate().GetX();
            long sensorY = sensor.GetCoordinate().GetY();
            long distanceToEdge = sensor.GetRange() + 1;
            long min = Math.Max(sensorX - distanceToEdge, minCoordinate);
            long max = Math.Min(sensorX + distanceToEdge, maxCoordinate);
            long tempY;

            for (long x = min; x < sensorX; ++x)
            {
                tempY = sensorY + (distanceToEdge - (x - min));
                if (InRange(tempY, minCoordinate, maxCoordinate) && !InRange(x, tempY))
                {
                    CalculateTuningFrequency(maxCoordinate, x, tempY);
                    return;
                }

                tempY = sensorY - (distanceToEdge - (x - min));
                if (InRange(tempY, minCoordinate, maxCoordinate) && !InRange(x, tempY))
                {
                    CalculateTuningFrequency(maxCoordinate, x, tempY);
                    return;
                }
            }

            tempY = sensorY + distanceToEdge;
            if (InRange(tempY, minCoordinate, maxCoordinate) && !InRange(sensorX, tempY))
            {
                CalculateTuningFrequency(maxCoordinate, sensorX, tempY);
                return;
            }

            tempY = sensorY - distanceToEdge;
            if (InRange(tempY, minCoordinate, maxCoordinate) && !InRange(sensorX, tempY))
            {
                CalculateTuningFrequency(maxCoordinate, sensorX, tempY);
                return;
            }

            for (long x = sensorX + 1; x <= max; ++x)
            {
                tempY = sensorY + (distanceToEdge - (x - sensorX));
                if (InRange(tempY, minCoordinate, maxCoordinate) && !InRange(x, tempY))
                {
                    CalculateTuningFrequency(maxCoordinate, x, tempY);
                    return;
                }

                tempY = sensorY - (distanceToEdge - (x - sensorX));
                if (InRange(tempY, minCoordinate, maxCoordinate) && !InRange(x, tempY))
                {
                    CalculateTuningFrequency(maxCoordinate, x, tempY);
                    return;
                }
            }
        }
    }

    private void CalculateTuningFrequency(long maxCoordinate, long x, long y) => tuningFrequency = maxCoordinate * x + y;

    private bool InRange(long x, long y) => sensors.Any(sensor => sensor.Contain(x, y));

    private static bool InRange(long y, long minCoordinate, long maxCoordinate) => minCoordinate <= y && y <= maxCoordinate;
}
