using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItransitionCourseProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItransitionCourseProject.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationContext _database;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager; 

        public AdminController(ApplicationContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager,
            SignInManager<User> signInManager)
        {
            _database = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        
        public async Task<IActionResult> AddAdmin(string[] selectedUsersId)
        {
            if (selectedUsersId != null)
            {
                foreach (var userId in selectedUsersId)
                {
                    var user = _database.Users.FirstOrDefault(u => u.Id == userId);
                    await _userManager.AddToRolesAsync(user, new[] { "Admin" });
                    await _signInManager.RefreshSignInAsync(await _userManager.FindByIdAsync(userId));
                }
            }
            return RedirectToAction("AdminPanel", "Admin");
        }
        
        public async Task<IActionResult> DeleteAdmin(string[] selectedUsersId)
        {
            if (selectedUsersId != null)
            {
                foreach (var userId in selectedUsersId)
                {
                    var user = _database.Users.FirstOrDefault(u => u.Id == userId);
                    await _userManager.RemoveFromRolesAsync(user, new [] { "Admin" });
                    await _signInManager.RefreshSignInAsync(await _userManager.FindByIdAsync(userId));
                }
            }
            return RedirectToAction("AdminPanel", "Admin");
        }

        public IActionResult DeleteUser(string[] selectedUsersId)
        {
            if (selectedUsersId != null)
                foreach (var userId in selectedUsersId)
                {
                    var user = _database.Users.FirstOrDefault(u => u.Id == userId);
                    _database.Remove(user);
                    _database.SaveChanges();
                }

            return RedirectToAction("AdminPanel", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> BlockUser(string[] selectedUsersId)
        {
            if (selectedUsersId != null)
                foreach (var userId in selectedUsersId)
                {
                    var user = _database.Users.FirstOrDefault(u => u.Id == userId);
                    await _userManager.SetLockoutEndDateAsync(user, DateTime.Today.AddYears(100));
                }

            return RedirectToAction("AdminPanel", "Admin");
        }

        public async Task<IActionResult> UnBlockUser(string[] selectedUsersId)
        {
            if (selectedUsersId != null)
                foreach (var userId in selectedUsersId)
                {
                    var user = _database.Users.FirstOrDefault(u => u.Id == userId);
                    await _userManager.SetLockoutEndDateAsync(user, null);
                }

            return RedirectToAction("AdminPanel", "Admin");
        }

        public async Task<IActionResult> AdminPanel()
        {
            ViewBag.AllProfiles = await _database.Users
                .ToListAsync();
            return View();
        }
    }
}