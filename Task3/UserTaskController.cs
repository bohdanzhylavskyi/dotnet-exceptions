﻿using Task3.DoNotChange;
using System;
using Task3.Exceptions;

namespace Task3
{
    public class UserTaskController
    {
        private readonly UserTaskService _taskService;

        public UserTaskController(UserTaskService taskService)
        {
            _taskService = taskService;
        }

        public bool AddTaskForUser(int userId, string description, IResponseModel model)
        {
            var task = new UserTask(description);

            try
            {
                _taskService.AddTaskForUser(userId, task);
                return true;
            } catch (BaseException e)
            {
                model.AddAttribute("action_result", e.Message);

                return false;
            }
        }
    }
}