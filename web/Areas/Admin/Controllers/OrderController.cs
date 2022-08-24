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
        [HttpGet]
        public ActionResult Details(int id)
        {
            var order = objQLBHEntities2.Orders.Where(n => n.Id == id).FirstOrDefault();
            return View(order);
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {

            var objorder = objQLBHEntities2.Orders.Where(n => n.Id == Id).FirstOrDefault();

            return View(objorder);
        }
        [HttpPost]
        public ActionResult Delete(Order objor)
        {

            var objorder = objQLBHEntities2.Orders.Where(n => n.Id == objor.Id).FirstOrDefault();
            objQLBHEntities2.Orders.Remove(objorder);
            objQLBHEntities2.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}