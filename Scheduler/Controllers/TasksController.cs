using System.Runtime.CompilerServices;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
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
    }
}
