using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ItransitionCourseProject.Models
{
    public class User : IdentityUser
    {
        public DateTime RegistrationDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string UserImage { get; set; }
        public List<Like> Likes { get; set; } = new();
    }
}