using System.Threading.Tasks;
using ItransitionCourseProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


namespace ItransitionCourseProject.Controllers
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

        // todo : finish adding roles to the user
        public async Task<string> AddRole()
        {
            // User user = await _userManager.FindByIdAsync("a9b162d4-f5fb-4517-bb1a-dcf63e894a06");
            // var userRoles = await _userManager.GetRolesAsync(user);
            // // получаем все роли
            // var allRoles = _roleManager.Roles.ToList();
            // // получаем список ролей, которые были добавлены
            // List<string> roles = new List<string>();
            // roles.Add("Admin");
            // var addedRoles = roles.Except(userRoles);
            // // получаем роли, которые были удалены
            //
            // await _userManager.AddToRolesAsync(user, addedRoles);
            // await _signInManager.RefreshSignInAsync(user);
            // await _roleManager.CreateAsync(new IdentityRole("Admin"));
            return "dwqqwd";
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
            ViewBag.AllProfiles = await _database.Users.ToListAsync();
            return View();
        }
    }
}