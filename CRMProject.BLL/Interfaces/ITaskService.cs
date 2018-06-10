using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRMProject.BLL.DTO;

namespace CRMProject.BLL.Interfaces
{
    // task operations
    public interface ITaskService
    {
        // get all tasks list
        Task<IEnumerable<TaskDTO>> GetUsersTasks(string userId);

        // create new task
        Task<bool> AddTask(TaskDTO task);

        // get task info
        Task<TaskDTO> GetTaskData(int id);

        // update task info
        Task<bool> SetTaskData(TaskDTO task);

        // get expiration
        Task<TimeSpan> GetExpiration(int id);

        // close task
        Task<bool> CloseTask(int id);

        // for choosing responsible user
        Task<IEnumerable<UserDTO>> GetUsers();

        // add comment
        Task<bool> AddComment(int taskId, int typeId, string commentText, int userId);
    }
}
