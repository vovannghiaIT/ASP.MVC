using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Context;
using static web.Common;

namespace web.Controllerss
{
    public class UserController : Controller
    {
        QLBHEntities2 objQLBHEntities2 = new QLBHEntities2();

       
        // GET: Pay
        public ActionResult Payment()
        {
            return View();
        }
        public ActionResult Address()
        {
            return View();
        }
        public ActionResult Main()
        {
            return View();
        }
        public ActionResult orders()
        {
            return View();
        }
        public ActionResult seller()
        {
            return View();
        }
        public ActionResult Setting()
        {
            return View();
        }
        public ActionResult Wishlist()
        {
            return View();
        }
    }
}