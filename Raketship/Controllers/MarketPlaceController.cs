using Raketship.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Raketship.Controllers
{
    public class MarketPlaceController : Controller
    {
        //
        // GET: /MarketPlace/

        public ActionResult Index()
        {
            ViewBag.ActiveNavItem = "marketplace";

            MarketPlaceContext db = new MarketPlaceContext();
            IEnumerable<MarketPlace> tables = db.MarketPlace.AsEnumerable();

            return View(tables);
        }

    }
}
