namespace Day_12;

public class Point
{
    private readonly int Row;
    private readonly int Column;
    private readonly char Value;
    private readonly int Counter;

    public Point(int row, int column, char value = 'a', int counter = 0)
    {
        Row = row;
        Column = column;
        Value = value;
        Counter = counter;
    }

    public int GetRow() => Row;

    public int GetColumn() => Column;

    public char GetValue() => Value;

    public int GetCounter() => Counter;

    public bool Equals(Point point) => Row == point.Row && Column == point.Column;
}
