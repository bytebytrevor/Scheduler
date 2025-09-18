using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Scheduler.Models;
using Scheduler.Models.Entities;

namespace Scheduler.Data;

public class SchedulerDbContext : IdentityDbContext<Users>
{
    public SchedulerDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<TaskItem> TaskItems { get; set; }
}
