using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class LoginController : Controller
    {
        ProjectDBEntities db = new ProjectDBEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(user u)
        {
            var user = db.users.Where(model => u.username == model.username && u.password == model.password).FirstOrDefault();
            if (user != null)
            {
                Session["UserId"] = u.Id.ToString();
                Session["Username"] = u.username.ToString();
                this.Session.Add("UserName", u.username);
                TempData["LoginSuccessMessage"] = "<script>alert('Log In Successfully')</script>";
                return RedirectToAction("Index","Dashboard");
            }
            else
            {
                ViewBag.ErrorMessage = "<script>alert('User or Password is Incorrect')</script>";
                return View();
            }          
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(user u)
        {
            if (ModelState.IsValid == true)
            {
                db.users.Add(u);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    ViewBag.userRegisterMessage = "<script>alert('User Register Successfully')</script>";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.userRegisterMessage = "<script>alert('Registeration Failed')</script>";
                }
            }
            return View();
        }
    }
    
}