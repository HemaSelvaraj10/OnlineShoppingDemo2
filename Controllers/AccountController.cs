using OnlineShoppingDemo2.Models;
using OnlineShoppingDemo2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingDemo2.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        private DataContext _context;

        public AccountController()
        {
            _context = new DataContext();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Register register)
        {
            if (!ModelState.IsValid)
                return View("Register", register);

            if (_context.Registers.Where(u => u.Email == register.Email || u.UserName == register.UserName).Any())
            {
                ModelState.AddModelError("Email", "UserName or Email Already Exists");
                return View("Register", register);
            }

            _context.Registers.Add(register);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }



        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginFormViewModel user)
        {
            if (!ModelState.IsValid)
                return View("Login", user);

            var loginuser = _context.Registers.Where(u => u.UserName == user.UserName && u.Password == user.Password).FirstOrDefault();

            if (loginuser == null)
            {
                ModelState.AddModelError("UserName", "UserName or Password Is Incorrect, please try with correct username or password");
                return View("Login", user);
            }
            else
            {
                Session["UserName"] = loginuser.UserName;
                return RedirectToAction("Index", "Home");
            }



        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}