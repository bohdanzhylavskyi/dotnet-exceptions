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
                throw new ArgumentNullException("'stringValue' can't be null");
            }

            var stringValueTrimmed = stringValue.Trim();

            if (stringValueTrimmed.Length == 0)
                throw new FormatException("Input should not be empty and should contain at least one non-space character");

            Sign? explicitSign = stringValueTrimmed[0] == '+'
                                ? Sign.Positive
                                : (stringValueTrimmed[0] == '-'
                                    ? Sign.Negative
                                    : (Sign?)null);

            bool isSignExplicitlySpecified = explicitSign != null;

            int result = 0;
            int startIndex = isSignExplicitlySpecified ? 1 : 0;
            Sign sign = explicitSign ?? Sign.Positive;

            for (int i = startIndex; i < stringValueTrimmed.Length; i++)
            {
                char c = stringValueTrimmed[i];

                if (c < '0' || c > '9')
                    throw new FormatException($"Invalid character '{c}' in input");

                result = sign == Sign.Positive
                    ? checked(result * 10 + (c - '0'))
                    : checked(result * 10 - (c - '0'));
            }

            return result;
        }

    }
}