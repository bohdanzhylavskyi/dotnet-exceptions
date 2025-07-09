using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.Exceptions
{
    public class InvalidUserIdException : BaseException
    {
        readonly public int UserId;

        public InvalidUserIdException(int userId) : base("Invalid userId")
        {
            UserId = userId;
        }
    }
}
