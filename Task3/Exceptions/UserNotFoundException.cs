using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.Exceptions
{
    public class UserNotFoundException : BaseException
    {
        public readonly int UserId;
        public UserNotFoundException(int userId) : base("User not found")
        {
            UserId = userId;
        }
    }
}
