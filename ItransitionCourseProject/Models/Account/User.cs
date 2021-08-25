using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
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