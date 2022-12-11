namespace Day_11;

public class Operation
{
    private readonly bool useOld;
    private readonly string mathematicalOperation;

    private long firstOperand;
    private long secondOperand;

    public Operation(string operation)
    {
        mathematicalOperation = operation.Split(' ')[1];
        string secondOperandString = operation.Split(' ')[2];
        useOld = secondOperandString == "old";

        secondOperand = useOld ? long.MinValue :
            long.TryParse(secondOperandString, out long secondPartNumericalValue) ? secondPartNumericalValue :
            0;
    }

    public long Execute(long worryLevel)
    {
        firstOperand = worryLevel;
        secondOperand = useOld ? worryLevel : secondOperand;

        return mathematicalOperation switch
        {
            "+" => firstOperand + secondOperand,
            "-" => firstOperand - secondOperand,
            "*" => firstOperand * secondOperand,
            "/" => firstOperand / secondOperand,
            _ => throw new NotImplementedException()
        };
    }
}
