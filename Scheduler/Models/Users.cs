using System;
using Microsoft.AspNetCore.Identity;

namespace Scheduler.Models;

public class Users : IdentityUser
{
    public required string FullName { get; set; }
}
