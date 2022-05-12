using Login_registraion_EFW.DBModel;
using Login_registraion_EFW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login_registraion_EFW.Controllers
{
    public class AccountController : Controller
    {
        USerDBEntities dbcontext = new USerDBEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            UserModel userModel = new UserModel();
            return View(userModel);
        }
        [HttpPost]
        public ActionResult Register(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                if (!dbcontext.Users.Any(e => e.Email == userModel.Email))
                {
                    User user = new User();
                    user.FirstName = userModel.FirstName;
                    user.LastName = userModel.LastName;
                    user.Email = userModel.Email;
                    user.Password = userModel.Password;
                    user.Created_On = DateTime.Now;
                  
                    dbcontext.Users.Add(user);
                    dbcontext.SaveChanges();
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("Error", "User already exist!!");
                    return View();
                }
            }

            return RedirectToAction("Register");
        }
        public ActionResult Login()
        {
            LoginModel login = new LoginModel();
            return View(login);
        }
        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                if (dbcontext.Users.Where(e=>e.Email==login.Email && e.Password==login.Password).FirstOrDefault()==null)
                {
                    ModelState.AddModelError("Error", "Email or Password is not Correct!");
                    return View();
                }
                else
                {
                    Session["Email"] = login.Email;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }
    }
}