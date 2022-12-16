namespace Day_15;

public class Parser
{
	private const string REMOVE_SENSOR_PART = "Sensor at ";
    private const string REMOVE_BEACON_PART = " closest beacon is at ";
    private const string REMOVE_X_PART = "x=";
    private const string REMOVE_Y_PART = "y=";

	private readonly HashSet<Sensor> sensors;

	public Parser(string[] lines)
	{
		sensors = new HashSet<Sensor>();
        Parse(lines);
	}

    public HashSet<Sensor> GetMarkedLocations() => sensors;

    private void Parse(string[] lines)
	{
		foreach (var line in lines)
		{
            string[] coordinates = line
	            .Replace(REMOVE_SENSOR_PART, string.Empty)
	            .Replace(REMOVE_BEACON_PART, string.Empty)
                .Replace(REMOVE_X_PART, string.Empty)
                .Replace(REMOVE_Y_PART, string.Empty)
                .Split(':');

            string sensorCoordinates = coordinates[0].Trim();
            string beaconCoordinates = coordinates[1].Trim();

            Beacon beacon = ParseBeacon(beaconCoordinates);
            ParseSensor(sensorCoordinates, beacon);
        }
    }

	private static Beacon ParseBeacon(string coordinate)
	{
        long x = long.Parse(coordinate.Split(',')[0]);
        long y = long.Parse(coordinate.Split(',')[1]);

        Point beaconCoordinate = new(x, y);

        Beacon beacon = new(beaconCoordinate);

		return beacon;
    }

    private void ParseSensor(string coordinate, Beacon beacon)
    {
        long x = long.Parse(coordinate.Split(',')[0]);
        long y = long.Parse(coordinate.Split(',')[1]);

        Point sensorCoordinate = new(x, y);

        Sensor sensor = new(sensorCoordinate, beacon);

        sensors.Add(sensor);
    }
}
