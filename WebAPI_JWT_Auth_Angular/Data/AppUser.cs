﻿using Microsoft.AspNetCore.Identity;

namespace WebAPI_JWT_Auth_Angular.Data
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
