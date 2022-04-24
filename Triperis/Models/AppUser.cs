﻿using Microsoft.AspNetCore.Identity;

namespace Triperis.Models
{
    public class AppUser : IdentityUser
    {
        //email, password and username are inherited from identityUser
        //roles are also taken care of by identityUser
        public bool CanCreateListings { get; set; }
    }
}