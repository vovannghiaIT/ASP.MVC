
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Context;

namespace Web.Models
{
    public class HomeModel
    {
     

        public List<Brand> ListBrands { get; set; }
        public List<Product> ListProduct { get; set; }
        public List<Category> ListCategory { get; set; }
       
        //public ActionResult Index( int? page)
        //{

        //    var lstProduct = new List<Product>();
            
           
        //        lstProduct = objQLBHEntities2.Products.ToList();
            
        //    int pageSize = 4;
        //    int pageNumber = (page ?? 1);
        //    lstProduct = lstProduct.OrderByDescending(n => n.Id).ToList();
        //    return View(lstProduct.ToPagedList(pageNumber, pageSize));
        //}
    }
}