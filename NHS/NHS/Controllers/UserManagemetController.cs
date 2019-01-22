using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHS.Models;

namespace NHS.Controllers
{
    public class UserManagemetController : Controller
    {
        NHSEntities ent = new NHSEntities();
        // GET: UserManagemet
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserDetails()
        {
            ViewBag.Drodown = (from x in ent.Roles select x).ToList();
            return View();
        }
    }
}