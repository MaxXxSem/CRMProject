using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasks = System.Threading.Tasks;
using CRMProject.DAL.Interfaces;
using CRMProject.BLL.Interfaces;
using CRMProject.BLL.DTO;
using CRMProject.DAL.Entities;
using AutoMapper;

namespace CRMProject.BLL.Services
{
    class TaskService : ITaskService
    {
        IUnitOfWork Db { get; set; }

        public TaskService(IUnitOfWork uow)
        {
            Db = uow;
        }

        public async Tasks.Task<IEnumerable<TaskDTO>> GetUsersTasks(string userId)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Task, TaskDTO>());
            var tasks = Mapper.Map<IEnumerable<Task>, IEnumerable<TaskDTO>>(await Db.Tasks.Get(t => t.User.UserData.Id == userId && t.Status == TaskStatus.Opened.ToString()));     // get user's tasks
            return tasks;
        }

        public async Tasks.Task<bool> AddTask(TaskDTO task)
        {
            if (task == null)
            {
                return false;
            }
            else
            {
                Task t = new Task()
                {
                    Title = task.Title,
                    Date = task.Date,
                    Description = task.Description,
                    Priority = task.Priority,
                    Status = TaskStatus.Opened.ToString(),
                    User = await Db.Users.Find(task.Id)
                };

                await Db.Tasks.Create(t);
                Db.Save();
                return true;
            }
        }

        // TODO: Comments
        public async Tasks.Task<TaskDTO> GetTaskData(int id)
        {
            var task = await Db.Tasks.Find(id);
            if (task != null)
            {
                var comments = await Db.Comments.Get(c => c.TypeId == task.TypeId && c.CommentedEntityId == task.Id);
                Mapper.Initialize(cfg => cfg.CreateMap<Comment, CommentDTO>());

                TaskDTO taskDTO = new TaskDTO()
                {
                    Id = task.Id,
                    Date = task.Date,
                    Title = task.Title,
                    Priority = task.Priority,
                    Status = task.Status,
                    Description = task.Description,
                    Comments = Mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDTO>>(comments)
                };

                return taskDTO;
            }

            return null;
        }

        public async Tasks.Task<bool> SetTaskData(TaskDTO task)
        {
            if (task != null)
            {
                var taskEntity = await Db.Tasks.Find(task.Id);

                if (taskEntity != null)
                {
                    taskEntity.Date = task.Date;
                    taskEntity.Description = task.Description;
                    taskEntity.Priority = task.Priority;
                    taskEntity.Status = task.Status;
                    taskEntity.Title = task.Title;

                    await Db.Tasks.Update(taskEntity);
                    Db.Save();
                    return true;
                }
            }

            return false;
        }

        public async Tasks.Task<DateTime> GetExpiration(int id)
        {
            var task = await Db.Tasks.Find(id);
            if (task != null)
            {
                return task.Date;
            }

            return DateTime.MinValue;           // if there is no task - return DateTime.MinValue
        }

        public async Tasks.Task<bool> CloseTask(int id)
        {
            var task = await Db.Tasks.Find(id);

            if (task != null)
            {
                task.Status = TaskStatus.Closed.ToString();         // set status to Closed
            }

            return false;
        }

        public async Tasks.Task<bool> AddComment(int taskId, int typeId, string commentText, int userId)
        {
            if (string.IsNullOrEmpty(commentText))
            {
                return false;
            }

            try
            {
                Comment comment = new Comment()
                {
                    Text = commentText,
                    CommentedEntityId = taskId,
                    TypeId = typeId,
                    User = await Db.Users.Find(userId)
                };

                await Db.Comments.Create(comment);
                Db.Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
