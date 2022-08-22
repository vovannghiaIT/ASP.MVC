using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Context;
using Web.Models;

namespace web.Controllers
{
    public class CategoryController : Controller
    {
        QLBHEntities2 objQLBHEntities = new QLBHEntities2();
        // GET: Category
        public ActionResult category()
        {
            var ListCategory = objQLBHEntities.Categories.ToList();
            return View(ListCategory);
        }
        public ActionResult Product_Category(int Id)
        {
            HomeModel objHomeModel = new HomeModel();
            objHomeModel.ListProduct = objQLBHEntities.Products.Where(n => n.CategoryId == Id).ToList();
            objHomeModel.ListCategory = objQLBHEntities.Categories.ToList();
            objHomeModel.ListBrands = objQLBHEntities.Brands.ToList();
            return View(objHomeModel);
        }
      
        public ActionResult Product_grid(int Id)
        {

            var listProduct_grid = objQLBHEntities.Products.Where(n => n.CategoryId == Id).ToList();
            return View(listProduct_grid);
        }
    }
}