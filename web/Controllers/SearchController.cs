using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Context;

namespace web.Controllers
{
    public class SearchController : Controller
    {
        QLBHEntities2 objQLBHEntities2 = new QLBHEntities2();

        // GET: Search
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KeySearch(string skey)
        {
            return RedirectToAction("KQTimkiem", new { @key = skey });
        }
        public ActionResult KQTimkiemPartial()
        {
            var objProduct = objQLBHEntities2.Products.ToList();
            return View(objProduct);
        }

    }
}