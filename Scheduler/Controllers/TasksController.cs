using System.Runtime.CompilerServices;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scheduler.Data;
using Scheduler.Models;
using Scheduler.Models.Entities;
using Scheduler.ViewModels;

namespace Scheduler.Controllers
{
    public class TasksController : Controller
    {
        private readonly SchedulerDbContext dbContext;

        public TasksController(SchedulerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: UsersController
        [HttpGet]
        public IActionResult CreateTask()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(CreateTaskViewModel viewModel)
        {
            var userId = User?.FindFirstValue(ClaimTypes.NameIdentifier);

            var taskItem = new TaskItem
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                DueDate = viewModel.DueDate,
                Complete = false,
                UserId = userId,
                User = await dbContext.Users.FindAsync(userId)
            };

            await dbContext.TaskItems.AddAsync(taskItem);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> TaskList()
        {

            var userId = User?.FindFirstValue(ClaimTypes.NameIdentifier);
            var tasks = await dbContext.TaskItems.ToListAsync();
            List<TaskItem> usertasks = new List<TaskItem>();

            foreach (var task in tasks)
            {
                if (task.UserId.ToString().Equals(userId))
                {
                    usertasks.Add(task);
                }
            }
            return View(usertasks);
        }

        [HttpGet]
        public async Task<IActionResult> EditTask(Guid id)
        {
            var task = await dbContext.TaskItems.FindAsync(id);

            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> EditTask(TaskItem viewModel)
        {
            var task = await dbContext.TaskItems.FindAsync(viewModel.Id);

            if (task is not null)
            {
                task.Name = viewModel.Name;
                task.Description = viewModel.Description;
                task.DueDate = viewModel.DueDate;
                task.Complete = viewModel.Complete;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("TaskList", "Tasks");
        }
    }
}
