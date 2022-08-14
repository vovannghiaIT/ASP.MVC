using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Context;

namespace VoVanNghia_2120110017.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        QLBHEntities2 objQLBHEntities2 = new QLBHEntities2();
        public ActionResult Index()
        {
            var listOrder = objQLBHEntities2.Orders.ToList();
            return View(listOrder);
        }
    }
}