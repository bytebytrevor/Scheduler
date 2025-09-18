using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduler.Models.Entities;

public class TaskItem
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool Complete { get; set; }
    // Foreign Key property
    public string UserId { get; set; }
    // Navigation property
    [ForeignKey("UserId")]
    public Users User { get; set; }
}
