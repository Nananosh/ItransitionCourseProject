using System.Threading.Tasks;
using ItransitionCourseProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;


namespace ItransitionCourseProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationContext _database;
        private readonly UserManager<User> _userManager;

        public AdminController(ApplicationContext context,UserManager<User> userManager)
        {
            _database = context;
            _userManager = userManager;
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