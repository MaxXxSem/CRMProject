using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRMProject.DAL.Repositories;
using CRMProject.BLL.Services;
using CRMProject.BLL.DTO;
using System.Linq;
using System.Threading.Tasks;

namespace CRMProject.Tests.BLL
{
    [TestClass]
    public class TaskServiceTest
    {
        [TestMethod]
        public async Task GetUsersTasks()
        {
            var tasks = await new TaskService(new UnitOfWork()).GetUsersTasks("d2644dea-aea0-4333-a08c-b66c286794df");
            Assert.IsTrue(tasks != null && tasks.Count() > 0);
        }

        [TestMethod]
        public async Task AddTask()
        {
            TaskDTO task = new TaskDTO()
            {
                Date = DateTime.Now,
                Description = "testDescr",
                Priority = "sdas",
                ResponsibleUserId = 3,
                Status = "asfafas",
                Title = "sdklgnd"
            };

            bool result = await new TaskService(new UnitOfWork()).AddTask(task);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task GetTaskData()
        {
            var task = await new TaskService(new UnitOfWork()).GetTaskData(1032);
            Assert.IsNotNull(task);
        }

        [TestMethod]
        public async Task SetTaskData()
        {
            TaskDTO task = new TaskDTO()
            {
                Id = 1032,
                Date = DateTime.Now,
                Description = "new",
                Priority = "new",
                ResponsibleUserId = 3,
                Status = "new",
                Title = "new"
            };

            bool result = await new TaskService(new UnitOfWork()).SetTaskData(task);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task GetExpiration()
        {
            var exp = await new TaskService(new UnitOfWork()).GetExpiration(1032);
            Assert.IsTrue(exp != TimeSpan.Zero);
        }

        [TestMethod]
        public async Task CloseTask()
        {
            bool result = await new TaskService(new UnitOfWork()).CloseTask(1032);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task AddComment()
        {
            bool result = await new TaskService(new UnitOfWork()).AddComment(1032, 4, "TaskComment", 3);
            Assert.IsTrue(result);
        }
    }
}
