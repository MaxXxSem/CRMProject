using System;
using System.Collections.Generic;
using CRMProject.BLL.DTO;

namespace CRMProject.BLL.Interfaces
{
    // task operations
    interface ITaskService
    {
        // get all tasks list
        IEnumerable<TaskDTO> GetTasks();

        // create new task
        bool AddTask(TaskDTO task);

        // get task info
        TaskDTO GetTaskData(int id);

        // update task info
        bool SetTaskData(TaskDTO task);

        // get expiration
        DateTime GetExpiration(int id);

        // close task
        bool CloseTask(int id);
    }
}
