using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CRMProject.BLL.Interfaces;
using CRMProject.BLL.Services;
using CRMProject.BLL.DTO;
using CRMProject.Models.ViewModels;
using Microsoft.AspNet.Identity;

namespace CRMProject.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private ITaskService service { get; set; }

        public TaskController(ITaskService taskService)
        {
            service = taskService;
        }

        // GET: Task
        public async Task<ActionResult> TasksList()
        {
            var tasks = await service.GetUsersTasks(User.Identity.GetUserId());
            List<TaskBasicViewModel> viewTasks = new List<TaskBasicViewModel>();
            if (tasks != null && tasks.Count() > 0)
            {
                foreach (var task in tasks)
                {
                    viewTasks.Add(new TaskBasicViewModel()
                    {
                        Id = task.Id,
                        Date = task.Date,
                        Description = task.Description,
                        Priority = task.Priority,
                        Title = task.Title,
                        ResponsibleUserName = task.ResponsibleUserName
                    });
                }
            }

            return View(viewTasks);
        }

        // TODO: choose ResponsibleUserId
        public async Task<ActionResult> AddTask()
        {
            SelectList priority = new SelectList(new List<string>() { "Normal", "Hot" });           // Priority DropDownList
            SelectList users = new SelectList(await service.GetUsers(), "Id", "UserName", 1);       // Users DropDownList
            ViewBag.Priority = priority;
            ViewBag.Users = users;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddTask(AddTaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                TaskDTO task = new TaskDTO()
                {
                    Title = model.Title,
                    Date = DateTime.Parse(model.Date),
                    Description = model.Description,
                    Priority = model.Priority,
                    ResponsibleUserId = model.ResponsibleUserId
                };

                bool result = await service.AddTask(task);
                if (result)
                {
                    return RedirectToAction("TasksList");
                }
            }

            return new HttpNotFoundResult();
        }
    }
}