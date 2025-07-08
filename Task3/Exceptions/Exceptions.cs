using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.Exceptions
{
    public abstract class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {
        }
    }

    public class InvalidUserIdException : DomainException
    {
        public InvalidUserIdException(): base("Invalid userId")
        {
        }
    }

    public class UserNotFoundException : DomainException
    {
        public UserNotFoundException() : base("User not found")
        {
        }
    }

    public class TaskDuplicateException : DomainException
    {
        public TaskDuplicateException() : base("The task already exists")
        {
        }
    }
}
