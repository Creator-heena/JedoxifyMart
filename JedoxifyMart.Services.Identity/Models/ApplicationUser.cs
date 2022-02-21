﻿using Microsoft.AspNetCore.Identity;

namespace JedoxifyMart.Services.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } =  string.Empty;

    }
}
