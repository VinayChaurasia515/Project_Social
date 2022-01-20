using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class SearchController : Controller
    {
        ProjectDBEntities db = new ProjectDBEntities();
        // GET: Search
        public ActionResult Index(string search)
        {
            var data = db.users.Where(model => model.firstName.StartsWith( search)).ToList();
         //   Session["UserName"]=data.fi
            return View(data);
        }
       // [HttpPost]
        //public ActionResult Searching(user u)
        //{

        //    return View();
        //}
    }
}