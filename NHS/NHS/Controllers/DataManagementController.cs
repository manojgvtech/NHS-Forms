using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHS.Models;

namespace NHS.Controllers
{
    public class DataManagementController : Controller
    {
        NHSEntities ent = new NHSEntities();
        // GET: DataManagement
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DataManagementDetails()
        {
            ViewBag.bindDataManagement = (from dmanagement in ent.DataManagement
                                          select dmanagement).ToList();
            return View();
        }
    }
}