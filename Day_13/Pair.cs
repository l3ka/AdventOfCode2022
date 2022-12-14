namespace Day_13;

public class Pair
{
    public string Literal { get; set; }
    public string Rest { get; set; }

    public Pair(string literal, string rest)
    {
        Literal = literal;
        Rest = rest;
    }
}
