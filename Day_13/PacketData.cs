namespace Day_13;

public class PacketData
{
    private const int RIGHT_ORDER = -1;
    private const int WRONG_ORDER = 1;
    private const int EQUAL = 0;

    public int CheckPacketOrder(string leftPacket, string rightPacket)
    {
        while (leftPacket.Any() && rightPacket.Any())
        {
            Pair leftPair = Split(leftPacket);
            Pair rightPair = Split(rightPacket);

            if (!leftPair.Literal.Any())
            {
                return -1;
            }
            if (!rightPair.Literal.Any())
            {
                return 1;
            }

            // If both values are integers 
            if (IsNumber(leftPair.Literal) && IsNumber(rightPair.Literal))
            {
                int firstNumber = int.Parse(leftPair.Literal);
                int secondNumber = int.Parse(rightPair.Literal);
                if (firstNumber < secondNumber)
                {
                    return RIGHT_ORDER;
                }
                if (secondNumber < firstNumber)
                {
                    return WRONG_ORDER;
                }
            }
            else
            {
                // If mixed type 
                if (IsMixedType(leftPair, rightPair) || IsMixedType(rightPair, leftPair))
                {
                    leftPair.Literal = MixedTypeConvertor(leftPair.Literal);
                    rightPair.Literal = MixedTypeConvertor(rightPair.Literal);
                }

                int compareResult = CheckPacketOrder(leftPair.Literal[1..^1], rightPair.Literal[1..^1]);
                if (compareResult != 0)
                {
                    return compareResult;
                }
            }
            leftPacket = leftPair.Rest;
            rightPacket = rightPair.Rest;
        }

        int comparePacketResult = rightPacket.Length > 0 ? RIGHT_ORDER : leftPacket.Length > 0 ? WRONG_ORDER : EQUAL;
        return comparePacketResult;
    }

    private static Pair Split(string packet)
    {
        if (!string.IsNullOrWhiteSpace(packet) && char.IsDigit(packet.First()))
        {
            string number = ToNumber(packet);
            int remainderIndex = number.Length == packet.Length ? number.Length : number.Length + 1;
            return new(number, packet[remainderIndex..]);
        }

        int numberOfParentheses = 0;
        int index = 0;

        // until end of packet or end of first segment
        while (!(index == packet.Length || (numberOfParentheses == 0 && packet[index] == ',')))
        {
            numberOfParentheses += packet[index] == '[' ? 1 : 0;
            numberOfParentheses -= packet[index] == ']' ? 1 : 0;
            ++index;
        }

        Pair pair = index == packet.Length ? new(packet, string.Empty) : new(packet[..index], packet[(index + 1)..]);
        return pair;
    }

    private static string ToNumber(string packet)
    {
        string number = string.Empty;
        for (int i = 0; i < packet.Length; ++i)
        {
            if (char.IsDigit(packet[i]))
            {
                number += packet[i];
            }
            else
            {
                break;
            }
        }
        return number;
    }

    private static bool IsNumber(string input)
    {
        for (int i = 0; i < input.Length; ++i)
        {
            if (!char.IsDigit(input[i]))
            {
                return false;
            }
        }
        return true;
    }

    private static bool IsMixedType(Pair left, Pair right) => left.Literal[0] == '[' && right.Literal[0] != '[';

    private static string MixedTypeConvertor(string input) => IsNumber(input) ? $"[{input}]" : input;
}
