using System;
using System.Collections.Generic;
using System.Linq;
using Task3.DoNotChange;
using Task3.Exceptions;

namespace Task3
{
    public class UserTaskService
    {
        private readonly IUserDao _userDao;

        public UserTaskService(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public void AddTaskForUser(int userId, UserTask task)
        {
            if (userId < 0)
                throw new InvalidUserIdException(userId);

            var user = _userDao.GetUser(userId);

            if (user == null)
                throw new UserNotFoundException(userId);

            var userTasks = user.Tasks;

            if (CheckForTaskDuplicate(userTasks, task))
            {
                throw new TaskDuplicateException(userId, task.Description);
            }

            userTasks.Add(task);
        }

        private bool CheckForTaskDuplicate(IList<UserTask> tasks, UserTask task)
        {
            return tasks.Any((t) => string.Equals(t.Description, task.Description, StringComparison.OrdinalIgnoreCase));
        }
    }
}