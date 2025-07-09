namespace Task3.Exceptions
{
    public class TaskDuplicateException : BaseException
    {
        public readonly int UserId;
        public readonly string TaskDescription;

        public TaskDuplicateException(int userId, string taskDescription) : base("The task already exists")
        {
            UserId = userId;
            TaskDescription = taskDescription;
        }
    }
}
