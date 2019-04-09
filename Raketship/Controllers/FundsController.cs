using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Raketship.Controllers
{
    public class FundsController : Controller
    {
        //
        // GET: /Funds/

        public ActionResult Index()
        {
            ViewBag.ActiveNavItem = "funds";
            return View();
        }

        public ActionResult Add()
        {
            ViewBag.ActiveNavItem = "funds";
            return View();
        }

        public ActionResult Withdraw()
        {
            ViewBag.ActiveNavItem = "funds";
            return View();
        }
    }
}
