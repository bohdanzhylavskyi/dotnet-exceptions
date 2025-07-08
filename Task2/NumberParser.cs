using System;

namespace Task2
{
    internal enum Sign
    {
        Positive,
        Negative
    }

    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            if (stringValue is null)
            {
                throw new ArgumentNullException(nameof(stringValue), "Input can't be null");
            }

            var stringValueTrimmed = stringValue.Trim();

            if (stringValueTrimmed.Length == 0)
                throw new FormatException("Input should not be empty and should contain at least one non-space character");

            return ParseNumberString(stringValueTrimmed);
        }

        private int ParseNumberString(string numberStr)
        {
            Sign? explicitSign = ResolveExplicitSignIfAny(numberStr);
            Sign sign = explicitSign ?? Sign.Positive;

            int result = 0;
            int startIndex = explicitSign != null ? 1 : 0;

            for (int i = startIndex; i < numberStr.Length; i++)
            {
                char c = numberStr[i];

                if (!char.IsDigit(c))
                    throw new FormatException($"Invalid character '{c}' in input");

                result = sign == Sign.Positive
                    ? checked(result * 10 + (c - '0'))
                    : checked(result * 10 - (c - '0'));
            }

            return result;
        }

        private Sign? ResolveExplicitSignIfAny(string numberStr)
        {
            if (numberStr[0] == '+')
            {
                return Sign.Positive;
            }
            
            if (numberStr[0] == '-')
            {
                return Sign.Negative;
            }

            return null;
        }

    }
}