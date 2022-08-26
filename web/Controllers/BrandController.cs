using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Context;
using Web.Models;

namespace web.Controllers
{
    public class BrandController : Controller
    {
        QLBHEntities2 objQLBHEntities = new QLBHEntities2();
        // GET: Brand
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Product_Category(int Id)
        {
            HomeModel objHomeModel = new HomeModel();
            objHomeModel.ListProduct = objQLBHEntities.Products.Where(n => n.BrandId == Id).ToList();
            objHomeModel.ListCategory = objQLBHEntities.Categories.ToList();
            objHomeModel.ListBrands = objQLBHEntities.Brands.ToList();
            return View(objHomeModel);
        }
    }
}