using System;
using System.ComponentModel.DataAnnotations;

namespace Scheduler.ViewModels;

public class VerifyEmailViewModel
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    public string Email { get; set; }
}
