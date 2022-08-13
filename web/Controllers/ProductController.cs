using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Context;

namespace web.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        QLBHEntities2 objQLBHEntities2 = new QLBHEntities2();
        public ActionResult Detail(int Id)
        {
            var objProduct = objQLBHEntities2.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
        

    }
}