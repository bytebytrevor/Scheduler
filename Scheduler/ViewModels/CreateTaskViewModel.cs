using System;
using Scheduler.Models;

namespace Scheduler.ViewModels;

public class CreateTaskViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool Complete { get; set; }
    public string UserId { get; set; }
    public Users User { get; set; }

}
