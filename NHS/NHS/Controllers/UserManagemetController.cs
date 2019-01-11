using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NHS.Controllers
{
    public class UserManagemetController : Controller
    {
        // GET: UserManagemet
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserDetails()
        {
            return View();
        }
    }
}