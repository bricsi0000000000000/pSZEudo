using ContractStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Cryptography;

namespace ContractStore.Controllers.UserManagement
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.User = UserManager.ActiveUser;
            return View();
        }

        public IActionResult LogIn()
        {
            return View("LogIn");
        }

        public IActionResult LogOut()
        {
            UserManager.ActiveUser = new User() { Name="" };
            ViewBag.User = UserManager.ActiveUser;

            return View("Index");
        }

        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public IActionResult LogIn(User user)
        {
            var database = new DatabaseContext();
            database.Users.Load();

            var savedUser = database.Users.ToList().Find(x => x.Name.Equals(user.Name));

            if (savedUser == null)
            {
                return View("LogIn");
            }

            string savedPasswordHash = savedUser.PasswordHash;
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(user.Password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return View("LogIn");
                }
            }

            UserManager.ActiveUser = savedUser;

            ViewBag.User = UserManager.ActiveUser;

            return View("Index");
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(user.Password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            var database = new DatabaseContext();
            database.Users.Load();
            database.Users.Add(new User() { ID = user.ID, Name = user.Name, Email = user.Email, PasswordHash = savedPasswordHash });
            database.SaveChanges();

            return View("LogIn");
        }
    }
}
