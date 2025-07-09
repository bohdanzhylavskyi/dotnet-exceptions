using System;

namespace Task3.Exceptions
{
    public abstract class BaseException : Exception
    {
        public BaseException() : base()
        {
        }

        public BaseException(string message) : base(message)
        {
        }

        public BaseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
