using System;
using System.Linq;
using System.Threading.Tasks;
using ItransitionCourseProject.Models;
using ItransitionCourseProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItransitionCourseProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationContext _database;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,
            ApplicationContext context)
        {
            _database = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Email = model.Email, UserName = model.UserName, RegistrationDate = DateTime.Now,
                    LastLoginDate = DateTime.Now
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel {ReturnUrl = returnUrl});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await _signInManager
                    .PasswordSignInAsync(model.UserName, model.Password, true, false);
                if (signInResult.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }

                    SetLastLoginDateToUser(model);
                    await _database.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Incorrect username or password");
            }

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult DeleteUser(string[] selectedUsersId)
        {
            if (selectedUsersId != null)
            {
                foreach (var userId in selectedUsersId)
                {
                    var user = _database.Users.FirstOrDefault(u => u.Id == userId);
                    _database.Remove(user);
                    _database.SaveChanges();
                }
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> BlockUser(string[] selectedUsersId)
        {
            if (selectedUsersId != null)
            {
                foreach (var userId in selectedUsersId)
                {
                    var user = _database.Users.FirstOrDefault(u => u.Id == userId);
                    await _userManager.SetLockoutEndDateAsync(user, DateTime.Today.AddYears(100));
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> UnBlockUser(string[] selectedUsersId)
        {
            if (selectedUsersId != null)
            {
                foreach (var userId in selectedUsersId)
                {
                    var user = _database.Users.FirstOrDefault(u => u.Id == userId);
                    await _userManager.SetLockoutEndDateAsync(user, null);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        private void SetLastLoginDateToUser(LoginViewModel model)
        {
            var user = _database.Users.FirstOrDefault(u => u.UserName == model.UserName);
            if (user != null)
            {
                user.LastLoginDate = DateTime.Now;
                _database.Entry(user).State = EntityState.Modified;
            }
        }
    }
}