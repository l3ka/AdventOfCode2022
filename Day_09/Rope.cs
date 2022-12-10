namespace Day_09;

public class Rope
{
    private const char MOVE_UP = 'U';
    private const char MOVE_DOWN = 'D';
    private const char MOVE_LEFT = 'L';
    private const char MOVE_RIGHT = 'R';

    private readonly Dictionary<(bool, bool), Point> diferentAxesDirections = new()
    {
        { (true, true), new Point(1, 1) },
        { (true, false), new Point(1, -1) },
        { (false, true), new Point(-1, 1) },
        { (false, false), new Point(-1, -1) }
    };

    private readonly Point[] rope;

    public Rope(int numberOfKnots)
    {
        rope = new Point[numberOfKnots];
        for (int i = 0; i < numberOfKnots; i++)
        {
            rope[i] = new Point(0, 0);
        }
    }

    public void Move(HashSet<(int x, int y)> visited, char direction, int numberOfSteps)
    {
        for (int i = 0; i < numberOfSteps; ++i)
        {
            for (int knot = 0; knot < rope.Length; ++knot)
            {
                if (knot == 0)
                {
                    MoveHead(rope[knot], direction);
                }
                else if (rope[knot - 1].DistanceGreaterThanOne(rope[knot]))
                {
                    MoveBody(rope[knot - 1], rope[knot]);
                }

                if (knot == rope.Length - 1)
                {
                    visited.Add((rope[knot].GetX(), rope[knot].GetY()));
                }
            }
        }
    }

    private static void MoveHead(Point head, char direction)
    {
        if (direction == MOVE_UP)
        {
            head.MoveUp();
        }
        else if (direction == MOVE_DOWN)
        {
            head.MoveDown();
        }
        else if (direction == MOVE_LEFT)
        {
            head.MoveLeft();
        }
        else if (direction == MOVE_RIGHT)
        {
            head.MoveRight();
        }
    }

    private void MoveBody(Point head, Point tail)
    {
        if (head.IsOnDifferentAxes(tail))
        {
            Point point = diferentAxesDirections[(head.GetX() > tail.GetX(), head.GetY() > tail.GetY())];
            tail.MoveForPoint(point);
        }
        else
        {
            Point point = new((head.GetX() + tail.GetX()) / 2, (head.GetY() + tail.GetY()) / 2);
            tail.MoveToPoint(point);
        }
    }
}
